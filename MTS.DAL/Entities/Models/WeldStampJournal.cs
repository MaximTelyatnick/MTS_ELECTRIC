using System;
using System.ComponentModel.DataAnnotations;

namespace MTS.DAL.Entities.Models
{
    public class WeldStampJournal
    {
        [Key]
        public int Id { get; set; }
        public int WeldStampId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
