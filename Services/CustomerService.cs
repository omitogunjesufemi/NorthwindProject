using System.Collections;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using NorthwindLibrary.Entities;

namespace NorthwindLibrary
{
    public class CustomerService : ICustomerService
    {
        protected CustomerRepository repository;
        public CustomerService(CustomerRepository _repository)
        {
            repository = _repository;
        }

        public Task<IList<Customer>> GetAllCustomers()
        {
            var customers = repository.GetAllAsync();
            return customers;
        }

        public Task<Customer> GetCustomer(int id)
        {
            var customer = repository.GetByCustomerID(id);
            return customer;
        }

        public Task<IList<Customer>> GetCustomersFromACompany(string companyName)
        {
            var customers = repository.GetByCompanyName(companyName);
            return customers;
        }

        public Task<Customer> CreateCustomer(Customer customer)
        {
            var newCustomer = repository.CreateAsync(customer);
            return newCustomer;
        }

        public Task<Customer> UpdateCustomer(Customer customer)
        {
            var updatedCustomer = repository.UpdateAsync(customer);
            return updatedCustomer;
        }

        public Task<bool> DeleteCustomer(int id)
        {
            var deleteStatus = repository.DeleteByCustomerID(id);
            return deleteStatus;
        }
    }
}