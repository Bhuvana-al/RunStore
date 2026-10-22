using System;
using Client.Enums;
using Client.Helpers;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Client.ViewModels;

public partial class PageViewModel : ViewModelBase
{
    [ObservableProperty]
    public partial PageViewsEnum PageName { get; set; }
}

