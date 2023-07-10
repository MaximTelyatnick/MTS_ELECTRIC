using MTS.BLL.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTS.BLL.DTO.ModelsDTO
{
    public class CashBookPageDTO : ObjectBase
    {
        [Key]
        public int Id { get; set; }
        public DateTime PageDate { get; set; }
        public string PageNumber { get; set; }
    }
}
