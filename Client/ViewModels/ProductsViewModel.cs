using System;
using System.Collections.ObjectModel;
using System.Linq;
using Avalonia.Controls;
using Client.Interfaces;
using Client.Models;
using Client.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Client.ViewModels;

public partial class ProductsViewModel : PageViewModel
{
    private IProductService _service;

    [ObservableProperty]
    public partial ObservableCollection<Product> Products {get; set; } = [];
    public ProductsViewModel(IProductService service)
    {
        PageTitle = "Våra produkter";
        _service = service;
        PageName = Helpers.ApplicationNameEnum.Products;
        LoadProudcts();
    }
    [RelayCommand]
    public void Edit(string id)
    {
        Console.WriteLine("Ändra uppgifter, " + id);
    }
    [RelayCommand]
    public void Delete(string id)
    {
        Console.WriteLine("Ta bort produkt, " + id);
    }
    private void LoadProudcts()
    {
        // var products = ProductServices.ListAllProducts();
        // Products = new ObservableCollection<Product>(products);

        try
        {
            //var service = new ProductServices();  //hard koppling, instead replaced with IProductService
            //Products = new ObservableCollection<Product>(service.ListAllProducts());
            Products = new ObservableCollection<Product>(_service.List());
            //Products.Contains(x => x.Name =="Nisse"); delegate
            //Products.First(c => c.ItemNumber == "1001");
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
