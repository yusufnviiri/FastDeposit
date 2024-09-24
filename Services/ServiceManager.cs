using AutoMapper;
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
  public sealed class ServiceManager:IServiceManager
    {
      
        private readonly Lazy<IWithdrawService> _withdrawService;
        private readonly Lazy<IDepositService> _depositService;
        public ServiceManager(ILoggerManager logger,IRepositoryManager repositoryManager,IMapper mapper)
        {
            _withdrawService = new Lazy<IWithdrawService>(() => new WithdrawService(logger, repositoryManager,mapper));
            _depositService = new Lazy<IDepositService>(() => new DepositService(logger,repositoryManager,mapper));
        }
        public IWithdrawService WithdrawService => _withdrawService.Value;
        public IDepositService DepositService => _depositService.Value;
    }
}
