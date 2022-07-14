using NorthwindLibrary.Entities;

namespace NorthwindLibrary
{
    public interface IOrderDetailService
    {
        Task<IList<OrderDetail>> GetAllOrderDetails(int id);
        Task<OrderDetail> AddToOrder(OrderDetail orderDetail);
        Task<OrderDetail> UpdateOrderDetailInCart(OrderDetail orderDetail);
        Task<bool> RemoveAProductFromOrder(int productID, int orderID);
    }
}
