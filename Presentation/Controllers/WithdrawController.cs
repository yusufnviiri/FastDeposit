using Contracts.ServiceContracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
        public WithdrawController(IServiceManager serviceManager) { 
        _service = serviceManager;
        }
        [HttpGet]
        public async Task<ActionResult> GetWithdraws([FromQuery] WithdrawParameters parameters)
        {
            var pagedResults = await _service.WithdrawService.AllWithdraws(parameters, tracking: false);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResults.Data));

            return Ok(pagedResults.Withdraws);
        }
    }
}
