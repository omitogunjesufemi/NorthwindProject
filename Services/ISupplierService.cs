using NorthwindLibrary.Entities;

namespace NorthwindLibrary
{
    public interface ISupplierService
    {
        Task<IList<Supplier>> GetAllSuppliers();
        Task<Supplier> AddSupplier(Supplier supplier);
        Task<Supplier> EditSupplier(Supplier supplier);
        Task<bool> DeleteSupplier(int id);
        Task<Supplier> GetSupplier(int id);
    }
}
