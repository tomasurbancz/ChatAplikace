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
using ChatAplikace.WPF.Services;
using Microsoft.AspNetCore.SignalR.Client;
using NavigationService = ChatAplikace.WPF.Services.NavigationService;

namespace ChatAplikace.WPF;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        Loaded += async (_, __) =>
        {
            var mainViewModel = new MainViewModel(new ChatHubService());
            this.DataContext = mainViewModel;

            await mainViewModel.Connect();
            mainViewModel.NavigateToLogin();
        };
    }
}