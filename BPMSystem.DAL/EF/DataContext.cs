using BPMSystem.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMSystem.DAL.EF
{
    public class DataContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Position> Positions { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        string connectionString = "Server=DESKTOP-G0D1JK5\\LATYSHEVSERVER;Database=BPMSystemDB;Trusted_Connection=True;";
        //        optionsBuilder.UseSqlServer(connectionString);
        //    }
        //    base.OnConfiguring(optionsBuilder);
        //}
    }
}
