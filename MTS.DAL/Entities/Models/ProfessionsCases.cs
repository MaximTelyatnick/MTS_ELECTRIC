using System.ComponentModel.DataAnnotations;

namespace MTS.DAL.Entities.Models
{
    public class ProfessionsCases
    {
        [Key]
        public int ProfessionCasesID { get; set; }
        public int ProfessionID { get; set; }
        public string NameDative { get; set; }
        public string NameGenitive { get; set; }
    }
}
