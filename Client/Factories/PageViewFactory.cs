using System;
using Client.Enums;
using Client.Helpers;
using Client.Interfaces;
using Client.Services;
using Client.ViewModels;

namespace Client.Factories;

// public class PageViewFactory (Func<PageViewsEnum, PageViewModel> pageFactory) : IPageViewFactory
// {
//     public PageViewModel LoadPageViewModel(PageViewsEnum pageName) => pageFactory.Invoke(pageName);
// }

public class PageViewFactory : IPageViewFactory
{
    public ViewModelBase LoadPageViewModel(PageViewsEnum page)
    {
        return page switch
        {
            PageViewsEnum.Home => new HomeViewModel(),
            PageViewsEnum.Products => new ProductsViewModel(new ProductServices()),
            PageViewsEnum.Customers => new CustomersViewModel(new CustomerServices()),
            PageViewsEnum.Orders => new OrdersViewModel(),
            PageViewsEnum.AddProduct => new AddProductViewModel(),
            _ => throw new InvalidOperationException("Det fanns inte det du ville ha"),
        };
    }

    public ViewModelBase LoadPageViewModel(PageViewsEnum page, string itemNumber)
    {
        return page switch
        {
            PageViewsEnum.EditProduct => new EditProductViewModel(new ProductServices(),itemNumber),
            _ => throw new InvalidOperationException("Det fanns inte det du ville ha")
        };
    }
}