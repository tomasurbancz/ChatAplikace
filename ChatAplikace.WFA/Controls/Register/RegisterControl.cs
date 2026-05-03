using ChatAplikace.WFA.Controls.Login;
using ChatAplikace.WFA.Forms;
using ChatAplikace.WFA.Services.Interface;

namespace ChatAplikace.WFA.Controls.Register;

public partial class RegisterControl : UserControl
{
    private INavigationService _navigationService;
    private IChatHubService _chatHubService;
    
    public RegisterControl(INavigationService navigationService, IChatHubService chatHubService)
    {
        InitializeComponent();
        _navigationService = navigationService;
        _chatHubService = chatHubService; 
        BackColor = Color.FromArgb(245, 247, 251);
        registerPanel.BackColor = Color.White;
        registerButton.BackColor = Color.FromArgb(66, 133, 244);
        registerButton.ForeColor = Color.White;
        registerButton.FlatStyle = FlatStyle.Flat;
        registerButton.FlatAppearance.BorderSize = 0;
        label1.ForeColor = Color.FromArgb(66, 133, 244);
        label1.Cursor = Cursors.Hand;
    }

    private void label1_Click(object sender, EventArgs e)
    {
        _navigationService.SetControl(new LoginControl(_navigationService, _chatHubService));
    }

    private async void registerButton_Click(object sender, EventArgs e)
    {
        bool success = await _chatHubService.Register(usernameBox.Text, passwordBox.Text);
        if (success)
        {
            _navigationService.SetControl(new LoginControl(_navigationService, _chatHubService));
        }
    }
}