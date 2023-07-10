using MTS.BLL.DTO.ModelsDTO;
using MTS.BLL.DTO.SelectedDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTS.BLL.Interfaces
{
    public interface IMtsSpecificationsService
    {
        IEnumerable<MTSSpecificationsDTO> GetAllSpecificationOldByPeriod(DateTime startDate, DateTime endDate);


        IEnumerable<MTSSpecificationsDTO> GetAllSpecificationOld();
        IEnumerable<MTSAdditCalculationsDTO> GetAdditCalculationUnits();

        //public IEnumerable<MTSCreateDetalsDTO> GetAllDetailsSpecific(int spesificId)
        //{
        //    var result = (from mtsSpec in mtsSpecificationsOld.GetAll()

        //                  join mtsDetal in mtsDetails.GetAll() on mtsSpec.ID equals mtsDetal.SPECIFICATIONS_ID into mtsDetals
        //                  from mtsDetal in mtsDetals.DefaultIfEmpty()

        //                  join mtsCreateDet in mtsCreateDetals.GetAll() on mtsDetal.CREATED_DETAILS_ID equals mtsCreateDet.ID into mtsCeateDetals
        //                  from mtsCreateDet in mtsCeateDetals.DefaultIfEmpty()

        //                  join mtsNom in mtsNomenclatures.GetAll() on mtsCreateDet.NOMENCLATURE_ID equals mtsNom.ID into mtsNomen
        //                  from mtsNom in mtsNomen.DefaultIfEmpty()

        //                  join mtsG in mtsGost.GetAll() on mtsNom.GOST_ID equals mtsG.ID into mtsGos
        //                  from mtsG in mtsGos.DefaultIfEmpty()

        //                  join mtsDetalsProc in mtsDetailsProcessing.GetAll() on mtsCreateDet.PROCESSING_ID equals mtsDetalsProc.ID into mtsDetalsProcces
        //                  from mtsDetalsProc in mtsDetalsProcces.DefaultIfEmpty()

        //                  join mtsGua in mtsGuages.GetAll() on mtsNom.GUAGE_ID equals mtsGua.ID into mtsGuag
        //                  from mtsGua in mtsGuag.DefaultIfEmpty()

        //                  where (mtsSpec.ID == spesificId /*&& mtsSpec.ID != null*/)

        //                  select new MTSCreateDetalsDTO()
        //                  {
        //                      ID = mtsCreateDet.ID,//mtsDetal.CREATED_DETAILS_ID,//??????????
        //                      NAME = mtsCreateDet.NAME,//1 
        //                      GOSTNAME = mtsG.NAME,//2 
        //                      NOMENCLATURESNOTE = mtsNom.NOTE,//3 
        //                      DRAWING = mtsCreateDet.DRAWING,//4
        //                      QUANTITY = mtsDetal.QUANTITY,//5
        //                      DETALSPROCESSING = mtsDetalsProc.NAME,//6
        //                      NOMENCLATURESNAME = mtsNom.NAME,//7
        //                      GUAEGENAME = mtsGua.NAME,//8 
        //                      WIDTH = mtsCreateDet.WIDTH,//9
        //                      HEIGHT = mtsCreateDet.HEIGHT,//10
        //                      NOMENCLATURESWEIGHT = mtsNom.WEIGHT,//11 
        //                      QUANTITY_OF_BLANKS = mtsDetal.QUANTITY_OF_BLANKS,//12                              
        //                      PROCESSING_ID = mtsCreateDet.PROCESSING_ID,
        //                      NOMENCLATURE_ID = mtsCreateDet.NOMENCLATURE_ID
        //                  });

        //    if (result == null)
        //        return null;



        //    return result.ToList();
        //}

        //public IEnumerable<MTSPurchasedProductsDTO> GetBuysDetalSpecific(int spesificId)
        //{
        //    var rez = (from mtsSpec in mtsSpecificationsOld.GetAll()

        //               join mtsPurc in mtsPurchasedProducts.GetAll() on mtsSpec.ID equals mtsPurc.SPECIFICATIONS_ID into mtsPurchased
        //               from mtsPurc in mtsPurchased.DefaultIfEmpty()

        //               join mtsNom in mtsNomenclatures.GetAll() on mtsPurc.NOMENCLATURES_ID equals mtsNom.ID into mtsNomen
        //               from mtsNom in mtsNomen.DefaultIfEmpty()

        //               join mtsMeas in mtsMeasure.GetAll() on mtsNom.MEASURE_ID equals mtsMeas.ID into mtsMeasur
        //               from mtsMeas in mtsMeasur.DefaultIfEmpty()

        //               join gost in mtsGost.GetAll() on mtsNom.GOST_ID equals gost.ID into gosts
        //               from gost in gosts.DefaultIfEmpty()

        //               where mtsSpec.ID == spesificId && mtsSpec.ID != null
        //               select new MTSPurchasedProductsDTO()
        //               {
        //                   ID = mtsSpec.ID,//mtsPurc.ID,
        //                   NOMENCLATURESNAME = mtsNom.NAME,
        //                   GUAEGENAME = mtsNom.GUAGE,
        //                   GOSTNAME = gost.NAME,
        //                   NOMENCLATURESNOTE = mtsNom.NOTE,
        //                   MEASURENAME = mtsMeas.NAME,
        //                   WEIGHT = mtsNom.WEIGHT,
        //                   QUANTITY = mtsPurc.QUANTITY,
        //                   NOMENCLATURES_ID = mtsPurc.NOMENCLATURES_ID,
        //                   SPECIFICATIONS_ID = mtsPurc.SPECIFICATIONS_ID
        //               }).DefaultIfEmpty().ToList();

        //    return rez;
        //}

        //public IEnumerable<MTSMaterialsDTO> GetMaterialsSpecific(int spesificId)
        //{
        //    var rez = (from mtsSpec in mtsSpecificationsOld.GetAll()

        //               join mtsMat in mtsMaterials.GetAll() on mtsSpec.ID equals mtsMat.SPECIFICATIONS_ID into mtsMater
        //               from mtsMat in mtsMater.DefaultIfEmpty()

        //               join mtsNom in mtsNomenclatures.GetAll() on mtsMat.NOMENCLATURES_ID equals mtsNom.ID into mtsNomen
        //               from mtsNom in mtsNomen.DefaultIfEmpty()

        //               join mtsMeas in mtsMeasure.GetAll() on mtsNom.MEASURE_ID equals mtsMeas.ID into mtsMeasur
        //               from mtsMeas in mtsMeasur.DefaultIfEmpty()

        //               join gost in mtsGost.GetAll() on mtsNom.GOST_ID equals gost.ID into gosts
        //               from gost in gosts.DefaultIfEmpty()

        //               where mtsSpec.ID == spesificId && mtsSpec.ID != null

        //               select new MTSMaterialsDTO()
        //               {
        //                   ID = mtsSpec.ID,//mtsMat.ID,
        //                   NOMENCLATURES_ID = mtsNom.ID,
        //                   NOMENCLATURESNAME = mtsNom.NAME,//1
        //                   GUAGENAME = mtsNom.GUAGE,//2
        //                   GOSTNAME = gost.NAME,//3
        //                   NOMENCLATURESNOTE = mtsNom.NOTE,//4
        //                   MEASURENAME = mtsMeas.NAME,//5
        //                   NOMENCLATURESWEIGHT = mtsNom.WEIGHT,//6
        //                   QUANTITY = mtsMat.QUANTITY,//7
        //                   SPECIFICATIONS_ID = mtsMat.SPECIFICATIONS_ID

        //               }).DefaultIfEmpty().ToList();

        //    return rez;

        //}


        //public IEnumerable<MTSCreateDetalsDTO> GetAllDetailsSpecific(int spesificId)
        //{
        //    var result = (

        //                  from mtsDetal in mtsDetails.GetAll() 

        //                  join mtsCreateDet in mtsCreateDetals.GetAll() on mtsDetal.CREATED_DETAILS_ID equals mtsCreateDet.ID into mtsCeateDetals
        //                  from mtsCreateDet in mtsCeateDetals.DefaultIfEmpty()

        //                  join mtsNom in mtsNomenclatures.GetAll() on mtsCreateDet.NOMENCLATURE_ID equals mtsNom.ID into mtsNomen
        //                  from mtsNom in mtsNomen.DefaultIfEmpty()

        //                  join mtsG in mtsGost.GetAll() on mtsNom.GOST_ID equals mtsG.ID into mtsGos
        //                  from mtsG in mtsGos.DefaultIfEmpty()

        //                  join mtsDetalsProc in mtsDetailsProcessing.GetAll() on mtsCreateDet.PROCESSING_ID equals mtsDetalsProc.ID into mtsDetalsProcces
        //                  from mtsDetalsProc in mtsDetalsProcces.DefaultIfEmpty()

        //                  join mtsGua in mtsGuages.GetAll() on mtsNom.GUAGE_ID equals mtsGua.ID into mtsGuag
        //                  from mtsGua in mtsGuag.DefaultIfEmpty()

        //                  where (mtsDetal.SPECIFICATIONS_ID == spesificId /*&& mtsSpec.ID != null*/)

        //                  select new MTSCreateDetalsDTO()
        //                  {
        //                      ID = mtsCreateDet.ID,//mtsDetal.CREATED_DETAILS_ID,//??????????
        //                      NAME = mtsCreateDet.NAME,//1 ++
        //                      GOSTNAME = mtsG.NAME,//2 
        //                      NOMENCLATURESNOTE = mtsNom.NOTE,//3 --
        //                      DRAWING = mtsCreateDet.DRAWING,//4++
        //                      QUANTITY = mtsDetal.QUANTITY,//5
        //                      DETALSPROCESSING = mtsDetalsProc.NAME,//6
        //                      NOMENCLATURESNAME = mtsNom.NAME,//7 --
        //                      GUAEGENAME = mtsGua.NAME,//8 
        //                      WIDTH = mtsCreateDet.WIDTH,//9++
        //                      HEIGHT = mtsCreateDet.HEIGHT,//10++
        //                      NOMENCLATURESWEIGHT = mtsNom.WEIGHT,//11 --
        //                      QUANTITY_OF_BLANKS = mtsDetal.QUANTITY_OF_BLANKS,//12                              
        //                      PROCESSING_ID = mtsCreateDet.PROCESSING_ID,//++
        //                      NOMENCLATURE_ID = mtsCreateDet.NOMENCLATURE_ID //--
        //                  }).ToList();




        //    return result;
        //}



        IEnumerable<MTSDetailsDTO> GetAllDetailsSpecificShort(int specificId);


        IEnumerable<MTSPurchasedProductsDTO> GetBuysDetalSpecificShort(int specificId);


        IEnumerable<MTSMaterialsDTO> GetMaterialsSpecificShort(int specificId);


        IEnumerable<MTSDetailsDTO> GetAllDetailsSpecific(int spesificId);



        //Nomenclature_id = (int)i.NOMENCLATURES_ID,
        //                                   Quantity = (decimal)(i.QUANTITY * val),
        //                                   Price = (decimal)i.MTS_NOMENCLATURES.PRICE * val,
        //                                   Name = i.MTS_NOMENCLATURES.NAME,
        //                                   Guage = i.MTS_NOMENCLATURES.GUAGE,
        //                                   Gost = i.MTS_NOMENCLATURES.MTS_GOST.NAME,
        //                                   Measure = i.MTS_NOMENCLATURES.MTS_MEASURE.NAME,
        //                                   Note = i.MTS_NOMENCLATURES.NOTE,
        //                                   SortPosition = (int)i.MTS_NOMENCLATURES.MTS_NOMENCLATURE_GROUPS.SORTPOSITION

        IEnumerable<MTSPurchasedProductsDTO> GetBuysDetalSpecific(int spesificId);



        IEnumerable<MTSMaterialsDTO> GetMaterialsSpecific(int spesificId);


        IEnumerable<MTSNomenclatureGroupsDTO> GetAllNomenclatureGroupsOld();
        IEnumerable<MTSGostDTO> GetAllGostOld();
        IEnumerable<MTSGuagesDTO> GetAllGuagesOld();

        IEnumerable<MTSMeasureDTO> GetAllMeasureOld();


        IEnumerable<MTSNomenclaturesDTO> GetAllNomenclatures(int nomenGroupId);
        IEnumerable<MTSNomenclaturesDTO> GetAllNomenclaturesAll();


        IEnumerable<MTSDetalsProcessingDTO> GetDetailsProccesing();


        IEnumerable<MTSCreateDetalsDTO> GetAllCreateDetals();


        MTSCreateDetalsDTO GetCreateDetalsByDrawingNumber(string drawignNumber);




       

        int MTSSpecificationCreate(MTSSpecificationsDTO mtsSpecificationDTO);


        void MTSSpecificationUpdate(MTSSpecificationsDTO mtsSpecificationDTO);


        bool MTSSpecificationDelete(int id);

        //-------
        int MTSCreateDetailsCreate(MTSCreateDetalsDTO mtsCreateDetalsDTO);


        void MTSCreateDetailsUpdate(MTSCreateDetalsDTO mtsCreateDetalsDTO);


        bool MTSCreateDetailsDelete(int id);


        int MTSDetailCreate(MTSDetailsDTO mtsDetalsDTO);


        void MTSDetailUpdate(MTSDetailsDTO mtsDetalsDTO);


        bool MTSDetailDelete(int id);

       

       

        int MTSPurchasedProductsCreate(MTSPurchasedProductsDTO mtsPurchasedProductsDTO);


        void MTSPurchasedProductsCreateRange(List<MTSPurchasedProductsDTO> source);


        void MTSPurchasedProductsUpdate(MTSPurchasedProductsDTO mtsPurchasedProductsDTO);

        bool MTSPurchasedProductsDelete(int id);




        int MTSMaterialCreate(MTSMaterialsDTO mtsMaterialsDTO);


        void MTSMaterialCreateRange(List<MTSMaterialsDTO> source);


        void MTSMaterialUpdate(MTSMaterialsDTO mtsMaterialsDTO);


        bool MTSMaterialDelete(int id);




        int MTSDetailsCreate(MTSDetailsDTO mtsDetailsDTO);


        void MTSDetailsCreateRange(List<MTSDetailsDTO> source);


        void MTSDetailsUpdate(MTSDetailsDTO mtsDetailsDTO);

        bool MTSDetailsDelete(int id);


        int MTSCreateDetalsCreate(MTSCreateDetalsDTO mtsCreateDetalsDTO);


        void MTSCreateDetalsUpdate(MTSCreateDetalsDTO mtsCreateDetalsDTO);


        bool MTSCreateDetalDelete(int id);

        int MTSCreateGost(MTSGostDTO mtsGostDTO);

        void MTSUpdateGost(MTSGostDTO mtsGostDTO);

        bool MTSDeleteGost(int id);

       
        int MTSCreateMeasure(MTSMeasureDTO mtsMeasureDTO);

        void MTSUpdateMeasure(MTSMeasureDTO mtsMeasureDTO);

        bool MTSDeleteMeasure(int id);


        void Dispose();
    }
}
