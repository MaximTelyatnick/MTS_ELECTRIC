using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using MTS.BLL.Interfaces;
using MTS.DAL.Interfaces;
using MTS.BLL.DTO.ModelsDTO;
using MTS.BLL.DTO.ReportsDTO;
using MTS.BLL.Infrastructure;
using System.IO;
using SpreadsheetGear;
using System.Diagnostics;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;

using MTS.BLL.DTO.SelectedDTO;
using Words = Microsoft.Office.Interop.Word;
using System.Globalization;
using MTS.BLL.NameCaseLib;
using System.Text.RegularExpressions;
using Nager.Date;
using AutoMapper;
using MTS.DAL.Entities.Models;
using MTS.DAL.Entities.QueryModels;
using MTS.BLL.DTO; 



namespace MTS.BLL.Services
{
    public class ReportService : IReportService
    {
        private string GeneratedReportsDir = Utils.HomePath + @"\Temp\";

        //private string GeneratedReportsDirTest = Utils.HomePathTemp + @"\Temp\";

        private Words._Application word;
        private Words._Document document;

        private IUnitOfWork Database { get; set; }




        

        private IMapper mapper;

        public ReportService(IUnitOfWork uow)
        {
            Database = uow;

           
            var config = new MapperConfiguration(cfg =>
            {
                
            });

            mapper = config.CreateMapper();
        }


        #region Mts specification

