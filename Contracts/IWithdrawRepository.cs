using Entities.Models;
using Shared.DataTransferObjects;
using Shared.RequestParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
   public interface IWithdrawRepository
    {
        Task<PagedList<Withdraw>> GetAllWithdraws(bool tracking,WithdrawParameters withdrawParameters);
        void CreateWithdraw(Withdraw transactionDto);
        Task<Withdraw> GetLastWithdraw();
    }
}
