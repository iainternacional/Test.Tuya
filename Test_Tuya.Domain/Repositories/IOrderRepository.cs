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
        Task<IReadOnlyList<Order>> GetAllAsync();
        Task<Order?> GetByIdAsync(Guid id);
        Task AddAsync(Order order);
        Task SaveChangesAsync();
        void Remove(Order order);
    }
}
