using ChatAplikace.Database.Entity;

namespace ChatAplikace.Backend.Services;

public interface IChatService
{
    Task SaveMessage(Guid userId, Guid roomId, string message);
    
}