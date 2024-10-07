using Entities.BaseModels;
using Microsoft.AspNetCore.Identity;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.ServiceContracts
{
   public interface IAuthenticationService
    {
        //Task<IdentityResult>RegisterUser(UserRegistrationDto userRegistrationDto);
        Task<IdentityResult> RegisterUser(UserRegistrationDto userRegistrationDto);

        Task<LoggedInUser> LoginUser(UserLoginDto userLoginDto);
        Task<string> CreateToken();

    }
}
