using System.ComponentModel.DataAnnotations;

namespace Employee.Application.Employees.Queries.GetEmployees;

public record EmployeeResponseDto
{
    public int Id { get; set; }
    public string EmployeeLastName { get; set; }
    public string EmployeeFirstName { get; set; }
    public string EmployeePhone { get; set; }
    public string EmployeeZip { get; set; }
    public DateTime HireDate { get; set; }
}
