using System;

namespace MTS.BLL.DTO.ModelsDTO
{
    public class MtsModificationsDTO
    {
        public long Id { get; set; }
        public string Number { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public int ResponsiblePersonId { get; set; }
    }
}
