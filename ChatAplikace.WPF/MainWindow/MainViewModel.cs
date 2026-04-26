using ChatAplikace.WPF.Services;
using ChatAplikace.WPF.Services.Interface;

namespace ChatAplikace.WPF;

public class MainViewModel : BaseViewModel
{
    private object _currentViewModel;
    public object CurrentViewModel
    {
        get => _currentViewModel;
        set
        {
            _currentViewModel = value;
            OnPropertyChanged();
        }
    }

    private IChatHubService _chatHubService;
    
    public MainViewModel(IChatHubService chatHubService)
    {
        _chatHubService = chatHubService;
    }

    public async Task Connect()
    {
        await _chatHubService.StartAsync();
    }
    
    public void NavigateToLogin()
    {
        CurrentViewModel = new LoginViewModel(new NavigationService(this), _chatHubService);
    }
}