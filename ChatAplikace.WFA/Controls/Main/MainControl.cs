using ChatAplikace.Database.Model;
using ChatAplikace.WFA.Forms;
using ChatAplikace.WFA.Services;
using ChatAplikace.WFA.Services.Interface;

namespace ChatAplikace.WFA.Controls.Login;

public partial class MainControl : UserControl
{
    private readonly INavigationService _navigationService;
    private readonly IChatHubService _chatHubService;
    private Guid _roomId = Guid.Empty;
    
    public MainControl(INavigationService navigationService, IChatHubService chatHubService)
    {
        InitializeComponent();
        _navigationService = navigationService;
        _chatHubService = chatHubService;
        ApplyUiTheme();
        messageBox.Visible = false;
        sendButton.Visible = false;
        Resize += (_, _) => ResizeDynamicControls();
    }

    private void ApplyUiTheme()
    {
        BackColor = Color.FromArgb(245, 247, 251);
        infoPanel.BackColor = Color.FromArgb(230, 236, 246);
        chatNamePanel.BackColor = Color.White;
        chatsPanel.BackColor = Color.FromArgb(239, 243, 250);
        messagesPanel.BackColor = Color.White;

        chatNameLabel.ForeColor = Color.FromArgb(36, 42, 58);
        chatsLabel.ForeColor = Color.FromArgb(36, 42, 58);

        logOutLabel.ForeColor = Color.FromArgb(220, 72, 72);
        logOutLabel.Cursor = Cursors.Hand;

        sendButton.BackColor = Color.FromArgb(66, 133, 244);
        sendButton.ForeColor = Color.White;
        sendButton.FlatStyle = FlatStyle.Flat;
        sendButton.FlatAppearance.BorderSize = 0;

        messageBox.BorderStyle = BorderStyle.FixedSingle;
    }

    private void logOutLabel_Click(object sender, EventArgs e)
    {
        _navigationService.SetControl(new LoginControl(_navigationService, _chatHubService));
    }

