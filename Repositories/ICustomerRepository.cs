using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using NorthwindLibrary.Entities;

namespace NorthwindLibrary
{
    public interface ICustomerRepository : IBaseRepository<Customer, NorthwindDbContext>
    {
        Task<Customer> GetByCustomerID(int id);
        Task<IList<Customer>> GetByCompanyName(string companyName);
        Task<bool> DeleteByCustomerID(int id);
    }
}