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
    public class AccountService : IAccountService
    {
        private readonly IAccountRepo _AccountRepo;
        private readonly IMapper _mapper;
        public AccountService(IAccountRepo AccountRepo, IMapper mapper)
        {
            _AccountRepo = AccountRepo;
            _mapper = mapper;
        }
        public async Task<bool> CreateAccount(AccountDTO entity)
        {
            try
            {
                var mappedAccount = _mapper.Map<Account>(entity);
                var reternedEntity = await _AccountRepo.AddAsync(mappedAccount);
                return reternedEntity != null ? true : false;
            }
            catch (Exception)
            {

                return false;
            }
           
        }
        public async Task<List<AccountDTO>> ListAccount()
        {
            var Accounts = await _AccountRepo.GetAllAsyn();
            var mappedAccount = _mapper.Map<IQueryable<AccountDTO>>(Accounts);
            return await mappedAccount.ToListAsync();
        }

        public Task<AccountDTO> DeleteAccount(int Id)
        {
            throw new NotImplementedException();
        }      

        public Task<AccountDTO> UpdateAccount(int Id, AccountDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
