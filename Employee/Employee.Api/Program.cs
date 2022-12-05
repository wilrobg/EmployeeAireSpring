using Employee.Api.Endpoints.Employees;
using Employee.Infrastructure;
using Employee.Infrastructure.Seeders;
using Employee.Application;
using Microsoft.OpenApi.Models;
using System.Reflection;
using Employee.Infrastructure.Configuration;

var builder = WebApplication.CreateBuilder(args);

//DI connection string to facilitate dapper
builder.Services.Configure<ConnectionStrings>(
    builder.Configuration.GetSection("ConnectionStrings"));

//Using EF Core just to create Database and seeding data.
var connectionString = builder.Configuration.GetConnectionString("EmployeeDB");
builder.Services.AddDbContext(connectionString!);
builder.Services.AddEmployees();

builder.Services.AddEndpointsApiExplorer();

//Adding Swagger Annotations
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1",
        new OpenApiInfo
        {
            Version = "v1",
            Title = $"Employee API",
            Description = "Minimal API in .NET 7."
        });

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

    options.EnableAnnotations();
    options.DocInclusionPredicate((name, api) => true);
});

//Adding Dependency Injection for each layer
builder.Services.AddApplication();
builder.Services.AddInfrastructure();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//Mapping endpoints using Minimal APIS.
//Segregate funcionality following SOLID principles
app.MapGetEmployeesEndpoint();
app.MapEmployeeSearch();

app.Run();
