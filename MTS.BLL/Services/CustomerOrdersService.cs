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

namespace MTS.BLL.Services
{
    public class CustomerOrdersService : ICustomerOrdersService
    {
        private IUnitOfWork Database { get; set; }

        private IRepository<CalcWithBuyers> calcWithBuyers;
        private IRepository<CalcWithBuyersSpec> calcWithBuyersSpec;
        private IRepository<CustomerOrders> customerOrders;
        private IRepository<CustomerOrderSpecifications> customerOrderSpecifications;
        private IRepository<CustomerOrderAssemblies> customerOrderAssemblies;
        private IRepository<CustomerOrderForWelding> customerOrderForWelding;
        private IRepository<Contractors> contractors;
        private IRepository<Currency> currency;
        //private IRepository<MtsAssemblies> mtsAssemblies;
        private IRepository<EmployeesDetails> employeesDetails;
        private IRepository<Users> users;
        private IRepository<ContractPayments> contractPayments;
        private IRepository<CustomerOrderPrepayments> customerOrderPrepayments;
        private IRepository<CustomerOrderPayments> customerOrderPayments;
        private IRepository<Bank_Payments> bankPayments;
        private IRepository<ReceiptDetails> receiptDetails;
        private IRepository<RECEIPTS> receipt;
        private IRepository<ORDERS> orders;
        private IRepository<NOMENCLATURES> nomenclatures;
        private IRepository<Units> units;


        private IMapper mapper;

        public CustomerOrdersService(IUnitOfWork uow)
        {
            Database = uow;

            calcWithBuyers = Database.GetRepository<CalcWithBuyers>();
            calcWithBuyersSpec = Database.GetRepository<CalcWithBuyersSpec>();
            customerOrders = Database.GetRepository<CustomerOrders>();
            customerOrderSpecifications = Database.GetRepository<CustomerOrderSpecifications>();
            customerOrderAssemblies = Database.GetRepository<CustomerOrderAssemblies>();
            contractors = Database.GetRepository<Contractors>();
            currency = Database.GetRepository<Currency>();
            //mtsAssemblies = Database.GetRepository<MtsAssemblies>();
            employeesDetails = Database.GetRepository<EmployeesDetails>();
            users = Database.GetRepository<Users>();
            contractPayments = Database.GetRepository<ContractPayments>();
            customerOrderPrepayments = Database.GetRepository<CustomerOrderPrepayments>();
            customerOrderPayments = Database.GetRepository<CustomerOrderPayments>();
            customerOrderForWelding = Database.GetRepository<CustomerOrderForWelding>();
            bankPayments = Database.GetRepository<Bank_Payments>();
            receiptDetails = Database.GetRepository<ReceiptDetails>();
            receipt = Database.GetRepository<RECEIPTS>();
            orders = Database.GetRepository<ORDERS>();
            nomenclatures = Database.GetRepository<NOMENCLATURES>();
            units = Database.GetRepository<Units>();



            var config = new MapperConfiguration(cfg =>
              {
                  cfg.CreateMap<CustomerOrders, CustomerOrdersDTO>();
                  cfg.CreateMap<CustomerOrdersDTO, CustomerOrders>();
                  cfg.CreateMap<CustomerOrderSpecifications, CustomerOrderSpecificationsDTO>();
                  cfg.CreateMap<CustomerOrderSpecificationsDTO, CustomerOrderSpecifications>();
                  cfg.CreateMap<CustomerOrderAssemblies, CustomerOrderAssembliesDTO>();
                  cfg.CreateMap<CustomerOrderAssembliesDTO, CustomerOrderAssemblies>();
                  cfg.CreateMap<CustomerOrderForWelding, CustomerOrderForWeldingDTO>();
                  cfg.CreateMap<ContractPayments, ContractPaymentsDTO>();
                  cfg.CreateMap<CustomerOrderPrepayments, CustomerOrderPrepaymentsDTO>();
                  cfg.CreateMap<CustomerOrderPrepaymentsDTO, CustomerOrderPrepayments>();
                  cfg.CreateMap<CustomerOrderPayments, CustomerOrderPaymentsDTO>();
                  cfg.CreateMap<CustomerOrderPaymentsDTO, CustomerOrderPayments>();
                  cfg.CreateMap<CalcWithBuyers, CalcWithBuyersDTO>();
                  cfg.CreateMap<CalcWithBuyersSpec, CalcWithBuyersSpecDTO>();
                  cfg.CreateMap<ReceiptDetails, ReceiptDetailsDTO>();
                  cfg.CreateMap<RECEIPTS, ReceiptsDTO>();
                  cfg.CreateMap<ORDERS, OrdersDTO>();
                  cfg.CreateMap<Units, UnitsDTO>();
              });
            mapper = config.CreateMapper();
        }

