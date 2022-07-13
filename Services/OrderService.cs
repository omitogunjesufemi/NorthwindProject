using System.Collections;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using NorthwindLibrary.Entities;

namespace NorthwindLibrary
{
    public class OrderService : IOrderService
    {
        private IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<Order> CreateOrder(Order order)
        {
            Order newOrder = await _orderRepository.CreateAsync(order);
            return newOrder;
        }

        public async Task<bool> DeleteOrder(int id)
        {
            bool deleteStatus = await _orderRepository.DeleteByOrderID(id);
            return deleteStatus;
        }

        public async Task<IList<Order>> GetAllOrders()
        {
            var orders = await _orderRepository.GetAllAsync();
            return orders;
        }

        public async Task<Order> GetOrder(int id)
        {
            Order order = await _orderRepository.GetByOrderID(id);
            if (order == null)
            {
                return null;
            }
            return order;
        }

        public async Task<Order> UpdateOrder(Order order)
        {
            Order updatedOrder = await _orderRepository.UpdateAsync(order);
            return updatedOrder;
        }
    }
}
