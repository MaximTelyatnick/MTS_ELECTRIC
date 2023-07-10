using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MTS.BLL.DTO.SelectedDTO;
using MTS.BLL.DTO.ModelsDTO;
using MTS.BLL.Interfaces;
using MTS.DAL.Entities.Models;
using MTS.DAL.Entities.QueryModels;
using MTS.DAL.Interfaces;
using FirebirdSql.Data.FirebirdClient;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using MTS.BLL.Infrastructure;

namespace MTS.BLL.Services
{
    public class AccountingOperationService : IAccountingOperationService
    {
        private IUnitOfWork Database { get; set; }
        private IRepository<AccountingOperation> accountingOperation;
        private IMapper mapper;

        public AccountingOperationService(IUnitOfWork uow)
        {
            Database = uow;
            accountingOperation = Database.GetRepository<AccountingOperation>();
            
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AccountingOperation, AccountingOperationDTO>();
            });

            mapper = config.CreateMapper();
        }
                
        public IEnumerable<AccountingOperationDTO> GetAccountingOperation()
        {
            return mapper.Map<IEnumerable<AccountingOperation>, List<AccountingOperationDTO>>(accountingOperation.GetAll());
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
