using MTS.BLL.Infrastructure;
using System;

namespace MTS.BLL.DTO.ModelsDTO
{
    public class DepartmentsDTO : ObjectBase
    {
        public int DepartmentID { get; set; }
        public int? RootID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int? Patron { get; set; }
    }
}
