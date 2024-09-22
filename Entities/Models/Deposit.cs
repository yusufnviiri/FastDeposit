using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.BaseModels;

namespace Entities.Models
{
    public class Deposit:SaccoTransaction
    {
        //[Column(TypeName = "nvarchar(450)")]
        //public string? DepositId { get; set; }
        public int DepositId { get; set; }
    }
}
