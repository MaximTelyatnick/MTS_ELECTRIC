﻿using System;
using System.ComponentModel.DataAnnotations;

namespace MTS.DAL.Entities.Models
{
   public class Tasks
    {
        [Key] 
        public int TaskId { get; set; }
        public int? ParentId { get; set; }
        public string TaskName { get; set; }
        public string TaskCaption { get; set; }
    }
}
