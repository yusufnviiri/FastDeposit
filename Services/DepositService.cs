using Contracts;
using Contracts.ServiceContracts;
using Repository.DbMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    internal sealed class DepositService:IDepositService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _loggerManager;

        public DepositService(ILoggerManager logger, RepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
            _loggerManager = logger;
        }
    }
}
