using System.Collections.ObjectModel;
using System.Drawing;
using System.Windows.Input;
using ChatAplikace.Database.Model;
using ChatAplikace.WPF.Services.Interface;

namespace ChatAplikace.WPF.ChatView;

public class ChatViewModel : BaseViewModel
{
    private readonly INavigationService _navigationService;
    private readonly IChatHubService _chatHubService;
    private bool _canOpenChat = true;
    public ObservableCollection<ChatItem> Chats { get; set; } = new();
    public ObservableCollection<ChatMessage> Messages { get; set; } = new();
    
    private string _chatUsername;
    public string ChatUsername
    {
        get => _chatUsername;
        set
        {
            if (_chatUsername != value)
            {
                _chatUsername = value;
                OnPropertyChanged();
            }
        }
    }
    
    public ChatViewModel(INavigationService navigationService, IChatHubService chatHubService)
    {
        _navigationService = navigationService;
        _chatHubService = chatHubService;
        LoadChats();
    }

    private async Task LoadChats()
    {
        List<ChatRoomModel> chatRooms = await _chatHubService.GetChatRooms();
        chatRooms.ForEach(room =>
        {
            Chats.Add(new ChatItem(){Name = room.Name, OpenCommand = new RelayCommand(() => OpenChat(room.Id))});
        }); 
    }
    
    private async Task OpenChat(Guid id)
    {
        _canOpenChat = false;
        List<MessageModel> messages = await _chatHubService.GetMessages(id);
        ChatUsername = await _chatHubService.GetChatRoomName(id);
        Console.WriteLine(ChatUsername);
        Messages.Clear();
        string current = "Left";
        messages.ForEach(message =>
        {
            Messages.Add(new ChatMessage(){Alignment = current, Message = message.Message, BackgroundColor = "DarkGreen", Time = message.UpdatedAt.ToShortTimeString()});
            if(current.Equals("Left")) current = "Right";
            else current = "Left";
        });
        _canOpenChat = true;
    }
    
}

public class ChatItem
{
    public string Name { get; set; }
    public ICommand OpenCommand { get; set; }
}

public class ChatMessage
{
    public string Message { get; set; }
    public string Alignment { get; set; }
    public string Time { get; set; }
    public string BackgroundColor { get; set; }
}