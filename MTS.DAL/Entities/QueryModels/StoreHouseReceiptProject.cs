﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTS.DAL.Entities.QueryModels
{
    public class StoreHouseReceiptProject
    {
        [Key]
        public int RecId { get; set; }
        public int ReceiptId { get; set; }
        public string ReceiptNum { get; set; }
        public string NomenclatureName { get; set; }
        public string Nomenclature { get; set; }
        public string UnitLocalName { get; set; }
        public string DebitNum { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public string CustomerOrder { get; set; }
        public decimal RemainsQuantity { get; set; }
        public decimal ReceiptQuantity { get; set; }
        //public string CustomerOrder { get; set; }
        public string Correction { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
