using System;
using System.Threading.Tasks;
using Avalonia.Controls;
using Client.Enums;
using Client.Interfaces;
using Client.Models;
using Client.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Client.ViewModels;

public partial class AddProductViewModel : ViewModelBase
{
    private readonly IProductService _productService;

    [ObservableProperty]
    public partial string ItemNumber { get; set; } = string.Empty;
    [ObservableProperty]
    public partial string ProductName { get; set; } = string.Empty;
    [ObservableProperty]
    public partial string Description { get; set; } = string.Empty;
    [ObservableProperty]
    public partial string Supplier { get; set; } = string.Empty;
    [ObservableProperty]
    public partial int Price { get; set; }

// Endast for design och preview hantering
// TODO: Ta bort när allt fungerar
public AddProductViewModel()
    {
        _productService = new ProductServices();
        PageTitle = "Ny Produkt";
    }
/**********************************/
public AddProductViewModel(IProductService productService)
    {
        //PageName = PageViewsEnum.AddProduct;
        PageTitle = "Ny Produkt";
        _productService = productService;
        //Task.Run(()=> LoadCustomers()).Wait();
        //Init();
    }
    [RelayCommand]
    private async Task Save()
    {
        // Behöver eventuellt göra validering här...
        Product product = new()
        {
            ItemNumber = ItemNumber,
            Name = ProductName,
            SupplierName = Supplier,
            ImageUrl = "Bild saknas",
            Description = "Ny produkt",
            Price = Price
        };

        //await _productService.Add(product);
        ClearData();
    }

    private void ClearData()
    {
        ItemNumber = string.Empty;
        ProductName = string.Empty;
        //Description = string.Empty;
        Supplier = string.Empty;
        Price = 0;
    }
}
