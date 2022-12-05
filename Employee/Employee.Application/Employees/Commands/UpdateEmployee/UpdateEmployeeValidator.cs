using Employee.Application.Employees.Commands.UpdateEmployee;
using FluentValidation;
using System.Text.RegularExpressions;

namespace Employee.Application.Employees.Commands.AddEmployee;

public class UpdateEmployeeValidator : AbstractValidator<UpdateEmployeeCommand>
{
	public UpdateEmployeeValidator()
	{
        RuleFor(r => r.EmployeeFirstName).NotEmpty();
        RuleFor(r => r.EmployeeLastName).NotEmpty();
        RuleFor(r => r.EmployeePhone).NotEmpty().Must(BeValidPhone).WithMessage("EmployeePhone must meet the following format (###) ###-####");
        RuleFor(r => r.EmployeeZip).NotEmpty().MaximumLength(10);
        RuleFor(r => r.HireDate).NotEmpty().LessThanOrEqualTo(DateTime.Today).WithMessage("HireDate must be valid");
    }

    private bool BeValidPhone(string phone)
    {
        Regex re = new(@"^\([\d]{3}\)\s?[\d]{3}-[\d]{4}$");
        var result = re.Match(phone);
        return result.Success;
    }
}
