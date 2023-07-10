﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTS.DAL.Entities.QueryModels
{
    public class BusinessTripsPrepaymentJournal
    {
        [Key]
        public int RecId { get; set; }
        public int BusinessTripsDetailsID { get; set; }
        public int BusinessTripsID { get; set; }
        public int BusinessTripsDecreeID { get; set; }
        public int DecreeType { get; set; }
        public String Doc_Number { get; set; }
        public DateTime? Doc_Date { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? AmountDays { get; set; }
        public bool? Check { get; set; }
        public int EmployeesID { get; set; }
        public string FullName { get; set; }
        public int AccountNumber { get; set; }
        public string ProfessionName { get; set; }
        public string DepartmentName { get; set; }
        public string CountryName { get; set; }
        public string CityName { get; set; }
        public string ContractorName { get; set; }
        public decimal Prepayment { get; set; }
        public decimal Payment { get; set; }
        public int? CustomerOrderId { get; set; }
        public string CustomerOrderNumber { get; set; }
        public DateTime? PaymentDate { get; set; }
        public decimal SaldoDebit { get; set; }
        public decimal SaldoCredit { get; set; }
        public string IdentNumber { get; set; }
    }
}
