using MTS.BLL.Infrastructure;
using System;

namespace MTS.BLL.DTO.ModelsDTO
{
    public class MtsSpecificationnsDTO : ObjectBase
    {
        public long Id { get; set; }
        public long? ParentId { get; set; }
        public long RootId { get; set; }
        public long? AssemblyId { get; set; }
        public long? MtsCreatedDetailId { get; set; }
        public long? MtsMaterialId { get; set; }
        public long? MtsModificationId { get; set; }
        public int? UserId { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? QuantityOfBlanks { get; set; }
        public short? MaterialStatus { get; set; }
        public string Description{ get; set; }

        public int? DesignerId { get; set; }
        public string Drawing { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
    }
}
