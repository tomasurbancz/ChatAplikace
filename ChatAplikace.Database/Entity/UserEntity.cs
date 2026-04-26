using System.ComponentModel.DataAnnotations.Schema;
using ChatAplikace.Database.Entity.Base;

namespace ChatAplikace.Database.Entity;

[Table("User")]
public class UserEntity : BaseEntity
{
    public string Username { get; set; }
    public string PasswordHash { get; set; }
    public bool Online { get; set; }

    public List<ChatRoomEntity> ChatRooms { get; set; } = new();
}