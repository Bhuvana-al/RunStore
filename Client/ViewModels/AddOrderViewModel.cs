using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Avalonia.Controls;
using Client.Interfaces;
using Client.Models;
using Client.Services;
using CommunityToolkit.Mvvm.Input;

namespace Client.ViewModels;

public partial class AddOrderViewModel : ViewModelBase
{
private readonly IOrderService _orderService;

public AddOrderViewModel()
    {
        _orderService = new OrderServices();
        PageTitle = "Beställa Produkt";
    }
public AddOrderViewModel(IOrderService orderService)
    {
        PageTitle = "Beställa Produkt";
        _orderService = orderService;
        //Task.Run(()=> LoadCustomers()).Wait();
        //Init();
    }
    [RelayCommand]
    private async Task Save()
    {

        Order order = new()
        {
            Customer = new(){FirstName = "Michael", LastName="Gustavsson", Email="michael@mail.com"},
            Items = [new Item()
                        {Product = new Product()
                            {ItemNumber="1000",Name="Gel 27",SupplierName="Asics",Price=1295},
                         Quantity=1},
                     new Item()
                        {Product = new Product()
                            {ItemNumber="1001",Name="Kompressions strumpor",SupplierName="Puma",Price=295},
                         Quantity=2}   
                    ]
        };
                
        await _orderService.Add(order);
    }

}
