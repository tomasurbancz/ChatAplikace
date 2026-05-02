using ChatAplikace.WFA.Forms;

namespace ChatAplikace.WFA.Controls.Login;

public partial class MainControl : UserControl
{
    private MainForm _mainForm;
    
    public MainControl(MainForm mainForm)
    {
        InitializeComponent();
        _mainForm = mainForm;
    }
}