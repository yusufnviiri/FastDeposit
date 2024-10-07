using Contracts.ServiceContracts;
using Entities.ErrorModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Shared.DataTransferObjects;
using Shared.RequestParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/withdraws")]
  public class WithdrawController: ControllerBase
    {
        private readonly IServiceManager _service;
        private readonly IHttpContextAccessor _context = new HttpContextAccessor();
        public WithdrawController(IServiceManager serviceManager,IHttpContextAccessor accessor) { 
        _service = serviceManager;
            _context = accessor;
        }
        [HttpGet]
        [Authorize]
        public async Task<ActionResult> GetWithdraws([FromQuery] WithdrawParameters parameters)
        {
            var pagedResults = await _service.WithdrawService.AllWithdraws(parameters, tracking: false);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResults.Data));

            return Ok(pagedResults.Withdraws);
        }
        [HttpGet("userWithdraws")]
        [Authorize]
        public async Task<IActionResult> GetUserDeposits([FromQuery] WithdrawParameters withdrawParameters)
        {
            var user = _service.getUserDetails.AuthenticatedUserDetails(_context);

            var pagedResults = await _service.WithdrawService.GetAllUserWithdraws(tracking: false, withdrawParameters, user.Id);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResults.metaData));
            return Ok(pagedResults.withdraws);
        }
        [Authorize]

        [HttpPost("create")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]

        public async Task<IActionResult> CreateWithdraw([FromBody] CreateSaccoTransactionDto createWithdraw)
        {
            var user = _service.getUserDetails.AuthenticatedUserDetails(_context);

            await _service.WithdrawService.CreateWithdrawAsync(createWithdraw,user.Id);
            
            return Ok();
        }
    }
}
