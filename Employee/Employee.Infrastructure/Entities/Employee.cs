using System.ComponentModel.DataAnnotations;

namespace Employee.Infrastructure.Entities;

public record Employee
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string EmployeeLastName { get; set; }

    [Required]
    [StringLength(50)]
    public string EmployeeFirstName { get; set; }

    [Required]
    [StringLength(50)]
    public string EmployeePhone { get; set; }

    [Required]
    [StringLength(10)]
    public string EmployeeZip { get; set; }

    [Required]
    public DateTime HireDate { get; set; }
}
