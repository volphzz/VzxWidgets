using System.Drawing;
using System.Windows.Forms;
using VzxWidgets.Controls;

namespace VzxWidgets.Demo;

public partial class Form1 : VzxForm
{
    public Form1()
    {
        InitializeComponent();
        BorderRadius = 16;
        BorderSize = 1;
        BorderColor = Color.FromArgb(45, 45, 62);
        HasDropShadow = true;
    }

    private void trackMaxDist_ValueChanged(object? sender, EventArgs e)
    {
        lblMaxDistVal.Text = $"{trackMaxDist.Value}m";
        if (espPreview != null)
        {
            espPreview.DistanceText = $"{trackMaxDist.Value}m";
        }
    }

    private void chkEspBox_CheckedChanged(object? sender, EventArgs e)
    {
        if (espPreview != null)
        {
            espPreview.ShowBox = chkEspBox.Checked;
        }

        if (chkEspBox.Checked)
        {
            toastSuccess.Visible = true;
            toastSuccess.BringToFront();
        }
        else
        {
            toastInfo.Visible = true;
            toastInfo.BringToFront();
        }
    }
}
