using System;

namespace Client.Models;

public class Item 
{
    public required Product Product { get; set; }
    public int Quantity { get; set; }
    public int LineSum
    {   
        get
        {
            return Product.Price * Quantity;
        }
    }
}
