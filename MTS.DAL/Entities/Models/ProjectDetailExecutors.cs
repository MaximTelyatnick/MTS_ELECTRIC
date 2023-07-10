﻿using System;
using System.ComponentModel.DataAnnotations;

namespace MTS.DAL.Entities.Models
{
   public  class ProjectDetailExecutors
    {
        [Key] 
        public int ProjectDetailExecutorId { get; set; }
        public int EmployeeId { get; set; }
        public int ProjectDetailId { get; set; }
    }
}
