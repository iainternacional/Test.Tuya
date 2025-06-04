using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Tuya.Domain.Entities
{
    public class Order
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public Guid CustomerId { get; private set; }
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

        public Customer? Customer { get; private set; }
        private Order() { }
        public Order(Guid customerId) => CustomerId = customerId;
    }
}