    private async void MainControl_Load(object sender, EventArgs e)
    {
        ResizeDynamicControls();

        await _chatHubService.ListenToMessages(async (message) =>
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Func<Task>(async () =>
                {
                    await LoadChats();
                    await LoadMessages(_roomId);
                }));
            }
            else
            {
                await LoadChats();
                await LoadMessages(_roomId);
            }
        });
        await _chatHubService.ListenToRoomAdded(async () =>
        {
            Console.WriteLine("ROOM");
            if (InvokeRequired)
            {
                BeginInvoke(new Func<Task>(async () =>
                {
                    await LoadChats();
                }));
            }
            else
            {
                await LoadChats();
            }
        });
        await LoadChats();
    }

    private async Task OpenChat(Guid id)
    {
        chatNameLabel.Text = await _chatHubService.GetChatRoomName(id);
        _roomId = id;
        await LoadMessages(id);
    }

    private async Task LoadMessages(Guid id)
    {
        messagesLayout.Controls.Clear();
        messageBox.Visible = true;
        sendButton.Visible = true;
        List<MessageModel> messages = await _chatHubService.GetMessages(id);
        Guid userId = await _chatHubService.GetUserId();
        messages.ForEach(message =>
        {
            bool isCurrentUser = message.UserId.Equals(userId);

            int maxBubbleWidth = Math.Max(220, (int)(messagesLayout.ClientSize.Width * 0.72f));
            Label label = new Label
            {
                Text = message.Message,
                AutoSize = false,
                Margin = new Padding(0),
                Padding = new Padding(8, 6, 8, 6),
                BackColor = isCurrentUser ? Color.FromArgb(66, 133, 244) : Color.FromArgb(240, 244, 252),
                ForeColor = isCurrentUser ? Color.White : Color.FromArgb(36, 42, 58),
                BorderStyle = BorderStyle.FixedSingle,
                TextAlign = ContentAlignment.MiddleLeft,
                MaximumSize = new Size(maxBubbleWidth, 0)
            };

            Size preferredSize = TextRenderer.MeasureText(
                message.Message,
                label.Font,
                new Size(maxBubbleWidth - label.Padding.Horizontal, int.MaxValue),
                TextFormatFlags.WordBreak);
            label.Size = new Size(
                Math.Min(maxBubbleWidth, preferredSize.Width + label.Padding.Horizontal + 6),
                preferredSize.Height + label.Padding.Vertical + 6);

            Panel rowPanel = new Panel
            {
                Width = Math.Max(100, messagesLayout.ClientSize.Width - 12),
                Height = label.Height + 2,
                Margin = new Padding(0, 0, 0, 8),
                Tag = isCurrentUser
            };

            rowPanel.Controls.Add(label);
            AlignMessageLabel(rowPanel, label, isCurrentUser);
            messagesLayout.Controls.Add(rowPanel);
        });
    }
    
    private async Task LoadChats()
    {
        chatsLayout.Controls.Clear();
        List<ChatRoomModel> models = await _chatHubService.GetChatRooms();
        models = models.OrderByDescending(model => model.UpdatedAt).ToList();
        models.ForEach(model =>
        {
            Button button = new Button();
            button.Text = model.Name;
            button.Width = Math.Max(100, chatsLayout.ClientSize.Width - 24);
            button.Height = 36;
            button.Margin = new Padding(0, 0, 0, 8);
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.BackColor = Color.White;
            button.ForeColor = Color.FromArgb(36, 42, 58);
            button.Click += async (_, __) =>
            {
                await OpenChat(model.Id);
            };
                
            chatsLayout.Controls.Add(button);
        });
        Button add = new Button();
        add.Text = "+";
        add.Width = Math.Max(100, chatsLayout.ClientSize.Width - 24);
        add.Height = 36;
        add.Margin = new Padding(0, 8, 0, 0);
        add.FlatStyle = FlatStyle.Flat;
        add.FlatAppearance.BorderSize = 0;
        add.BackColor = Color.FromArgb(66, 133, 244);
        add.ForeColor = Color.White;
        add.Click += (_, __) =>
        {
            new AddChatForm(_chatHubService).Show();
        };
        chatsLayout.Controls.Add(add);
    }

    private void ResizeDynamicControls()
    {
        sendButton.Left = Math.Max(0, inputPanel.ClientSize.Width - sendButton.Width);
        messageBox.Width = Math.Max(80, sendButton.Left - 8);

        foreach (Control control in chatsLayout.Controls)
        {
            control.Width = Math.Max(100, chatsLayout.ClientSize.Width - 24);
        }

        foreach (Control control in messagesLayout.Controls)
        {
            if (control is Panel rowPanel && rowPanel.Controls.Count > 0 && rowPanel.Controls[0] is Label label)
            {
                bool isCurrentUser = rowPanel.Tag is bool isOwnMessage && isOwnMessage;
                rowPanel.Width = Math.Max(100, messagesLayout.ClientSize.Width - 12);
                int maxBubbleWidth = Math.Max(220, (int)(messagesLayout.ClientSize.Width * 0.72f));
                label.MaximumSize = new Size(maxBubbleWidth, 0);
                Size preferredSize = TextRenderer.MeasureText(
                    label.Text,
                    label.Font,
                    new Size(maxBubbleWidth - label.Padding.Horizontal, int.MaxValue),
                    TextFormatFlags.WordBreak);
                label.Size = new Size(
                    Math.Min(maxBubbleWidth, preferredSize.Width + label.Padding.Horizontal + 6),
                    preferredSize.Height + label.Padding.Vertical + 6);
                rowPanel.Height = label.Height + 2;
                AlignMessageLabel(rowPanel, label, isCurrentUser);
            }
        }
    }

    private static void AlignMessageLabel(Panel rowPanel, Label label, bool alignRight)
    {
        label.Top = 0;
        label.Left = alignRight
            ? Math.Max(0, rowPanel.ClientSize.Width - label.Width)
            : 0;
    }

    private async void sendButton_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(messageBox.Text.Trim())) return;
        if (_roomId.Equals(Guid.Empty)) return;
        await _chatHubService.SendToRoom(_roomId, messageBox.Text.Trim());
        messageBox.Text = "";
    }
}