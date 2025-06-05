using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Tuya.Domain.Entities;

namespace Test_Tuya.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<Order> Orders => Set<Order>();
        public AppDbContext(DbContextOptions<AppDbContext> o) : base(o) { }
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Customer>(cfg =>
            {
                cfg.HasKey(c => c.Id);
                cfg.Property(c => c.Name).IsRequired().HasMaxLength(200);
                cfg.Property(c => c.Email).IsRequired().HasMaxLength(200);
            });

            mb.Entity<Order>(cfg =>
            {
                cfg.HasKey(o => o.Id);
                cfg.HasOne(o => o.Customer)
                   .WithMany()
                   .HasForeignKey(o => o.CustomerId);
            });
        }
    }
}
