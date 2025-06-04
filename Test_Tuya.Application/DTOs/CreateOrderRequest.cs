using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Tuya.Application.DTOs
{
    public sealed record CreateOrderRequest(Guid CustomerId /*, List<OrderDetailDto> Items */);
}