        #region Get method's

        public IEnumerable<CustomerOrdersDTO> GetCustomerOrders()
        {
            return mapper.Map<IEnumerable<CustomerOrders>, IList<CustomerOrdersDTO>>(customerOrders.GetAll());
        }

        public bool CheckCustomerOrderEnable(int? customerOrderId)
        {
            if (customerOrderId == null)
                return false;
            return (mapper.Map<IEnumerable<CustomerOrders>, IList<CustomerOrdersDTO>>(customerOrders.GetAll()).Any(search => search.Id == customerOrderId && search.Enable == 1));
        }

        



        

        



        



        //public IEnumerable<CustomerOrdersDTO> GetCustomerOrdersShortForBusinessTrips()
        //{
        //    var result = (from co in customerOrders.GetAll()
        //                  join c in contractors.GetAll() on co.ContractorId equals c.Id into coc
        //                  from c in coc.DefaultIfEmpty()
        //                  join ag in contractors.GetAll() on co.AgreementId equals ag.Id into coag
        //                  from ag in coag.DefaultIfEmpty()
        //                  where !(co.OrderNumber.Trim() == null || co.OrderNumber.Trim() == String.Empty)
        //                  orderby co.
        //                  select new CustomerOrdersDTO
        //                  {
        //                      Id = co.Id,
        //                      OrderNumber = co.OrderNumber,
        //                      OrderDate = co.OrderDate,
        //                      OrderPrice = co.OrderPrice,
        //                      CurrencyPrice = co.CurrencyPrice,
        //                      ContractorId = co.ContractorId,
        //                      ContractorName = c.Name,
        //                      AgreementId = co.AgreementId,
        //                      AgreementName = ag.Name,
        //                      Details = co.Details,
        //                      Drawing = a.Drawing,
        //                      CurrencyId = co.CurrencyId,
        //                      CurrencyName = cu.Code,
        //                      AssemblyId = co.AssemblyId,
        //                      AssemblyName = a.Name,
        //                      DesignerName = e.LastName + " " + e.FirstName.Substring(1, 1) + "." + e.MiddleName.Substring(1, 1) + ".",
        //                      DateCreate = co.DateCreate,
        //                      DateUpdate = co.DateUpdate,
        //                      UserId = co.UserId,
        //                      UserName = eu.LastName
        //                  });

        //    return result.ToList();
        //}

       

        public IEnumerable<CustomerOrderSpecificationsDTO> GetCustomerOrderSpecificationsByOrderId(int orderId)
        {
            var result = (from s in customerOrderSpecifications.GetAll()
                          where s.CustomerOrderId == orderId
                          select new CustomerOrderSpecificationsDTO()
                          {
                              Id = s.Id,
                              CustomerOrderId = s.CustomerOrderId,
                              Name = s.Name,
                              Quantity = s.Quantity,
                              SinglePrice = s.SinglePrice,
                              SingleCurrencyPrice = s.SingleCurrencyPrice,
                              SumPrice = (s.Quantity * s.SinglePrice),
                              SumCurrencyPrice = (s.Quantity * s.SingleCurrencyPrice)
                          }
                );

            return result.ToList();
        }

        public IEnumerable<CustomerOrderSpecificationsDTO> GetCustomerOrderSpecificationsByOrderList(List<CustomerOrdersForCWBDTO> orderList)
        {
            var specSource = (from s in customerOrderSpecifications.GetAll()
                              join co in customerOrders.GetAll() on s.CustomerOrderId equals co.Id
                              select new CustomerOrderSpecificationsDTO()
                      {
                          Id = s.Id,
                          CustomerOrderId = s.CustomerOrderId,
                          CustomerOrderNumber = co.OrderNumber,
                          Name = s.Name,
                          Quantity = s.Quantity,
                          SinglePrice = s.SinglePrice,
                          SingleCurrencyPrice = s.SingleCurrencyPrice,
                          SumPrice = (s.Quantity * s.SinglePrice),
                          SumCurrencyPrice = (s.Quantity * s.SingleCurrencyPrice)
                      }).ToList();

            var result = specSource.Where(s => orderList.Any(o => o.CustomerOrderId == s.CustomerOrderId));

            return result.ToList();
        }

       

