﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTS.DAL.Entities.ReportModel
{
    public class CalcWithBuyersShortReport
    {
        [Key]
        public int RecId { get; set; }
        public int ContractorsId { get; set; }
        public int EmployeesId { get; set; }
        public int CurrencyId { get; set; }
        public string PartnerSrn { get; set; }
        public string PartnerName { get; set; }
        public string CurrencyName { get; set; }
        public decimal StartDebit { get; set; }
        public decimal StartCredit { get; set; }
        public decimal StartDebitCurrency { get; set; }
        public decimal StartCreditCurrency { get; set; }
        public decimal DebitPeriod { get; set; }
        public decimal DebitPeriodCurrency { get; set; }
        public decimal CreditPeriod { get; set; }
        public decimal CreditPeriodCurrency { get; set; }
        public decimal EndDebit { get; set; }
        public decimal EndCredit { get; set; }
        public decimal EndDebitCurrency { get; set; }
        public decimal EndCreditCurrency { get; set; }
    }
}
