using MTS.BLL.Infrastructure;
using System;

namespace MTS.BLL.DTO.ModelsDTO
{
    public class PackingListMaterialsDTO : ObjectBase
    {
        public int Id { get; set; }
        //public int PackingListId { get; set; }
        public byte[] Scan { get; set; }
        public string FileName { get; set; }
    }
}