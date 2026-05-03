using ChatAplikace.Database.Entity;

namespace ChatAplikace.Backend.Services;

public interface IUserService
{
    Task<List<ChatRoomEntity>> GetRooms(Guid userId);
    Task<UserEntity?> Login(string username, string password);
    Task<bool> Register(string username, string password);
    Task<Guid> GetUserId(string username);
}