﻿using MTS.BLL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTS.BLL.DTO.ModelsDTO
{
    public class AgreementTypeDocumentsDTO : ObjectBase
    {
        public int Id { get; set; }
        public string TypeDocuments { get; set; }
    }
}
