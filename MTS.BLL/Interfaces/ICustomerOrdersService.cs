using System.Collections.Generic;
using MTS.BLL.DTO.ModelsDTO;
using MTS.BLL.DTO.SelectedDTO;
using System;

namespace MTS.BLL.Interfaces
{
     public interface ICustomerOrdersService
    {

         bool CheckCustomerOrderEnable(int? customerOrderId);



         IEnumerable<CustomerOrderSpecificationsDTO> GetCustomerOrderSpecificationsByOrderId(int orderId);
         IEnumerable<CustomerOrderSpecificationsDTO> GetCustomerOrderSpecificationsByOrderList(List<CustomerOrdersForCWBDTO> orderList);

         IEnumerable<ContractPaymentsDTO> GetContractPaymentsByPeriod(DateTime beginDate, DateTime endDate);
         IEnumerable<CustomerOrderPrepaymentsDTO> GetCustomerOrderPrepaymentsById(int customerOrderId);
         IEnumerable<CustomerOrderPaymentsDTO> GetCustomerOrderPaymentsById(int customerOrderId);
         IEnumerable<CustomerOrderForWeldingDTO> GetCustomerOrderForWelding(DateTime beginDate, DateTime endDate);

         

         int CustomerOrderCreate(CustomerOrdersDTO customerOrder);
         void CustomerOrderUpdate(CustomerOrdersDTO customerOrder);
         bool CustomerOrderDelete(int id);

         int CustomerOrderSpecificationCreate(CustomerOrderSpecificationsDTO cosDTO);
         void CustomerOrderSpecificationCreateRange(List<CustomerOrderSpecificationsDTO> source);
         void CustomerOrderSpecificationUpdate(CustomerOrderSpecificationsDTO cosDTO);
         bool CustomerOrderSpecificationDelete(int id);

         int CustomerOrderAssemblyCreate(CustomerOrderAssembliesDTO coaDTO);
         void CustomerOrderAssemblyUpdate(CustomerOrderAssembliesDTO coaDTO);
         bool CustomerOrderAssemblyDelete(int id);

         int CustomerOrderPrepaymentCreate(CustomerOrderPrepaymentsDTO coprDTO);
         bool CustomerOrderPrepaymentDelete(int id);

         int CustomerOrderPaymentCreate(CustomerOrderPaymentsDTO copDTO);
         bool CustomerOrderPaymentDelete(int id);
    }
}
