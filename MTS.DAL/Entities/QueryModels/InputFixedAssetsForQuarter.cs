﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MTS.DAL.Entities.QueryModels
{
    public class InputFixedAssetsForQuarter
    {
        [Key]
        public int RecId { get; set; }
        public int BalanceAccountId { get; set; }
        public string BalanceAccountNum { get; set; }
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public decimal FirstQuarterSum { get; set; }
        public decimal FirstQuarterSumSold { get; set; }
        public decimal FirstQuarterSumExpen { get; set; }
        public decimal SecondQuarterSum { get; set; }
        public decimal SecondQuarterSumSold { get; set; }
        public decimal SecondQuarterSumExpen { get; set; }
        public decimal ThirdQuarterSum { get; set; }
        public decimal ThirdQuarterSumSold { get; set; }
        public decimal ThirdQuarterSumExpen { get; set; }
        public decimal FourthQuarterSum { get; set; }
        public decimal FourthQuarterSumSold { get; set; }
        public decimal FourthQuarterSumExpen { get; set; }

    }
}
