using System;
using System.Collections.ObjectModel;
using Client.Enums;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Client.ViewModels;

public partial class ViewModelBase : ObservableObject
{
    [ObservableProperty]
    public partial string PageTitle {get; set; }= "";
}

