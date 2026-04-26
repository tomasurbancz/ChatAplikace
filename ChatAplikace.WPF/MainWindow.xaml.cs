using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ChatAplikace.Database.Entity;
using ChatAplikace.Database.Model;
using Microsoft.AspNetCore.SignalR.Client;

namespace ChatAplikace.WPF;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        Load();
    }

    private async Task Load()
    {
        HubConnection connection = new HubConnectionBuilder()
            .WithUrl("http://localhost:5099/chatHub")
            .WithAutomaticReconnect()
            .Build();

        Console.WriteLine("START");
        await connection.StartAsync();
        Console.WriteLine("PART1");
        var result = await connection.InvokeAsync<bool>("Login", "Ahoj", "123");
        if (!result)
        {
            Console.WriteLine("BAD LOGIN");
            return;
        }
        await connection.InvokeAsync("JoinAllRooms");
        await connection.InvokeAsync("JoinRoom", Guid.Parse("BA5999E5-4001-4978-BD3B-B0E1958B21C3"));
        await connection.InvokeAsync("SendToRoom", Guid.Parse("BA5999E5-4001-4978-BD3B-B0E1958B21C3"), "Ahoj");
        connection.On<MessageModel>("ReceiveMessage", async (message) =>
        {
            Console.WriteLine(message.UserId + " -> " + message.Message);
            
        });
    }
}