        public bool SpecificationProcess(MTSSpecificationsDTO mtsSpecification, List<MTSDetailsDTO> mtsDetailsList, List<MTSPurchasedProductsDTO> mtsBuyDetailsList, List<MTSMaterialsDTO> mtsMaterialsList, string homeDirectory, bool sortament = false)
        {
            #region summaryValues

            decimal weightOfWorkpiece = 0;
            decimal shawing = 0;
            decimal scrap = 0;

            #endregion summaryValues

            #region Detail's

            var summDetailsQuantity = mtsDetailsList.GroupBy(c => c.NOMENCLATURE_ID).Select(g => new
            {
                id = g.Key,
                summQuantity = g.Sum(c =>
                  c.PROCESSING_ID == 2 ? (c.QUANTITY * c.HEIGHT * c.WIDTH * c.NOMENCLATURESWEIGHT * 0.000001m) / c.QUANTITY_OF_BLANKS :
                  c.PROCESSING_ID == 3 ? (c.QUANTITY * c.HEIGHT * c.HEIGHT * c.NOMENCLATURESWEIGHT * 0.000001m * 0.25m * 3.1415m) / c.QUANTITY_OF_BLANKS :
                  c.PROCESSING_ID == 1 ? (c.QUANTITY * c.HEIGHT * (c.NOMENCLATURESWEIGHT == 0 ? 1 : c.NOMENCLATURESWEIGHT) * 0.001m) / c.QUANTITY_OF_BLANKS : 0),
                summQ2 = g.Sum(c => c.QUANTITY),
                color = g.Sum(c => c.CHANGES),
            }).ToList();

            var sp1 = summDetailsQuantity
               .Join(mtsDetailsList, i => i.id, y => y.NOMENCLATURE_ID, (i, y) => new { i, y })
               .OrderBy(@t1 => @t1.y.NOM_GROUP_SORTPOSITION)
               .Select(t2 => new SpecificationPrintModelDTO
               {
                   Nomenclature_id = (int)t2.y.NOMENCLATURE_ID,
                   RatioOfWaste = (decimal)(t2.y.NOM_GROUP_RATIO_OF_WASTE == 0 ? 1 : t2.y.NOM_GROUP_RATIO_OF_WASTE),
                   Guage = t2.y.GUAEGENAME,
                   Gost = t2.y.GOSTNAME,
                   Name = t2.y.NOMENCLATURESNAME,
                   Note = t2.y.NOMENCLATURESNOTE,
                   Measure = t2.y.MEASURE_NAME,
                   Price = (decimal)t2.y.NOMENCLATURESPRICE,
                   AdditCalculationQuantity = (decimal)(t2.y.NOM_GROUP_ADDIT_CALCULATION_ID == 1 ? t2.i.summQuantity * t2.y.NOM_GROUP_RATIO_OF_WASTE / t2.y.NOMENCLATURESWEIGHT
                                                       : (t2.y.NOM_GROUP_ADDIT_CALCULATION_ID == 2 ? t2.i.summQ2 : 0)),
                   AdditCalculationMeasure = t2.y.NOM_GROUP_ADDIT_CALCULATION_ID == null ? string.Empty : t2.y.NOM_GROUP_ADDIT_CALCULATION_MEASURE,
                   Quantity = (decimal)(t2.i.summQuantity * (t2.y.NOM_GROUP_RATIO_OF_WASTE == 0 ? 1 : t2.y.NOM_GROUP_RATIO_OF_WASTE)),
                   NomenclatureGroupId = (int)t2.y.NOM_GROUP_ID,
                   Weight = (decimal)t2.y.NOMENCLATURESWEIGHT,
                   SortPosition = (int)t2.y.NOM_GROUP_SORTPOSITION,
                   GuageId = (int)t2.y.GUAEGESORT,
                   Color = (int)t2.i.color
               }).ToList();


            var groupMaterial = sp1.GroupBy(gr => gr.Nomenclature_id).Select(sl => sl.FirstOrDefault()).ToList();

            var sp = new List<SpecificationPrintModelDTO>();

            //если складской работник
            //for (int i = 1; i <= 77; i++)
            //{
            //    var res = (from n in sp1
            //               where n.SortPosition == i
            //               orderby GetGuage(n.Guage)
            //               select n);

            //    sp.AddRange(res);
            //}


            for (int i = 1; i <= 77; i++)
            {
                var res = (from n in groupMaterial
                           where n.SortPosition == i
                           orderby n.Name, n.GuageId
                           select n);

                sp.AddRange(res);
            }


            foreach (var tt in sp)
            {
                weightOfWorkpiece += tt.Quantity;
                scrap += tt.NomenclatureGroupId == 1 ? tt.Quantity * tt.RatioOfWaste : 0;
            }

            #endregion

            #region PurchasedProducts

            var pProductsSum1 = new List<SpecificationPrintModelDTO>();

            pProductsSum1.AddRange(from i in mtsBuyDetailsList
                                   select new SpecificationPrintModelDTO
                                       {
                                           Id = i.ID,
                                           Nomenclature_id = (int)i.NOMENCLATURES_ID,
                                           Quantity = (decimal)(i.QUANTITY * mtsSpecification.QUANTITY),
                                           Price = (decimal)i.NOMENCLATURESPRICE * mtsSpecification.QUANTITY,
                                           Name = i.NOMENCLATURESNAME,
                                           Guage = i.GUAEGENAME,
                                           Gost = i.GOSTNAME,
                                           Measure = i.MEASURENAME,
                                           Note = i.NOMENCLATURESNOTE,
                                           SortPosition = (int)i.NOM_GROUP_SORTPOSITION
                                       });
            


            var pProductsSum2 = (from i in pProductsSum1
                                 group i by new { i.Nomenclature_id, i.Name, i.Guage, i.Gost, i.Measure, i.SortPosition, i.Note } into g
                                 orderby g.Key.SortPosition, g.Key.Name
                                 select new SpecificationPrintModelDTO
                                 {
                                     Nomenclature_id = g.Key.Nomenclature_id,
                                     Quantity = g.Sum(c => c.Quantity),
                                      Price =g.Sum(c=>c.Price),
                                     Name = g.Key.Name,
                                     Guage = g.Key.Guage,
                                     Gost = g.Key.Gost,
                                     Measure = g.Key.Measure,
                                     SortPosition = g.Key.SortPosition,
                                      Note = g.Key.Note
                                 }).ToList();

            var pProductsSum = (from i in pProductsSum2
                                orderby i.SortPosition, i.Name
                                select new SpecificationPrintModelDTO
                                {
                                    Nomenclature_id = i.Nomenclature_id,
                                    Quantity = i.Quantity,
                                    Name = i.Name,
                                    Guage = i.Guage,
                                    Gost = i.Gost,
                                    Measure = i.Measure,
                                    SortPosition = i.SortPosition,
                                    Price = i.Price,
                                    Note = i.Note
                                }).ToList();


            //join gost in mtsGost.GetAll() on mtsNom.GOST_ID equals gost.ID into gosts
            //           from gost in gosts.DefaultIfEmpty()

            #endregion purchasedProducts

            #region materials

            var materialsSum1 = new List<SpecificationPrintModelDTO>();

            #region materials step 1

            materialsSum1.AddRange(from i in mtsMaterialsList
                                   select new SpecificationPrintModelDTO
                                   {
                                       Id = i.ID,
                                       Nomenclature_id = (int)i.NOMENCLATURES_ID,
                                       Quantity = (decimal)(i.QUANTITY * mtsSpecification.QUANTITY),
                                       Price = (decimal)i.NOMENCLATURESPRICE * mtsSpecification.QUANTITY,
                                       Name = i.NOMENCLATURESNAME,
                                       Guage = i.GUAGENAME,
                                       Gost = i.GOSTNAME,
                                       Measure = i.MEASURENAME,
                                       Note = i.NOMENCLATURESNOTE,
                                       SortPosition = (int)i.NOM_GROUP_SORTPOSITION
                                   });

            #endregion materials step 1

            #region materials step 2

            var materialsSum2 = (from i in materialsSum1
                                 group i by new { i.Nomenclature_id, i.Name, i.Guage, i.Gost, i.Measure, i.SortPosition, i.Note } into g
                                 orderby g.Key.SortPosition, g.Key.Name
                                 select new SpecificationPrintModelDTO
                                 {
                                     Nomenclature_id = g.Key.Nomenclature_id,
                                     Quantity = g.Sum(c => c.Quantity),
                                     Price = g.Sum(c => c.Price),
                                     Name = g.Key.Name,
                                     Guage = g.Key.Guage,
                                     Gost = g.Key.Gost,
                                     Measure = g.Key.Measure,
                                     SortPosition = g.Key.SortPosition,
                                     Note = g.Key.Note
                                 }).ToList();


            #endregion materials step 2

            #region materials step 3

            var materialsSum = (from i in materialsSum2
                                orderby i.SortPosition, i.Name
                                select new SpecificationPrintModelDTO
                                {
                                    Nomenclature_id = i.Nomenclature_id,
                                    Quantity = i.Quantity,
                                    Name = i.Name,
                                    Guage = i.Guage,
                                    Gost = i.Gost,
                                    Measure = i.Measure,
                                    SortPosition = i.SortPosition,
                                    Price = i.Price,
                                    Note = i.Note
                                }).ToList();

            #endregion materials step 3

            #endregion materials

            if (sortament)
                sp = sp.OrderBy(srt => srt.SortPosition).ThenBy(tsrt => Utils.SortStringNumbers(tsrt.Guage)).ToList();
            //sp = sp.OrderBy(srt => srt.SortPosition).ThenBy(tsrt => Utils.SortStringNumbers(tsrt.Guage)).ToList();
            var allResults = sp.Concat(pProductsSum).Concat(materialsSum).ToList();

            scrap *= 0.07m;

            //shawing = weightOfWorkpiece - ((decimal)(mtsSpecification.WEIGHT == null ? 0 : mtsSpecification.WEIGHT - scrap));

            shawing = (decimal)weightOfWorkpiece - (decimal)mtsSpecification.WEIGHT - scrap;
            PrintTechProcessSpecification(mtsSpecification, allResults, scrap, shawing, weightOfWorkpiece, homeDirectory, sortament);

            return true;
        }

