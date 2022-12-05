using FluentValidation;
using System.Text.RegularExpressions;

namespace Employee.Application.Employees.Commands.AddEmployee;

public class AddEmployeeValidator : AbstractValidator<AddEmployeeCommand>
{
	public AddEmployeeValidator()
	{
        RuleFor(r => r.EmployeeFirstName).NotEmpty();
        RuleFor(r => r.EmployeeLastName).NotEmpty();
        RuleFor(r => r.EmployeePhone).Must(BeValidPhone).WithMessage("EmployeePhone must meet the following format (###) ###-####");
        RuleFor(r => r.EmployeeZip).NotEmpty().MaximumLength(10);
        RuleFor(r => r.HireDate).NotEmpty();
    }

    private bool BeValidPhone(string phone)
    {
        Regex re = new(@"^\([\d]{3}\)\s?[\d]{3}-[\d]{4}$");
        var result = re.Match(phone);
        return result.Success;
    }
}