        public IEnumerable<ContractPaymentsDTO> GetContractPaymentsByPeriod(DateTime beginDate, DateTime endDate)
        {
            FbParameter[] Parameters =
                {
                    new FbParameter("BeginDate", beginDate),
                    new FbParameter("EndDate", endDate)
                };

            string procName = @"select * from ""GetContractPayments""(@BeginDate, @EndDate)";

            return mapper.Map<IEnumerable<ContractPayments>, List<ContractPaymentsDTO>>(contractPayments.SQLExecuteProc(procName, Parameters));
        }

        public IEnumerable<CustomerOrderForWeldingDTO> GetCustomerOrderForWelding(DateTime beginDate, DateTime endDate)
        {

            FbParameter[] Parameters =
                {
                    new FbParameter("BeginDate", beginDate),
                    new FbParameter("EndDate", endDate)
                };

            string procName = @"select * from ""GetCustomerOrderForWeldingProc""(@BeginDate, @EndDate)";

            return mapper.Map<IEnumerable<CustomerOrderForWelding>, List<CustomerOrderForWeldingDTO>>(customerOrderForWelding.SQLExecuteProc(procName, Parameters));
        }

        public IEnumerable<CustomerOrderPrepaymentsDTO> GetCustomerOrderPrepaymentsById(int customerOrderId)
        {
            var result = (from pr in customerOrderPrepayments.GetAll()
                          join bp in bankPayments.GetAll() on pr.BankPaymentId equals bp.Id
                          join c in contractors.GetAll() on bp.Contractor_Id equals c.Id into bpc
                          from c in bpc.DefaultIfEmpty()
                          join e in employeesDetails.GetAll() on bp.EmployeesId equals e.EmployeeID into bpe
                          from e in bpe.DefaultIfEmpty()
                          join cu in currency.GetAll() on bp.CurrencyId equals cu.Id
                          where pr.CustomerOrderId == customerOrderId
                          select new CustomerOrderPrepaymentsDTO()
                          {
                              Id = pr.Id,
                              BankPaymentId = pr.BankPaymentId,
                              CustomerOrderId = pr.CustomerOrderId,
                              Prepayment = pr.Prepayment,
                              PrepaymentCurrency = pr.PrepaymentCurrency,
                              PrepaymentVatPrice = ((bp.VatPrice ?? 0) > 0 ? Math.Round((pr.Prepayment ?? 0) / 6, 2) : 0.00m),
                              ContractorName = (bp.Contractor_Id != null)
                                                ? c.Name
                                                : e.LastName + " " + e.FirstName.Substring(1, 1).ToUpper() + "." + e.MiddleName.Substring(1, 1).ToUpper() + ".",
                              PrepaymentDate = bp.Payment_Date,
                              PrepaymentNumber = bp.Payment_Document,
                              CurrencyCode = cu.Code,
                              Selected = false
                          });

            return result.ToList();
        }

        public IEnumerable<CustomerOrderPaymentsDTO> GetCustomerOrderPaymentsById(int customerOrderId)
        {
            var result = (from p in customerOrderPayments.GetAll()
                          join bp in bankPayments.GetAll() on p.BankPaymentId equals bp.Id
                          join c in contractors.GetAll() on bp.Contractor_Id equals c.Id into bpc
                          from c in bpc.DefaultIfEmpty()
                          join e in employeesDetails.GetAll() on bp.EmployeesId equals e.EmployeeID into bpe
                          from e in bpe.DefaultIfEmpty()
                          join cu in currency.GetAll() on bp.CurrencyId equals cu.Id
                          where p.CustomerOrderId == customerOrderId
                          select new CustomerOrderPaymentsDTO()
                          {
                              Id = p.Id,
                              BankPaymentId = p.BankPaymentId,
                              CustomerOrderId = p.CustomerOrderId,
                              Payment = p.Payment,
                              PaymentCurrency = p.PaymentCurrency,
                              PaymentVatPrice = ((bp.VatPrice ?? 0) > 0 ? Math.Round((p.Payment ?? 0) / 6, 2) : 0.00m),
                              ContractorName = (bp.Contractor_Id != null)
                                                ? c.Name
                                                : e.LastName + " " + e.FirstName.Substring(1, 1).ToUpper() + "." + e.MiddleName.Substring(1, 1).ToUpper() + ".",
                              PaymentDate = bp.Payment_Date,
                              PaymentNumber = bp.Payment_Document,
                              CurrencyCode = cu.Code,
                              Selected = false
                          });

            return result.ToList();
        }

