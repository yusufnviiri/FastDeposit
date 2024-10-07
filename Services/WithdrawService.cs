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

        public async Task<(IEnumerable<ShowSaccoTransactionDto> withdraws, MetaData metaData)> GetAllUserWithdraws(bool tracking, WithdrawParameters withdrawParameters, string Id)
        {
            var withdrawsFromDb = await _repositoryManager.WithdrawManager.GetUserWithdraws(tracking, withdrawParameters, Id);
            var withdrawDto = _mapper.Map<IEnumerable<ShowSaccoTransactionDto>>(withdrawsFromDb).OrderByDescending(k => k.Id);

            return (withdraws: withdrawDto, MetaData: withdrawsFromDb.MetaData);
        }
        public async Task<ShowSaccoTransactionDto> GetLastWithdrawTransaction()
        {
            var withdraws = await AllWithdraws(new WithdrawParameters(), tracking: false);
            return withdraws.Withdraws.FirstOrDefault();
        }
        public async Task<Withdraw> CreateWithdrawAsync(CreateSaccoTransactionDto transactionDto, string Id)
        {
            var lastWithdraw = await GetLastWithdrawTransaction();
            Withdraw withdraw = new Withdraw();
            withdraw.Amount = transactionDto.Amount;
            withdraw.UserId = Id;
            withdraw.SetBalance(lastWithdraw.Balance, "deposit");
            //var withraw4 = new Withdraw { Amount = 547100, Balance = 83900, UserId = "100" };

            _repositoryManager.WithdrawManager.CreateWithdraw(withdraw);
            await _repositoryManager.SaveAsync();
            return withdraw;
        }

    }
}
