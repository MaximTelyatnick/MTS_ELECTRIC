﻿using System;
using System.ComponentModel.DataAnnotations;

namespace MTS.DAL.Entities.Models
{
   public class Country
    {
        [Key]
        public int Country_Id { get; set; }
        public string CountryName { get; set; }
        public string CountryName_UA { get; set; }
    }
}
