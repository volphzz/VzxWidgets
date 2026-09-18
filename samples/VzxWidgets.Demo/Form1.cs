namespace VzxWidgets.Demo;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void toggle1_CheckedChanged(object? sender, EventArgs e)
    {
        lblToggleState.Text = toggle1.Checked ? "Ativado (True)" : "Desativado (False)";
    }
}
