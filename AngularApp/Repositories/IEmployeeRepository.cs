using AngularApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularApp.Repositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllEmployees();
        Task<int> AddEmployee(Employee employee);
        Task<int> UpdateEmployee(Employee employee);
        Task<Employee> GetEmployeeData(int id);
        Task<int> DeleteEmployee(int id);
        Task<List<City>> GetCities();
    }
}
