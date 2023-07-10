using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MTS.BLL.Infrastructure;

namespace MTS.BLL.DTO.ModelsDTO
{
    public class CashBookAdditionalTypeDTO : ObjectBase
   {
      [Key]
      public int Id { get; set; }
      public string NameAdditionalType { get; set; }
   }
}


