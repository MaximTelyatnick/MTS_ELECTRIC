using MTS.BLL.DTO.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTS.BLL.Interfaces
{
    public interface IInfrastructureService
    {
        IEnumerable<ColorsDTO> GetColorsAll();
        int ColorsCreate(ColorsDTO colorsDTO);
        void ColorsUpdate(ColorsDTO colorsDTO);
        bool ColorsDelete(int id);
    }
}
