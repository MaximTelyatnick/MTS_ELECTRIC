using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTS.DAL.Entities.QueryModels
{
    public class LastIdInvoicesReqGen
    {
        [Key]
        public int RecId { get; set; }
        public int GenId { get; set; }
    }
}
