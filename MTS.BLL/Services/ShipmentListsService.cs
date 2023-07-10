﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Internal;
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
    public class ShipmentListsService : IShipmentListsService
    {
        private IUnitOfWork Database { get; set; }
        private IRepository<ShipmentLists> shipmentLists;
        private IRepository<CustomerOrders> customerOrders;
        private IRepository<DocumentTypes> documentTypes;
        private IMapper mapper;

        public ShipmentListsService(IUnitOfWork uow)
        {
            Database = uow;
            shipmentLists = Database.GetRepository<ShipmentLists>();
            customerOrders = Database.GetRepository<CustomerOrders>();
            documentTypes = Database.GetRepository<DocumentTypes>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ShipmentLists, ShipmentListsDTO>();
                cfg.CreateMap<ShipmentListsDTO, ShipmentLists>();
                cfg.CreateMap<CustomerOrders, CustomerOrdersDTO>();
                cfg.CreateMap<DocumentTypes, DocumentTypesDTO>();

            });

            mapper = config.CreateMapper();
        }

        public IEnumerable<ShipmentListsDTO> GetShipmentLists(DateTime beginDate, DateTime endDate)
        {

            var result = (from o in shipmentLists.GetAll()
                          join c in customerOrders.GetAll() on o.CustomerOrderId equals c.Id into pc
                          from c in pc.DefaultIfEmpty()
                          join t in documentTypes.GetAll() on o.DocumentTypeId equals t.DocumentTypeId into tc
                          from t in tc.DefaultIfEmpty()
                          where (o.ShipmentDate >= beginDate && o.ShipmentDate <= endDate)
                          select new ShipmentListsDTO
                          {
                              ShipmentNumber = o.ShipmentNumber,
                              ShipmentDate = o.ShipmentDate,
                              ShipmentListId =o.ShipmentListId,
                              CustomerOrderId = o.CustomerOrderId,
                              Description = o.Description,
                              ShipmentScan = o.ShipmentScan,
                              FileName = o.FileName,
                              DocumentTypeId = t.DocumentTypeId,
                              DocumentTypeName= t.DocumentTypeName,
                              OrderNumber = c.OrderNumber,
                              OrderDate = c.OrderDate

                          }).ToList();

            return result.Select(s => { s.ScanPersence = (s.ShipmentScan.Length > 0 ? 1 : 0); return s; }).ToList();
        }

        #region ReceiptCertificates CRUD method`s

        public int CreateShipmentList(ShipmentListsDTO dtomodel)
        {
            var record = shipmentLists.Create(mapper.Map<ShipmentLists>(dtomodel));
            return record.ShipmentListId;
        }


        public void UpdateShipmentList(ShipmentListsDTO dtomodel)
        {
            var entity = shipmentLists.GetAll().SingleOrDefault(c => c.ShipmentListId == dtomodel.ShipmentListId);
            shipmentLists.Update(mapper.Map<ShipmentListsDTO, ShipmentLists>(dtomodel, entity));
        }


        public bool RemoveShipmentListById(long id)
        {
            try
            {
                var delEntity = shipmentLists.GetAll().SingleOrDefault(c => c.ShipmentListId == id);
                shipmentLists.Delete(delEntity);
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #endregion

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
