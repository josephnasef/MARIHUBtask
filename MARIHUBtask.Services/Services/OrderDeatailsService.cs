using AutoMapper;
using MARIHUBtask.DTO.DTOs;
using MARIHUBtask.Repository.Abstraction;
using MARIHUBtask.Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MARIHUBtask.Services.Services
{
    public class OrderDeatailsService : IOrderDeatailsService
    {
        private readonly IOrderDeatailsRepo _OrderDeatailsRepo;
        private readonly IMapper _mapper;
        public OrderDeatailsService(IOrderDeatailsRepo OrderDeatailsRepo, IMapper mapper)
        {
            _OrderDeatailsRepo = OrderDeatailsRepo;
            _mapper = mapper;
        }
        public Task<bool> CreateOrderDeatails(OrderDeatailsDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<OrderDeatailsDTO> DeleteOrderDeatails(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<OrderDeatailsDTO> ListOrderDeatails()
        {
            throw new NotImplementedException();
        }

        public Task<OrderDeatailsDTO> UpdateOrderDeatails(int Id, OrderDeatailsDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
