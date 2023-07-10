﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTS.DAL.Entities.ReportModel
{
    public class BusinessTripsReportPaymentsByPeriod
    {
        [Key]
        public int Id { get; set; }
        public int BusinessTripsDetailId { get; set; }
        public DateTime? Payment_Date { get; set; }
        public string ReportName { get; set; }
        public string Comment { get; set; }
        public string VatAccountNum { get; set; }
        public decimal? VatPayment { get; set; }
        public string CurrencyName { get; set; }
        public decimal? CurrencyPayment { get; set; }
        public string AccountNum { get; set; }
        public decimal? Payment { get; set; }
        public int EmployeeID { get; set; }
        public string Fio { get; set; }
    }
}
