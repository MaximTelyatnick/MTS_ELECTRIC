﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MTS.DAL.Entities.Models
{
   public  class ContractorContactPersons
    {
        [Key]
        public int Id { get; set; }
        public int ContractorId { get; set; }
        public int ContactPersonId { get; set; }
    }
}
