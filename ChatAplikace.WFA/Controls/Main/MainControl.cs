using ChatAplikace.Database.Model;
using ChatAplikace.WFA.Forms;
using ChatAplikace.WFA.Services;
using ChatAplikace.WFA.Services.Interface;
using Timer = System.Threading.Timer;

namespace ChatAplikace.WFA.Controls.Login;

public partial class MainControl : UserControl
{
    private const int MessageBottomSpacerHeight = 20;
    private readonly INavigationService _navigationService;
    private readonly IChatHubService _chatHubService;
    private Guid _roomId = Guid.Empty;
    private bool _currentlyTyping = false;
    private List<Guid> _typingChats = new ();
    private Dictionary<Guid, Label> _animationTyping = new();
    private bool _blockLoading = false;
    
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
        Font = new Font("Segoe UI", 10F, FontStyle.Regular);
        BackColor = Color.FromArgb(226, 233, 239);
        tableLayoutPanel1.BackColor = BackColor;
        infoPanel.BackColor = Color.FromArgb(17, 27, 33);
        chatNamePanel.BackColor = Color.FromArgb(32, 44, 51);
        chatsPanel.BackColor = Color.FromArgb(17, 27, 33);
        messagesPanel.BackColor = Color.FromArgb(239, 234, 226);
        inputPanel.BackColor = Color.FromArgb(240, 242, 245);
        messagesLayout.BackColor = messagesPanel.BackColor;

        // Remove cell gaps inside the root layout so background stays visually continuous.
        infoPanel.Margin = Padding.Empty;
        chatNamePanel.Margin = Padding.Empty;
        chatsPanel.Margin = Padding.Empty;
        messagesPanel.Margin = Padding.Empty;

