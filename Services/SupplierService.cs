using System.Collections;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using NorthwindLibrary.Entities;

namespace NorthwindLibrary
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;

        public SupplierService(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public async Task<Supplier> AddSupplier(Supplier supplier)
        {
            var newSupplier = await _supplierRepository.CreateAsync(supplier);
            return newSupplier;
        }

        public async Task<bool> DeleteSupplier(int id)
        {
            return await _supplierRepository.DeleteBySupplierID(id);
        }

        public async Task<Supplier> EditSupplier(Supplier supplier)
        {
            var editedSupplier = await _supplierRepository.UpdateAsync(supplier);
            return editedSupplier;
        }

        public async Task<IList<Supplier>> GetAllSuppliers()
        {
            var suppliers = await _supplierRepository.GetAllAsync();
            return suppliers;
        }

        public async Task<Supplier> GetSupplier(int id)
        {
            var supplier = await _supplierRepository.GetBySupplierID(id);
            return supplier;
        }
    }
}
