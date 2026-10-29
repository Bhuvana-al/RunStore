using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Avalonia.Controls;
using Client.Enums;
using Client.Interfaces;
using Client.Models;
using Client.Services;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Client.ViewModels;

public partial class OrdersViewModel : ViewModelBase
{
    private readonly IOrderService _orderService;

    [ObservableProperty]
    public partial ObservableCollection<Order> Orders {get; set; } = [];
    
    public OrdersViewModel()
    {
        _orderService = new OrderServices();
        PageTitle = "Beställningar";
        Init();
    }
    public OrdersViewModel(IOrderService orderService)
    {
        PageTitle = "Beställningar";
        _orderService = orderService;
        Init();
    }

    private async void Init()
    {
        await LoadOrders();
    }

    private async Task LoadOrders()
    {
        try
        {
            Orders = new ObservableCollection<Order>(await _orderService.List());
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

}
