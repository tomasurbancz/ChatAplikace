using System.Windows.Input;
using ChatAplikace.WPF.ChatView;
using ChatAplikace.WPF.Services.Interface;

namespace ChatAplikace.WPF;

public class LoginViewModel : BaseViewModel
{
    private readonly INavigationService _navigationService;
    private readonly IChatHubService _chatHubService;
    public string Username { get; set; }
    public string Password { get; set; }
    public ICommand LoginCommand { get; }
    private bool _isBusy;
    private Timer _errorHide;
    private string _errorVisibility;
    public string ErrorVisibility
    {
        get => _errorVisibility;
        set
        {
            _errorVisibility = value;
            OnPropertyChanged();
        }
    }


    public LoginViewModel(INavigationService navigationService, IChatHubService chatHubService)
    {
        _navigationService = navigationService;
        _chatHubService = chatHubService;
        LoginCommand = new RelayCommand(Login, () => !_isBusy);
        ErrorVisibility = "Hidden";
        _errorHide = new Timer((_) =>
        {
            ErrorVisibility = "Visible";
        });
    }

    public async Task Login()
    {
        _isBusy = true;
        Console.WriteLine($"Username: {Username}, Password: {Password}");
        bool success = await _chatHubService.Login(Username.Trim(), Password.Trim());
        if (success)
        {
            _navigationService.Navigate(new ChatViewModel(_navigationService, _chatHubService));
        }
        else
        {
            ErrorVisibility = "Visible";
            await Task.Delay(1000);
            ErrorVisibility = "Hidden";
        }
        _isBusy = false;
    }
}