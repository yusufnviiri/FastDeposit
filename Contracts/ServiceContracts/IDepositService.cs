using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.DataTransferObjects;
using Shared.RequestParameters;

namespace Contracts.ServiceContracts
{
   public interface IDepositService
    {
        Task<IEnumerable<ShowSaccoTransactionDto>> GetAllDeposits(bool tracking, DepositParameters depositParameters);
        //Task<ShowSaccoTransactionDto> GetDepositById(int Id,bool tracking);
        Task<ShowSaccoTransactionDto> GetDepositById(int Id, bool tracking);

        Task<ShowSaccoTransactionDto> CreateDeposit(CreateSaccoTransactionDto transaction);
    }
}
