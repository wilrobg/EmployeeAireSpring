using System.ComponentModel.DataAnnotations;

namespace Employee.Web.ViewModels.Employee;

public record UpdateEmployeeViewModel
{
    public int Id { get; set; }

    [Required]
    [Display(Name = "First Name")]
    public string EmployeeFirstName { get; set; }

    [Required]
    [Display(Name = "Last Name")]
    public string EmployeeLastName { get; set; }

    [Required]
    [Display(Name = "Phone Number")]
    [RegularExpression(@"^\([\d]{3}\)\s?[\d]{3}-[\d]{4}$", ErrorMessage = "Phone must meet the following format (###) ###-###")]
    public string EmployeePhone { get; set; }

    [Required]
    [Display(Name = "Zip Code")]
    [MaxLength(10)]
    public string EmployeeZip { get; set; }

    [Required]
    [Display(Name = "Hire Date")]
    [DataType(DataType.Date)]
    public DateTime HireDate { get; set; }
}
