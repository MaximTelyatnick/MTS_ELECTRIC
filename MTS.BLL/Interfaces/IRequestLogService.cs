﻿using MTS.BLL.DTO.ModelsDTO;
using MTS.BLL.DTO.SelectedDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTS.BLL.Interfaces
{
    public interface IRequestLogService
    {
        IEnumerable<RequestLogJournalDTO> GetRequestLogProc(DateTime beginDate, DateTime endDate);
        IEnumerable<RequestLogContractorsDTO> GetRequestLogContractors();
        IEnumerable<RequestLogDTO> GetRequestLog();
        IEnumerable<ColorsDTO> GetColors();
       

        int RequestLogCreate(RequestLogDTO requestLogDTO);
        void RequestLogUpdate(RequestLogDTO requestLogDTO);
        bool RequestLogDelete(int id);

        int RequestLogConractorCreate(RequestLogContractorsDTO requestLogContractorDTO);
        void RequestLogContractorUpdate(RequestLogContractorsDTO requestLogContractorDTO);
        bool RequestLogContractorDelete(int id);

        void Dispose();
    }
}
