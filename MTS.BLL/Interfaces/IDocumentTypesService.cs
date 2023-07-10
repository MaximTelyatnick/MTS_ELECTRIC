using System.Collections.Generic;
using MTS.BLL.DTO.ModelsDTO;
using MTS.BLL.DTO.SelectedDTO;
using System;

namespace MTS.BLL.Interfaces
{
    public interface IDocumentTypesService
    {
        IEnumerable<DocumentTypesDTO> GetDocumentTypes();
        DocumentTypesDTO GetDocumentTypeById(int id);

        int DocumentTypeCreate(DocumentTypesDTO documentType);
        void DocumentTypeUpdate(DocumentTypesDTO documentType);
        bool DocumentTypeDelete(int id);
        
        void Dispose();

    }
}
