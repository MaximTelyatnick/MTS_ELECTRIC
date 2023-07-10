using System.Collections.Generic;
using MTS.BLL.DTO.ModelsDTO;
using MTS.BLL.DTO.SelectedDTO;
using System;

namespace MTS.BLL.Interfaces
{
    public interface IReceiptCertificateService
    {
        ReceiptCertificatesDTO GetCertificate(long id);
        IEnumerable<ReceiptCertificatesDTO> GetCertificates();
        IEnumerable<OrdersInfoDTO> GetOrdersWithCertificate(DateTime beginDate, DateTime endDate);
        IEnumerable<ExpenditureByOrdersDTO> GetExpenditureByCustomerOrders(DateTime beginDate, DateTime endDate);

        long CreateCertificate(ReceiptCertificatesDTO dtomodel);
        void UpdateCertificate(ReceiptCertificatesDTO dtomodel);
        bool RemoveCertificateById(long id);

        void Dispose();
    }
}
