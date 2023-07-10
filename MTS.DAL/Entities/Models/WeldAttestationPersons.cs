using System;
using System.ComponentModel.DataAnnotations;

namespace MTS.DAL.Entities.Models
{
    public class WeldAttestationPersons
    {
        [Key]
        public int Id { get; set; }
        public int WeldAttestationId { get; set; }
        public int EmployeeId { get; set; }
    }
}
