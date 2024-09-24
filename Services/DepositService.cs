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

        public IEnumerable<ShowSaccoTransactionDto> GetAllDeposits(bool tracking)
        {
            

            var deposits = _repo.DepositManager.GetAllDeposits(tracking);
                var result = _mapper.Map<IEnumerable<ShowSaccoTransactionDto>>(deposits);
                return result;
           
        }
    }
}
