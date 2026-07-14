using EmployeeAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        // Hardcoded Employee List
        private static List<Employee> employees = new List<Employee>()
        {
            new Employee
            {
                Id = 1,
                Name = "John",
                Department = "IT",
                Salary = 50000
            },
            new Employee
            {
                Id = 2,
                Name = "Rahul",
                Department = "HR",
                Salary = 45000
            },
            new Employee
            {
                Id = 3,
                Name = "Amit",
                Department = "Finance",
                Salary = 60000
            }
        };

        // GET : api/Employee
        [HttpGet]
        public ActionResult<List<Employee>> GetEmployees()
        {
            return employees;
        }

        // POST : api/Employee
        [HttpPost]
        public ActionResult<Employee> AddEmployee([FromBody] Employee employee)
        {
            employees.Add(employee);

            return Ok(employee);
        }

        // PUT : api/Employee?id=1
        [HttpPut]
        public ActionResult<Employee> UpdateEmployee(int id, [FromBody] Employee employee)
        {
            // Check if id is less than or equal to zero
            if (id <= 0)
            {
                return BadRequest("Invalid employee id");
            }

            // Find employee by id
            Employee? existingEmployee = employees.FirstOrDefault(e => e.Id == id);

            // Check if employee exists
            if (existingEmployee == null)
            {
                return BadRequest("Invalid employee id");
            }

            // Update employee details
            existingEmployee.Name = employee.Name;
            existingEmployee.Department = employee.Department;
            existingEmployee.Salary = employee.Salary;

            // Return updated employee
            return Ok(existingEmployee);
        }

        // DELETE : api/Employee?id=1
        [HttpDelete]
        public ActionResult DeleteEmployee(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid employee id");
            }

            Employee? employee = employees.FirstOrDefault(e => e.Id == id);

            if (employee == null)
            {
                return BadRequest("Invalid employee id");
            }

            employees.Remove(employee);

            return Ok("Employee deleted successfully.");
        }
    }
}