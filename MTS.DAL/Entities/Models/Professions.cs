using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MTS.DAL.Entities.Models
{
    public class Professions
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProfessionID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int ProfessionGroupID { get; set; }
    }
}
