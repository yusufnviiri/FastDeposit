using Contracts.ServiceContracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace Services
{
    public sealed class GetUserDetails:IGetUserDetails
    {
        private IHttpContextAccessor _context { get; set; }

        public User AuthenticatedUserDetails(IHttpContextAccessor httpContext)
        { 

            _context = httpContext;
            var User = _context.HttpContext.User;        
            var userId =User.FindFirst(ClaimTypes.Actor)?.Value; // The user ID from the token
            var userEmail =User.FindFirst(ClaimTypes.Name)?.Value;        // Email claim
            var role = User.FindFirst(ClaimTypes.Role)?.Value;             // Role claim if available
            var user = new User { Id = userId, Email = userEmail,FirstName=role };

            return user;
           
        }
    }
}
