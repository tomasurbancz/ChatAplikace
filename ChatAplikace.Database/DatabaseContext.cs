using ChatAplikace.Database.Entity;
using Microsoft.EntityFrameworkCore;

namespace ChatAplikace.Database;

public class DatabaseContext : DbContext
{
    public DbSet<ChatRoomEntity> ChatRooms { get; set; }
    public DbSet<MessageEntity> Messages { get; set; }
    public DbSet<UserEntity> Users { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlite("Data Source=ChatAplikaceDatabase.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<MessageEntity>()
            .HasOne(m => m.ChatRoom)
            .WithMany(u => u.Messages)
            .HasForeignKey(m => m.ChatRoomId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<MessageEntity>()
            .HasOne(m => m.User)
            .WithMany()
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ChatRoomEntity>()
            .HasMany(m => m.Users)
            .WithMany(m => m.ChatRooms);
    }
}