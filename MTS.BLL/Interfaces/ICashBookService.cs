﻿using MTS.BLL.DTO.ModelsDTO;
using MTS.BLL.DTO.SelectedDTO;
using MTS.BLL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTS.BLL.Interfaces
{
    public interface ICashBookService
    {
        IEnumerable<CashBookPageDTO> GetPageByPeriod(DateTime beginDate, DateTime endDate);
        IEnumerable<CashBookBasisTypeDTO> GetBasis();
        IEnumerable<CashBookRecordJournalDTO> GetCashBookRecords(int cashBookPageId);
        IEnumerable<CashBookBalanceDTO> GetCashBookBalanceByPeriod(DateTime beginDate, DateTime endDate);
        IEnumerable<CashBookRecordTypeDTO> GetCashBookRecordType();
        IEnumerable<CashBookContractorDTO> GetContractors();
        IEnumerable<CashBookPageDTO> GetCashBookPages();
        IEnumerable<CashBookRecordDTO> GetCashBookRecords();
        IEnumerable<CashBookRecordDTO> GetCashBookRecords(DateTime date);
        string GetLatestPageNumber(DateTime pageDate);
        IEnumerable<CashBookAdditionalTypeDTO> GetCashBookAdditional();
        string GetLatestRecordDocumentNumber(DateTime pageDate, Utils.CurencyOperationType recordCurencyOperation, List<CashBookRecordJournalDTO> models);
        string GetLatestRecordDocumentNumber(DateTime pageDate, Utils.CurencyOperationType recordCurencyOperation);
        


        int CashBookPageCreate(CashBookPageDTO cashBookPageDTO);
        void CashBookPageUpdate(CashBookPageDTO cashBookPageDTO);
        bool CashBookPageDelete(int id);

        int CashBookRecordCreate(CashBookRecordDTO cashBookRecordDTO);
        void CashBookRecordCreateRange(List<CashBookRecordDTO> source);
        void CashBookRecordUpdate(CashBookRecordDTO cashBookRecordDTO);
        bool CashBookRecordDelete(int id);
        bool CashBookRecordRemoveRange(List<CashBookRecordDTO> source);
        

        int CashBookBasisCreate(CashBookBasisTypeDTO cashBookBasisTypeyDTO);
        void CashBookBasisUpdate(CashBookBasisTypeDTO cashBookBasisTypeDTO);
        bool CashBookBasisDelete(int id);

        int CashBookContractorCreate(CashBookContractorDTO cashBookContractorDTO);
        void CashBookContractorUpdate(CashBookContractorDTO cashBookContractorDTO);
        bool CashBookContractorDelete(int id);

        int CashBookAdditionalTypeCreate(CashBookAdditionalTypeDTO cashBookAdditionalTypeDTO);
        void CashBookAdditionalTypeUpdate(CashBookAdditionalTypeDTO cashBookAdditionalTypeDTO);
        bool CashBookAdditionalTypeDelete(int id);


        void Dispose();

        //void CashBookAdditionalTypeDelete(int p);

    }
}
