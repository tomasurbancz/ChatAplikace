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
        ApplyTheme();
    }

    private void ApplyTheme()
    {
        Font = new Font("Segoe UI", 10F, FontStyle.Regular);
        BackColor = Color.FromArgb(32, 44, 51);
        tableLayoutPanel1.BackColor = BackColor;

        loginPanel.BackColor = Color.FromArgb(32, 44, 51);
        loginPanel.Padding = new Padding(12);

        loginLabel.ForeColor = Color.FromArgb(233, 237, 240);
        loginLabel.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);

        usernameBox.BackColor = Color.FromArgb(240, 242, 245);
        usernameBox.BorderStyle = BorderStyle.FixedSingle;
        usernameBox.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
        usernameBox.ForeColor = Color.FromArgb(17, 27, 33);

        passwordBox.BackColor = Color.FromArgb(240, 242, 245);
        passwordBox.BorderStyle = BorderStyle.FixedSingle;
        passwordBox.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
        passwordBox.ForeColor = Color.FromArgb(17, 27, 33);
        passwordBox.UseSystemPasswordChar = true;

        loginButton.BackColor = Color.FromArgb(18, 140, 126);
        loginButton.ForeColor = Color.White;
        loginButton.FlatStyle = FlatStyle.Flat;
        loginButton.FlatAppearance.BorderSize = 0;
        loginButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(15, 120, 109);
        loginButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(12, 101, 92);
        loginButton.Cursor = Cursors.Hand;
        loginButton.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);

        label1.ForeColor = Color.FromArgb(37, 211, 102);
        label1.Cursor = Cursors.Hand;
        label1.Font = new Font("Segoe UI", 9.5F, FontStyle.Underline);
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