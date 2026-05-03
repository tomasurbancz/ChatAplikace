using ChatAplikace.WFA.Controls.Register;
using ChatAplikace.WFA.Forms;
using ChatAplikace.WFA.Services;
using ChatAplikace.WFA.Services.Interface;

namespace ChatAplikace.WFA.Controls.Login;

public partial class LoginControl : UserControl
{
    private readonly INavigationService _navigationService;
    private readonly IChatHubService _chatHubService;
    
    public LoginControl(INavigationService navigationService, IChatHubService chatHubService)
    {
        InitializeComponent();
        _navigationService = navigationService;
        _chatHubService = chatHubService;
        BackColor = Color.FromArgb(245, 247, 251);
        loginPanel.BackColor = Color.White;
        loginButton.BackColor = Color.FromArgb(66, 133, 244);
        loginButton.ForeColor = Color.White;
        loginButton.FlatStyle = FlatStyle.Flat;
        loginButton.FlatAppearance.BorderSize = 0;
        label1.ForeColor = Color.FromArgb(66, 133, 244);
        label1.Cursor = Cursors.Hand;
    }

    private void label1_Click(object sender, EventArgs e)
    {
        _navigationService.SetControl(new RegisterControl(_navigationService, _chatHubService));
    }

    private async void loginButton_Click(object sender, EventArgs e)
    {
        bool success = await _chatHubService.Login(usernameBox.Text, passwordBox.Text);
        if (success)
        {
            await _chatHubService.JoinAllRooms();
            _navigationService.SetControl(new MainControl(_navigationService, _chatHubService));
        }
    }
}