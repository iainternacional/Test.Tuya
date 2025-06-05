using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
                var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production";

                var configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())           // donde se ejecuta la CLI
               .AddJsonFile("appsettings.json", optional: true)
               .AddJsonFile($"appsettings.{environment}.json", optional: true)
               .Build();

                // ――3‒ Aplica la cadena
                var connectionString = configuration.GetConnectionString("Default");
                optionsBuilder.UseSqlServer(connectionString);
            
        }
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
