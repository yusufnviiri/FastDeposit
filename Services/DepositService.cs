using Contracts;
using Contracts.ServiceContracts;
using Repository.DbMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace Services
{
    internal sealed class DepositService : IDepositService
    {
        private readonly IRepositoryManager _repo;
        private readonly ILoggerManager _logger;

        public DepositService(ILoggerManager logger, IRepositoryManager repositoryManager)
        {
            _repo = repositoryManager;
            _logger = logger;
        }

        public IEnumerable<Deposit> GetAllDeposits(bool tracking)
        {
            try
            {
                var deposits = _repo.DepositManager.GetAllDeposits(tracking);
                return deposits;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in method {nameof(GetAllDeposits)} {ex}");
                throw;
            }
        }
    }
}
