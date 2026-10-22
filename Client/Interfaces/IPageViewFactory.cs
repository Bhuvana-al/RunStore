using System;
using Client.Enums;
using Client.Helpers;
using Client.ViewModels;

namespace Client.Interfaces;

public interface IPageViewFactory
{
    //PageViewModel LoadPageViewModel(PageViewsEnum pageName);
    ViewModelBase LoadPageViewModel(PageViewsEnum page);
}
