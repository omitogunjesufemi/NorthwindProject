using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using NorthwindLibrary.Entities;

namespace NorthwindLibrary
{
    public interface ICustomerService
    {
         Task<IList<Customer>> GetAllCustomers();
         Task<Customer> GetCustomer(string id);
         Task<IList<Customer>> GetCustomersFromACompany(string companyName);
         Task<Customer> CreateCustomer(Customer customer);
         Task<Customer> UpdateCustomer(Customer customer);
         Task<bool> DeleteCustomer(int id);

    }
}