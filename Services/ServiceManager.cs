using AutoMapper;
using Contracts;
using Contracts.ServiceContracts;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
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
        private readonly Lazy<IAuthenticationService> _authenticationService;
        public readonly Lazy<IGetUserDetails> _userDetailsService;
        public ServiceManager(ILoggerManager logger,IRepositoryManager repositoryManager,IMapper mapper, UserManager<User> userManager,
IConfiguration configuration)    {
            _withdrawService = new Lazy<IWithdrawService>(() => new WithdrawService(logger, repositoryManager,mapper));
            _depositService = new Lazy<IDepositService>(() => new DepositService(logger,repositoryManager,mapper,userManager));
            _authenticationService = new Lazy<IAuthenticationService>(() => new AuthenticationService(logger,mapper,userManager,configuration));
            _userDetailsService = new Lazy<IGetUserDetails>(() => new GetUserDetails());
        }
        public IWithdrawService WithdrawService => _withdrawService.Value;
        public IDepositService DepositService => _depositService.Value;
        public IAuthenticationService AuthenticationService => _authenticationService.Value;
        public IGetUserDetails getUserDetails => _userDetailsService.Value;
    }
}
