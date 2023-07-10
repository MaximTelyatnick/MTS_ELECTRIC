﻿using System;
using System.ComponentModel.DataAnnotations;

namespace MTS.DAL.Entities.Models
{
   public  class ContactPersonAddress
    {
        [Key]
        public int Id { get; set; }
        public int ContactPersonId { get; set; }
        public int? ContactKindId { get; set; }
        public string  Details { get; set; }
    }
}
