using System;

namespace MTS.BLL.DTO.ModelsDTO
{
   public  class ContactKindsDTO
    {
        public int Id { get; set; }
        public string KindName { get; set; }
        public int? ContactTypeId { get; set; }
    }
}
