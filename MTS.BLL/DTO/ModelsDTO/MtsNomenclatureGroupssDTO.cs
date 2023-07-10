using MTS.BLL.Infrastructure;
using System;

namespace MTS.BLL.DTO.ModelsDTO
{
    public class MtsNomenclatureGroupssDTO : ObjectBase
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public int? MtsAdditCalculationId { get; set; }
        public string Name { get; set; }
        public decimal? RatioOfWaste { get; set; }
        public short? AdditCalculationActive { get; set; }

        public string AdditUnitLocalName { get; set; }
    }
}
