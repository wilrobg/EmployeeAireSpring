using System.ComponentModel.DataAnnotations;

namespace Employee.Web.ViewModels.Employee;

public record EmployeeViewModel
{
    public int Id { get; set; }
    public string EmployeeLastName { get; set; }
    public string EmployeeFirstName { get; set; }
    public string EmployeePhone { get; set; }
    public string EmployeeZip { get; set; }

    [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
    public DateTime HireDate { get; set; }
}
