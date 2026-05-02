using ChatAplikace.WFA.Forms;

namespace ChatAplikace.WFA.Controls.Login;

public partial class LoginControl : UserControl
{
    private MainForm _mainForm;
    
    public LoginControl(MainForm mainForm)
    {
        InitializeComponent();
        _mainForm = mainForm;

    }
    
}