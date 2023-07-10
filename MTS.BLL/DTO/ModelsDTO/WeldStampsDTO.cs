using MTS.BLL.Infrastructure;
using System;


namespace MTS.BLL.DTO.ModelsDTO
{
    public class WeldStampsDTO : ObjectBase
    {
        public int Id { get; set; }
        public string StampNumber { get; set; }
        public DateTime StampDate { get; set; }
        //public int UserId { get; set; }
        //public DateTime DateAdded { get; set; }
    }
}
