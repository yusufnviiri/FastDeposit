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
  internal sealed class WithdrawService:IWithdrawService
    { private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _loggerManager;

        public WithdrawService(ILoggerManager logger,IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
            _loggerManager = logger;
        }
    }
}
