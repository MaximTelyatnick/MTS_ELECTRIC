using MTS.BLL.Infrastructure;
using System;

namespace MTS.BLL.DTO.ModelsDTO
{
    public class DocumentTypesDTO : ObjectBase
    {
        public int DocumentTypeId { get; set; }
        public string DocumentTypeName { get; set; }
        public short DocumentKind { get; set; }
    }
}
