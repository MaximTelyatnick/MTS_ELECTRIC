using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTS.DAL.Entities.Models
{
    public class BusinessCardPhotos
    {
        [Key]
        public int Id { get; set; }
        public byte[] Photo { get; set; }
        public int BusinessCardId { get; set; }
    }
}
