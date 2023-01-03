using AutoMapper;
using MARIHUBtask.Domin.Models;
using MARIHUBtask.DTO.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MARIHUBtask.DTO.MappingConfigurations
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<Account, AccountDTO>()
                .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.ID))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))               
                .ReverseMap();            
            CreateMap<ApplicationUser, ApplicationUserDTO>()
                  .ForMember(dest => dest.AccountID, opt => opt.MapFrom(src => src.AccountID)).ReverseMap();   
            CreateMap<OrderDeatails, OrderDeatailsDTO>()
                  .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.OrderID)).ReverseMap();
            CreateMap<Order, OrderDTO>()
                .ForMember(dest => dest.ApplicationUserId, opt => opt.MapFrom(src => src.applicationUser.Id))
                .ForMember(dest => dest.AccountId, opt => opt.MapFrom(src => src.AccountID)).ReverseMap();
        }

    }
}
