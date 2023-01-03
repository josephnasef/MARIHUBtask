using MARIHUBtask.DTO.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MARIHUBtask.Services.Abstraction
{
    public interface IOrderDeatailsService
    {
        Task<OrderDeatailsDTO> ListOrderDeatails();
        Task<bool> CreateOrderDeatails(OrderDeatailsDTO entity);
        Task<OrderDeatailsDTO> UpdateOrderDeatails(int Id, OrderDeatailsDTO entity);
        Task<OrderDeatailsDTO> DeleteOrderDeatails(int Id);
    }
}
