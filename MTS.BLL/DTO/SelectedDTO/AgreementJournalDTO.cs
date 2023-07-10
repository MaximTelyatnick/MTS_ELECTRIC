﻿using MTS.BLL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTS.BLL.DTO.ModelsDTO
{
    public class AgreementJournalDTO : ObjectBase
    {
        public int AgreementId { get; set; }
        public int ContractorId { get; set; }
        public int? CurrencyId { get; set; }
        public int? AgreementIdFromContractors { get; set; }
        public string ContractorName { get; set; }
        public string NumberOrder { get; set; }
        public DateTime? DateOrder { get; set; }
        public decimal? Price { get; set; }
        public string Srn { get; set; }
        public string Type { get; set; }
        public int? TypeId { get; set; }
        public string NumberWithTilda { get; set; }
        public string UrlNameJournal { get; set; }
        public string CurrencyName { get; set; }  
        
       

    }
}
