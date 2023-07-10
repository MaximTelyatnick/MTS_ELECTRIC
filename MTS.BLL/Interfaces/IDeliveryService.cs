using System.Collections.Generic;
using MTS.BLL.DTO.ModelsDTO;
using MTS.BLL.DTO.SelectedDTO;
using System;

namespace MTS.BLL.Interfaces
{
    public interface IDeliveryService
    {
        IEnumerable<DeliveryContractorDebtsDTO> GetDeliveryContractorDebts(DateTime endDate);
        IEnumerable<DeliveryPaymentsDTO> GetDeliveryPayments(DateTime beginDate, DateTime endDate);
        IEnumerable<DeliveryOrdersDTO> GetDeliveryOrders(DateTime beginDate, DateTime endDate);
        IEnumerable<DeliveryStoreRemainsDTO> GetDeliveryStoreRemains(DateTime endDate);
        IEnumerable<DeliveryStoreRemainsReceiptDTO> GetDeliveryStoreRemainsWithReceipt(DateTime endDate);


        int ReceiptDetailsCreate(ReceiptDetailsDTO receiptDetailsDTO);
        void ReceiptDetailsCreateRange(List<ReceiptDetailsDTO> source);
        void ReceiptDetailsUpdate(ReceiptDetailsDTO receiptDetailsDTO);
        bool ReceiptDetailsDelete(int id);
        bool ReceiptDetailsRemoveRange(List<ReceiptDetailsDTO> source);

        void Dispose();
    }
}
