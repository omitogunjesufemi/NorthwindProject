using System.Collections;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using NorthwindLibrary.Entities;

namespace NorthwindLibrary
{
    public class ShipperService : IShipperService
    {
        private readonly ShipperRepository _repository;

        public ShipperService(ShipperRepository repository)
        {
            _repository = repository;
        }

        public async Task<Shipper> AddShipper(Shipper shipper)
        {
            var newShipper = await _repository.CreateAsync(shipper);
            return newShipper;
        }

        public async Task<bool> DeleteShipper(int shipperId)
        {
            return await _repository.DeleteByShipperID(shipperId);
        }

        public async Task<IList<Shipper>> GetAllShippers()
        {
            var shippers = await _repository.GetAllAsync();
            return shippers;
        }

        public async Task<Shipper> GetShipper(int shipperId)
        {
            var shipper = await _repository.GetByShipperID(shipperId);
            return shipper;
        }

        public async Task<Shipper> UpdateShipper(Shipper shipper)
        {
            var updatedShipper = await _repository.UpdateAsync(shipper);
            return updatedShipper;
        }
    }
}
