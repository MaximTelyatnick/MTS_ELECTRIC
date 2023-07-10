using System;
using System.ComponentModel.DataAnnotations;

namespace MTS.DAL.Entities.Models
{
    public class DocumentTypes
    {
        [Key]
        public int DocumentTypeId { get; set; }
        public string DocumentTypeName { get; set; }
        public short DocumentKind { get; set; }
    }
}