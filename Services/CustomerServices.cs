using System;
using System.Collections.Generic;

namespace Client.Services;

public class CustomerServices
{
    public static List<Customer> ListAllCustomers()
    {
        return [
            new Customer{
                FirstName = "Ganapathi", 
                LastName = "Srinivasan",
                AddressLine="Dalagärdet 66",
                PostalCode="422 60",
                City="Göteborg",
                Phone = "+46 765217404",
                Email = "srinivasan.ganapathi@gmail.com"},
            new Customer{
                FirstName = "Barani", 
                LastName = "Adhiseshan",
                AddressLine="Hisingen 4",
                PostalCode="422 50",
                City="Göteborg",
                Phone = "+46 734854350",
                Email = "barani.seshan@gmail.com"}
        ];
    }
}
