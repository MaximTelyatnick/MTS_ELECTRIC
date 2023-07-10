using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MTS.DAL.Entities.QueryModels
{
    public class FixedAssetsReportRegisterCh1
    {
        [Key]
        public int Id { get; set; }
        public decimal CurrentAmortizationForPeriod { get; set; }
        public string FamNum { get; set; }
        public int RecId { get; set; }
    }
}
