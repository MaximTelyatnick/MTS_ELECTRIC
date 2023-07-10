using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTS.DAL.Entities.Models
{
    public class MTS_USER_GROUPS
    {
        public int ID { get; set; }
        public string NAME { get; set; }
        public int? USER_RIGHTS_ID { get; set; }

    }
}
