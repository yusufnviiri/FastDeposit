using Contracts.ServiceContracts;
using Microsoft.AspNetCore.Mvc;
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
            try
            {
                var deposits = _service.DepositService.GetAllDeposits(tracking: false);
                return Ok(deposits);
            }
            catch 
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
