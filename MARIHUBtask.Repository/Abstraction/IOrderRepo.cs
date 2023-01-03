using MARIHUBtask.Domin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MARIHUBtask.Repository.Abstraction
{
    public interface IOrderRepo
    {
        Task<Order> AddAsync(Order entity);
        Task<Order> GetByAsync(params object[] Id);
        IEnumerable<Order> GetAll();
        Task<IEnumerable<Order>> GetAllAsyn();
        Order Update(Order entity);
        Task<Order> UpdateAsync(Order entity);
        Order Remove(Order entity);
        Task<Order> RemoveByIdAsync(params object[] Id);
        Order RemoveById(params object[] Id);
    }
}
