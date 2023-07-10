using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTS.DAL.Entities.Models
{
    public class MTS_AUTHORIZATION_USERS
    {
        [Key]
        public int ID { get; set; }
        public string NAME { get; set; }
        public string PWD { get; set; }
        public int? USER_GROUPS_ID { get; set; }
        public string LOGIN { get; set; }
        public int? ONLINE { get; set; }
    }
}
