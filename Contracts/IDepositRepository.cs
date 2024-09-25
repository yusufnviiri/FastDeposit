using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace Contracts
{
    public interface IDepositRepository
    {
       Task<IEnumerable<Deposit>> GetAllDeposits(bool tracking);
        Task<Deposit> FindDepositById(int id,bool tracking);
    }
}
