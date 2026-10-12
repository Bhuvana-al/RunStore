using System;
using System.Collections.ObjectModel;
using Client.Interfaces;
using Client.Models;
using Client.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Client.ViewModels;

public partial class ProductsViewModel : ViewModelBase
{
    private IProductService _service;

    [ObservableProperty]
    public partial ObservableCollection<Product> Products {get; set; } = [];
    public ProductsViewModel(IProductService service)
    {
        PageTitle = "Våra produkter";
        _service = service;
        LoadProudcts();
    }
    // [RelayCommand]
    // public void Edit()
    // {
    //     Console.WriteLine("Ändra uppgifter");
    // }
    // [RelayCommand]
    // public void Delete()
    // {
    //     Console.WriteLine("Ta bort produkt");
    // }
    private void LoadProudcts()
    {
        // var products = ProductServices.ListAllProducts();
        // Products = new ObservableCollection<Product>(products);

        try
        {
            //var service = new ProductServices();  //hard koppling, instead replaced with IProductService
            //Products = new ObservableCollection<Product>(service.ListAllProducts());
            Products = new ObservableCollection<Product>(_service.List());
        }
        catch(Exception ex)
        {
            // Byts ut till en tjusig popup senare...
            Console.WriteLine(ex.Message);
        }
        // Products = [
        //     new Product{ItemNumber="1001", Name="Gel 27", SupplierName="Asics", Price=2295},
        //     new Product{ItemNumber="1002", Name="Superblast 3", SupplierName="Asics", Price=1890}
        //  ];
    }
}