        #endregion

        #region CustomerOrders CRUD method's

        public int CustomerOrderCreate(CustomerOrdersDTO customerOrder)
        {
            var createrecord = customerOrders.Create(mapper.Map<CustomerOrders>(customerOrder));
            return (int)createrecord.Id;
        }

        public void CustomerOrderUpdate(CustomerOrdersDTO customerOrder)
        {
            var eGroup = customerOrders.GetAll().SingleOrDefault(c => c.Id == customerOrder.Id);
            customerOrders.Update((mapper.Map<CustomerOrdersDTO, CustomerOrders>(customerOrder, eGroup)));
        }

        public bool CustomerOrderDelete(int id)
        {
            try
            {
                customerOrders.Delete(customerOrders.GetAll().FirstOrDefault(c => c.Id == id));
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #endregion

        #region CustomerOrderSpecifications CRUD method's

        public int CustomerOrderSpecificationCreate(CustomerOrderSpecificationsDTO cosDTO)
        {
            var createrecord = customerOrderSpecifications.Create(mapper.Map<CustomerOrderSpecifications>(cosDTO));
            return (int)createrecord.Id;
        }

        public void CustomerOrderSpecificationCreateRange(List<CustomerOrderSpecificationsDTO> source)
        {
            customerOrderSpecifications.CreateRange(mapper.Map<List<CustomerOrderSpecificationsDTO>, IEnumerable<CustomerOrderSpecifications>>(source));
        }

        public void CustomerOrderSpecificationUpdate(CustomerOrderSpecificationsDTO cosDTO)
        {
            var eGroup = customerOrderSpecifications.GetAll().SingleOrDefault(c => c.Id == cosDTO.Id);
            customerOrderSpecifications.Update((mapper.Map<CustomerOrderSpecificationsDTO, CustomerOrderSpecifications>(cosDTO, eGroup)));
        }

        public bool CustomerOrderSpecificationDelete(int id)
        {
            try
            {
                customerOrderSpecifications.Delete(customerOrderSpecifications.GetAll().FirstOrDefault(c => c.Id == id));
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #endregion

        #region CustomerOrderAssemblies CRUD method's

        public int CustomerOrderAssemblyCreate(CustomerOrderAssembliesDTO coaDTO)
        {
            var createrecord = customerOrderAssemblies.Create(mapper.Map<CustomerOrderAssemblies>(coaDTO));
            return (int)createrecord.Id;
        }

        public void CustomerOrderAssemblyUpdate(CustomerOrderAssembliesDTO coaDTO)
        {
            var eGroup = customerOrderAssemblies.GetAll().SingleOrDefault(c => c.Id == coaDTO.Id);
            customerOrderAssemblies.Update((mapper.Map<CustomerOrderAssembliesDTO, CustomerOrderAssemblies>(coaDTO, eGroup)));
        }

        public bool CustomerOrderAssemblyDelete(int id)
        {
            try
            {
                customerOrderAssemblies.Delete(customerOrderAssemblies.GetAll().FirstOrDefault(c => c.Id == id));
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #endregion

        #region CustomerOrderPrepayments CRUD method's

        public int CustomerOrderPrepaymentCreate(CustomerOrderPrepaymentsDTO coprDTO)
        {
            var createrecord = customerOrderPrepayments.Create(mapper.Map<CustomerOrderPrepayments>(coprDTO));
            return (int)createrecord.Id;
        }

        public bool CustomerOrderPrepaymentDelete(int id)
        {
            try
            {
                customerOrderPrepayments.Delete(customerOrderPrepayments.GetAll().FirstOrDefault(c => c.Id == id));
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #endregion

        #region CustomerOrderPayments CRUD method's

        public int CustomerOrderPaymentCreate(CustomerOrderPaymentsDTO copDTO)
        {
            var createrecord = customerOrderPayments.Create(mapper.Map<CustomerOrderPayments>(copDTO));
            return (int)createrecord.Id;
        }

        public bool CustomerOrderPaymentDelete(int id)
        {
            try
            {
                customerOrderPayments.Delete(customerOrderPayments.GetAll().FirstOrDefault(c => c.Id == id));
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #endregion
    }
}
