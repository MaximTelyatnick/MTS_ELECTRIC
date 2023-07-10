﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTS.DAL.Entities.QueryModels
{
    public class InvoicesInfo
    {
        public int Id { get; set; }
        public int ContractorId { get; set; }
        public DateTime MonthCurrent { get; set; }
        public DateTime MonthInvoice { get; set; }
        public int BalanceAccountId { get; set; }
        public int NoteId { get; set; }
        public int RegistryId { get; set; }
        public int ColorId { get; set; }
        public string Invoice_Number { get; set; }
        public float Price { get; set; }
        public float Vat { get; set; }
        public decimal NonTaxable { get; set; }
        public float TotalPrice { get; set; }
        public decimal VatCheck { get; set; }
        public string ConstractorName { get; set; }
        public string ContractorCode { get; set; }
        public string ColorName { get; set; }
        public string ColorCode { get; set; }
        public string BalName { get; set; }
        public string InvNoteName { get; set; }
        public string RegionName { get; set; }
        public DateTime DateOfCorrection { get; set; }
        public string NumberOfCorrection { get; set; }
      
    }
}
