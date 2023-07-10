using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MTS.BLL.Infrastructure;

namespace MTS.BLL.DTO.ModelsDTO
{
    public class DeliveryDTO : ObjectBase
    {
        public int Id { get; set; }
        public string DeliveryName { get; set; }
    }
}
