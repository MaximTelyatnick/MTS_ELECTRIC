using System;
using System.ComponentModel.DataAnnotations;

namespace MTS.DAL.Entities.QueryModels
{
   public class DeliveryStoreRemains
    {
        [Key]
        public int NomenclatureId { get; set; }
        public string Nomenclature { get; set; }
        public string NomenclatureName { get; set; }
        public decimal? RemainsQuantity { get; set; }
        public decimal? RemainsPrice { get; set; }
        public string Measure { get; set; }
    }
}
