using Contracts.ServiceContracts;
using Microsoft.AspNetCore.Mvc;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IServiceManager _service;


        [HttpPost("register")]
        public async Task< IActionResult> RegisterUser([FromBody] UserRegistrationDto user)
        {
            if (user == null || !ModelState.IsValid)
                return BadRequest();
            var res = await _service.AuthenticationService.RegisterUser(user); 

            return Ok(res);
            
      
        }
    }
}
