using System.Collections.ObjectModel;
using System.Windows.Input;
using ChatAplikace.WPF.Services.Interface;

namespace ChatAplikace.WPF.ChatView;

public class ChatViewModel : BaseViewModel
{
    private readonly INavigationService _navigationService;
    private readonly IChatHubService _chatHubService;
    private bool _canOpenChat = true;
    public ObservableCollection<ChatItem> Chats { get; set; } = new();
    
    public ChatViewModel(INavigationService navigationService, IChatHubService chatHubService)
    {
        _navigationService = navigationService;
        _chatHubService = chatHubService;
        Chats.Add(new ChatItem(){Name = "Chatik", OpenCommand = new RelayCommand(OpenChat, () => _canOpenChat)});
        Chats.Add(new ChatItem(){Name = "Chatik", OpenCommand = new RelayCommand(OpenChat, () => _canOpenChat)});
        Chats.Add(new ChatItem(){Name = "Chatik", OpenCommand = new RelayCommand(OpenChat, () => _canOpenChat)});
        Chats.Add(new ChatItem(){Name = "Chatik", OpenCommand = new RelayCommand(OpenChat, () => _canOpenChat)});
        Chats.Add(new ChatItem(){Name = "Chatik", OpenCommand = new RelayCommand(OpenChat, () => _canOpenChat)});
        Chats.Add(new ChatItem(){Name = "Chatik", OpenCommand = new RelayCommand(OpenChat, () => _canOpenChat)});
        Chats.Add(new ChatItem(){Name = "Chatik", OpenCommand = new RelayCommand(OpenChat, () => _canOpenChat)});
        Chats.Add(new ChatItem(){Name = "Chatik", OpenCommand = new RelayCommand(OpenChat, () => _canOpenChat)});
        Chats.Add(new ChatItem(){Name = "Chatik", OpenCommand = new RelayCommand(OpenChat, () => _canOpenChat)});
        
    }
    private async Task OpenChat()
    {
        // logika otevření chatu
    }
    
}

public class ChatItem
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public ICommand OpenCommand { get; set; }
}