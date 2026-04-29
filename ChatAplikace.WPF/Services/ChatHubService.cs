using ChatAplikace.Database.Model;
using ChatAplikace.WPF.Services.Interface;
using Microsoft.AspNetCore.SignalR.Client;

namespace ChatAplikace.WPF.Services;

public class ChatHubService : IChatHubService
{
    public HubConnection Connection { get; private set; }

        public ChatHubService()
        {
            Connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:5099/chatHub")
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
    
    public async Task<bool> Login(string username, string password)
    {
        return await Connection.InvokeAsync<bool>("Login", username, password);   
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
}