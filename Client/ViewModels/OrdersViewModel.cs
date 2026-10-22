using System;
using Avalonia.Controls;
using Client.Enums;

namespace Client.ViewModels;

public partial class OrdersViewModel : PageViewModel
{
    public OrdersViewModel()
    {
        PageName = PageViewsEnum.Orders;
    }
}
