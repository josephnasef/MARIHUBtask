using MARIHUBtask.DTO.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MARIHUBtask.Services.Abstraction
{
   public interface IOrderService
    {
        Task<List<OrderDTO>> ListOrder();
        Task<List<OrderDTO>> ListOrderForUser(string UserId);
        Task<bool> CreateOrder(OrderDTO entity);
        Task<OrderDTO> UpdateOrder(int Id, OrderDTO entity);
        Task<OrderDTO> DeleteOrder(int Id);
    }
}
