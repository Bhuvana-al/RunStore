using System;
using Client.Interfaces;
using Client.Services;
using Client.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace Client.Helpers;

public static class ServiceCollectionExtensions
{
    public static void AddServices(this IServiceCollection collection)
    {
        // collection.AddSingleton<MainViewModel>();
        // collection.AddTransient<IProductService, ProductServices>();
        collection.AddSingleton<MainWindowViewModel>();
        collection.AddTransient<HomeViewModel>();
        collection.AddTransient<CustomersViewModel>();
        collection.AddTransient<ProductsViewModel>();
        collection.AddTransient<OrdersViewModel>();
        collection.AddTransient<IProductService, ProductServices>(); //dependency injection
        collection.AddTransient<ICustomerService, CustomerServices>();
    }
}