        public bool MapTechProcess(MTSSpecificationsDTO mtsSpecification, List<MTSDetailsDTO> mtsDetailsList, bool sortByDrawing, string homeDirectory, int quantity = 1)
        {

            mtsSpecification.QUANTITY = mtsSpecification.QUANTITY * quantity;

            for (int i = 0; i < mtsDetailsList.Count; i++)
                mtsDetailsList[i].QUANTITY = mtsDetailsList[i].QUANTITY * quantity;


            if (!sortByDrawing)
                return PrintMapTechProcess(mtsSpecification, mtsDetailsList, homeDirectory);
            else
                return PrintMapTechProcess(mtsSpecification, mtsDetailsList.OrderBy(sort => sort.DRAWING).ToList(), homeDirectory);
        }

        public decimal? GetGuage(string obj)
        {
            decimal a = 0, b = 0, c = 0;

            string result = "";
            for (int i = 0; i < obj.Length; i++)
            {
                if (result.Length > 0)
                {
                    if (obj[i] == ',' || obj[i] == '.')
                    {
                        result += ',';
                        continue;
                    }

                    if (obj[i] == 'x' || obj[i] == 'X' || obj[i] == 'х' || obj[i] == 'Х')
                    {
                        char h = result[result.Length - 1];

                        if (h != 'x' || h != 'X' || h != 'х' || h != 'Х')
                        {
                            if (result.Length - 1 != i)
                            {
                                result += 'x';
                                continue;
                            }
                        }
                    }
                }

                if (Char.IsDigit(obj[i]))
                    result += obj[i];
            }

            string a1 = "";
            string b1 = "";
            string c1 = "";
            int step = 0;

            for (int i = 0; i < result.Length; i++)
            {
                char z = result[i];
                if (z != 'x')
                {
                    if (step == 0)
                        a1 += z;

                    if (step == 1)
                        b1 += z;

                    if (step == 2)
                        c1 += z;
                }
                else { step++; }
            }

            if (a1.Length != 0)
                a = Convert.ToDecimal(a1);

            if (b1.Length != 0)
                b = Convert.ToDecimal(b1);

            if (c1.Length != 0)
                c = Convert.ToDecimal(c1);

            decimal? n = a + b + c;

            if (n == null)
                return null;

            return n;
        }

