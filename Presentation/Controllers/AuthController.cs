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

        public AuthController(IServiceManager service)
        {
            _service = service;
        }
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] UserRegistrationDto user)
        {
            if (user == null || !ModelState.IsValid)
                return BadRequest();
            var res = await _service.AuthenticationService.RegisterUser(user);

            var username = User.Identity.Name;
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // The user's ID
            var userEmail = User.FindFirstValue(ClaimTypes.Email);        // The user's email
            var userName = User.FindFirstValue(ClaimTypes.Name);          // The user's username


            return Ok(res);


        }
        [HttpPost("login")]
        public async Task<IActionResult> LoginUser([FromBody] UserLoginDto user)
        {
            //if (user == null || !ModelState.IsValid)
            //    return BadRequest();
            //var res = await _service.AuthenticationService.LoginUser(user);
            //return Ok(res);

            var auth = await _service.AuthenticationService.LoginUser(user);
            if (!auth) { 
            return Unauthorized(); }
        else{
                return Ok(new
                {
                    Token = await _service.AuthenticationService.CreateToken()
                });
            };



        }
    }
}
