using System.Windows.Input;
using ChatAplikace.WPF.Services.Interface;

namespace ChatAplikace.WPF;

public class LoginViewModel : BaseViewModel
{
    private readonly INavigationService _nav;
    private readonly IChatHubService _chatHubService;
    public string Username { get; set; }
    public string Password { get; set; }
    public ICommand LoginCommand { get; }
    public bool IsBusy { get; set; }
    

    public LoginViewModel(INavigationService nav, IChatHubService chatHubService)
    {
        _nav = nav;
        _chatHubService = chatHubService;
        LoginCommand = new RelayCommand(Login, () => !IsBusy);
    }

    public async Task Login()
    {
        IsBusy = true;
        Console.WriteLine("SUCCESS LOGIN? " + (await _chatHubService.Login(Username, Password)));
        IsBusy = false;
    }
}