using AngularApp.Models;
using AngularApp.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AngularApp.Controllers
{
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employee;
        
        public EmployeeController(IEmployeeRepository employee)
        {
            _employee = employee;
        }

        [HttpGet]
        [Route("Index")]
        public Task<IEnumerable<Employee>> Index()
        {
            return _employee.GetAllEmployees();
        }

        [HttpPost]
        [Route("Create")]
        public Task<int> Create([FromBody] Employee employee)
        {
            return _employee.AddEmployee(employee);
        }

        [HttpGet]
        [Route("Details/{id}")]
        public Task<Employee> Details(int id)
        {
            return _employee.GetEmployeeData(id);
        }

        [HttpPut]
        [Route("Edit")]
        public Task<int> Edit([FromBody]Employee employee)
        {
            return _employee.UpdateEmployee(employee);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public Task<int> Delete(int id)
        {
            return _employee.DeleteEmployee(id);
        }

        [HttpGet]
        [Route("GetCityList")]
        public Task<List<City>> Details()
        {
            return _employee.GetCities();
        }


    }
}
