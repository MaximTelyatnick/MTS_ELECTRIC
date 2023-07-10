﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MTS.BLL.Infrastructure;

namespace MTS.BLL.DTO.ModelsDTO
{
    public class AgreementDocumentsDTO : ObjectBase
    {
        public int Id { get; set; }
        public string NameDocument { get; set; }
        public string URL { get; set; }
        public int? AgreementId { get; set; }
        public int? AgreementTypeDocumentsId { get; set; }
        public string AgreementTypeDocumentsName { get; set; }
        public string ResponsiblePerson { get; set; }
        public DateTime? DateCreateFile { get; set; }
        public int ResponsiblePersonId { get; set; }
    }
}
