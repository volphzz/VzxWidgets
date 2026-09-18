namespace VzxWidgets.Demo;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void trackSensitivity_ValueChanged(object? sender, EventArgs e)
    {
        lblSensitivityVal.Text = $"( {trackSensitivity.Value}% )";
    }

    private void trackXAxis_ValueChanged(object? sender, EventArgs e)
    {
        lblXAxisVal.Text = $"( {trackXAxis.Value}% )";
    }

    private void trackYAxis_ValueChanged(object? sender, EventArgs e)
    {
        lblYAxisVal.Text = $"( {trackYAxis.Value}% )";
    }

    private void trackDelay_ValueChanged(object? sender, EventArgs e)
    {
        lblDelayVal.Text = $"( {trackDelay.Value} ms )";
    }
}
