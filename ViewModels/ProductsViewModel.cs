using System;
using System.Collections.ObjectModel;
using Client.Models;
using Client.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Client.ViewModels;

public partial class ProductsViewModel : ViewModelBase
{
    [ObservableProperty]
    public partial ObservableCollection<Product> Products {get; set; } = [];
    public ProductsViewModel()
    {
        PageTitle = "Våra produkter";
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
            Products = new ObservableCollection<Product>(ProductServices.ListAllProducts());
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
