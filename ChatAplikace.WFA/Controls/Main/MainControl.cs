using ChatAplikace.Database.Model;
using ChatAplikace.WFA.Forms;
using ChatAplikace.WFA.Services;
using ChatAplikace.WFA.Services.Interface;

namespace ChatAplikace.WFA.Controls.Login;

public partial class MainControl : UserControl
{
    private INavigationService _navigationService;
    private IChatHubService _chatHubService;
    
    public MainControl(INavigationService navigationService, IChatHubService chatHubService)
    {
        InitializeComponent();
        _navigationService = navigationService;
        _chatHubService = chatHubService;
    }

    private void logOutLabel_Click(object sender, EventArgs e)
    {
        _navigationService.SetControl(new LoginControl(_navigationService, _chatHubService));
    }

    private async void MainControl_Load(object sender, EventArgs e)
    {
        messagesLayout.FlowDirection = FlowDirection.TopDown;
        messagesLayout.WrapContents = false;
        messagesLayout.AutoScroll = true;
        chatsLayout.FlowDirection = FlowDirection.TopDown;
        chatsLayout.WrapContents = false;
        chatsLayout.AutoScroll = true;
        await LoadChats();
    }

    private async Task OpenChat(Guid id)
    {
        chatNameLabel.Text = await _chatHubService.GetChatRoomName(id);
        await LoadMessages(id);
    }

    private async Task LoadMessages(Guid id)
    {
        messagesLayout.Controls.Clear();
        List<MessageModel> messages = await _chatHubService.GetMessages(id);
        Guid userId = await _chatHubService.GetUserId();
        messages.ForEach(message =>
        {
            Label label = new Label();
            label.Text = message.Message;
            label.TextAlign = ContentAlignment.MiddleLeft;
            if (message.UserId.Equals(userId))
            {
                label.TextAlign = ContentAlignment.MiddleRight;
            }
            messagesLayout.Controls.Add(label);
        });
    }
    
    private async Task LoadChats()
    {
        chatsLayout.Controls.Clear();
        List<ChatRoomModel> models = await _chatHubService.GetChatRooms();
        models.ForEach(model =>
        {
            Button button = new Button();
            button.Text = model.Name;
            button.Width = chatsLayout.ClientSize.Width - 20;
            button.Click += async (_, __) =>
            {
                await OpenChat(model.Id);
            };
                
            chatsLayout.Controls.Add(button);
        });
        Button add = new Button();
        add.Text = "+";
        add.Width = chatsLayout.ClientSize.Width - 20;
        add.Click += (_, __) =>
        {

        };
    }
}