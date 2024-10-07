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
using NLog.Targets;

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
        [HttpGet]
        [Authorize]
        public async Task< IActionResult> GetDeposits([FromQuery] DepositParameters depositParameters)
        {          
            var username = User.Identity.Name;
            var pagedResults = await _service.DepositService.GetAllDeposits(tracking: false,depositParameters);
            Console.WriteLine(username);
            Response.Headers.Add("X-Pagination",JsonSerializer.Serialize(pagedResults.metaData));
            return Ok(pagedResults.deposits);
            }
        [HttpGet("userDeposits")]
        [Authorize]
        public async Task<IActionResult> GetUserDeposits([FromQuery] DepositParameters depositParameters)
        {
            var user = _service.getUserDetails.AuthenticatedUserDetails(_context);

            var pagedResults = await _service.DepositService.GetAllUserDeposits(tracking: false, depositParameters,user.Id);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResults.metaData));
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
            //return CreatedAtRoute("depositId", new { id = depositDto.Id }, depositDto);
            if (depositDto is null)
            {
                return BadRequest("Data invalid");
            }
            return Ok();


        }
        [Authorize]

        [HttpPost("fetchExceldata")]
public async Task<IActionResult> CreateDepositFromExcelData()
        {
            await _service.DepositService.CreateDepositFromExcelData();
            return Ok();
        }

        [HttpPost("uploadFile")]
        public async Task<IActionResult> UploadExcelFile(IFormFile file)
        {
           if(file is  null|| file.Length < 1)
            {
                return BadRequest("No file Uploaded");
            }

           var path = Path.Combine(Directory.GetCurrentDirectory(),"Uploads",file.FileName);
            Directory.CreateDirectory(Path.GetDirectoryName(path));
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return Ok( new {FilePath=path});

        }
    }
}
