using Entities.Models;
using Shared.DataTransferObjects;
using Shared.RequestParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.ServiceContracts
{
   public interface IWithdrawService
    {
        Task<(IEnumerable<ShowSaccoTransactionDto> Withdraws,MetaData Data)> AllWithdraws(WithdrawParameters withdrawParameters,bool tracking);
        Task<(IEnumerable<ShowSaccoTransactionDto> withdraws, MetaData metaData)> GetAllUserWithdraws(bool tracking, WithdrawParameters withdrawParameters, string Id);
        Task <Withdraw> CreateWithdrawAsync(CreateSaccoTransactionDto transactionDto,string id);
    }
}
