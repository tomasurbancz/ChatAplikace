using ChatAplikace.WFA.Services.Interface;

namespace ChatAplikace.WFA.Forms;

public partial class AddChatForm : Form
{
    private readonly IChatHubService _chatHubService;
    
    public AddChatForm(IChatHubService chatHubService)
    {
        InitializeComponent();
        _chatHubService = chatHubService;
        ApplyTheme();
    }

    private void ApplyTheme()
    {
        Font = new Font("Segoe UI", 10F, FontStyle.Regular);
        BackColor = Color.FromArgb(32, 44, 51);

        addLabel.ForeColor = Color.FromArgb(233, 237, 240);
        addLabel.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold);

        usernameBox.BackColor = Color.FromArgb(240, 242, 245);
        usernameBox.BorderStyle = BorderStyle.FixedSingle;
        usernameBox.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
        usernameBox.ForeColor = Color.FromArgb(17, 27, 33);

        chatNameBox.BackColor = Color.FromArgb(240, 242, 245);
        chatNameBox.BorderStyle = BorderStyle.FixedSingle;
        chatNameBox.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
        chatNameBox.ForeColor = Color.FromArgb(17, 27, 33);

        addButton.BackColor = Color.FromArgb(18, 140, 126);
        addButton.ForeColor = Color.White;
        addButton.FlatStyle = FlatStyle.Flat;
        addButton.FlatAppearance.BorderSize = 0;
        addButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(15, 120, 109);
        addButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(12, 101, 92);
        addButton.Cursor = Cursors.Hand;
        addButton.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);

        wrongDataLabel.ForeColor = Color.FromArgb(255, 120, 117);
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