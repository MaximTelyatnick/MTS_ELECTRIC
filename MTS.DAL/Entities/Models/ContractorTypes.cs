using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MTS.DAL.Entities.Models
{
   public  class ContractorTypes
    {
        [Key]
        public int TypeId { get; set; }
        public string TypeName { get; set; }

    }
}
