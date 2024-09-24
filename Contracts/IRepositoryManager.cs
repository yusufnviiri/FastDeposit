using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryManager
    { IWithdrawRepository WithdrawManager { get; }
        IDepositRepository DepositManager { get; }
        void Save();
    }
}
