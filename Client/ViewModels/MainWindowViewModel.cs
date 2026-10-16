using System;
using Client.Factories;
using Client.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Client.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private readonly PageViewFactory _factory;
    // private readonly HomeViewModel _homeView;
    // private readonly ProductsViewModel _productsView;
    // private readonly OrdersViewModel _ordersView;
    // private readonly CustomersViewModel _customersView;

    [ObservableProperty]
    public partial ViewModelBase CurrentView { get; set; }
//    public MainWindowViewModel() {}

    /* public MainWindowViewModel(
            ProductsViewModel productsViewModel,
            HomeViewModel homeViewModel,
            CustomersViewModel customersViewModel,
            OrdersViewModel ordersViewModel)
    {
        _productsView = productsViewModel;
        _homeView = homeViewModel;
        _customersView = customersViewModel;
        _ordersView = ordersViewModel;

        CurrentView = _homeView;
    } */

    public MainWindowViewModel() {}
    public MainWindowViewModel(PageViewFactory factory)
    {
        _factory = factory;
        GoToHome();
    }

    [RelayCommand] //GoToHomeCommand
    private void GoToHome() => CurrentView = _factory.LoadPageViewModel(Helpers.ApplicationNameEnum.Home);
    [RelayCommand] //GoToProductsCommand
    //private void GoToProducts() => CurrentView =_productsView;
    private void GoToProducts() => CurrentView = _factory.LoadPageViewModel(Helpers.ApplicationNameEnum.Products);
    [RelayCommand]
    private void GoToOrders() => CurrentView = _factory.LoadPageViewModel(Helpers.ApplicationNameEnum.Orders);
    [RelayCommand]
    private void GoToCustomers() => CurrentView = _factory.LoadPageViewModel(Helpers.ApplicationNameEnum.Customers);
}
