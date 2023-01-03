using MARIHUBtask.Domin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MARIHUBtask.Repository.Abstraction
{
    public interface IApplicationUserRepo
    {
        Task<ApplicationUser> AddAsync(ApplicationUser entity);
        Task<ApplicationUser> GetByAsync(params object[] Id);
        IEnumerable<ApplicationUser> GetAll();
        Task<IEnumerable<ApplicationUser>> GetAllAsyn();
        ApplicationUser Update(ApplicationUser entity);
        ApplicationUser Remove(ApplicationUser entity);
        Task<ApplicationUser> RemoveByIdAsync(params object[] Id);
        Task<ApplicationUser> UpdateAsync(ApplicationUser entity);
        ApplicationUser RemoveById(params object[] Id);
    }
}
