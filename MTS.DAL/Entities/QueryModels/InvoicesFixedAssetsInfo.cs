﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTS.DAL.Entities.QueryModels
{
    public class InvoicesFixedAssetsInfo
    {
        [Key]
        public int InvoiceRequirementMaterialId { get; set; }
        public string InventoryNumber { get; set; }
        public string InventoryName { get; set; }
        public string GroupName { get; set; }
        public string FixedSupplierFullName { get; set; }
        public int? OperatingPerson_Id { get; set; }
        public string OperatingPersonFullName { get; set; }
        public string Description { get; set; }
        public string ReceiptNum { get; set; }
        public string Nomenclature { get; set; }
        public string NomenclatureName { get; set; }
        public string BalanceAccountNum { get; set;}
        public string CreditAccountNum { get; set; }
        public string Number { get; set; }
        public DateTime Date { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? TotalPrice { get; set; }
        public string InvoiceSupplierFullName { get; set; }
    }
}
