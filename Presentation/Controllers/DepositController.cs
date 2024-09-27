using Contracts.ServiceContracts;
using Microsoft.AspNetCore.Mvc;
using Shared.DataTransferObjects;
using Entities.ErrorModel;
using Shared.RequestParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace Presentation.Controllers
{
    [Route("api/deposits")]
    [ApiController]
    
   public class DepositController:ControllerBase
    {
        private readonly IServiceManager _service;
        private readonly IHttpContextAccessor _context = new HttpContextAccessor();
        public DepositController(IServiceManager service,IHttpContextAccessor httpContext)
        {
            _service = service;
            _context = httpContext;
        }
        [Authorize]
        [HttpGet]

        public async Task< IActionResult> GetDeposits([FromQuery] DepositParameters depositParameters)
        {
            var username = User.Identity.Name;
            var pagedResults = await _service.DepositService.GetAllDeposits(tracking: false,depositParameters);

            Response.Headers.Add("X-Pagination",JsonSerializer.Serialize(pagedResults.metaData));
            return Ok(pagedResults.deposits);
            }

        [HttpGet("{id:int}",Name ="depositId")]

        public  async Task< IActionResult> GetDeposits( [FromQuery] DepositParameters depositParameters,int id)
        { 
         var deposit =await _service.DepositService.GetDepositById(id,tracking: false);
            return Ok(deposit);
        
        }
        [Authorize]
        [HttpPost("create")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task< IActionResult> CreateDeposit( [FromBody] CreateSaccoTransactionDto transaction)
        {
            var user = _service.getUserDetails.AuthenticatedUserDetails(_context);

            var depositDto =await _service.DepositService.CreateDeposit(transaction,user.Id);
            return CreatedAtRoute("depositId", new { id = 3 }, depositDto);
        
        }

        }
}
