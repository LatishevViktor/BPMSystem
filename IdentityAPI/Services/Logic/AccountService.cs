using IdentityAPI.Entities;
using IdentityAPI.Enums;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityAPI.Services.Logic
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public async Task CreateAccount(Account account)
        {
            await _accountRepository.CreateAccount(account);
        }

        public async Task<IEnumerable<Account>> GetAllAccounts()
        {
            return await _accountRepository.GetAllAccounts();
        }

        public async Task<Account> GetUserByLogin(string email, string password)
        {
            var user = await _accountRepository.GetUserByLogin(email, password);
            user.Role = new Roles[] { (Roles)user.RoleId };
            return user;    
        }
    }
}
