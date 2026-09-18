using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using VzxWidgets.Helpers;

namespace VzxWidgets.Controls;

[ToolboxItem(true)]
[DefaultEvent("KeyChanged")]
public class VzxKeybind : Control
{
    private Keys _currentKey = Keys.Insert;
    private bool _isListening = false;
    private Color _boxBackColor = Color.FromArgb(28, 28, 38);
    private Color _borderColor = Color.FromArgb(50, 50, 68);
    private Color _activeBorderColor = Color.FromArgb(155, 80, 255);
    private int _borderRadius = 6;

    public event EventHandler? KeyChanged;

    public VzxKeybind()
    {
        DoubleBuffered = true;
        Size = new Size(80, 28);
        Cursor = Cursors.Hand;
        ForeColor = Color.FromArgb(220, 220, 235);
        Font = new Font("Segoe UI Semibold", 8.5f, FontStyle.Bold);
        SetStyle(ControlStyles.Selectable |
                 ControlStyles.AllPaintingInWmPaint |
                 ControlStyles.OptimizedDoubleBuffer |
                 ControlStyles.ResizeRedraw |
                 ControlStyles.SupportsTransparentBackColor |
                 ControlStyles.UserPaint, true);
    }

    [Category("VzxWidgets")]
    public Keys CurrentKey
    {
        get => _currentKey;
        set
        {
            if (_currentKey != value)
            {
                _currentKey = value;
                Invalidate();
                KeyChanged?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    [Category("VzxWidgets")]
    [DefaultValue(6)]
    public int BorderRadius
    {
        get => _borderRadius;
        set { _borderRadius = Math.Max(0, value); Invalidate(); }
    }

    protected override void OnClick(EventArgs e)
    {
        base.OnClick(e);
        _isListening = true;
        Focus();
        Invalidate();
    }

    protected override void OnKeyDown(KeyEventArgs e)
    {
        base.OnKeyDown(e);
        if (_isListening)
        {
            if (e.KeyCode == Keys.Escape)
            {
                CurrentKey = Keys.None;
            }
            else
            {
                CurrentKey = e.KeyCode;
            }
            _isListening = false;
            Invalidate();
        }
    }

    protected override void OnLostFocus(EventArgs e)
    {
        base.OnLostFocus(e);
        _isListening = false;
        Invalidate();
    }

    protected override void OnPaint(PaintEventArgs pevent)
    {
        var g = pevent.Graphics;
        GraphicsHelper.ApplyHighQuality(g);

        var rect = new RectangleF(0, 0, Width - 1, Height - 1);
        using var path = GraphicsHelper.GetRoundedRectangle(rect, _borderRadius);
        using var brush = new SolidBrush(_boxBackColor);
        using var pen = new Pen(_isListening ? _activeBorderColor : _borderColor, 1.2f);

        g.FillPath(brush, path);
        g.DrawPath(pen, path);

        string display = _isListening ? "..." : _currentKey.ToString();
        TextRenderer.DrawText(g, display, Font, ClientRectangle, _isListening ? _activeBorderColor : ForeColor,
            TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
    }
}
