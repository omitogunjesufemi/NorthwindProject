using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using NorthwindLibrary.Entities;

namespace NorthwindLibrary
{
    public class CustomerRepository : BaseRepository<Customer, NorthwindDbContext>, ICustomerRepository
    {
        protected NorthwindDbContext context;

        public CustomerRepository(NorthwindDbContext _context):base(_context)
        {
            context = _context;
        }

        public async Task<Customer> GetByCustomerID(string id)
        {
            Customer customer = await context.Customers.FindAsync(id);
            return customer;
        }

        public async Task<IList<Customer>> GetByCompanyName(string companyName)
        {
            IList<Customer> customers = await context.Customers.Where(c=>c.CompanyName == companyName).ToListAsync();
            return customers;
        }

        public async Task<bool> DeleteByCustomerID(int id)
        {
            Customer customer = await context.Customers.FindAsync(id);
            context.Customers.Remove(customer);
            await context.SaveChangesAsync();
            return true;
        }
    }
}