        //печать спецификации
        public bool PrintTechProcessSpecification(MTSSpecificationsDTO mtsSpecification, List<SpecificationPrintModelDTO> dataSource, decimal scrap, decimal shawing, decimal weightOfWorkpiece,string homeDirectory, bool sortament = false)
        {
            

            if (!Directory.Exists(homeDirectory))
            {
                Directory.CreateDirectory(homeDirectory);
            }

            try
            {
                Factory.GetWorkbook(GeneratedReportsDir + @"\Templates\MtsStartedSpecificationReport.xls");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не знайдено шаблон документа!\n" + ex.Message, "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            

            var Workbook = Factory.GetWorkbook(GeneratedReportsDir + @"\Templates\MtsStartedSpecificationReport.xls");
            var Worksheet = Workbook.Worksheets[0];
            var Сells = Worksheet.Cells;

            Worksheet.PageSetup.LeftHeader = "\n Изделие: " + mtsSpecification.NAME;
            Worksheet.PageSetup.RightHeader = "\n Чертеж: " + mtsSpecification.DRAWING;

            IWorkbookSet workbookSet = Factory.GetWorkbookSet();
            workbookSet.ReadVBA = true;

            IRange cells = Worksheet.Cells;
            //mtsSpecification.COMPILATION_NAMES = mtsSpecification.COMPILATION_NAMES.Replace(";", ";\n");
            //cells["B" + 2].Value = "Изделие: "+ mtsSpecification.NAME + "\n" + mtsSpecification.COMPILATION_NAMES;

            cells["A2"].Value = "Изделие:" + mtsSpecification.NAME;

            if (mtsSpecification.COMPILATION_NAMES == null)
                cells["A2"].Value = "Изделие:" + mtsSpecification.NAME;
            else
            {
                int namesLength = 0;

                //string compilationName = "Изделия:" + spec.NAME + " \n";
                string compilationName = "";
                var arr = mtsSpecification.COMPILATION_NAMES.ToCharArray();
                foreach (var a in arr)
                {
                    if (a != ';')
                    {
                        compilationName += a;
                    }
                    else
                    {
                        if (namesLength != arr.Count() - 1)
                            compilationName += " \n";
                    }
                    namesLength++;
                }
                cells["Q3"].Value = compilationName;
            }

            cells["E1"].Value = "Составлена " + ((DateTime)mtsSpecification.CREATION_DATE).ToShortDateString();
            cells["E2"].Value = mtsSpecification.DRAWING;
            cells["A3"].Formula = "=Q3";


            if (mtsSpecification.COMPILATION_DRAWINGS == null)
                cells["E2"].Value = mtsSpecification.DRAWING;
            else
            {
                var arrQuantites = mtsSpecification.COMPILATION_QUANTITIES.ToCharArray();

                List<string> massQuantity = new List<string>();

                string h = "";
                int j = 0;

                foreach (var q in arrQuantites)
                {
                    if (q != ';')
                    {
                        h += q;

                        if (j == arrQuantites.Count() - 1)
                            massQuantity.Add(h);
                    }
                    else
                    {
                        massQuantity.Add(h);
                        h = "";
                    }
                    j++;
                }

                //string compilationDrawing = spec.DRAWING + " \n";
                string compilationDrawing = "";
                var drawingArray = mtsSpecification.COMPILATION_DRAWINGS.ToCharArray();

                int dictCount = 0;
                int drawingLength = 0;

                foreach (var a in drawingArray)
                {
                    if (a != ';')
                    {
                        compilationDrawing += a;
                    }
                    else
                    {
                        if (drawingLength == drawingArray.Count() - 1)
                            compilationDrawing += " -" + massQuantity[dictCount] + " шт.";
                        else
                            compilationDrawing += " -" + massQuantity[dictCount] + " шт." + " \n";

                        dictCount++;
                    }

                    if (drawingLength == drawingArray.Count() - 1)
                    {
                        break;
                    }

                    drawingLength++;
                }
                cells["E3"].Value = compilationDrawing;

            }

            decimal allQuantity = 0;
            int startWith = 6;
            int numbering = 1;

            string firstName = dataSource.First().Name;

            List<SpecificationPrintModelDTO> dataSourceOrderList = new List<SpecificationPrintModelDTO>();

            //if (sortament)
            //    dataSourceOrderList = dataSource.OrderBy(srt => srt.Guage).ToList();
            //else
            //    dataSourceOrderList = dataSource.ToList();

            dataSourceOrderList = dataSource.ToList();

            foreach (var dat in dataSourceOrderList)
            {

                if (dat.Color >= 1)
                {
                    cells["B" + (startWith) + ":I" + startWith].Interior.Color = Color.FromArgb(169, 169, 169);
                    //cells["B" + (startWith) + ":I" + startWith].Interior.Color = Color.Aquamarine;
                    firstName = firstName == null ? "" : firstName;
                }

                if (startWith > 5 && dat.Name.Trim().ToLower() != firstName.Trim().ToLower())
                    cells["B" + (startWith) + ":I" + startWith].Borders[BordersIndex.EdgeTop].LineStyle = LineStyle.Continous;

                if (startWith > 6 && dat.Name.Trim().ToLower() == firstName.Trim().ToLower())
                {
                    cells["A" + startWith].Value = numbering;
                    cells["B" + startWith].Value = string.Empty;

                }
                else
                {
                    cells["A" + startWith].Value = numbering;


                    if (dat.Name.Length > 100)
                        cells["B" + startWith].Rows.AutoFit();

                    cells["B" + startWith].Value = dat.Name == null ? "" : dat.Name.Trim();
                    firstName = dat.Name;
                }

                cells["A" + startWith].VerticalAlignment = VAlign.Top;
                cells["B" + startWith].VerticalAlignment = VAlign.Top;
                cells["C" + startWith].VerticalAlignment = VAlign.Top;
                cells["D" + startWith].VerticalAlignment = VAlign.Top;
                cells["E" + startWith].VerticalAlignment = VAlign.Top;
                cells["F" + startWith].VerticalAlignment = VAlign.Top;
                cells["G" + startWith].VerticalAlignment = VAlign.Top;
                cells["H" + startWith].VerticalAlignment = VAlign.Top;
                cells["I" + startWith].VerticalAlignment = VAlign.Top;

                cells["C" + startWith].Value = dat.Guage;
                cells["C" + startWith].HorizontalAlignment = HAlign.Center;

                cells["D" + startWith].Value = dat.Gost == "нет" ? dat.Note : dat.Gost;

                cells["D" + startWith].HorizontalAlignment = HAlign.Center;

                cells["E" + startWith].Value = dat.Measure;

                cells["F" + startWith].Value = dat.Quantity;
                allQuantity += dat.Quantity;

                cells["G" + startWith].Value = dat.Price;

                cells["I" + startWith].Value = dat.Note;

                cells["H" + startWith].Formula = "=F" + (startWith) + "*G" + (startWith);

                cells["A" + startWith].RowHeight = 28;

                if (dat.AdditCalculationQuantity != 0)
                {
                    cells["E" + startWith].VerticalAlignment = VAlign.Top;
                    cells["F" + startWith].VerticalAlignment = VAlign.Top;

                    startWith++;
                    cells["E" + startWith].Value = dat.AdditCalculationMeasure;
                    cells["F" + startWith].Value = dat.AdditCalculationQuantity;
                    //cells["A" + startWith + ":" + "I" + startWith].Borders.LineStyle = SpreadsheetGear.LineStyle.Continous;
                    //cells["A" + (startWith) + ":I" + startWith].Borders[BordersIndex.EdgeBottom].LineStyle = LineStyle.Continous;

                    cells["A" + (startWith - 1) + ":A" + startWith].Borders[BordersIndex.EdgeLeft].LineStyle = LineStyle.Continous;
                    cells["A" + (startWith - 1) + ":A" + startWith].Borders[BordersIndex.EdgeRight].LineStyle = LineStyle.Continous;

                    cells["B" + (startWith - 1) + ":B" + startWith].Borders[BordersIndex.EdgeLeft].LineStyle = LineStyle.Continous;
                    cells["B" + (startWith - 1) + ":B" + startWith].Borders[BordersIndex.EdgeRight].LineStyle = LineStyle.Continous;
                    cells["C" + (startWith - 1) + ":C" + startWith].Borders[BordersIndex.EdgeRight].LineStyle = LineStyle.Continous;
                    cells["D" + (startWith - 1) + ":D" + startWith].Borders[BordersIndex.EdgeRight].LineStyle = LineStyle.Continous;
                    cells["E" + (startWith - 1) + ":E" + startWith].Borders[BordersIndex.EdgeRight].LineStyle = LineStyle.Continous;
                    cells["F" + (startWith - 1) + ":F" + startWith].Borders[BordersIndex.EdgeRight].LineStyle = LineStyle.Continous;
                    cells["G" + (startWith - 1) + ":G" + startWith].Borders[BordersIndex.EdgeRight].LineStyle = LineStyle.Continous;
                    cells["H" + (startWith - 1) + ":H" + startWith].Borders[BordersIndex.EdgeRight].LineStyle = LineStyle.Continous;
                    cells["H" + (startWith - 1) + ":I" + startWith].Borders[BordersIndex.EdgeRight].LineStyle = LineStyle.Dash;
                }
                else
                {
                    cells["A" + startWith].Borders.LineStyle = LineStyle.Continous;
                    cells["B" + startWith].Borders.LineStyle = LineStyle.Continous;
                    cells["C" + startWith].Borders.LineStyle = LineStyle.Continous;
                    cells["D" + startWith].Borders.LineStyle = LineStyle.Continous;
                    cells["E" + startWith].Borders.LineStyle = LineStyle.Continous;
                    cells["F" + startWith].Borders.LineStyle = LineStyle.Continous;
                    cells["G" + startWith].Borders.LineStyle = LineStyle.Continous;
                    cells["H" + startWith].Borders.LineStyle = LineStyle.Continous;
                    cells["I" + startWith].Borders.LineStyle = LineStyle.Continous;
                }

                startWith++;
                numbering++;
            }

            //итог по стобцу сумма
            startWith++;
            cells["D" + startWith].RowHeight = 16;
            cells["D" + startWith].HorizontalAlignment = HAlign.Left;
            cells["F" + startWith].HorizontalAlignment = HAlign.Right;
            cells["D" + startWith + ": E" + startWith].Merge();
            cells["D" + startWith].Value = "Итого материалов";
            cells["D" + (startWith) + ":I" + startWith].Borders[BordersIndex.EdgeBottom].LineStyle = LineStyle.Dash;

            for (int i = 0; i < dataSourceOrderList.Count; i++)
            {
                cells["H" + startWith].Formula = "=SUM(H" + 5 + ":H" + (startWith - 2) + ")";
            }

            startWith++;
            cells["D" + startWith].RowHeight = 16;
            cells["D" + startWith].HorizontalAlignment = HAlign.Left;
            cells["F" + startWith].HorizontalAlignment = HAlign.Right;
            cells["D" + startWith + ": E" + startWith].Merge();
            cells["D" + startWith].Value = "Чистый вес";
            cells["F" + startWith].Value = mtsSpecification.WEIGHT;
            cells["D" + (startWith) + ":I" + startWith].Borders[BordersIndex.EdgeBottom].LineStyle = LineStyle.Dash;

            startWith++;
            cells["D" + startWith].RowHeight = 16;
            cells["D" + startWith].HorizontalAlignment = HAlign.Left;
            cells["F" + startWith].HorizontalAlignment = HAlign.Right;
            cells["D" + startWith + ": E" + startWith].Merge();
            cells["D" + startWith].Value = "Вес заготовок";
            cells["F" + startWith].Value = weightOfWorkpiece;

            weightOfWorkpiece = weightOfWorkpiece == 0 ? 1 : weightOfWorkpiece;

            cells["H" + startWith].Value = "k=" + Math.Round((decimal)mtsSpecification.WEIGHT / weightOfWorkpiece, 3);
            cells["D" + (startWith) + ":I" + startWith].Borders[BordersIndex.EdgeBottom].LineStyle = LineStyle.Dash;

            startWith++;
            cells["D" + startWith].RowHeight = 16;
            cells["D" + startWith].HorizontalAlignment = HAlign.Left;
            cells["F" + startWith].HorizontalAlignment = HAlign.Right;
            cells["D" + startWith + ": E" + startWith].Merge();
            cells["D" + startWith].Value = "Стружка";
            cells["F" + startWith].Value = shawing;
            cells["H" + startWith].Value = Math.Round(shawing * 0.03m);
            cells["D" + (startWith) + ":I" + startWith].Borders[BordersIndex.EdgeBottom].LineStyle = LineStyle.Dash;

            startWith++;
            cells["D" + startWith].RowHeight = 16;
            cells["D" + startWith].HorizontalAlignment = HAlign.Left;
            cells["F" + startWith].HorizontalAlignment = HAlign.Right;
            cells["D" + startWith + ": E" + startWith].Merge();
            cells["D" + startWith].Value = "Лом";
            cells["F" + startWith].Value = scrap;

            var val = scrap * 0.09m;
            cells["H" + startWith].Value = Math.Round(val);
            cells["D" + (startWith) + ":I" + startWith].Borders[BordersIndex.EdgeBottom].LineStyle = LineStyle.Dash;

            startWith += 2;
            cells["B" + startWith].Value = "Начальник ТО______________";
            cells["B" + startWith].RowHeight = 20;

            startWith++;
            cells["B" + startWith].Value = "Составил___________________";
            cells["B" + startWith].RowHeight = 28;
            cells["C" + startWith + ": D" + startWith].Merge();
            cells["C" + startWith].Value = mtsSpecification.AUTHORIZATION_USERS_NAME == null ? "" : mtsSpecification.AUTHORIZATION_USERS_NAME;
            cells["C" + startWith].HorizontalAlignment = HAlign.Left;
            cells["E" + (startWith - 1) + ": I" + (startWith - 1)].Merge();
            cells["E" + (startWith - 1)].Value = "Экономист________________";

            startWith++;
            cells["E" + (startWith - 1)].Value = "Дата печати " + DateTime.Now;
            cells["E" + (startWith - 1) + ": I" + (startWith - 1)].Merge();
            cells["E" + (startWith - 1)].RowHeight = 20;


            try
            {
                string fileName = String.Format("Спецификация на изделие  " + mtsSpecification.NAME);
                Workbook.SaveAs(homeDirectory + "/" + fileName + ".xls", FileFormat.XLS97);

                if (MessageBox.Show("Відкрити файл " + fileName + ".xls ?", "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Process process = new Process();
                    process.StartInfo.Arguments = "\"" + homeDirectory + "/" + fileName + ".xls" + "\"";
                    //process.StartInfo.FileName = "Excel.exe";
                    process.StartInfo.FileName = "SOFFICE.exe";
                    process.Start();
                }

            }

            catch (System.IO.IOException)
            {
                MessageBox.Show("Документ уже открыто, сохраните документ и попробуйте снова!!!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (System.ComponentModel.Win32Exception) { MessageBox.Show("Не знайдено пакет програм Microsoft Excel!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning); }

            return true;
        }

        //печать карты техпроцесса
        public bool PrintMapTechProcess(MTSSpecificationsDTO mtsSpecification, List<MTSDetailsDTO> dataSource, string homeDirectory)
        {
            if (!Directory.Exists(homeDirectory))
            {
                Directory.CreateDirectory(homeDirectory);
            }

            try
            {
                Factory.GetWorkbook(GeneratedReportsDir + @"\Templates\MtsStartedProcessMapReport.xls");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не знайдено шаблон документа!\n" + ex.Message, "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            var Workbook = Factory.GetWorkbook(GeneratedReportsDir + @"\Templates\MtsStartedProcessMapReport.xls");
            var Worksheet = Workbook.Worksheets[0];
            var Сells = Worksheet.Cells;
            int startWith = 4;

            IRange cells = Worksheet.Cells;

            cells["A1"].Value = "Карта Маршрутного технологического процесса";
            cells["A1"].HorizontalAlignment = HAlign.Left;
            cells["A1"].Font.Bold = true;
            cells["A2"].Formula = "=Q2";
            

            if (mtsSpecification.COMPILATION_NAMES == null || mtsSpecification.COMPILATION_NAMES == "")
                cells["Q2"].Value = "Изделие:" + mtsSpecification.NAME;
            else
            {
                string compilationName = "Изделиe:" + mtsSpecification.NAME + " \n";
                var arr = mtsSpecification.COMPILATION_NAMES.ToCharArray();
                foreach (var a in arr)
                {
                    if (a != ';')
                        compilationName += a;
                    else
                        compilationName += " \n";
                }
                cells["Q2"].Value = compilationName;
            }

            //---------------------------------------------------------

            cells["E1"].Value = "Составлена " + ((DateTime)mtsSpecification.CREATION_DATE).ToShortDateString();
            cells["E2"].Value = mtsSpecification.DRAWING;

            if (mtsSpecification.COMPILATION_DRAWINGS == null)
                cells["E2"].Value = "Чертеж: " + mtsSpecification.DRAWING;
            else
            {
                var arrQuantites = mtsSpecification.COMPILATION_QUANTITIES.ToCharArray();

                List<string> massQuantity = new List<string>();

                string h = "";
                int j = 0;

                foreach (var q in arrQuantites)
                {
                    if (q != ';')
                    {
                        h += q;

                        if (j == arrQuantites.Count() - 1)
                            massQuantity.Add(h);
                    }
                    else
                    {
                        massQuantity.Add(h);
                        h = "";
                    }
                    j++;
                }

                string compilationDrawing = "Чертеж:" + mtsSpecification.DRAWING + " \n";
                var drawingArray = mtsSpecification.COMPILATION_DRAWINGS.ToCharArray();

                int dictCount = 0;
                int drawingLength = 0;

                foreach (var a in drawingArray)
                {
                    if (a != ';')
                    {
                        compilationDrawing += a;
                    }
                    else
                    {
                        if (drawingLength == drawingArray.Count() - 1)
                            compilationDrawing += " -" + massQuantity[dictCount] + " шт.";
                        else
                            compilationDrawing += " -" + massQuantity[dictCount] + " шт." + " \n";

                        dictCount++;
                    }

                    if (drawingLength == drawingArray.Count() - 1)
                        break;

                    drawingLength++;
                }
                cells["E2"].Value = compilationDrawing;
            }
            //---------------------------------------------------------
            //var dataSource = dataSource.ToList();

            int autoIncrement = 1;
            var isFoundChanges1 = dataSource.FirstOrDefault(x => x.CHANGES == 1);
            foreach (var dat in dataSource)
            {
                if (((isFoundChanges1 != null) && (dat.CHANGES == 1)) || ((isFoundChanges1 == null) && (dat.CHANGES == 0)))
                {
                    cells["A" + (startWith)].RowHeight = 23;
                    cells["A" + (startWith)].VerticalAlignment = VAlign.Center;
                    cells["A" + (startWith)].Value = autoIncrement;
                    cells["A" + (startWith)].Borders.LineStyle = LineStyle.Continous;

                    cells["B" + (startWith)].VerticalAlignment = VAlign.Center;
                    cells["B" + (startWith)].Value = dat.NAME;
                    cells["B" + (startWith)].Borders.LineStyle = LineStyle.Continous;

                    cells["C" + (startWith)].VerticalAlignment = VAlign.Center;
                    cells["C" + (startWith)].Value = dat.DRAWING;
                    cells["C" + (startWith)].Borders.LineStyle = LineStyle.Continous;

                    cells["D" + (startWith)].VerticalAlignment = VAlign.Center;
                    cells["D" + (startWith)].Value = dat.QUANTITY;
                    cells["D" + (startWith)].Borders.LineStyle = LineStyle.Continous;

                    cells["E" + (startWith)].VerticalAlignment = VAlign.Center;
                    cells["E" + (startWith)].Value = dat.NOMENCLATURESNAME + " " + dat.GUAEGENAME;
                    cells["E" + (startWith)].Borders.LineStyle = LineStyle.Continous;

                    cells["F" + (startWith)].VerticalAlignment = VAlign.Center;
                    cells["F" + (startWith)].Value = dat.GOSTNAME;
                    cells["F" + (startWith)].Borders.LineStyle = LineStyle.Continous;

                    cells["G" + (startWith)].VerticalAlignment = VAlign.Center;
                    cells["G" + (startWith)].Value = dat.WIDTH == 0 ?
                                                dat.HEIGHT.ToString() :
                                                dat.HEIGHT + "*" + dat.WIDTH;

                    cells["G" + (startWith)].Borders.LineStyle = LineStyle.Continous;

                    cells["H" + (startWith)].VerticalAlignment = VAlign.Center;
                    cells["H" + (startWith)].Value = dat.QUANTITY_OF_BLANKS;
                    cells["H" + (startWith)].Borders.LineStyle = LineStyle.Continous;

                    autoIncrement++;
                    startWith++;
                }
            }

            startWith += 2;
            cells["A" + startWith].Value = "Начальник ТО______________";
            cells["A" + startWith].RowHeight = 20;

            startWith++;
            cells["A" + startWith].Value = "Составил___________________" + mtsSpecification.AUTHORIZATION_USERS_NAME;
            cells["A" + startWith].RowHeight = 20;

            startWith++;
            cells["A" + startWith].Value = "Дата печати " + DateTime.Now;
            cells["A" + startWith].RowHeight = 20;



            try
            {
                string fileName = String.Format("Карта технологического процесса проекта " + mtsSpecification.NAME);
                Workbook.SaveAs(homeDirectory + "/" + fileName + ".xls", FileFormat.Excel8);

                if (MessageBox.Show("Відкрити файл " + fileName + ".xls ?", "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Process process = new Process();
                    process.StartInfo.Arguments = "\"" + homeDirectory + "/" + fileName + ".xls" + "\"";
                    //process.StartInfo.FileName = "Excel.exe";
                    process.StartInfo.FileName = "SOFFICE.exe";
                    process.Start();
                }

            }

            catch (System.IO.IOException)
            {
                MessageBox.Show("Документ уже открыто, сохраните документ и попробуйте снова!!!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (System.ComponentModel.Win32Exception) { MessageBox.Show("Не знайдено пакет програм Microsoft Excel!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning); }

            return true;
        }

        //печать карты маршрутного техпроцесса
        public bool PrintMapRouteTechProcess(MTSSpecificationsDTO mtsSpecification, List<MTSDetailsDTO> dataSource, string homeDirectory)
        {
            if (!Directory.Exists(homeDirectory))
            {
                Directory.CreateDirectory(homeDirectory);
            }

            try
            {
                Factory.GetWorkbook(GeneratedReportsDir + @"\Templates\MtsStartedProcessMapLongReport.xls");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не знайдено шаблон документа!\n" + ex.Message, "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            var Workbook = Factory.GetWorkbook(GeneratedReportsDir + @"\Templates\MtsStartedProcessMapLongReport.xls");
            var Worksheet = Workbook.Worksheets[0];
            var Сells = Worksheet.Cells;
            int startWith = 4;

            IRange cells = Worksheet.Cells;

            if (mtsSpecification.COMPILATION_NAMES == null)
                cells["B2"].Value = "Изделие:" + mtsSpecification.NAME;
            else
            {
                int namesLength = 0;
                string compilationName = "";
                var arr = mtsSpecification.COMPILATION_NAMES.ToCharArray();
                foreach (var a in arr)
                {
                    if (a != ';')
                    {
                        compilationName += a;
                    }
                    else
                    {
                        if (namesLength != arr.Count() - 1)
                            compilationName += " \n";
                    }
                    namesLength++;
                }
                cells["B2"].Value = compilationName;
            }

            for (int i = 0; i < dataSource.Count(); i++)
            {
                cells["A" + startWith].Value = (i+1);
                cells["A" + startWith].HorizontalAlignment = HAlign.Left;
                cells["A" + startWith].VerticalAlignment = VAlign.Center;
                cells["B" + startWith].Value = dataSource[i].NAME;
                cells["B" + startWith].HorizontalAlignment = HAlign.Left;
                cells["B" + startWith].VerticalAlignment = VAlign.Center;
                cells["C" + startWith].Value = dataSource[i].DRAWING;
                cells["C" + startWith].HorizontalAlignment = HAlign.Left;
                cells["C" + startWith].VerticalAlignment = VAlign.Center;
                cells["D" + startWith].Value = dataSource[i].QUANTITY;
                cells["D" + startWith].HorizontalAlignment = HAlign.Left;
                cells["D" + startWith].VerticalAlignment = VAlign.Center;
                cells["E" + startWith].Value = dataSource[i].NOMENCLATURESNAME + " " + dataSource[i].GUAEGENAME;
                cells["E" + startWith].HorizontalAlignment = HAlign.Left;
                cells["E" + startWith].VerticalAlignment = VAlign.Center;
                cells["F" + startWith].Value = dataSource[i].GOSTNAME;
                cells["F" + startWith].HorizontalAlignment = HAlign.Left;
                cells["F" + startWith].VerticalAlignment = VAlign.Center;

                string detailPeram="";

                if(dataSource[i].WIDTH!= 0 && dataSource[i].HEIGHT!= 0)
                    detailPeram = dataSource[i].HEIGHT.ToString() + "*" + dataSource[i].WIDTH.ToString();
                else
                    detailPeram = dataSource[i].HEIGHT.ToString();

                cells["G" + startWith].Value = detailPeram;
                cells["G" + startWith].HorizontalAlignment = HAlign.Left;
                cells["G" + startWith].VerticalAlignment = VAlign.Center;
                cells["H" + startWith].Value = dataSource[i].QUANTITY_OF_BLANKS;
                cells["H" + startWith].HorizontalAlignment = HAlign.Left;
                cells["H" + startWith].VerticalAlignment = VAlign.Center;
                cells["A" + startWith + ":" + "X" + startWith].Borders.LineStyle = SpreadsheetGear.LineStyle.Continous; ;
                startWith++;
                
            }

            startWith+=2;
            cells["A" + startWith].Value = "Начальник ТО______________";
            startWith++;
            cells["A" + startWith].Value = "Составил___________________" + mtsSpecification.AUTHORIZATION_USERS_NAME;
            startWith++;
            cells["A" + startWith].Value = "Дата печати " + DateTime.Now.ToString();
            startWith++;

            try
            {
                string fileName = String.Format("Карта Маршрутного технолгического процесса проекта " + mtsSpecification.NAME);
                Workbook.SaveAs(homeDirectory + "/"+ fileName + ".xls", FileFormat.Excel8);

                if (MessageBox.Show("Відкрити файл " + fileName + ".xls ?", "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    Process process = new Process();
                    process.StartInfo.Arguments = "\"" + homeDirectory + "/" + fileName + ".xls" + "\"";
                    //process.StartInfo.FileName = "Excel.exe";
                    process.StartInfo.FileName = "SOFFICE.exe";
                    process.Start();
                }

            }

            catch (System.IO.IOException)
            {
                MessageBox.Show("Документ уже открыто, сохраните документ и попробуйте снова!!!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (System.ComponentModel.Win32Exception) { MessageBox.Show("Не знайдено пакет програм Microsoft Excel!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning); }

            return true;
        }

        #endregion


        //#endregion

        #region Setting

        private static string HomePath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); //Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]);
        private readonly string _generatedReportsDir = HomePath;// + @"\Отчеты\По командировке";

        private void InsertLines(int lineNum)
        {
            int iCount;
            for (iCount = 1; iCount <= lineNum; iCount++)
            {
                word.Selection.TypeParagraph();
            }
        }

        private bool SaveAsXls(IWorkbook workbook, string path, string filename)
        {
            try
            {
                if (!Directory.Exists(_generatedReportsDir + path))
                {
                    Directory.CreateDirectory(_generatedReportsDir + path);
                }
                var name = _generatedReportsDir + path + filename + ".xls";
                workbook.SaveAs(name, FileFormat.Excel8);
                return true;
            }
            catch (IOException)
            {
                //MessageBox.Show("Документ уже открыт!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        private bool SaveAsDoc(string path, string filename)
        {
            try
            {
                if (!Directory.Exists(_generatedReportsDir + path))
                {
                    Directory.CreateDirectory(_generatedReportsDir + path);
                }
                var name = _generatedReportsDir + path + filename + ".doc";
                document.SaveAs(name);
                return true;
            }
            catch (IOException)
            {
                //MessageBox.Show("Документ уже открыт!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        private void RunXls(string path, string filename)
        {
            try
            {
                var name = _generatedReportsDir + path + filename + ".xls";
                var process = new Process();
                process.StartInfo.Arguments = "\"" + name + "\"";
                //process.StartInfo.FileName = "Excel.exe";
                process.StartInfo.FileName = "SOFFICE.exe";
                process.Start();
            }
            catch (System.ComponentModel.Win32Exception)
            {
                //MessageBox.Show("Не найден Microsoft Excel!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RunDoc(string filename)
        {
            try
            {
                var name = _generatedReportsDir + filename + ".doc";
                var process = new Process { StartInfo = { Arguments = "\"" + name + "\"", FileName = "Word.exe" } };
                process.Start();
            }
            catch (System.ComponentModel.Win32Exception)
            {
                //MessageBox.Show("Не найден Microsoft Excel!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string[] vsS =
            {
                "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M",
                "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z",

                "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI", "AJ", "AK",
                "AL", "AM", "AN", "AO", "AP", "AQ", "AR", "AS", "AT", "AU", "AV",
                "AW", "AX", "AY", "AZ",

                "BA", "BB", "BC", "BD", "BE", "BF", "BG", "BH", "BI", "BJ", "BK", "BL", "BM",
                "BN", "BO", "BP", "BQ", "BR", "BS", "BT", "BU", "BV", "BW", "BX", "BY", "BZ",

                "CA", "CB", "CC", "CD", "CE", "CF", "CG", "CH", "CI", "CJ", "CK", "CL", "CM",
                "CN", "CO", "CP", "CQ", "CR", "CS", "CT", "CU", "CV", "CW", "CX", "CY", "CZ"
            };

        private void SetPageBreak(SpreadsheetGear.IWorksheet worksheet, int row, int col)
        {
            worksheet.Cells[row, col].PageBreak = SpreadsheetGear.PageBreak.Manual;
        }

        private string SetFormula(int cell1, int row1, int cell2, int row2, string formula, bool needEq = true)
        {
            return (needEq == true ? "=" : "") + formula + "(" + vsS[cell1] + Convert.ToString(row1) + ":" + vsS[cell2] + Convert.ToString(row2) + ")";
        }

        private string SetFormula(string cell1, int row1, string cell2, int row2, string formula, bool needEq = true)
        {
            return (needEq == true ? "=" : "") + formula + "(" + cell1 + Convert.ToString(row1) + ":" + cell2 + Convert.ToString(row2) + ")";
        }

        private void PrintSignatures(SpreadsheetGear.IRange cells, int startPosition)
        {
            cells["A" + startPosition].Value = "Виконавець:";
            cells["A" + startPosition].HorizontalAlignment = HAlign.Right;
            cells["B" + startPosition + ":C" + startPosition].Borders[BordersIndex.EdgeBottom].LineStyle = LineStyle.Continous;
            cells["E" + startPosition + ":F" + startPosition].Borders[BordersIndex.EdgeBottom].LineStyle = LineStyle.Continous;
            cells["B" + (startPosition + 1) + ":C" + (startPosition + 1)].Merge();
            cells["E" + (startPosition + 1) + ":F" + (startPosition + 1)].Merge();
            cells["B" + (startPosition + 1) + ":C" + (startPosition + 1)].Value = "(ПІБ, посада)";
            cells["E" + (startPosition + 1) + ":F" + (startPosition + 1)].Value = "(підпис)";
            cells["B" + (startPosition + 1) + ":C" + (startPosition + 1)].HorizontalAlignment = HAlign.Center;
            cells["E" + (startPosition + 1) + ":F" + (startPosition + 1)].HorizontalAlignment = HAlign.Center;
        }

        #endregion Setting

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}

