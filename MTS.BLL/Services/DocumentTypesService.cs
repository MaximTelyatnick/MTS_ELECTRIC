﻿using System;
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
    public class DocumentTypesService: IDocumentTypesService
    {
        private IUnitOfWork Database { get; set; }
        private IRepository<DocumentTypes> documentTypes;

         private IMapper mapper;

         public DocumentTypesService(IUnitOfWork uow)
        {
            Database = uow;
            documentTypes = Database.GetRepository<DocumentTypes>();

           var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DocumentTypes, DocumentTypesDTO>();
                cfg.CreateMap<DocumentTypesDTO, DocumentTypes>();
             
            });

            mapper = config.CreateMapper();
         }

         public IEnumerable<DocumentTypesDTO> GetDocumentTypes()
         {
             return mapper.Map<IEnumerable<DocumentTypes>, List<DocumentTypesDTO>>(documentTypes.GetAll());
         }

         public DocumentTypesDTO GetDocumentTypeById(int id)
         {
             return mapper.Map<DocumentTypes, DocumentTypesDTO>(documentTypes.GetAll().SingleOrDefault(w => w.DocumentTypeId == id));
         }

         public int DocumentTypeCreate(DocumentTypesDTO documentType)
         {
             var createrecord = documentTypes.Create(mapper.Map<DocumentTypes>(documentType));
             return (int)createrecord.DocumentTypeId;
         }

         public void DocumentTypeUpdate(DocumentTypesDTO documentType)
         {
             var eGroup = documentTypes.GetAll().SingleOrDefault(c => c.DocumentTypeId == documentType.DocumentTypeId);
             documentTypes.Update((mapper.Map<DocumentTypesDTO, DocumentTypes>(documentType, eGroup)));
         }

         public bool DocumentTypeDelete(int id)
         {
             try
             {
                 documentTypes.Delete(documentTypes.GetAll().FirstOrDefault(c => c.DocumentTypeId == id));
                 return true;
             }
             catch (Exception ex)
             {
                 return false;
             }
         }

         public void Dispose()
         {
             Database.Dispose();
         }
    }
}

