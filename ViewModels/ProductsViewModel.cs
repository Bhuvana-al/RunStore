using System.Collections.ObjectModel;
using Client.Models;
using Client.Services;
using CommunityToolkit.Mvvm.ComponentModel;

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

    private void LoadProudcts()
    {
        // var products = ProductServices.ListAllProducts();
        // Products = new ObservableCollection<Product>(products);

        Products = new ObservableCollection<Product>(ProductServices.ListAllProducts());

        // Products = [
        //     new Product{ItemNumber="1001", Name="Gel 27", SupplierName="Asics", Price=2295},
        //     new Product{ItemNumber="1002", Name="Superblast 3", SupplierName="Asics", Price=1890}
        //  ];
    }
}
