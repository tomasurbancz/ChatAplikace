using ChatAplikace.Database.Entity;
using ChatAplikace.Database.Model.Base;

namespace ChatAplikace.Database.Model;

public class MessageModel : BaseModel
{
    public Guid UserId { get; set; }
    public UserEntity User { get; set; }
    
    public Guid ChatRoomId { get; set; }
    public ChatRoomEntity ChatRoom { get; set; }
    
    public string Message { get; set; }
}