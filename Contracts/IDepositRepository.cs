using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;
using Shared.RequestParameters;

namespace Contracts
{
    public interface IDepositRepository
    {
       Task<IEnumerable<Deposit>> GetAllDeposits(bool tracking, DepositParameters depositParameters);
        Task<Deposit> FindDepositById( int id,bool tracking);
        void CreateDeposit(Deposit deposit);
    }
}
