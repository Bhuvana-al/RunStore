using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Client.Interfaces;
using Client.Services;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Client.ViewModels;

public partial class CustomersViewModel : ViewModelBase
{
    private ICustomerService _customerService;

    [ObservableProperty]
    public partial ObservableCollection<Customer> Customers {get; set; } = [];
    
    public CustomersViewModel(ICustomerService customerService)
    {
        PageTitle = "Kund Lista";
        _customerService = customerService;
        LoadCustomers();
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
