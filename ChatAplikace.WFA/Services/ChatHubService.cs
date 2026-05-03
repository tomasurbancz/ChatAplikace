using ChatAplikace.Database.Model;
using ChatAplikace.WFA.Services.Interface;
using Microsoft.AspNetCore.SignalR.Client;

namespace ChatAplikace.WFA.Services;

public class ChatHubService : IChatHubService
{
    public HubConnection Connection { get; private set; }

    public ChatHubService()
    {
        Connection = new HubConnectionBuilder()
            .WithUrl("http://obscure-halibut-rqqjw67xp7w257w9-5099.app.github.dev/chatHub")
            .WithAutomaticReconnect()
            .Build();
    }

    public async Task StartAsync()
    {
        if (Connection.State == HubConnectionState.Disconnected)
            await Connection.StartAsync();
    }

    public async Task JoinAllRooms()
    {
        await Connection.InvokeAsync("JoinAllRooms");
    }

    public async Task JoinToRoom(Guid id)
    {
        await Connection.InvokeAsync("JoinRoom", id);
    }

    public async Task SendToRoom(Guid id, string message)
    {
        await Connection.InvokeAsync("SendToRoom", id, message);

    }

    public async Task ListenToMessages(Action<MessageModel> callback)
    {
        Connection.On<MessageModel>("ReceiveMessage", callback);
    }

    public async Task ListenToRoomAdded(Action callback)
    {
        Connection.On("AddedToChat", callback);
    }

    public async Task ListenToStartTyping(Action<Guid, Guid> callback)
    {
        Connection.On("StartedTyping", callback);
    }

    public async Task ListenToEndTyping(Action<Guid> callback)
    {
        Connection.On("EndedTyping", callback);
    }
    
    public async Task<bool> Login(string username, string password)
    {
        return await Connection.InvokeAsync<bool>("Login", username, password);   
    }

    public async Task<bool> Register(string username, string password)
    {
        return await Connection.InvokeAsync<bool>("Register", username, password);
    }

    public async Task SendMessage(string message)
    {
        await Connection.InvokeAsync("SendMessage", message);
    }

    public async Task<List<MessageModel>> GetMessages(Guid id)
    {
        return await Connection.InvokeAsync<List<MessageModel>>("GetAllMessages", id);
    }

    public async Task<string> GetChatRoomName(Guid id)
    {
        return await Connection.InvokeAsync<string>("GetChatRoomName", id);
    }

    public async Task<List<ChatRoomModel>> GetChatRooms()
    {
        return await Connection.InvokeAsync<List<ChatRoomModel>>("GetChatRooms");
    }

    public async Task<Guid> GetUserId()
    {
        return await Connection.InvokeAsync<Guid>("GetUserId");
    }

    public async Task<Guid> GetUserIdByName(string username)
    {
        return await Connection.InvokeAsync<Guid>("GetUserIdByName", username);
    }

    public async Task<Guid> CreateRoom(string name)
    {
        return await Connection.InvokeAsync<Guid>("CreateRoom", name);
    }

    public async Task AddUserToRoom(Guid id, Guid roomId)
    {
        await Connection.InvokeAsync("AddUserToRoom", id, roomId);
    }

    public async Task StartTyping(Guid roomId)
    {
        await Connection.InvokeAsync("StartTyping", roomId);
    }

    public async Task EndTyping(Guid roomId)
    {
        await Connection.InvokeAsync("EndTyping", roomId);
    }
}