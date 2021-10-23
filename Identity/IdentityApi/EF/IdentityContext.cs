using IdentityApi.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityApi.EF
{
    public class IdentityContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options) { }
    }
}
