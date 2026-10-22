using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Client.Interfaces;
using Client.Models;
using Client.Repositories;

namespace Client.Services;

public class CustomerServices : ICustomerService
{
    
    //static string path = string.Concat(Environment.CurrentDirectory,"/Data/customers.json");
    //static Storage<Customer> storage = new();
    public async Task<List<Customer>> List()
    {
        var httpService = new HttpService<Customer>();
        var customers = await httpService.Get("customers");
        return customers;
        
        // StoreCustomers(new Customer{
        //         FirstName = "Barani", 
        //         LastName = "Adhiseshan",
        //         AddressLine="Hisingen 4",
        //         PostalCode="422 50",
        //         City="Göteborg",
        //         Phone = "+46 734854350",
        //         Email = "barani.seshan@gmail.com"});

        // var storage = new Storage<Customer>();
        // var path = string.Concat(Environment.CurrentDirectory, "/Data/customers.json");
        // var customers = storage.Read(path);
        
        // return customers;

        /*return [
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
        ];*/
        
    }
    // public static void StoreCustomers(Customer cust)
    // {
    //     var customers = storage.Read(path);
    //     customers.Add((Customer)cust);
    //     storage.Write(path, customers);
    // }
}
