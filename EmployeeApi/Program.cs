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

app.MapGet("/employees/{id}", (int id) => TypedResults.Ok(EmployeeManager.Get(id))).WithName("GetEmployee");

app.MapPost("/employees", (Employee employee) =>
{
    EmployeeManager.Create(employee);
    return TypedResults.Created($"/employees/{employee.Id}", employee);
}).WithName("CreateEmployee");

app.MapPut("/employees/{id}", (int id, Employee employee) =>
{
    EmployeeManager.Update(id, employee);
    return TypedResults.Ok(employee);
}).WithName("UpdateEmployeeById");

app.MapPut("/employees", (Employee employee) =>
{
    EmployeeManager.UpdateEmployee(employee);
    return TypedResults.Ok(employee);
}).WithName("UpdateEmployee");

app.MapPatch("/employees/{id}/name", (int id, string name) =>
{
    EmployeeManager.ChangeName(id, name);
    return TypedResults.Ok();
}).WithName("ChangeEmployeeName");

app.MapDelete("/employees/{id}", (int id) =>
{
    EmployeeManager.DeleteEmployee(id);
    return TypedResults.Ok();
}).WithName("DeleteEmployee");


app.Run();
