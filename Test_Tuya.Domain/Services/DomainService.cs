using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Tuya.Domain.Entities;
using Test_Tuya.Domain.DTOs;
namespace Test_Tuya.Domain.Services
{
    public sealed class DomainService
    {
        public DomainData Process(Entity entity)
        => new(entity.GetData().Value.ToUpperInvariant());
    }
}
