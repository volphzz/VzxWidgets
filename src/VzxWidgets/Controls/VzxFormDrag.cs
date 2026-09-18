using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace VzxWidgets.Controls;

[ToolboxItem(true)]
public class VzxFormDrag : Component
{
    [DllImport("user32.dll")]
    private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
    [DllImport("user32.dll")]
    private static extern bool ReleaseCapture();

    private Control? _targetControl;

    [Category("VzxWidgets")]
    public Control? TargetControl
    {
        get => _targetControl;
        set
        {
            if (_targetControl != null)
            {
                _targetControl.MouseDown -= Control_MouseDown;
            }
            _targetControl = value;
            if (_targetControl != null)
            {
                _targetControl.MouseDown += Control_MouseDown;
            }
        }
    }

    private void Control_MouseDown(object? sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left && _targetControl != null)
        {
            var form = _targetControl.FindForm();
            if (form != null)
            {
                ReleaseCapture();
                SendMessage(form.Handle, 0xA1, 0x2, 0); // WM_NCLBUTTONDOWN + HT_CAPTION
            }
        }
    }
}
