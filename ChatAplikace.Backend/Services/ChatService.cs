using ChatAplikace.Database;
using ChatAplikace.Database.Entity;

namespace ChatAplikace.Backend.Services;

public class ChatService : IChatService
{
    private readonly DatabaseContext _databaseContext;
    
    public ChatService(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }
    
    public async Task SaveMessage(Guid userId, Guid roomId, string message)
    {
        MessageEntity messageEntity = new MessageEntity()
        {
            UserId = userId,
            ChatRoomId = roomId,
            Message = message
        };
        await _databaseContext.Messages.AddAsync(messageEntity);
        await _databaseContext.SaveChangesAsync();
    }
}