using Entities.BaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Entities.Models
{
   public class Withdraw:SaccoTransaction
    {
        //[Column(TypeName = "nvarchar(450)")]

        //public string? WithdrawId { get; set; }
        [Column("WithdrawId")]

        public int Id{ get; set; }



    }
}
