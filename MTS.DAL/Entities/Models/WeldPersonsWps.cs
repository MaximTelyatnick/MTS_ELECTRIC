using System.ComponentModel.DataAnnotations;

namespace MTS.DAL.Entities.Models
{
    public class WeldPersonsWps
    {
        [Key]
        public int Id { get; set; }
        public int WeldAttestationPersonId { get; set; }
        public int WeldWpsId { get; set; }
    }
}
