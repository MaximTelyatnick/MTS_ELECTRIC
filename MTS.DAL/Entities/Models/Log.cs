﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTS.DAL.Entities.Models
{
    public class Log
    {
        [Key]
        public int Id { get; set; }
        public int EmployeeId  { get; set; }
     //   public string FormName { get; set; }
        public int TaskId { get; set; }
        public string OperationType { get; set; }
        public DateTime? RecDate { get; set; }
        public DateTime? RecTime { get; set; }

    }
}
