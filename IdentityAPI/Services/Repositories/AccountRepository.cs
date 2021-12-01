using IdentityAPI.EF;
using IdentityAPI.Entities;
using IdentityAPI.Enums;

using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace IdentityAPI.Services
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AuthContext _authContext;
        public AccountRepository()
        {
            _authContext = new AuthContext();
        }
        public async Task CreateAccount(Account account)
        {
            _authContext.Accounts.Add(account);
            await _authContext.SaveChangesAsync();
        }

        public async Task<Account> GetUserByLogin(string email, string password)
        {
            var user = await  _authContext.Accounts.SingleOrDefaultAsync(u => u.Email == email && u.Password == password);
            return user;
        }

        public async Task<IEnumerable<Account>> GetAllAccounts()
        {
            return await _authContext.Accounts.ToListAsync();
        }
    }
}
