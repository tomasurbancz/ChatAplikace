using ChatAplikace.WFA.Services.Interface;

namespace ChatAplikace.WFA.Forms;

public partial class AddChatForm : Form
{
    private readonly IChatHubService _chatHubService;
    
    public AddChatForm(IChatHubService chatHubService)
    {
        InitializeComponent();
        _chatHubService = chatHubService;
        BackColor = Color.FromArgb(245, 247, 251);
        addLabel.ForeColor = Color.FromArgb(36, 42, 58);
        addButton.BackColor = Color.FromArgb(66, 133, 244);
        addButton.ForeColor = Color.White;
        addButton.FlatStyle = FlatStyle.Flat;
        addButton.FlatAppearance.BorderSize = 0;
    }

    private async void addButton_Click(object sender, EventArgs e)
    {
        Guid userId = await _chatHubService.GetUserIdByName(usernameBox.Text);
        if (userId.Equals(Guid.Empty))
        {
            wrongDataLabel.Visible = true;
            return;
        }

        if (string.IsNullOrWhiteSpace(chatNameBox.Text.Trim()))
        {
            wrongDataLabel.Visible = true;
            return;
        }

        var id = await _chatHubService.CreateRoom(chatNameBox.Text.Trim());
        await _chatHubService.AddUserToRoom(userId, id);
        Close();
    }

    private void usernameBox_TextChanged(object sender, EventArgs e)
    {
        wrongDataLabel.Visible = false;
    }

    private void chatNameBox_TextChanged(object sender, EventArgs e)
    {
        wrongDataLabel.Visible = false;
    }
}