using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using NorthwindLibrary.Entities;

namespace NorthwindLibrary
{
    public interface ISupplierRepository : IBaseRepository<Supplier>
    {
         Task<Supplier> GetBySupplierID(int id);
         Task<bool> DeleteBySupplierID(int id);
    }
}