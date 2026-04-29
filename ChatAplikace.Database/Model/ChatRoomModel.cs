using ChatAplikace.Database.Entity;
using ChatAplikace.Database.Model.Base;

namespace ChatAplikace.Database.Model;

public class ChatRoomModel : BaseModel
{
    public string Name { get; set; }
    public List<UserEntity> Users { get; set; } = new();
    public List<MessageEntity> Messages { get; set; } = new();
}