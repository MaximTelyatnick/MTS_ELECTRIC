using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTS.DAL.Entities.Models
{
    public class MTS_USER_RIGHTS
    {
        public int ID { get; set; }
        public short? CAN_WRITE { get; set; }
        public short? EDIT_NOMENCLATURES { get; set; }
        public short? STOREHOUSE_SORTING { get; set; }
    }
}
