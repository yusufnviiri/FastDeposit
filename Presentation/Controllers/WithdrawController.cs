using Contracts.ServiceContracts;
using Entities.ErrorModel;
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
        public async Task<ActionResult> GetWithdraws([FromQuery] WithdrawParameters parameters)
        {
            var pagedResults = await _service.WithdrawService.AllWithdraws(parameters, tracking: false);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResults.Data));

            return Ok(pagedResults.Withdraws);
        }
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