        chatNameLabel.ForeColor = Color.FromArgb(233, 237, 240);
        chatNameLabel.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold);
        chatsLabel.ForeColor = Color.FromArgb(233, 237, 240);
        chatsLabel.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);

        logOutLabel.ForeColor = Color.FromArgb(37, 211, 102);
        logOutLabel.Cursor = Cursors.Hand;
        logOutLabel.Font = new Font("Segoe UI", 9.5F, FontStyle.Underline);

        sendButton.BackColor = Color.FromArgb(18, 140, 126);
        sendButton.ForeColor = Color.White;
        sendButton.FlatStyle = FlatStyle.Flat;
        sendButton.FlatAppearance.BorderSize = 0;
        sendButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(15, 120, 109);
        sendButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(12, 101, 92);
        sendButton.Cursor = Cursors.Hand;
        sendButton.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);

        messageBox.BorderStyle = BorderStyle.FixedSingle;
        messageBox.BackColor = Color.White;
        messageBox.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
        messageBox.ForeColor = Color.FromArgb(17, 27, 33);

        messagesLayout.Padding = new Padding(0, 0, 8, 12);
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
        await _chatHubService.ListenToStartTyping(async (roomId, userId) =>
        {
            Guid myId = await _chatHubService.GetUserId();
            if (userId.Equals(myId)) return;
            _typingChats.Add(roomId);
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
        await _chatHubService.ListenToEndTyping(async (roomId) =>
        {
            if (_typingChats.Contains(roomId)) _typingChats.Remove(roomId);
            if (_animationTyping.ContainsKey(roomId)) _animationTyping.Remove(_roomId);
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
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        timer.Interval = 200;
        List<string> typingAnimations = ["Typing", "Typing.", "Typing..", "Typing..."];
        timer.Tick += (_, __) =>
        {
            foreach (var keyValuePair in new Dictionary<Guid, Label>(_animationTyping))
            {
                int index = typingAnimations.FindIndex(x => x.Equals(keyValuePair.Value.Text));
                if (index == 3) index = 0;
                else index++;
                keyValuePair.Value.Text = typingAnimations[index];
            }
        };
        timer.Start();
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
            Panel bubblePanel = CreateMessageBubble(message.Message, message.CreatedAt, isCurrentUser, maxBubbleWidth);

            Panel rowPanel = new Panel
            {
                Width = Math.Max(100, messagesLayout.ClientSize.Width - 12),
                Height = bubblePanel.Height + 2,
                Margin = new Padding(0, 0, 0, 8),
                BackColor = messagesLayout.BackColor,
                Tag = isCurrentUser
            };

            rowPanel.Controls.Add(bubblePanel);
            AlignMessageBubble(rowPanel, bubblePanel, isCurrentUser);
            messagesLayout.Controls.Add(rowPanel);
        });

        AddMessageBottomSpacer();
        EnsureMessageListCanScrollToBottom();
    }
    
    private async Task LoadChats()
    {
        if (_blockLoading) return;
        _blockLoading = true;
        chatsLayout.Controls.Clear();
        List<ChatRoomModel> models = await _chatHubService.GetChatRooms();
        models = models.OrderByDescending(model => model.UpdatedAt).ToList();
        models.ForEach(async model =>
        {
            List<MessageModel> messages = await _chatHubService.GetMessages(model.Id);
            string lastMessage = messages
                .OrderByDescending(m => m.UpdatedAt)
                .Select(m => m.Message)
                .FirstOrDefault() ?? "No messages yet";

            Panel itemPanel = new Panel
            {
                Width = Math.Max(100, chatsLayout.ClientSize.Width - 24),
                Height = 52,
                Margin = new Padding(0, 0, 0, 8),
                BackColor = Color.FromArgb(32, 44, 51),
                Cursor = Cursors.Hand,
                Padding = new Padding(10, 6, 10, 6)
            };

            Label nameLabel = new Label
            {
                Dock = DockStyle.Top,
                Height = 20,
                Text = model.Name,
                ForeColor = Color.FromArgb(233, 237, 240),
                Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleLeft
            };

            Label subtitleLabel = new Label
            {
                Dock = DockStyle.Fill,
                Text = lastMessage,
                ForeColor = Color.FromArgb(134, 150, 160),
                Font = new Font("Segoe UI", 8.5F, FontStyle.Regular),
                TextAlign = ContentAlignment.MiddleLeft,
                AutoEllipsis = true
            };
            
            if (_typingChats.Contains(model.Id) && !_animationTyping.ContainsKey(model.Id))
            {
                _animationTyping.Add(model.Id, subtitleLabel);
                subtitleLabel.Text = "Typing";
            }

            EventHandler openChatHandler = async (_, __) =>
            {
                await OpenChat(model.Id);
            };

            itemPanel.Click += openChatHandler;
            nameLabel.Click += openChatHandler;
            subtitleLabel.Click += openChatHandler;

            itemPanel.Controls.Add(subtitleLabel);
            itemPanel.Controls.Add(nameLabel);
            chatsLayout.Controls.Add(itemPanel);
        });
        Button add = new Button();
        add.Text = "+";
        add.Width = Math.Max(100, chatsLayout.ClientSize.Width - 24);
        add.Height = 36;
        add.Margin = new Padding(0, 8, 0, 0);
        add.FlatStyle = FlatStyle.Flat;
        add.FlatAppearance.BorderSize = 0;
        add.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 190, 91);
        add.FlatAppearance.MouseDownBackColor = Color.FromArgb(22, 165, 78);
        add.BackColor = Color.FromArgb(37, 211, 102);
        add.ForeColor = Color.White;
        add.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
        add.Cursor = Cursors.Hand;
        add.Click += (_, __) =>
        {
            new AddChatForm(_chatHubService).Show();
        };
        chatsLayout.Controls.Add(add);
        _blockLoading = false;
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
            if (control.Name == "MessageBottomSpacer")
            {
                control.Width = Math.Max(100, messagesLayout.ClientSize.Width - 12);
                continue;
            }

            if (control is Panel rowPanel && rowPanel.Controls.Count > 0 && rowPanel.Controls[0] is Panel bubblePanel)
            {
                bool isCurrentUser = rowPanel.Tag is bool isOwnMessage && isOwnMessage;
                rowPanel.Width = Math.Max(100, messagesLayout.ClientSize.Width - 12);
                int maxBubbleWidth = Math.Max(220, (int)(messagesLayout.ClientSize.Width * 0.72f));
                ResizeMessageBubble(bubblePanel, maxBubbleWidth);
                rowPanel.Height = bubblePanel.Height + 2;
                AlignMessageBubble(rowPanel, bubblePanel, isCurrentUser);
            }
        }

        EnsureMessageListCanScrollToBottom();
    }

    private Panel CreateMessageBubble(string messageText, DateTime time, bool isCurrentUser, int maxBubbleWidth)
    {
        Panel bubblePanel = new Panel
        {
            BackColor = isCurrentUser ? Color.FromArgb(217, 253, 211) : Color.FromArgb(255, 255, 255),
            BorderStyle = BorderStyle.None,
            Padding = new Padding(10, 8, 10, 6),
            Tag = isCurrentUser
        };

        Label textLabel = new Label
        {
            Name = "MessageTextLabel",
            Text = messageText,
            AutoSize = false,
            ForeColor = Color.FromArgb(17, 27, 33),
            Font = new Font("Segoe UI", 9.5F, FontStyle.Regular),
            TextAlign = ContentAlignment.TopLeft
        };

        Label timeLabel = new Label
        {
            Name = "MessageTimeLabel",
            Text = time.Hour + ":" + time.Minute,
            AutoSize = false,
            ForeColor = Color.FromArgb(102, 119, 128),
            Font = new Font("Segoe UI", 7.5F, FontStyle.Regular),
            TextAlign = ContentAlignment.MiddleRight
        };

        bubblePanel.Controls.Add(textLabel);
        bubblePanel.Controls.Add(timeLabel);
        ResizeMessageBubble(bubblePanel, maxBubbleWidth);
        return bubblePanel;
    }

    private static void ResizeMessageBubble(Panel bubblePanel, int maxBubbleWidth)
    {
        Label? textLabel = bubblePanel.Controls.Find("MessageTextLabel", false).FirstOrDefault() as Label;
        Label? timeLabel = bubblePanel.Controls.Find("MessageTimeLabel", false).FirstOrDefault() as Label;
        if (textLabel == null || timeLabel == null)
        {
            return;
        }

        int horizontalPadding = bubblePanel.Padding.Horizontal;
        int verticalPadding = bubblePanel.Padding.Vertical;
        int contentWidth = maxBubbleWidth - horizontalPadding;

        Size measuredText = TextRenderer.MeasureText(
            textLabel.Text,
            textLabel.Font,
            new Size(contentWidth, int.MaxValue),
            TextFormatFlags.WordBreak);

        Size measuredTime = TextRenderer.MeasureText(
            timeLabel.Text,
            timeLabel.Font,
            new Size(contentWidth, int.MaxValue),
            TextFormatFlags.SingleLine);

        int bubbleInnerWidth = Math.Max(measuredText.Width, measuredTime.Width + 6);
        int bubbleWidth = Math.Min(maxBubbleWidth, bubbleInnerWidth + horizontalPadding);

        int labelWidth = bubbleWidth - horizontalPadding;
        textLabel.Location = new Point(bubblePanel.Padding.Left, bubblePanel.Padding.Top);
        textLabel.Size = new Size(labelWidth, measuredText.Height + 2);

        timeLabel.Location = new Point(bubblePanel.Padding.Left, textLabel.Bottom + 2);
        timeLabel.Size = new Size(labelWidth, measuredTime.Height + 2);

        bubblePanel.Size = new Size(bubbleWidth, timeLabel.Bottom + bubblePanel.Padding.Bottom);
    }

    private static void AlignMessageBubble(Panel rowPanel, Panel bubblePanel, bool alignRight)
    {
        bubblePanel.Top = 0;
        bubblePanel.Left = alignRight
            ? Math.Max(0, rowPanel.ClientSize.Width - bubblePanel.Width)
            : 0;
    }

    private void EnsureMessageListCanScrollToBottom()
    {
        if (messagesLayout.Controls.Count == 0)
        {
            return;
        }

        Control lastControl = messagesLayout.Controls.Cast<Control>()
            .FirstOrDefault(c => c.Name == "MessageBottomSpacer")
            ?? messagesLayout.Controls[messagesLayout.Controls.Count - 1];
        BeginInvoke(() =>
        {
            messagesLayout.ScrollControlIntoView(lastControl);
        });
    }

    private void AddMessageBottomSpacer()
    {
        Panel spacer = new Panel
        {
            Name = "MessageBottomSpacer",
            Width = Math.Max(100, messagesLayout.ClientSize.Width - 12),
            Height = MessageBottomSpacerHeight,
            Margin = Padding.Empty,
            BackColor = messagesLayout.BackColor
        };
        messagesLayout.Controls.Add(spacer);
    }

    private async void sendButton_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(messageBox.Text.Trim())) return;
        if (_roomId.Equals(Guid.Empty)) return;
        await _chatHubService.SendToRoom(_roomId, messageBox.Text.Trim());
        _currentlyTyping = false;
        messageBox.Text = "";
    }

    private async void messageBox_TextChanged(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(messageBox.Text))
        {
            if (!_currentlyTyping) await _chatHubService.StartTyping(_roomId);
            _currentlyTyping = true;
        }
        else
        {
            if (_currentlyTyping) await _chatHubService.EndTyping(_roomId);
            _currentlyTyping = false;
        }
    }
}