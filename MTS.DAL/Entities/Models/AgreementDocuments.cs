﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MTS.DAL.Entities.Models
{
    public class AgreementDocuments
    {
        [Key]
        public int Id { get; set; }
        public string NameDocument { get; set; }
        public string URL { get; set; }
        public int? AgreementId { get; set; }
        public int? AgreementTypeDocumentsId { get; set; }
        public int ResponsiblePersonId { get; set; }
        public DateTime? DateCreateFile { get; set; }
    }
}
