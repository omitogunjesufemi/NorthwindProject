using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using NorthwindLibrary.Entities;

namespace NorthwindLibrary
{
    public interface IEmployeeService
    {
        Task<IList<Employee>> GetAllEmployees();
        Task<Employee> GetEmployee(int id);
        Task<Employee> AddEmployee(Employee employee); 
        Task<Employee> UpdateEmployee(Employee employee);
        Task<bool> DeleteEmployee(int id);
    }
}
