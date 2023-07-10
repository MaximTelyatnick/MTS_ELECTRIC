using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MTS.BLL.DTO.ModelsDTO;
using MTS.BLL.DTO.SelectedDTO;

namespace MTS.BLL.Interfaces
{
    public interface IBankPaymentsService
    {
        IEnumerable<Bank_PaymentsDTO> GetBankPayments();
        IEnumerable<BankPaymentsInfoDTO> GetBankPaymentsJournal(DateTime beginDate, DateTime endDate);
        IEnumerable<BankPaymentsSelectDTO> GetBankPaymentsForCOPrepayments(DateTime beginDate, DateTime endDate);
        IEnumerable<BankPaymentsSelectDTO> GetBankPaymentsForCOPayments(DateTime beginDate, DateTime endDate);

        bool GetExistImportPayment(DateTime? paymentDate, string paymentDocument, int? bankAccountId, decimal paymentPrice);

        int BankPaymentCreate(Bank_PaymentsDTO bpDTO);
        void BankPaymentUpdate(Bank_PaymentsDTO bpDTO);
        bool BankPaymentDelete(int id);
                
        void Dispose();
    }
}
