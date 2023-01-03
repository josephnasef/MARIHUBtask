using MARIHUBtask.DTO.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MARIHUBtask.Services.Abstraction
{
    public interface IAccountService
    {
        Task<List<AccountDTO>> ListAccount();
        Task<bool> CreateAccount(AccountDTO entity);
        Task<AccountDTO> UpdateAccount(int Id, AccountDTO entity);
        Task<AccountDTO> DeleteAccount(int Id);
    }
}
