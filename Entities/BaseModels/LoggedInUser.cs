using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.BaseModels
{
   public sealed class LoggedInUser
    {
        public User User { get; set; }
        public bool IsAuthenticated { get; set; }
    }
}
