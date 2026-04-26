using ChatAplikace.WPF.Services.Interface;

namespace ChatAplikace.WPF.Services;

public class NavigationService : INavigationService
{
    public MainViewModel MainViewModel { get; }

    public NavigationService(MainViewModel main)
    {
        MainViewModel = main;
    }

    public void Navigate(object viewModel)
    {
        MainViewModel.CurrentViewModel = viewModel;
    }
}