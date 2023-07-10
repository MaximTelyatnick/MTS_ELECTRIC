using MTS.BLL.DTO.ModelsDTO;
using MTS.BLL.DTO.SelectedDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTS.BLL.Interfaces
{
    public interface IAccountingOperationService
    {
        IEnumerable<AccountingOperationDTO> GetAccountingOperation();
        
        void Dispose();
    }
}
