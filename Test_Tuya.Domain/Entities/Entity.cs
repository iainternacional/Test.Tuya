using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Tuya.Domain.Entities
{
    public class Entity
    {
        private DataValue _data;
        public DataValue GetData() => _data;
        public void SetData(DataValue data) => _data = data;
    }
}
