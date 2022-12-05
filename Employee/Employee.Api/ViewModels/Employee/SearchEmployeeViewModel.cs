using System.ComponentModel.DataAnnotations;

namespace Employee.Web.ViewModels.Employee;

public record SearchEmployeeViewModel
{
    [Display(Name = "First Name")]
    public string EmployeeFirstName { get; set; }

    [Display(Name = "Last Name")]
    public string EmployeeLastName { get; set; }
}
