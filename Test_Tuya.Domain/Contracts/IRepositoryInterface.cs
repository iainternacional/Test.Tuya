using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Tuya.Domain.Entities;

namespace Test_Tuya.Domain.Contracts
{
    public interface IRepository
    {
        DataValue Get();
        void Save(DataValue data);
    }
}
