using Microsoft.AspNetCore.Mvc;
using EmployeeAPI.Data;
using EmployeeAPI.Models;
using System.Linq;

namespace EmployeeAPI.Controllers;

[ApiController]
[Route("api/Emp")]
public class EmployeeController : ControllerBase
{
    [HttpGet(Name = "GetAllEmployees")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetEmployees()
    {
        return Ok(EmployeeData.Employees);
    }

    [HttpPost]
    public IActionResult AddEmployee(Employee employee)
    {
        EmployeeData.Employees.Add(employee);
        return Ok("Employee Added Successfully");
    }
    [HttpGet("{id}")]
[ActionName("GetEmployeeById")]
public IActionResult GetEmployee(int id)
{
    var employee = EmployeeData.Employees.FirstOrDefault(e => e.Id == id);

    if (employee == null)
    {
        return NotFound();
    }

    return Ok(employee);
}
}