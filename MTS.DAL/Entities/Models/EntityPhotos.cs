using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MTS.DAL.Entities.Models
{
    public class EntityPhotos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EntityID { get; set; }
        public byte[] Photo { get; set; }
        public string LocalCopyPath { get; set; }
    }
}
