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
    internal sealed class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _db;

        public OrderRepository(AppDbContext db) => _db = db;

        public Task<IReadOnlyList<Order>> GetAllAsync() =>
    _db.Orders.AsNoTracking()
              .ToListAsync()
              .ContinueWith(t => (IReadOnlyList<Order>)t.Result);

        public Task<Order?> GetByIdAsync(Guid id) =>
            _db.Orders.FindAsync(new object?[] { id }).AsTask();

        public async Task AddAsync(Order order)
            => await _db.Orders.AddAsync(order);

        public Task SaveChangesAsync() =>
            _db.SaveChangesAsync();

        public void Remove(Order order) => _db.Orders.Remove(order);
    }
}
