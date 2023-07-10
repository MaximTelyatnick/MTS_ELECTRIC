using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MTS.DAL.Entities.Models
{
    public class MTS_NOMENCLATURE_GROUPS
    {
        [Key]
        public int ID { get; set; }
        public string NAME { get; set; }
        public int? PARENT_ID { get; set; }
        public decimal? RATIO_OF_WASTE { get; set; }
        public int? ADDIT_CALCULATION_ID { get; set; }
        public bool? ADDIT_CALCULATION_ACTIVE { get; set; }
        public int? CODPROD { get; set; }
        public int SORTPOSITION { get; set; }
    }
}
