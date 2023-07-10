﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTS.DAL.Entities.ReportModel
{
    public class ContractorVat
    {
        [Key]
        public int Id { get; set; }
        public string Tin { get; set; }
        public string Name { get; set; }
        public decimal SaldoDebitStart { get; set; }
        public decimal SaldoCreditStart { get; set; }
        public decimal DebitVat63 { get; set; }
        public decimal DebitVat631 { get; set; }
        public decimal CreditPeriod { get; set; }
        public decimal SaldoDebitEnd { get; set; }
        public decimal SaldoCreditEnd { get; set; }
    }
}
