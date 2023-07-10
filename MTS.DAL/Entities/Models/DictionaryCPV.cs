﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTS.DAL.Entities.Models
{
    public class DictionaryCPV
    {
        [Key]
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string CodeCPV { get; set; }
        public string DescriptionUA { get; set; }
        public string DescriptionENU { get; set; }
        public string Grouping { get; set; }
        public int? Level { get; set; }
    }
}
