using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MTS.DAL.Entities.Models
{
    public class MTS_GUAGES
    {
        [Key]
        public int ID { get; set; }
        public string NAME { get; set; }
        public int SORTING { get; set; }
    }
}
