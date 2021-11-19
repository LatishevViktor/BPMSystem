using IdentityAPI.Entities;

using Microsoft.EntityFrameworkCore;

namespace IdentityAPI.EF
{
    public class AuthContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public AuthContext()
        {

        }
        public AuthContext(DbContextOptions<AuthContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connectionString = "Server=DESKTOP-G0D1JK5\\LATYSHEVSERVER;Database=IdentityBPM;Trusted_Connection=True;";
                optionsBuilder.UseSqlServer(connectionString);
            }
            base.OnConfiguring(optionsBuilder);
        }
    }
}
