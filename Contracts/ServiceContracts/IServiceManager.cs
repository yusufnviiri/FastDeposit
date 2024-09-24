using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.ServiceContracts
{
   public interface IServiceManager
    {
        IWithdrawService WithdrawService { get; }
        IDepositService DepositService { get; }
    }
}
