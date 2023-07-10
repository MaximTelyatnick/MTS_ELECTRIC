using System.Collections.Generic;
using MTS.BLL.DTO.ModelsDTO;
using MTS.BLL.DTO.SelectedDTO;
using System;

namespace MTS.BLL.Interfaces
{
   public interface IMtsNomenclaturesService
    {
        IEnumerable<MtsNomenclaturessDTO> GetNomenclarures();


        IEnumerable<MTSGostDTO> GetGosts();

        int GetLastSortPositionNomenclatureGroup();




        IEnumerable<MTSNomenclatureGroupsDTO> GetNomenclatureGroups();
        bool CheckNomenclaturesGroup(int nomenclaturesGroupId);






        #region Nomenclatures CRUD method's

        long NomenclarureCreate(MTSNomenclaturesDTO mtsNomenclature);


        void NomenclarureUpdate(MTSNomenclaturesDTO mtsNomenclature);


        bool NomenclarureDelete(long id);

        #endregion

        #region MtsNomenclatureGroups CRUD method's

        int NomenclarureGroupCreate(MTSNomenclatureGroupsDTO mtsNomenclatureGroup);


        void NomenclarureGroupUpdate(MTSNomenclatureGroupsDTO mtsNomenclatureGroup);


        bool NomenclarureGroupDelete(int id);


        #endregion

        #region MtsGosts CRUD method's

        long GostCreate(MTSGostDTO mtsGost);


        void GostUpdate(MTSGostDTO mtsGost);


        bool GostDelete(long id);
        #endregion

        #region MtsNomenclatureGroup CRUD method's
        int NomenclatureGroupCreate(MTSNomenclatureGroupsDTO mtsNomGroup);
        void NomenclatureGroupUpdate(MTSNomenclatureGroupsDTO mtsNomGroup);
        bool NomenclatureGroupDelete(long id);
        #endregion

        #region MtsNomenclature CRUD method's
        int NomenclatureCreate(MTSNomenclaturesDTO mtsNom);

        void NomenclatureUpdate(MTSNomenclaturesDTO mtsNom);

        bool NomenclaturesDelete(long id);
        #endregion  

        void Dispose();
    }
}
