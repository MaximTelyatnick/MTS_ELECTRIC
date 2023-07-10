using MTS.BLL.Infrastructure;
using System;

namespace MTS.BLL.DTO.ModelsDTO
{
    public class UnitsDTO : ObjectBase
    {
        public int UnitId { get; set; }
        public string UnitCode { get; set; }
        public string UnitFullName { get; set; }
        public string UnitLocalName { get; set; }
    }
}
