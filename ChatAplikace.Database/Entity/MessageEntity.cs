using System.ComponentModel.DataAnnotations.Schema;
using ChatAplikace.Database.Entity.Base;

namespace ChatAplikace.Database.Entity;

[Table("Message")]
public class MessageEntity : BaseEntity
{
    public Guid UserId { get; set; }
    public UserEntity User { get; set; }
    
    public Guid ChatRoomId { get; set; }
    public ChatRoomEntity ChatRoom { get; set; }
    
    public string Message { get; set; }
}