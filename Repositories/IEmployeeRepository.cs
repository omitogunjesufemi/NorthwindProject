using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using NorthwindLibrary.Entities;
namespace NorthwindLibrary
{
    public interface IEmployeeRepository : IBaseRepository<Employee, NorthwindDbContext>
    {
         Task<Employee> GetByEmployeeID(int id);
         Task<bool> DeleteByEmployeeID(int id);
    }
}