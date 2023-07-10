using System;

namespace MTS.BLL.DTO.ModelsDTO
{
    public class Mts_Addit_CalculationsDTO
    {
        public int Id { get; set; }
        public int UnitId { get; set; }

        public int MtsNomenclatureGroupId { get; set; }
        public string GroupName { get; set; }
        public string AdditUnitLocalName { get; set; }
    }
}
