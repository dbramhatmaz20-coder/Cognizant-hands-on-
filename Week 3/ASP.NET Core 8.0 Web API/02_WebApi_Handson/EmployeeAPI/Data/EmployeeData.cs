using EmployeeAPI.Models;

namespace EmployeeAPI.Data;

public static class EmployeeData
{
    public static List<Employee> Employees = new()
    {
        new Employee
        {
            Id=1,
            Name="Rahul",
            Department="IT"
        },

        new Employee
        {
            Id=2,
            Name="Anjali",
            Department="HR"
        }
    };
}