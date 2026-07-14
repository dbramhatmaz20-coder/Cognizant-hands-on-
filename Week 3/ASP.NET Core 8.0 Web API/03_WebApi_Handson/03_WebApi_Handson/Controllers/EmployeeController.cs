using Microsoft.AspNetCore.Mvc;
using _03_WebApi_Handson.Models;
using _03_WebApi_Handson.Filters;

namespace _03_WebApi_Handson.Controllers
{
    [ApiController]
    [Route("[controller]")]
    // [CustomAuthFilter]
    public class EmployeeController : ControllerBase
    {
        private List<Employee> employees;

        public EmployeeController()
        {
            employees = GetStandardEmployeeList();
        }

        private List<Employee> GetStandardEmployeeList()
        {
            return new List<Employee>()
            {
                new Employee
                {
                    Id = 1,
                    Name = "John",
                    Salary = 50000,
                    Permanent = true,
                    Department = new Department
                    {
                        Id = 101,
                        Name = "IT"
                    },
                    Skills = new List<Skill>()
                    {
                        new Skill
                        {
                            Id = 1,
                            Name = "C#"
                        },
                        new Skill
                        {
                            Id = 2,
                            Name = "SQL"
                        }
                    },
                    DateOfBirth = new DateTime(2001,5,10)
                },

                new Employee
                {
                    Id = 2,
                    Name = "Alice",
                    Salary = 70000,
                    Permanent = false,
                    Department = new Department
                    {
                        Id = 102,
                        Name = "HR"
                    },
                    Skills = new List<Skill>()
                    {
                        new Skill
                        {
                            Id = 3,
                            Name = "Communication"
                        }
                    },
                    DateOfBirth = new DateTime(1999,3,15)
                }
            };
        }
       [HttpGet]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status500InternalServerError)]
public ActionResult<List<Employee>> GetStandard()
{
    throw new Exception("This is a custom exception.");
}

[HttpPost]
public IActionResult AddEmployee([FromBody] Employee employee)
{
    employees.Add(employee);
    return Ok(employee);
}

[HttpPut]
public IActionResult UpdateEmployee([FromBody] Employee employee)
{
    var emp = employees.FirstOrDefault(e => e.Id == employee.Id);

    if (emp == null)
    {
        return NotFound();
    }

    emp.Name = employee.Name;
    emp.Salary = employee.Salary;
    emp.Permanent = employee.Permanent;
    emp.Department = employee.Department;
    emp.Skills = employee.Skills;
    emp.DateOfBirth = employee.DateOfBirth;

    return Ok(emp);
}
    }
}