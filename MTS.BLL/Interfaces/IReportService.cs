using MTS.BLL.DTO.ModelsDTO;
using MTS.BLL.DTO.ReportsDTO;
using MTS.BLL.DTO.SelectedDTO;
using System;
using System.Collections.Generic;
using MTS.BLL.DTO;

namespace MTS.BLL.Interfaces
{
    public interface IReportService
    {
        

        bool MapTechProcess(MTSSpecificationsDTO mtsSpecification, List<MTSDetailsDTO> mtsDetailsList, bool sortByDrawing, string homeDirectory, int quantity = 1);
        bool PrintMapRouteTechProcess(MTSSpecificationsDTO mtsSpecification, List<MTSDetailsDTO> dataSource, string homeDirectory);
        bool SpecificationProcess(MTSSpecificationsDTO mtsSpecification, List<MTSDetailsDTO> mtsDetailsList, List<MTSPurchasedProductsDTO> mtsBuyDetailsList, List<MTSMaterialsDTO> mtsMaterialsList, string homeDirectory, bool sortament = false);

        void Dispose();



    }
}
