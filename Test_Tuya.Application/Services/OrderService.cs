using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Tuya.Application.DTOs;
using Test_Tuya.Domain.Entities;
using Test_Tuya.Domain.Repositories;

namespace Test_Tuya.Application.Services
{
    public sealed class OrderService
    {
        private readonly ICustomerRepository _customers;
        private readonly IOrderRepository _orders;   // Defínelo igual que Customer

        public OrderService(ICustomerRepository customers,
                            IOrderRepository orders)
            => (_customers, _orders) = (customers, orders);

        public async Task<OrderResponse> CreateOrderAsync(
            CreateOrderRequest request)
        {
            // 1. Valida cliente existente
            var customer = await _customers.GetByIdAsync(request.CustomerId)
                          ?? throw new InvalidOperationException("Cliente no existe");

            // 2. Crea orden
            var order = new Order(customer.Id);
            await _orders.AddAsync(order);
            await _orders.SaveChangesAsync();

            return new OrderResponse(order.Id, order.CreatedAt);
        }

        public async Task CancelOrderAsync(Guid orderId)
        {
            var order = await _orders.GetByIdAsync(orderId)
                        ?? throw new InvalidOperationException("Orden no existe");

            // regla de cancelación (ej. 24 h)
            /* … */

            _orders.Remove(order);
            await _orders.SaveChangesAsync();
        }
    }
}
