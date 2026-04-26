using ChatAplikace.WPF.Services.Interface;

namespace ChatAplikace.WPF.ChatView;

public class ChatViewModel : BaseViewModel
{
    private readonly INavigationService _navigationService;
    private readonly IChatHubService _chatHubService;

    public ChatViewModel(INavigationService navigationService, IChatHubService chatHubService)
    {
        _navigationService = navigationService;
        _chatHubService = chatHubService;
    }
}