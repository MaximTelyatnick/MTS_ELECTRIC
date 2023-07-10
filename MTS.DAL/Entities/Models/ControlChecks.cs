using System;
using System.ComponentModel.DataAnnotations;

namespace MTS.DAL.Entities.Models
{
    public class ControlChecks
    {
        [Key]
        public int ControlCheckId { get; set; }
        public int? ProjectDetailId { get; set; }
        public DateTime ControlDate { get; set; }
        public int ControlPersonId { get; set; }
        public string Description { get; set; }
        public string MarkDocumentNumber { get; set; }
        public int? CustomerOrderId { get; set; }
    }
}
