using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;
using Microsoft.AspNetCore.Http;

namespace Contracts.ServiceContracts
{
    public interface IGetUserDetails
    {
        User AuthenticatedUserDetails(IHttpContextAccessor httpContext);
    }
}
