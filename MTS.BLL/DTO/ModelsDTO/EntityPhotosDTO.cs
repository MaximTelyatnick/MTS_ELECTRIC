using System;

namespace MTS.BLL.DTO.ModelsDTO
{
    public class EntityPhotosDTO
    {
        public int EntityID { get; set; }
        public byte[] Photo { get; set; }
        public string LocalCopyPath { get; set; }
    }
}
