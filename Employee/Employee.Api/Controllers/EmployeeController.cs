﻿using AutoMapper;
using Employee.Application.Employees.Commands.AddEmployee;
using Employee.Application.Employees.Commands.DeleteEmployee;
using Employee.Application.Employees.Commands.UpdateEmployee;
using Employee.Application.Employees.Queries.GetById;
using Employee.Application.Employees.Queries.GetEmployees;
using Employee.Web.Endpoints.Employees;
using Employee.Web.ViewModels.Employee;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Employee.Web.Controllers;

[ApiExplorerSettings(IgnoreApi = true)]
[Route("[controller]")]
public class EmployeeController : Controller
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    public EmployeeController(IMediator mediator, IMapper mapper)
    {
        _mediator= mediator;
        _mapper= mapper;
    }

    public async Task<IActionResult> Index()
    {
        var result = await _mediator.Send(new GetEmployeesQuery());
        var vm = _mapper.Map<IEnumerable<EmployeeViewModel>>(result);
        return View(vm);
    }

    [HttpGet("DeleteEmployee/{Id}")]
    public async Task<IActionResult> DeleteEmployee(int id)
    {
        await _mediator.Send(new DeleteEmployeeCommand { Id = id});

        return RedirectToAction(nameof(Index));
    }

    [HttpGet("CreateEmployee")]
    public IActionResult CreateEmployee()
    {
        return View();
    }

    [HttpPost("CreateEmployee")]
    public async Task<IActionResult> CreateEmployee(AddEmployeeViewModel vm)
    {
        if (!ModelState.IsValid)
            return View();

        var request = _mapper.Map<AddEmployeeCommand>(vm);
        var result = await _mediator.Send(request);
        return RedirectToAction(nameof(Index));   
    }

    [HttpGet("UpdateEmployee/{id:int}")]
    public async Task<IActionResult> UpdateEmployee(int id)
    {
        var employee = await _mediator.Send(new GetByIdCommand { Id = id});
        var vm = _mapper.Map<UpdateEmployeeViewModel>(employee);
        return View(vm);
    }

    [HttpPost("UpdateEmployee/{id:int}")]
    public async Task<IActionResult> UpdateEmployee(int id,UpdateEmployeeViewModel vm)
    {
        if (!ModelState.IsValid)
            return View();

        var request = _mapper.Map<UpdateEmployeeCommand>(vm);
        
        request.Id = id;

        var result = await _mediator.Send(request);

        return RedirectToAction(nameof(Index));
    }
}
