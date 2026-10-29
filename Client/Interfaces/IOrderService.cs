using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Client.Models;

namespace Client.Interfaces;

public interface IOrderService
{
    Task Add(Order order);
    Task<OrderRestDb> Find(string itemNumber);
    Task<List<Order>> List();
}
