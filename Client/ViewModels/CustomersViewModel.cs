using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using Client.Enums;
using Client.Interfaces;
using Client.Models;
using Client.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Client.ViewModels;

public partial class CustomersViewModel : ViewModelBase
{
    private ICustomerService _customerService;

    [ObservableProperty]
    public partial ObservableCollection<Customer> Customers {get; set; } = [];
    
    public CustomersViewModel()
    {
        _customerService = new CustomerServices();
        PageTitle = "Kund Lista";
        Init();
    }
    public CustomersViewModel(ICustomerService customerService)
    {
        _customerService = customerService;
        //PageName = PageViewsEnum.Customers;
        PageTitle = "Kund Lista";
        //Task.Run(()=> LoadCustomers()).Wait();
        Init();
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
    
    private async void Init()
    {
        await LoadCustomers();
    }
    private async Task LoadCustomers()
    {
        try
        {
            //var customers = CustomerServices.ListAllCustomers();
            //Customers = new ObservableCollection<Customer>(customers);
            var customers = await _customerService.List();
            Customers = new ObservableCollection<Customer>(customers);
        }
        catch(Exception ex)
        {
            // Byts ut till en tjusig popup senare...
            Console.WriteLine(ex.Message);
        }
    } 
}
