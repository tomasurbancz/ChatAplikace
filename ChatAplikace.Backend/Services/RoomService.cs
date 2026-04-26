using ChatAplikace.Database;
using ChatAplikace.Database.Entity;
using ChatAplikace.Database.Model;
using Microsoft.EntityFrameworkCore;

namespace ChatAplikace.Backend.Services;

public class RoomService : IRoomService
{
    private readonly DatabaseContext _databaseContext;

    public RoomService(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }
    
    public async Task CreateRoom(Guid userId, string roomName)
    {
        var user = await _databaseContext.Users.FindAsync(userId);
        if (user == null) return;
        
        var chatRoom = new ChatRoomEntity()
        {
            Name = roomName,
            Users = [user]
        };
        await _databaseContext.ChatRooms.AddAsync(chatRoom);
        await _databaseContext.SaveChangesAsync();
    }

    public async Task JoinRoom(Guid userId, Guid roomId)
    {
        var chatRoom = await _databaseContext.ChatRooms.Include(u => u.Users).FirstOrDefaultAsync(r => r.Id == roomId);
        if (chatRoom == null) return;
        var user = await _databaseContext.Users.FindAsync(userId);
        if (user == null) return;
        chatRoom.Users.Add(user);
        await _databaseContext.SaveChangesAsync();
    }

    public async Task LeaveRoom(Guid userId, Guid roomId)
    {
        var chatRoom = await _databaseContext.ChatRooms.Include(u => u.Users).FirstOrDefaultAsync(r => r.Id == roomId);
        if (chatRoom == null) return;
        var user = await _databaseContext.Users.FindAsync(userId);
        if (user == null) return;
        chatRoom.Users.Remove(user);
        await _databaseContext.SaveChangesAsync();
    }

    public async Task<MessageModel?> SendMessage(Guid userId, Guid roomId, string message)
    {
        var user = await _databaseContext.Users.FindAsync(userId);
        if(user == null) return null;
        var chatRoom = await _databaseContext.ChatRooms.FindAsync(roomId);
        if (chatRoom == null) return null;
        if(string.IsNullOrWhiteSpace(message)) return null;
        var messageEntity = new MessageEntity()
        {
            Message = message,
            UserId = userId,
            ChatRoomId = roomId
        };
        chatRoom.Messages.Add(messageEntity);
        await _databaseContext.Messages.AddAsync(messageEntity);
        await _databaseContext.SaveChangesAsync();
        var messageModel = new MessageModel()
        {
            Message = messageEntity.Message,
            UserId = messageEntity.UserId,
            ChatRoomId = messageEntity.ChatRoomId,
            CreatedAt = messageEntity.CreatedAt,
            UpdatedAt = messageEntity.UpdatedAt,
            Id = messageEntity.Id
        };
        return messageModel;
    }

    public async Task<List<MessageEntity>> GetAllMessages(Guid roomId)
    {
        return await _databaseContext.Messages.Where(m => m.ChatRoomId == roomId).ToListAsync();
    }
}