﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTS.DAL.Entities.QueryModels
{
    public class ToolActMaterialsJournal
    {
        public int Id { get; set; }
        public int ToolActId { get; set; }
        public int InvoiceRequirementId { get; set; }
        public int Receipt_Id { get; set; }
        public decimal Required_Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string InvoiceRequirementNumber { get; set; }
        public DateTime? InvoiceRequirementDate { get; set; }
        public string ResponsiblePersonName { get; set; }
        public string ReceiptNum { get; set; }
        public DateTime? OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public string Nomenclature { get; set; }
        public string NomenclatureName { get; set; }
        public string UnitLocalName { get; set; }
        public string UnitCode { get; set; }
        public string BalanceAccountNum { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? TotalPriceQuantity { get; set; }

    }
}
