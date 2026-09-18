using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using VzxWidgets.Helpers;

namespace VzxWidgets.Controls;

[ToolboxItem(true)]
[DefaultEvent("CheckedChanged")]
public class VzxToggleSwitch : Control
{
    private bool _checked = false;
    private Color _onBackColor = Color.FromArgb(187, 200, 254);
    private Color _onToggleColor = Color.FromArgb(18, 18, 26);
    private Color _offBackColor = Color.FromArgb(50, 50, 65);
    private Color _offToggleColor = Color.FromArgb(160, 160, 175);

    public event EventHandler? CheckedChanged;

    public VzxToggleSwitch()
    {
        Size = new Size(55, 28);
        MinimumSize = new Size(40, 20);
        Cursor = Cursors.Hand;
        DoubleBuffered = true;

        SetStyle(ControlStyles.AllPaintingInWmPaint |
                 ControlStyles.OptimizedDoubleBuffer |
                 ControlStyles.ResizeRedraw |
                 ControlStyles.SupportsTransparentBackColor |
                 ControlStyles.UserPaint, true);
    }

    [Category("VzxWidgets")]
    [DefaultValue(false)]
    public bool Checked
    {
        get => _checked;
        set
        {
            if (_checked != value)
            {
                _checked = value;
                Invalidate();
                CheckedChanged?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    [Category("VzxWidgets")]
    public Color OnBackColor
    {
        get => _onBackColor;
        set { _onBackColor = value; Invalidate(); }
    }

    [Category("VzxWidgets")]
    public Color OnToggleColor
    {
        get => _onToggleColor;
        set { _onToggleColor = value; Invalidate(); }
    }

    [Category("VzxWidgets")]
    public Color OffBackColor
    {
        get => _offBackColor;
        set { _offBackColor = value; Invalidate(); }
    }

    [Category("VzxWidgets")]
    public Color OffToggleColor
    {
        get => _offToggleColor;
        set { _offToggleColor = value; Invalidate(); }
    }

    protected override void OnMouseClick(MouseEventArgs e)
    {
        base.OnMouseClick(e);
        if (e.Button == MouseButtons.Left)
        {
            Checked = !Checked;
        }
    }

    protected override void OnPaint(PaintEventArgs pevent)
    {
        var g = pevent.Graphics;
        GraphicsHelper.ApplyHighQuality(g);

        int toggleSize = Height - 6;
        var rectSurface = new RectangleF(0, 0, Width, Height);

        using var pathBg = GraphicsHelper.GetRoundedRectangle(rectSurface, Height / 2f);

        Color bg = _checked ? _onBackColor : _offBackColor;
        using (var brush = new SolidBrush(bg))
        {
            g.FillPath(brush, pathBg);
        }

        float toggleX = _checked ? Width - toggleSize - 3 : 3;
        var rectToggle = new RectangleF(toggleX, 3, toggleSize, toggleSize);
        Color toggleCol = _checked ? _onToggleColor : _offToggleColor;

        using (var brushToggle = new SolidBrush(toggleCol))
        {
            g.FillEllipse(brushToggle, rectToggle);
        }
    }
}
