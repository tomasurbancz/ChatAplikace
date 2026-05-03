using ChatAplikace.WFA.Forms;
using ChatAplikace.WFA.Services.Interface;

namespace ChatAplikace.WFA.Services;

public class NavigationService : INavigationService
{
    private MainForm _mainForm;
    
    public NavigationService(MainForm mainForm)
    {
        _mainForm = mainForm;
    }
    
    public void SetControl(UserControl control)
    {
        _mainForm.Controls.Clear();
        control.Dock = DockStyle.Fill;
        _mainForm.Controls.Add(control);
    }
}