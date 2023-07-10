using MTS.BLL.DTO.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTS.BLL.Interfaces
{
    public interface ILogService
    {

        IEnumerable<LogDTO> GetLogs();
        int LogCreate(LogDTO logDTO);
        void LogUpdate(LogDTO logDTO);
        bool LogDelete(int id);
    }
}
