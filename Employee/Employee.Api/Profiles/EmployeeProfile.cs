using AutoMapper;
using Employee.Application.Employees.Commands.AddEmployee;
using Employee.Application.Employees.Commands.UpdateEmployee;
using Employee.Application.Employees.Queries.GetById;
using Employee.Application.Employees.Queries.GetEmployees;
using Employee.Web.ViewModels.Employee;

namespace Employee.Web.Profiles;
public class EmployeeProfile : Profile
{
	public EmployeeProfile()
	{
		CreateMap<EmployeeResponseDto, EmployeeViewModel>();
		CreateMap<AddEmployeeViewModel, AddEmployeeCommand>();
        CreateMap<GetByIdResponseDto, UpdateEmployeeViewModel>();
        CreateMap<UpdateEmployeeViewModel, UpdateEmployeeCommand>();
    }
}
