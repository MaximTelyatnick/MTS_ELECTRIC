using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MTS.DAL.Entities.Models
{
    public class MTS_CREATED_DETAILS
    {
        [Key]
        public int ID { get; set; }
        public int? NOMENCLATURE_ID { get; set; }
        public int? PROCESSING_ID { get; set; }
        public string NAME { get; set; }
        public string DRAWING { get; set; }
        public decimal? WIDTH { get; set; }
        public decimal? HEIGHT { get; set; }
    }
}
