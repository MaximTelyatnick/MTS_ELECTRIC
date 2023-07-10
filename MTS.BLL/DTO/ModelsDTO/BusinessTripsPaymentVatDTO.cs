using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTS.BLL.DTO.ModelsDTO
{
    public class BusinessTripsPaymentVatDTO
    {
        public int VatID { get; set; }
        public int VatAccountID { get; set; }
        public decimal VatPayment { get; set; }
    }
}
