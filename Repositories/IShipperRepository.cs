using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using NorthwindLibrary.Entities;

namespace NorthwindLibrary
{
    public interface IShipperRepository : IBaseRepository<Shipper>
    {
         Task<Shipper> GetByShipperID(int id);
         Task<bool> DeleteByShipperID(int id);
    }
}