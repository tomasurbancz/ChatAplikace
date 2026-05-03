using ChatAplikace.Database.Model;

namespace ChatAplikace.WFA.Services.Interface;

public interface IChatHubService
{
    Task StartAsync();
    Task JoinAllRooms();
    Task JoinToRoom(Guid id);
    Task SendToRoom(Guid id, string message);
    Task ListenToMessages(Action<MessageModel> callback);
    Task ListenToRoomAdded(Action callback);
    Task<bool> Login(string username, string password);
    Task<bool> Register(string username, string password);
    Task SendMessage(string message);
    Task<List<MessageModel>> GetMessages(Guid id);
    Task<string> GetChatRoomName(Guid id);
    Task<List<ChatRoomModel>> GetChatRooms();
    Task<Guid> GetUserId();
    Task<Guid> GetUserIdByName(string username);
    Task<Guid> CreateRoom(string name);
    Task AddUserToRoom(Guid id, Guid roomId);
    Task StartTyping(Guid roomId);
    Task EndTyping(Guid roomId);
    Task ListenToStartTyping(Action<Guid, Guid> callback);
    Task ListenToEndTyping(Action<Guid> callback);
}