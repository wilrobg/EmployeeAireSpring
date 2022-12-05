using Employee.Infrastructure;
using Employee.Infrastructure.Seeders;
using Employee.Application;
using Microsoft.OpenApi.Models;
using System.Reflection;
using Employee.Infrastructure.Configuration;
using Employee.Web.Extensions;
using Employee.Web.Profiles;

var builder = WebApplication.CreateBuilder(args);

//DI connection string to facilitate dapper
builder.Services.Configure<ConnectionStrings>(
    builder.Configuration.GetSection("ConnectionStrings"));

//Using EF Core just to create Database and seeding data.
var connectionString = builder.Configuration.GetConnectionString("EmployeeDB");
builder.Services.AddDbContext(connectionString!);
await builder.Services.AddEmployees();

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

builder.Services.AddAutoMapper(typeof(EmployeeProfile));

//Adding Dependency Injection for each layer
builder.Services.AddApplication();
builder.Services.AddInfrastructure();

//Adding razor pages
builder.Services.AddControllersWithViews().AddNewtonsoftJson();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseGlobalExceptionHandler();

app.UseRouting();

app.UseHttpsRedirection(); 
app.UseStaticFiles();
app.UseCookiePolicy();

app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
    endpoints.MapRazorPages();
});

app.MapEndpoints();

app.Run();
