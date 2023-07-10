﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTS.DAL.Entities.QueryModels
{
    public class WeldStampJournalInfo
    {
        [Key]
        public int Id { get; set; }
        public int WeldStampId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string EmployeesFio { get; set; }
        public int AccountNumber { get; set; }
        public string ProfessionName { get; set; }
        public string StampNumber { get; set; }
        public DateTime? StampDate { get; set; }
    }
}
