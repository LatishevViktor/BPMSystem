using IdentityAPI.Entities;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace IdentityAPI.Services
{
    public interface IAccountRepository
    {
        Task<IEnumerable<Account>> GetAllAccounts();
        Task CreateAccount(Account account);

        Task<Account> GetUserByLogin(string email, string password);
    }
}
