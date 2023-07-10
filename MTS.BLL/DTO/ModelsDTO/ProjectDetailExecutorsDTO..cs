using System;
using MTS.BLL.Infrastructure;

namespace MTS.BLL.DTO.ModelsDTO
{
   public class ProjectDetailExecutorsDTO 
    {
       public int ProjectDetailExecutorId { get; set; }
       public int? EmployeeId { get; set; }
       public int? ProjectDetailId { get; set; }
       public int? WeldStampId { get; set; }
       public int? WeldStampJournalId { get; set; }
       public string StampNumber { get; set; }
       public DateTime? BeginDate { get; set; }
       public string Fio { get; set; }
       public string ProfessionName { get; set; }
       public int AccountNumber { get; set; }

    }
}
