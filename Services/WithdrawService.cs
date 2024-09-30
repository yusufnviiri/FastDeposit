using AutoMapper;
using Contracts;
using Contracts.ServiceContracts;
using Entities.Models;
using Microsoft.CodeAnalysis;
using Repository.DbMethods;
using Shared.DataTransferObjects;
using Shared.RequestParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
  internal sealed class WithdrawService:IWithdrawService
    { private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _loggerManager;
        private readonly IMapper _mapper;

        public WithdrawService(ILoggerManager logger,IRepositoryManager repositoryManager,IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _loggerManager = logger;
            _mapper = mapper;
        }

        public async Task<(IEnumerable<ShowSaccoTransactionDto> Withdraws, MetaData Data)>AllWithdraws(WithdrawParameters withdrawParameters,bool tracking)
        {
            var withdrawsWithMetaData= await _repositoryManager.WithdrawManager.GetAllWithdraws(tracking, withdrawParameters);
            var result = _mapper.Map<IEnumerable<ShowSaccoTransactionDto>>(withdrawsWithMetaData);

            return (Withdraws:result, Data: withdrawsWithMetaData.MetaData);

        }
        public async Task CreateWithdrawAsync(CreateSaccoTransactionDto transactionDto)
        {
            var lastWithdraw = await _repositoryManager.WithdrawManager.GetLastWithdraw();
            Withdraw withdraw = new Withdraw()
            {
                Amount = transactionDto.Amount,
            };
            withdraw.SetBalance((decimal)lastWithdraw.Balance,"withdraw");

            _repositoryManager.WithdrawManager.CreateWithdraw(withdraw);
            await _repositoryManager.SaveAsync();
        }

    }
}
