﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTS.BLL.DTO.ModelsDTO
{
    public class AgreementOrderScanDTO
    {
        public int Id { get; set; }
        //public int AgreementOrderId { get; set; }
        public byte[] Scan { get; set; }
        public string FileName { get; set; }
    }
}
