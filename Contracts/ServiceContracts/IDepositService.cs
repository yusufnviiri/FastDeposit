using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.DataTransferObjects;

namespace Contracts.ServiceContracts
{
   public interface IDepositService
    {
        Task<IEnumerable<ShowSaccoTransactionDto>> GetAllDeposits(bool tracking);
        Task<ShowSaccoTransactionDto> GetDepositById(int Id,bool tracking);
    }
}
