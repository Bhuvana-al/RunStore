using System;
using Client.Enums;
using Client.Factories;
using Client.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Client.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private readonly PageViewFactory _pageViewFactory;
    //private readonly AddProductViewModel _addProductVM = new();
    
    // private readonly HomeViewModel _homeView;
    // private readonly ProductsViewModel _productsView;
    // private readonly OrdersViewModel _ordersView;
    // private readonly CustomersViewModel _customersView;

    [ObservableProperty]
    public partial ViewModelBase CurrentView { get; set; } = new();
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

    //public MainWindowViewModel() {}
    public MainWindowViewModel(PageViewFactory pageViewFactory)
    {
        _pageViewFactory = pageViewFactory;
        GoToHome();
    }

    [RelayCommand] //GoToHomeCommand
    private void GoToHome() => CurrentView = _pageViewFactory.LoadPageViewModel(Enums.PageViewsEnum.Home);
    [RelayCommand] //GoToProductsCommand
    //private void GoToProducts() => CurrentView =_productsView;
    private void GoToProducts() => CurrentView = _pageViewFactory.LoadPageViewModel(Enums.PageViewsEnum.Products);
    [RelayCommand]
    private void GoToOrders() => CurrentView = _pageViewFactory.LoadPageViewModel(Enums.PageViewsEnum.Orders);
    [RelayCommand]
    private void GoToCustomers() => CurrentView = _pageViewFactory.LoadPageViewModel(Enums.PageViewsEnum.Customers);
    [RelayCommand]
    private void GoToAddProduct() => CurrentView = _pageViewFactory.LoadPageViewModel(Enums.PageViewsEnum.AddProduct);
    [RelayCommand]
    private void GoToEditProduct(string ItemNumber) => CurrentView = _pageViewFactory.LoadPageViewModel(Enums.PageViewsEnum.EditProduct, ItemNumber);
    
}
