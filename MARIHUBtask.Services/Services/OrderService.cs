using AutoMapper;
using MARIHUBtask.Domin.Models;
using MARIHUBtask.DTO.DTOs;
using MARIHUBtask.Repository.Abstraction;
using MARIHUBtask.Services.Abstraction;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MARIHUBtask.Services.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepo _OrderRepo;
        private readonly IMapper _mapper;
        public OrderService(IOrderRepo OrderRepo, IMapper mapper)
        {
            _OrderRepo = OrderRepo;
            _mapper = mapper;
        }
        public async Task<bool> CreateOrder(OrderDTO entity)
        {
            var AllOrder = _OrderRepo.GetAll().Where(s => s.OrderDate.Month == DateTime.Now.Month && s.applicationUser.Id == entity.ApplicationUserId);
            if (AllOrder.Any())
            {
                var totalMonthlyPrice = AllOrder.Select(s => s.TotalPrice).ToArray();
                Decimal totalPrice = 0;
                for (int i = 0; i < totalMonthlyPrice.Count(); i++)
                {
                    totalPrice += totalMonthlyPrice[i];
                }
                if (totalPrice > 5000)
                {
                    var mappedOrder = _mapper.Map<Order>(entity);
                    var Orders = await _OrderRepo.AddAsync(mappedOrder);
                    return Orders != null;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
          
        }

        public Task<OrderDTO> DeleteOrder(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<OrderDTO>> ListOrder()
        {
            var Orders = await _OrderRepo.GetAllAsyn();
            var mappedOrders = _mapper.Map<IQueryable<OrderDTO>>(Orders);
            return await mappedOrders.ToListAsync();
        }
         public async Task<List<OrderDTO>> ListOrderForUser(string UserId)
        {
            var Orders = await _OrderRepo.GetAllAsyn();
            Orders = Orders.Where(s => s.ApplicationUserId == UserId);
            var mappedOrders = _mapper.Map<IQueryable<OrderDTO>>(Orders);
            return await mappedOrders.ToListAsync();
        }

        public Task<OrderDTO> UpdateOrder(int Id, OrderDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
