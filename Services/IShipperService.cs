using NorthwindLibrary.Entities;

namespace NorthwindLibrary
{
    public interface IShipperService
    {
        Task<IList<Shipper>> GetAllShippers();
        Task<Shipper> GetShipper(int shipperId);
        Task<Shipper> AddShipper(Shipper shipper);
        Task<Shipper> UpdateShipper(Shipper shipper);
        Task<bool> DeleteShipper(int shipperId);
    }
}
