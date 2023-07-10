using MTS.BLL.Infrastructure;
using System;

namespace MTS.BLL.DTO.ModelsDTO
{
    public class WeldStampJournalDTO : ObjectBase
    {
        public int Id { get; set; }
        public int WeldStampId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
