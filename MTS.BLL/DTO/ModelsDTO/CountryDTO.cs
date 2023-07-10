using MTS.BLL.Infrastructure;
using System;

namespace MTS.BLL.DTO.ModelsDTO
{
    public class CountryDTO : ObjectBase
    {
        public int Country_Id { get; set; }
        public string CountryName { get; set; }
        public string CountryName_UA { get; set; }
    }
}
