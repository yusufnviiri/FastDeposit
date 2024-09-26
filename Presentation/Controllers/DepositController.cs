using Contracts.ServiceContracts;
using Microsoft.AspNetCore.Mvc;
using Shared.DataTransferObjects;
using Entities.ErrorModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Presentation.Controllers
{
    [Route("api/deposits")]
    [ApiController]
    
   public class DepositController:ControllerBase
    {
        private readonly IServiceManager _service;
        public DepositController(IServiceManager service)
        {
            _service = service;
        }
        [Authorize]
        [HttpGet]

        public async Task< IActionResult> GetDeposits() {          
            var deposits = await _service.DepositService.GetAllDeposits(tracking: false);
                return Ok(deposits);
            }

        [HttpGet("{id:int}",Name ="depositId")]

        public  async Task< IActionResult> GetDeposits(int id)
        { 
         var deposit =await _service.DepositService.GetDepositById(id,tracking: false);
            return Ok(deposit);
        
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]


        public async Task< IActionResult> CreateDeposit( [FromBody] CreateSaccoTransactionDto transaction)
        {
           var depositDto =await _service.DepositService.CreateDeposit(transaction);
            return CreatedAtRoute("depositId", new { id = 2 }, depositDto);
        
        }

        }
}
