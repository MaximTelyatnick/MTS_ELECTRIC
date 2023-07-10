using MTS.BLL.Infrastructure;
namespace MTS.BLL.DTO.ModelsDTO
{
    public class CustomerOrderAssembliesDTO : ObjectBase
    {
        public int Id { get; set; }
        public int CustomerOrderSpecId { get; set; }
        public long? AssemblyId { get; set; }
        public string Drawing { get; set; }
        public string Name { get; set; }
    }
}
