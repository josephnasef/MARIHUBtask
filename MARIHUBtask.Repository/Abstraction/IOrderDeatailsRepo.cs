using MARIHUBtask.Domin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MARIHUBtask.Repository.Abstraction
{
    public interface IOrderDeatailsRepo
    {
        Task<OrderDeatails> AddAsync(OrderDeatails entity);
        Task<OrderDeatails> GetByAsync(params object[] Id);
        IEnumerable<OrderDeatails> GetAll();
        Task<IEnumerable<OrderDeatails>> GetAllAsyn();
        OrderDeatails Update(OrderDeatails entity);
        Task<OrderDeatails> UpdateAsync(OrderDeatails entity);
        OrderDeatails Remove(OrderDeatails entity);
        Task<OrderDeatails> RemoveByIdAsync(params object[] Id);
        OrderDeatails RemoveById(params object[] Id);
    }
}
