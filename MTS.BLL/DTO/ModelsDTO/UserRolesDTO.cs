using MTS.BLL.Infrastructure;

namespace MTS.BLL.DTO.ModelsDTO
{
    public class UserRolesDTO : ObjectBase
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public int? DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }
}
