using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
  public sealed class DepositNotFoundException:NotFoundException
    {
        public DepositNotFoundException( int DepositId):base($"The deposit with Id: {DepositId} doesn't exist in database!!")
        {
            
        }
    }
}
