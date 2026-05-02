using ChatAplikace.WFA.Controls.Login;

namespace ChatAplikace.WFA.Forms;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
        LoginControl loginControl = new LoginControl(this);
        loginControl.Dock = DockStyle.Fill;
        Controls.Add(loginControl);
    }
}