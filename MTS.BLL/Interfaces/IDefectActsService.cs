using System.Collections.Generic;
using MTS.BLL.DTO.ModelsDTO;
using MTS.BLL.DTO.SelectedDTO;
using System;

namespace MTS.BLL.Interfaces
{
   public interface IDefectActsService
    {
       IEnumerable<DefectActRepliesDTO> GetDefectActReplies(int id);
       
       int CreateDefectAct(DefectActsDTO dtomodel);
       void UpdateDefectAct(DefectActsDTO dtomodel);
       bool RemoveDefectActById(long id);
       
       int CreateDefectActReplie(DefectActRepliesDTO dtomodel);
       void UpdateDefectActReplie(DefectActRepliesDTO dtomodel);
       bool RemoveDefectActReplieById(long id);
       
       void Dispose();
    }
}
