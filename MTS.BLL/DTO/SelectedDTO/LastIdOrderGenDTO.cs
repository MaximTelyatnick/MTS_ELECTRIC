using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTS.BLL.DTO.SelectedDTO
{
    public class LastIdOrderGenDTO
    {
        [Key]
        public int RecId { get; set; }
        public int GenId { get; set; }
    }
}
