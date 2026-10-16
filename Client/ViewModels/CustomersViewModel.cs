using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Client.Interfaces;
using Client.Models;
using Client.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Client.ViewModels;

public partial class CustomersViewModel : PageViewModel
{
    private ICustomerService _customerService;

    [ObservableProperty]
    public partial ObservableCollection<Customer> Customers {get; set; } = [];
    
    public CustomersViewModel(ICustomerService customerService)
    {
        _customerService = customerService;
        PageName = Helpers.ApplicationNameEnum.Customers;
        PageTitle = "Kund Lista";
        LoadCustomers();
    }

    [RelayCommand]
    public void Edit(string custid)
    {
        Console.WriteLine("Ändra kunden, " + custid);
    }
    [RelayCommand]
    public void Delete(string custid)
    {
        Console.WriteLine("Ta bort kunden, " + custid);
    }
    private void LoadCustomers()
    {
        try
        {
            //var customers = CustomerServices.ListAllCustomers();
            //Customers = new ObservableCollection<Customer>(customers);
            Customers = new ObservableCollection<Customer>(_customerService.List());
        }
        catch(Exception ex)
        {
            // Byts ut till en tjusig popup senare...
            Console.WriteLine(ex.Message);
        }
    } 
}
