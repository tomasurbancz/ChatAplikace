using ChatAplikace.WFA.Controls.Register;
using ChatAplikace.WFA.Forms;
using ChatAplikace.WFA.Services;
using ChatAplikace.WFA.Services.Interface;

namespace ChatAplikace.WFA.Controls.Login;

public partial class LoginControl : UserControl
{
    private INavigationService _navigationService;
    private IChatHubService _chatHubService;
    
    public LoginControl(INavigationService navigationService, IChatHubService chatHubService)
    {
        InitializeComponent();
        _navigationService = navigationService;
        _chatHubService = chatHubService;
        BackColor = Color.Green;
    }

    private void label1_Click(object sender, EventArgs e)
    {
        _navigationService.SetControl(new RegisterControl(_navigationService, _chatHubService));
    }

    private async void loginButton_Click(object sender, EventArgs e)
    {
        bool success = await _chatHubService.Login(usernameBox.Text, passwordBox.Text);
        Console.WriteLine("SUCCESS: " + success);
    }
}