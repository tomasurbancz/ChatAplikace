using ChatAplikace.WFA.Controls.Login;
using ChatAplikace.WFA.Forms;
using ChatAplikace.WFA.Services.Interface;

namespace ChatAplikace.WFA.Controls.Register;

public partial class RegisterControl : UserControl
{
    private readonly INavigationService _navigationService;
    private readonly IChatHubService _chatHubService;
    
    public RegisterControl(INavigationService navigationService, IChatHubService chatHubService)
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

        registerPanel.BackColor = Color.FromArgb(32, 44, 51);
        registerPanel.Padding = new Padding(12);

        registerLabel.ForeColor = Color.FromArgb(233, 237, 240);
        registerLabel.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);

        usernameBox.BackColor = Color.FromArgb(240, 242, 245);
        usernameBox.BorderStyle = BorderStyle.FixedSingle;
        usernameBox.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
        usernameBox.ForeColor = Color.FromArgb(17, 27, 33);

        passwordBox.BackColor = Color.FromArgb(240, 242, 245);
        passwordBox.BorderStyle = BorderStyle.FixedSingle;
        passwordBox.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
        passwordBox.ForeColor = Color.FromArgb(17, 27, 33);
        passwordBox.UseSystemPasswordChar = true;

        registerButton.BackColor = Color.FromArgb(18, 140, 126);
        registerButton.ForeColor = Color.White;
        registerButton.FlatStyle = FlatStyle.Flat;
        registerButton.FlatAppearance.BorderSize = 0;
        registerButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(15, 120, 109);
        registerButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(12, 101, 92);
        registerButton.Cursor = Cursors.Hand;
        registerButton.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);

        label1.ForeColor = Color.FromArgb(37, 211, 102);
        label1.Cursor = Cursors.Hand;
        label1.Font = new Font("Segoe UI", 9.5F, FontStyle.Underline);
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