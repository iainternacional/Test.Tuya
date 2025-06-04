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

        public Task<IReadOnlyList<Order>> GetAllAsync(CancellationToken ct) =>
    _db.Orders.AsNoTracking()
              .ToListAsync(ct)
              .ContinueWith(t => (IReadOnlyList<Order>)t.Result, ct);

        public Task<Order?> GetByIdAsync(Guid id, CancellationToken ct) =>
            _db.Orders.FindAsync(new object?[] { id }, ct).AsTask();

        public async Task AddAsync(Order order, CancellationToken ct)
            => await _db.Orders.AddAsync(order, ct);

        public Task SaveChangesAsync(CancellationToken ct) =>
            _db.SaveChangesAsync(ct);

        public void Remove(Order order) => _db.Orders.Remove(order);
    }
}
