using MARIHUBtask.DTO.DTOs;
using MARIHUBtask.Services.Abstraction;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MARIHUBtask.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _OrderMangement;
        public OrdersController(IOrderService userMangement)
        {
            _OrderMangement = userMangement;
        }
        [HttpGet("GetAll")]
        public async Task<IEnumerable<OrderDTO>> GetAllForUser(string UserId)
        {
            var result = await _OrderMangement.ListOrderForUser(UserId);
            return result;
        }

        [HttpPost("Create")]
        public Task<bool> Post([FromBody] OrderDTO value)
        {
            var result = _OrderMangement.CreateOrder(value);
            return result;
        }
       
    }
}
