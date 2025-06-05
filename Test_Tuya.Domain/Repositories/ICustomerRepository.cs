using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Tuya.Domain.Entities;

namespace Test_Tuya.Domain.Repositories
{
    public interface ICustomerRepository
    {
        Task<IReadOnlyList<Customer>> GetAllAsync();
        Task<Customer?> GetByIdAsync(Guid id);
        Task AddAsync(Customer customer);
        Task SaveChangesAsync();
    }
}
