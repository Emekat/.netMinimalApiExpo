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

app.MapGet("/employees/{id:int}", async (int id) => TypedResults.Ok(EmployeeManager.Get(id))).WithName("GetEmployee");

app.MapPost("/employees", async (Employee employee) =>
{
    EmployeeManager.Create(employee);
    return TypedResults.Created();
}).WithName("CreateEmployee");

app.MapPut("/employees", async (Employee employee) =>
{
    EmployeeManager.UpdateEmployee(employee);
    return TypedResults.Ok(employee);
}).WithName("UpdateEmployee");

app.MapPatch("/employees/{id:int}/name", async (int id, string name) =>
{
    EmployeeManager.ChangeName(id, name);
    return TypedResults.Ok();
}).WithName("ChangeEmployeeName");

app.MapDelete("/employees/{id:int}", async (int id) =>
{
    EmployeeManager.DeleteEmployee(id);
    return TypedResults.Ok();
}).WithName("DeleteEmployee");


app.Run();
