using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTS.DAL.Entities.Models
{
    public class MTS_ADDIT_CALCULATION
    {
        [Key]
        public int ID { get; set; }
      //  public int UnitId { get; set; }
        public int MEASURE_ID { get; set; }
    }
}
