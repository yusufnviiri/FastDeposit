using Contracts.ServiceContracts;
using Microsoft.AspNetCore.Mvc;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        [HttpGet]

        public IActionResult GetDeposits() {          
            var deposits = _service.DepositService.GetAllDeposits(tracking: false);
                return Ok(deposits);
            }

        [HttpGet("{id:int}",Name ="depositId")]

        public IActionResult GetDeposits(int id)
        { 
         var deposit = _service.DepositService.GetDepositById(id,tracking: false);
            return Ok(deposit);
        
        }

        [HttpPost]

        public async Task< IActionResult> CreateDeposit(CreateSaccoTransactionDto transaction)
        {
           var depositDto =await _service.DepositService.CreateDeposit(transaction);
            return CreatedAtRoute("depositId", new { id = depositDto.Id }, depositDto);
        
        }

        }
}
