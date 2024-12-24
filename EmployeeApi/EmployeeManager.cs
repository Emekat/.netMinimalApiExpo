using EmployeeApi.Models;

namespace EmployeeApi;

public static class EmployeeManager
{
    private static readonly List<Employee> Employees = new();
    
    private static int GetEmployeeIndex(int id)
    {
        var employeeIndex = Employees.FindIndex(e => e.Id == id);
        if (employeeIndex == -1)
        {
            throw new ArgumentException($"Employee with {id} does not exist");
        }
        return employeeIndex;
    }
    
    public  static List<Employee> GetEmployees()
    {
        return Employees;
    }
    public static Employee Get(int id)
    {
        var employee = Employees.FirstOrDefault(e => e.Id == id);
        if (employee == null)
        {
            throw new ArgumentException($"Employee with {id} does not exist");
        }
        return employee;
    }
    public static void Create(Employee employee)
    {
        Employees.Add(employee);
    }
    public static void Update(int id, Employee employee)
    {
        var employeeIndex = GetEmployeeIndex(id);
        Employees[employeeIndex] = employee;
    }
    
    public static void UpdateEmployee(Employee employee)
    {
        Employees[GetEmployeeIndex(employee.Id)] = employee;
    }
    public static void DeleteEmployee(int id)
    {
        var employeeIndex = GetEmployeeIndex(id);
        Employees.RemoveAt(employeeIndex);
    }
    public static void DeleteEmployee(Employee employee)
    {
        Employees.Remove(employee);
    }
    public static void DeleteEmployees()
    {
        Employees.Clear();
    }
   public static void ChangeName(int id, string name)
    {
        var employeeIndex = GetEmployeeIndex(id);
        Employees[GetEmployeeIndex(id)].Name = name;
    }
}