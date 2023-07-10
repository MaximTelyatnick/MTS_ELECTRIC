﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTS.DAL.Entities.Models
{
    public class CustomerOrderPrepayments
    {
        [Key]
        public int Id { get; set; }
        public int CustomerOrderId { get; set; }
        public int BankPaymentId { get; set; }
        public decimal? Prepayment { get; set; }
        public decimal? PrepaymentCurrency { get; set; }
    }
}
