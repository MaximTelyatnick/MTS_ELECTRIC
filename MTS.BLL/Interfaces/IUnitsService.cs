using MTS.BLL.DTO.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTS.BLL.Interfaces
{
    public interface IUnitsService
    {
        IEnumerable<UnitsDTO> GetUnits();
        int UnitCreate(UnitsDTO unit);
        void UnitUpdate(UnitsDTO unit);
        bool UnitDelete(int id);
    }
}
