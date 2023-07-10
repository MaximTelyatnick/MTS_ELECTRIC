using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTS.BLL.DTO.ModelsDTO
{
    public class MTSUserGroupsDTO
    {
        public int ID { get; set; }
        public string NAME { get; set; }
        public int? USER_RIGHTS_ID { get; set; }
    }
}
