using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Tuya.Domain.Entities;
using Test_Tuya.Domain.Repositories;
using Test_Tuya.Infrastructure.Data;

namespace Test_Tuya.Infrastructure.Repositories
{
    internal sealed class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _db;
        public CustomerRepository(AppDbContext db) => _db = db;

        public Task<IReadOnlyList<Customer>> GetAllAsync() =>
    _db.Customers.AsNoTracking()
              .ToListAsync()
              .ContinueWith(t => (IReadOnlyList<Customer>)t.Result);

        public Task<Customer?> GetByIdAsync(Guid id) =>
            _db.Customers.FindAsync(new object?[] { id }).AsTask();

        public async Task AddAsync(Customer customer)
            => await _db.Customers.AddAsync(customer);

        public Task SaveChangesAsync() =>
            _db.SaveChangesAsync();
    }
}
