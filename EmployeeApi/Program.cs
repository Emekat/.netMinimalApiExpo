using EmployeeApi;
using EmployeeApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
EmployeeManager.Create(new Employee
{
    Id = 1,
    Name = "John Doe",
    City = "New York",
    Region = "NY",
    PostalCode = "10001",
    Address = "123 Main Street",
    Country = "USA",
    Phone = "123-456-7890",
    Salary = 100000
});

app.MapGet("/employees", () => Results.Ok(EmployeeManager.GetEmployees())).WithName("GetEmployees");    

app.MapGet("/employees/{id}", (int id) => Results.Ok(EmployeeManager.Get(id))).WithName("GetEmployee");

app.MapPost("/employees", (Employee employee) =>
{
    EmployeeManager.Create(employee);
    return Results.Created($"/employees/{employee.Id}", employee);
}).WithName("CreateEmployee");

app.MapPut("/employees/{id}", (int id, Employee employee) =>
{
    EmployeeManager.Update(id, employee);
    return Results.Ok(employee);
}).WithName("UpdateEmployeeById");

app.MapPut("/employees", (Employee employee) =>
{
    EmployeeManager.UpdateEmployee(employee);
    return Results.Ok(employee);
}).WithName("UpdateEmployee");

app.MapPatch("/employees/{id}/name", (int id, string name) =>
{
    EmployeeManager.ChangeName(id, name);
    return Results.Ok();
}).WithName("ChangeEmployeeName");

app.MapDelete("/employees/{id}", (int id) =>
{
    EmployeeManager.DeleteEmployee(id);
    return Results.Ok();
}).WithName("DeleteEmployee");


app.Run();
