namespace EmployeeApi.Models;

public record Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string City { get; set; } = null!;
    public string Region { get; set; } = null!;
    public string PostalCode { get; set; } = null!;
    public string Address { get; set; } 
    public string Country { get; set; }
    public string Phone { get; set; }
    public decimal Salary { get; set; }
    
}