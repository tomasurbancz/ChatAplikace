using ChatAplikace.WFA.Controls.Login;
using ChatAplikace.WFA.Services;

namespace ChatAplikace.WFA.Forms;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
        BackColor = Color.FromArgb(244, 247, 252);
    }

    private async void MainForm_Load(object sender, EventArgs e)
    {
        NavigationService navigationService = new NavigationService(this);
        ChatHubService chatHubService = new ChatHubService();
        await chatHubService.StartAsync();
            
            
        navigationService.SetControl(new LoginControl(navigationService, chatHubService));
    }
}