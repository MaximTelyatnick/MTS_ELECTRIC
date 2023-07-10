﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using MTS.BLL.Interfaces;
using MTS.BLL.Services;
using MTS.BLL.DTO;
using MTS.BLL.DTO.ModelsDTO;
using MTS.BLL.DTO.SelectedDTO;
using Ninject;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using System.IO;

namespace MTS.GUI.Delivery
{
    public partial class DeliveryContractorDebtsFm : DevExpress.XtraEditors.XtraForm
    {
        private IDeliveryService deliveryService;
        private BindingSource сontractorDebtsBS = new BindingSource();

        public DeliveryContractorDebtsFm(UserTasksDTO userTasksDTO)
        {
            InitializeComponent();
            DateTime end_Date = DateTime.Today;// год - месяц - день
            priceCol.Visible = (userTasksDTO.PriceAttribute == 1);
            endDateEdit.EditValue = end_Date;

            LoadData(end_Date);
        }

        private void LoadData(DateTime endDate)
        {
            splashScreenManager.ShowWaitForm();
            deliveryService = Program.kernel.Get<IDeliveryService>();
            var сontractorDebts = deliveryService.GetDeliveryContractorDebts(endDate);
            сontractorDebtsBS.DataSource = сontractorDebts;
            deliveryContractorDebtsGrid.DataSource = сontractorDebtsBS;
            
            splashScreenManager.CloseWaitForm();
            deliveryContractorDebtsGridView.CollapseAllGroups();
            deliveryContractorDebtsGrid.Focus();
        }

        private void showContractorDebtsForDate_Click(object sender, EventArgs e)
        {
            DateTime end_Date = (DateTime)endDateEdit.EditValue;
            LoadData(end_Date);
        }

        private void xlsBtn_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Excel (2010)(.xlsx)|*.xlsx|Excel (2003) (.xls)|*.xls";
                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    string exportFilePath = saveDialog.FileName;

                    var optionXls = new XlsExportOptions();
                    optionXls.ExportMode = XlsExportMode.SingleFilePageByPage;
                    optionXls.SheetName = "Заборгованість по контрагентам";
                    optionXls.TextExportMode = DevExpress.XtraPrinting.TextExportMode.Text;

                    var optionXlsx = new XlsxExportOptions();
                    optionXlsx.ExportMode = XlsxExportMode.SingleFilePageByPage;
                    optionXlsx.SheetName = "Заборгованість по контрагентам";
                    optionXlsx.TextExportMode = DevExpress.XtraPrinting.TextExportMode.Text;

                    string fileExtenstion = new FileInfo(exportFilePath).Extension;

                    switch (fileExtenstion)
                    {
                        case ".xls":
                            deliveryContractorDebtsGrid.ExportToXls(exportFilePath, optionXls);
                            break;
                        case ".xlsx":
                            deliveryContractorDebtsGrid.ExportToXlsx(exportFilePath, optionXlsx);
                            break;
                        default:
                            break;
                    }

                    if (File.Exists(exportFilePath))
                    {
                        try
                        {
                            System.Diagnostics.Process.Start(exportFilePath);
                        }
                        catch
                        {
                            String msg = "The file could not be opened." + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                            MessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        String msg = "The file could not be saved." + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                        MessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

    }
}