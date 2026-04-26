using System.Collections.Concurrent;
using ChatAplikace.Backend.Manager;
using ChatAplikace.Backend.Services;
using ChatAplikace.Database.Entity;
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

    public async Task CreateRoom(string name)
    {
        if (_connections.TryGetUser(Context.ConnectionId, out var userId))
        {
            await _roomService.CreateRoom(userId, name);
        }
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

    public async Task AddToRoom(Guid roomId)
    {
        
    }
     
    public async Task JoinRoom(Guid roomId)
    {
        if (_connections.TryGetUser(Context.ConnectionId, out var userId))
        {
            await _roomService.JoinRoom(userId, roomId);
            await Groups.AddToGroupAsync(Context.ConnectionId, roomId.ToString());
        }
        //await Clients.Group(roomId).SendAsync("SystemMessage", $"{Context.ConnectionId} joined {roomId}");
    }
    
    public override async Task OnConnectedAsync()
    {
        await base.OnConnectedAsync();
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        Logout(Context.ConnectionId);
        await base.OnDisconnectedAsync(exception);
    }
}

