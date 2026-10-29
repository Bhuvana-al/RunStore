using System;
using Avalonia.Controls;
using Client.Enums;
using Client.Factories;
using Client.Interfaces;
using Client.Services;
using Client.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace Client.Helpers;

public static class ServiceCollectionExtensions
{
    // Syftet är att skapa en metod som lägger till tjänser services
    // i ServiceCollection objektet. Som vi fått via Microsoft.Extensions.DependencyInjection...
    public static void AddServices(this IServiceCollection collection)
    {
        // Om någon efterfrågar interface IProductService så ger
        // vi dem en instans av KalleAnka objektet...
        collection.AddSingleton<MainWindowViewModel>();
        collection.AddSingleton<PageViewFactory>();
        collection.AddTransient<HomeViewModel>();
        collection.AddTransient<ProductsViewModel>();
        collection.AddTransient<CustomersViewModel>();
        collection.AddTransient<IProductService, ProductServices>();
        collection.AddTransient<ICustomerService, CustomerServices>();
        collection.AddTransient<OrdersViewModel>();
        collection.AddTransient<AddOrderViewModel>();
        collection.AddTransient<IOrderService, OrderServices>();
    }
}

// public static class ServiceCollectionExtensions
// {
//     public static void AddServices(this IServiceCollection collection)
//     {
//         // collection.AddSingleton<MainViewModel>();
//         // collection.AddTransient<IProductService, ProductServices>();
//         collection.AddSingleton<MainWindowViewModel>();
//         collection.AddSingleton<PageViewFactory>();
//         collection.AddTransient<HomeViewModel>();
//         collection.AddTransient<CustomersViewModel>();
//         collection.AddTransient<ProductsViewModel>();
//         collection.AddTransient<OrdersViewModel>();
//         collection.AddTransient<AddProductViewModel>();
//         collection.AddTransient<IProductService, ProductServices>(); //dependency injection
//         collection.AddTransient<ICustomerService, CustomerServices>();

//         // Michael moved below portion to PageViewFactory in Lektion 23/RunStore
//         collection.AddSingleton<Func<PageViewsEnum, PageViewModel>>(c => name => name switch
//         {
//             PageViewsEnum.Home => c.GetRequiredService<HomeViewModel>(),
//             PageViewsEnum.Customers => c.GetRequiredService<CustomersViewModel>(),
//             PageViewsEnum.Orders => c.GetRequiredService<OrdersViewModel>(),
//             PageViewsEnum.Products => c.GetRequiredService<ProductsViewModel>(),
//             PageViewsEnum.AddProduct => c.GetRequiredService<AddProductViewModel>(),
//               _ => throw new InvalidOperationException("Det fanns inte det du ville ha")
//         });
//     }
// }
