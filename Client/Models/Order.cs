using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Client.Models;

public class Order
{
    public string OrderId { get; set; } = Guid.NewGuid().ToString().Replace("-", "");
    public DateTime OrderDate {get; set; } = DateTime.Now;
    public required Customer Customer  {get; set; }
    public required List<Item> Items { get; set; }
    public int OrderValue 
    {
        get
        {
            return Items.Sum(c => c.LineSum);
        }
    }
}
