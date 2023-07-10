using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTS.DAL.Entities.Models
{
    public class BusinessTripsPurpose
    {
        [Key]
        public int PurposeID { get; set; }
        public string Purpose { get; set; }
    }
}
