using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using NorthwindLibrary.Entities;

namespace NorthwindLibrary
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeService(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<Employee> AddEmployee(Employee employee)
        {
            var newEmployee = await _repository.CreateAsync(employee);
            return newEmployee;
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            var deleteStatus = await _repository.DeleteByEmployeeID(id);
            return deleteStatus;
        }

        public async Task<IList<Employee>> GetAllEmployees()
        {
            var employees = await _repository.GetAllAsync();
            return employees;
        }

        public async Task<Employee> GetEmployee(int id)
        {
            var employee =  await _repository.GetByEmployeeID(id);
            return employee;
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            var updatedEmployee = await _repository.UpdateAsync(employee);
            return employee;
        }
    }
}
