using MTS.BLL.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTS.BLL.DTO.ModelsDTO
{
    public class BusinessCardDTO : ObjectBase
    {
        [Key]
        public int Id { get; set; }
        public String ContactPersonName { get; set; }
        public String ContractorInfo { get; set; }
        public int? UserId { get; set; }
        public int BusinessCardsFactoryId { get; set; }
    }
}
