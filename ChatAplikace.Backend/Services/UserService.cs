using ChatAplikace.Database;
using ChatAplikace.Database.Entity;
using Microsoft.EntityFrameworkCore;

namespace ChatAplikace.Backend.Services;

public class UserService : IUserService
{
    private readonly DatabaseContext _databaseContext;

    public UserService(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }
    
    public async Task<List<ChatRoomEntity>> GetRooms(Guid userId)
    {
        return await _databaseContext.ChatRooms.Where(r => r.Users.Any(u => u.Id == userId)).ToListAsync();
    }

    public async Task<UserEntity?> Login(string username, string password)
    {
        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            return null;

        var user = await _databaseContext.Users.FirstOrDefaultAsync(u => u.Username == username);
        if (user == null) return null;
        if (!BCrypt.Net.BCrypt.Verify(password, user.PasswordHash)) return null;
        return user;
    }

    public async Task<bool> Register(string username, string password)
    {
        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            return false;

        var exists = await _databaseContext.Users.AnyAsync(u => u.Username == username);
        if (exists) return false;
        var user = new UserEntity()
        {
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(password),
            Online = false,
            Username = username
        };
        await _databaseContext.Users.AddAsync(user);
        await _databaseContext.SaveChangesAsync();
        return true;
    }
}