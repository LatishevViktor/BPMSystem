using BPMSystem.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace BPMSystem.Domain.DataContext
{
    public class BpmContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Position> Positions { get; set; }
        public BpmContext(DbContextOptions<BpmContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = "Server=DESKTOP-G0D1JK5\\LATYSHEVSERVER;Database=BPMSystemDB;Trusted_Connection=True;";
                optionsBuilder.UseSqlServer(connectionString);
            }
            base.OnConfiguring(optionsBuilder);
        }
    }
}
