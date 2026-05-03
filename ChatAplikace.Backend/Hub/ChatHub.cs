using System.Collections.Concurrent;
using System.Security.Claims;
using ChatAplikace.Backend.Manager;
using ChatAplikace.Backend.Services;
using ChatAplikace.Database.Entity;
using ChatAplikace.Database.Model;
using Microsoft.AspNetCore.SignalR;

namespace ChatAplikace.Backend.Hub;

public class ChatHub : Microsoft.AspNetCore.SignalR.Hub
{
    private readonly ChatService _chatService;
    private readonly RoomService _roomService;
    private readonly UserService _userService;
    private readonly ConnectionManager _connections;
    

    public ChatHub(ChatService chatService, UserService userService, RoomService roomService, ConnectionManager connections)
    {
        _chatService = chatService;
        _userService = userService;
        _roomService = roomService;
        _connections = connections;
    }
    
    public async Task SendToRoom(Guid roomId, string message)
    {
        if (_connections.TryGetUser(Context.ConnectionId, out var userId))
        {
            var messageEntity = await _roomService.SendMessage(userId, roomId, message);
            if (messageEntity == null) return;
            await Clients.Group(roomId.ToString()).SendAsync("ReceiveMessage", messageEntity);
        }
    }

    public async Task<bool> Login(string username, string password)
    {
        var user = await _userService.Login(username, password);
        if (user == null) return false;
        _connections.Add(Context.ConnectionId, user.Id);
        return true;
    }

    public async Task<bool> Register(string username, string password)
    {
        var user = await _userService.Register(username, password);
        if (!user) return false;
        return true;
    }
    
    public async Task Logout(string connection)
    {
        _connections.Remove(connection);
    }

    public async Task<Guid> CreateRoom(string name)
    {
        if (_connections.TryGetUser(Context.ConnectionId, out var userId))
        {
            var id = await _roomService.CreateRoom(userId, name);
            await Groups.AddToGroupAsync(Context.ConnectionId, id.ToString());
            await Clients.Group(id.ToString()).SendAsync("AddedToChat");
            return id;
        }

        return Guid.Empty;
    }
    
    public async Task JoinAllRooms()
    {
        if (_connections.TryGetUser(Context.ConnectionId, out var userId))
        {
            var rooms = await _userService.GetRooms(userId);
            rooms.ForEach(async void (room) =>
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, room.Id.ToString());
            });
        }
       
    }

    public async Task<List<ChatRoomModel>> GetChatRooms()
    {
        if (_connections.TryGetUser(Context.ConnectionId, out var userId))
        {
            var rooms = await _userService.GetRooms(userId);
            List<ChatRoomModel> models = new List<ChatRoomModel>();
            rooms.ForEach(room =>
            {
                ChatRoomModel model = new ChatRoomModel() {CreatedAt = room.CreatedAt, Messages = room.Messages, UpdatedAt = room.UpdatedAt, Id = room.Id, Name = room.Name, Users = room.Users };
                models.Add(model);
            });
            return models;   
        }

        return new();
    }

    public async Task AddToRoom(Guid roomId)
    {
        
    }

    public async Task<List<MessageModel>> GetAllMessages(Guid roomId)
    {
        return await _roomService.GetAllMessages(roomId);
    }
     
    public async Task JoinRoom(Guid roomId)
    {
        if (_connections.TryGetUser(Context.ConnectionId, out var userId))
        {
            await _roomService.JoinRoom(userId, roomId);
            await Groups.AddToGroupAsync(Context.ConnectionId, roomId.ToString());
        }
    }

    public async Task AddUserToRoom(Guid userId, Guid roomId)
    {
        await _roomService.JoinRoom(userId, roomId);
        if (_connections.TryGetConnection(userId, out var connectionId))
        {
            await Groups.AddToGroupAsync(connectionId, roomId.ToString());
            await Clients.Group(roomId.ToString()).SendAsync("AddedToChat");
        }
    }

    public async Task<string> GetChatRoomName(Guid id)
    {
        return await _roomService.GetName(id);
    }
    
    public override async Task OnConnectedAsync()
    {
        await base.OnConnectedAsync();
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        await Logout(Context.ConnectionId);
        await base.OnDisconnectedAsync(exception);
    }

    public async Task<Guid> GetUserId()
    {
        if (_connections.TryGetUser(Context.ConnectionId, out var userId))
        {
            return userId;
        }
        return Guid.Empty;
    }

    public async Task<Guid> GetUserIdByName(string username)
    {
        return await _userService.GetUserId(username);
    }
}

