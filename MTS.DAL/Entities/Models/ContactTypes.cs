using System;
using System.ComponentModel.DataAnnotations;

namespace MTS.DAL.Entities.Models
{
   public  class ContactTypes
    {
        [Key]
        public int Id{ get; set; }
        public string TypeName { get; set; }

    }
}
