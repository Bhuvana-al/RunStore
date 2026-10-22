using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Avalonia.Controls;
using Client.Enums;
using Client.Interfaces;
using Client.Models;
using Client.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Client.ViewModels;

public partial class ProductsViewModel : ViewModelBase
{
    private readonly IProductService _productService;

    [ObservableProperty]
    public partial ObservableCollection<Product> Products {get; set; } = [];
    
    public ProductsViewModel()
    {
        _productService = new ProductServices();
        PageTitle = "Våra produkter";
        Init();
    }
    public ProductsViewModel(IProductService productService)
    {
        PageTitle = "Våra produkter";
        _productService = productService;
        //PageName = PageViewsEnum.Products;
        
        //Task.Run(() => LoadProudcts()).Wait();
        Init();
    }

    // [RelayCommand]
    // public void Edit(string id)
    // {
    //     Console.WriteLine("Ändra uppgifter, " + id);
    // }
    [RelayCommand]
    public void Delete(string id)
    {
        Console.WriteLine("Ta bort produkt, " + id);
    }
    
    private async void Init()
    {
        await LoadProducts();
    }

    private async Task LoadProducts()
    {
        // var products = ProductServices.ListAllProducts();
        // Products = new ObservableCollection<Product>(products);

        try
        {
            //var service = new ProductServices();  //hard koppling, instead replaced with IProductService
            //Products = new ObservableCollection<Product>(service.ListAllProducts());
            Products = new ObservableCollection<Product>(await _productService.List());
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
