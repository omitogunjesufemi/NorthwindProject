using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using NorthwindLibrary.Entities;

namespace NorthwindLibrary
{
    public class EmployeeRepository : BaseRepository<Employee, NorthwindDbContext>, IEmployeeRepository
    {
        protected NorthwindDbContext context;

        public EmployeeRepository(NorthwindDbContext _context):base(_context)
        {
            context = _context;
        }

        public async Task<Employee> GetByEmployeeID(int id)
        {
            var employee = await context.Employees.FindAsync(id);
            return employee;
        }

        public async Task<bool> DeleteByEmployeeID(int id)
        {
            var employee = await context.Employees.FindAsync(id);
            context.Employees.Remove(employee);
            await context.SaveChangesAsync();
            return true;
        }
        
    }
}