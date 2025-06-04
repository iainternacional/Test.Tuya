using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Tuya.Domain.Entities;

namespace Test_Tuya.Domain.Repositories
{
    public interface IOrderRepository
    {
        Task<IReadOnlyList<Order>> GetAllAsync(CancellationToken ct);
        Task<Order?> GetByIdAsync(Guid id, CancellationToken ct);
        Task AddAsync(Order order, CancellationToken ct);
        Task SaveChangesAsync(CancellationToken ct);
        void Remove(Order order);
    }
}
