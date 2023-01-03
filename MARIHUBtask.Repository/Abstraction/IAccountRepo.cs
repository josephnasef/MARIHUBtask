using MARIHUBtask.Domin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MARIHUBtask.Repository.Abstraction
{
    public interface IAccountRepo
    {
        Task<Account> AddAsync(Account entity);
        Task<Account> GetByAsync(params object[] Id);
        IEnumerable<Account> GetAll();
        Task<IEnumerable<Account>> GetAllAsyn();
        Account Update(Account entity);
        Task<Account> UpdateAsync(Account entity);
        Account Remove(Account entity);
        Task<Account> RemoveByIdAsync(params object[] Id);      
        Account RemoveById(params object[] Id);
    }
}
