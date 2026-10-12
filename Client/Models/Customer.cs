using System;

namespace Client;

//public record class Customer
public class Customer
{
    public string CustomerId { get; set; } = Guid.NewGuid().ToString();
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public string? Phone {get; set; }
    public string? AddressLine { get; set; }
    public string? PostalCode { get; set; }
    public string? City { get; set; }

    public void Edit()
    {
        Console.WriteLine("Ändra kunden");
    }
    public void Delete()
    {
        Console.WriteLine("Ta bort kunden");
    }
}
