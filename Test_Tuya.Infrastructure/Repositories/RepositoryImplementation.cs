using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Tuya.Domain.Contracts;
using Test_Tuya.Domain.Entities;
using Test_Tuya.Infrastructure.Data;

namespace Test_Tuya.Infrastructure.Repositories
{
    internal sealed class RepositoryImplementation : IRepository
    {
        private readonly AppDbContext _db;
        public RepositoryImplementation(AppDbContext db) => _db = db;

        public DataValue Get() => _db.DataValues.AsNoTracking().First();

        public void Save(DataValue data)
        {
            _db.DataValues.Update(data);
            _db.SaveChanges();
        }
    }
}
