using System.ComponentModel.DataAnnotations.Schema;
using ChatAplikace.Database.Entity.Base;

namespace ChatAplikace.Database.Entity;

[Table("ChatRoom")]
public class ChatRoomEntity : BaseEntity
{
    public string Name { get; set; }
    public List<UserEntity> Users { get; set; } = new();
    public List<MessageEntity> Messages { get; set; } = new();
}