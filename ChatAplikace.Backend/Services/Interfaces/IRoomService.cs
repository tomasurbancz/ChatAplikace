using ChatAplikace.Database.Entity;
using ChatAplikace.Database.Model;

namespace ChatAplikace.Backend.Services;

public interface IRoomService
{
    Task CreateRoom(Guid userId, string roomName);
    Task JoinRoom(Guid userId, Guid roomId);
    Task LeaveRoom(Guid userId, Guid roomId);
    Task<MessageModel?> SendMessage(Guid userId, Guid roomId, string message);
    Task<List<MessageEntity>> GetAllMessages(Guid roomId);
}