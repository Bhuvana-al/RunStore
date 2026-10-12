using System;
using System.Collections.Generic;
using Client.Interfaces;
using Client.Models;
using Client.Repositories;

namespace Client.Services;

public class ProductServices : IProductService
{
    //static string path = string.Concat(Environment.CurrentDirectory,"/Data/products.json");
    //static Storage<Product> storage = new();
    public List<Product> List()
    {
        //StoreProducts(new Product{ItemNumber="1010", Name="Testitem", Description="Test write", SupplierName="Asics", Price=2295});
        var storage = new Storage<Product>();
        var path = string.Concat(Environment.CurrentDirectory,"/Data/products.json");
        var products = storage.Read(path);
        
        return products;

        // return [
        //     new Product{ItemNumber="1001", Name="Gel 27", SupplierName="Asics", Price=2295},
        //     new Product{ItemNumber="1002", Name="Superblast 3", SupplierName="Asics", Price=1890}
        // ];
    }
    // public static void StoreProducts(Product item)
    // {
    //     var products = storage.Read(path);
    //     products.Add((Product)item);
    //     storage.Write(path, products);
    // }

    public class ProductServicesFromDb : IProductService
    {
        public List<Product> List()
        {
            throw new NotImplementedException();
        }
    }
}
