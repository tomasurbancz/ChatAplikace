using ChatAplikace.Backend.Hub;
using ChatAplikace.Backend.Manager;
using ChatAplikace.Backend.Services;
using ChatAplikace.Database;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowWpf", policy =>
    {
        policy
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials()
            .SetIsOriginAllowed(_ => true); // pro dev
    });
});
builder.Services.AddSignalR();
builder.Services.AddDbContext<DatabaseContext>();
builder.Services.AddScoped<ChatService>();
builder.Services.AddScoped<RoomService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddSingleton<ConnectionManager>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseCors("AllowWpf");

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
    db.Database.Migrate();
}

app.MapHub<ChatHub>("/chatHub");

app.Run();