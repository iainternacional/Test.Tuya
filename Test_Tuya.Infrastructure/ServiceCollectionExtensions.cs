using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Tuya.Domain.Repositories;
using Test_Tuya.Infrastructure.Data;
using Test_Tuya.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Test_Tuya.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(
        this IServiceCollection svcs, IConfiguration cfg)
        {
            svcs.AddDbContext<AppDbContext>(opt =>
                opt.UseSqlServer(cfg.GetConnectionString("Default")));

            svcs.AddScoped<ICustomerRepository, CustomerRepository>();
            svcs.AddScoped<IOrderRepository, OrderRepository>();

            return svcs;
        }
    }
}
