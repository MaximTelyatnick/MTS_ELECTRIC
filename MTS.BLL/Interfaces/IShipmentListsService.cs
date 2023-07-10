using System.Collections.Generic;
using MTS.BLL.DTO.ModelsDTO;
using MTS.BLL.DTO.SelectedDTO;
using System;


namespace MTS.BLL.Interfaces
{
   public interface IShipmentListsService
    {
       IEnumerable<ShipmentListsDTO> GetShipmentLists(DateTime beginDate, DateTime endDate);
       int CreateShipmentList(ShipmentListsDTO dtomodel);
       void UpdateShipmentList(ShipmentListsDTO dtomodel);
       bool RemoveShipmentListById(long id);
       void Dispose();
    }
}
