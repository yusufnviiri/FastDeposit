using Contracts;
using Contracts.ServiceContracts;
using Repository.DbMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;
using Shared.DataTransferObjects;
using AutoMapper;
using Entities.Exceptions;

namespace Services
{
    internal sealed class DepositService : IDepositService
    {
        private readonly IRepositoryManager _repo;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;


        public DepositService(ILoggerManager logger, IRepositoryManager repositoryManager,IMapper mapper)
        {
            _repo = repositoryManager;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ShowSaccoTransactionDto>> GetAllDeposits(bool tracking)
        {            
            var deposits = await _repo.DepositManager.GetAllDeposits(tracking);
                var result = _mapper.Map<IEnumerable<ShowSaccoTransactionDto>>(deposits);
           
                return result;           
        }

        //public async Task<ShowSaccoTransactionDto> GetDepositById(int Id, bool tracking) { 
        //var deposit = await _repo.DepositManager.FindDepositById(Id, tracking);
        //    if (deposit == null) { throw new DepositNotFoundException(Id); }
        //    var depositDto =_mapper.Map<ShowSaccoTransactionDto>(deposit);
        //    return depositDto;

        //}
        public async Task< ShowSaccoTransactionDto> GetDepositById(int Id, bool tracking)
        {
            var deposit =  await _repo.DepositManager.FindDepositById(Id, tracking);
            if (deposit == null) { throw new DepositNotFoundException(Id); }
            var depositDto = _mapper.Map<ShowSaccoTransactionDto>(deposit);
            return depositDto;

        }
        public async Task<ShowSaccoTransactionDto> CreateDeposit(CreateSaccoTransactionDto tranaction)
        {
            var deposit = new Deposit();
            deposit.Amount= tranaction.Amount;
            //deposit.SetBalance(7000, "deposit");
            _repo.DepositManager.CreateDeposit(deposit);

            await _repo.SaveAsync();
            var depositDto = _mapper.Map<ShowSaccoTransactionDto>(deposit);
            return depositDto;
        }
    }
}
