using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.BaseModels
{
  public class DataFromExcelFile
    {
        public string? Name {  get; set; }
        public string? UserId { get; set; }
        public string? Amount { get; set; }
        public string? PhoneNumber { get; set; }
        public string? DateCreated { get; set; }    
    }
}
