using MTS.BLL.Infrastructure;
using System;

namespace MTS.BLL.DTO.ModelsDTO
{
    public class WeldAttestationPersonsDTO : ObjectBase
    {
        public int Id { get; set; }
        public int WeldAttestationId { get; set; }
        public int EmployeeId { get; set; }
    }
}
