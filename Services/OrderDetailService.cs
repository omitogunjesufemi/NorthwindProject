using System.Collections;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using NorthwindLibrary.Entities;

namespace NorthwindLibrary
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IOrderDetailRepository _orderDetailRepository;

        public OrderDetailService(IOrderDetailRepository orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }

        public async Task<OrderDetail> AddToOrder(OrderDetail orderDetail)
        {
            var newOrderDetail = await _orderDetailRepository.CreateAsync(orderDetail);
            return newOrderDetail;
        }

        public async Task<IList<OrderDetail>> GetAllOrderDetails(int id)
        {
            var orderDetails = await _orderDetailRepository.GetAllAsync();
            return orderDetails;
        }

        public async Task<bool> RemoveAProductFromOrder(int productID, int orderID)
        {
            var deleteStatus = await _orderDetailRepository.DeleteAllOrderDetailsForAProductID(productID,orderID);
            return deleteStatus;
        }

        public async Task<OrderDetail> UpdateOrderDetailInCart(OrderDetail orderDetail)
        {
            var updatedOrderDetail = await _orderDetailRepository.UpdateAsync(orderDetail);
            return updatedOrderDetail;
        }
    }
}
