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
using HarfBuzzSharp;

namespace Client.ViewModels;

public partial class ProductsViewModel : ViewModelBase
{
    private readonly IProductService _productService;

    [ObservableProperty]
    public partial bool ShowDialog {get; set;}
    [ObservableProperty]
    public partial ObservableCollection<Product> Products {get; set; } = [];
    
    public ProductsViewModel()
    {
        _productService = new ProductServices();
        PageTitle = "Våra produkter";
        ShowDialog = false;
        Init();
    }
    public ProductsViewModel(IProductService productService)
    {
        PageTitle = "Våra produkter";
        _productService = productService;
        ShowDialog = false;
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
    public async Task Delete(string id)
    {
        try
        {
            ShowDialog = true;

            // ProductRestDb product = await _productService.Find(id);
            // if (product is not null)
            // {
            //     await _productService.Delete(product._id);
            //     await LoadProducts();
            // }
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    
    private async void Init()
    {
        await LoadProducts();
    }

    [RelayCommand]
    private void Confirm()
    {
        Console.WriteLine("Tar bort produkten");
        ShowDialog = false;
    }
    
    [RelayCommand]
    private void Cancel()
    {
        Console.WriteLine("Jasååå, du ångrar dig, fegis!");
        ShowDialog = false;
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
