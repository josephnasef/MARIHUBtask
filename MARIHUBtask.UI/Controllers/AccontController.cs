using MARIHUBtask.DTO.DTOs;
using MARIHUBtask.Services.Abstraction;
using MARIHUBtask.Services.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MARIHUBtask.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccontController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccontController(IAccountService accountService)
        {
            _accountService = accountService;
        }
       
        [HttpGet("GetAll")]
        [Authorize("First")]
        public async Task< IEnumerable<AccountDTO>> Get()
        {
            return await _accountService.ListAccount();
        }

        [HttpPost("Create")]
        [Authorize("First")]
        public Task<bool> Post([FromBody] AccountDTO accountDTO)
        {
            return _accountService.CreateAccount(accountDTO);
        }
    }
}
