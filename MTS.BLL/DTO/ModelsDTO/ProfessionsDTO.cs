using MTS.BLL.Infrastructure;
using System;

namespace MTS.BLL.DTO.ModelsDTO
{
    public class ProfessionsDTO : ObjectBase
    {
        public int ProfessionID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int ProfessionGroupID { get; set; }
    }
}
