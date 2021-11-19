using IdentityAPI.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityAPI.Services.Logic
{
    public interface IAccountService
    {
        //Task<Account> GetAccountById(int id);
        Task<IEnumerable<Account>> GetAllAccounts();
        Task CreateAccount(Account account);
        Task<Account> GetUserByLogin(string email, string password);
    }
}
