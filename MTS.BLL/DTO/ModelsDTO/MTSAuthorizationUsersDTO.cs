﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MTS.BLL.Infrastructure;

namespace MTS.BLL.DTO.ModelsDTO
{
    public class MTSAuthorizationUsersDTO:ObjectBase
    {
        public int ID { get; set; }
        public string NAME { get; set; }
        public string PWD { get; set; }
        public int? USER_GROUPS_ID { get; set; }
        public string LOGIN { get; set; }
        public int ONLINE { get; set; }
    }
}
