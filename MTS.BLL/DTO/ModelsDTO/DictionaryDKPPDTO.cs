using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTS.BLL.DTO.ModelsDTO
{
    public class DictionaryDKPPDTO
    {
        [Key]
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string CodeDKPP { get; set; }
        public string DescriptionUA { get; set; }
        public int? Level { get; set; }
        public string CodeUKTV { get; set; }
    }
}
