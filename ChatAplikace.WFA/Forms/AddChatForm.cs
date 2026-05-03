using ChatAplikace.WFA.Services.Interface;

namespace ChatAplikace.WFA.Forms;

public partial class AddChatForm : Form
{
    private IChatHubService _chatHubService;
    private INavigationService _navigationService;
    
    public AddChatForm(IChatHubService chatHubService, INavigationService navigationService)
    {
        InitializeComponent();
        _chatHubService = chatHubService;
        _navigationService = navigationService;
    }

    private void addButton_Click(object sender, EventArgs e)
    {
        
    }
}