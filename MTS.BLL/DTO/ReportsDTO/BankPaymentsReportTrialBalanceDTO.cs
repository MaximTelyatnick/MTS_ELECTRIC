﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTS.BLL.DTO.ReportsDTO
{
    public class BankPaymentsReportTrialBalanceDTO
    {
        public int RecId { get; set; }
        public DateTime Payment_Date { get; set; }
        public string PurposeAccountNum { get; set; }
        public int Bank_Account_Id { get; set; }
        public decimal DebitPrewPeriod { get; set; }
        public decimal CreditPrewPeriod { get; set; }
        public decimal DebitFromPeriod { get; set; }
        public decimal CreditFromPeriod { get; set; }
        public decimal DebitEndPeriod { get; set; }
        public decimal CreditEndPeriod { get; set; }
    }
}
