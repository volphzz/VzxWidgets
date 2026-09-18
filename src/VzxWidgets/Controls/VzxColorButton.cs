using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using VzxWidgets.Helpers;

namespace VzxWidgets.Controls;

[ToolboxItem(true)]
[DefaultEvent("ColorChanged")]
public class VzxColorButton : Control
{
    private Color _selectedColor = Color.White;
    private Color _borderColor = Color.FromArgb(60, 60, 80);
    private int _borderRadius = 4;

    public event EventHandler? ColorChanged;

    public VzxColorButton()
    {
        DoubleBuffered = true;
        Size = new Size(18, 14);
        Cursor = Cursors.Hand;
        SetStyle(ControlStyles.AllPaintingInWmPaint |
                 ControlStyles.OptimizedDoubleBuffer |
                 ControlStyles.ResizeRedraw |
                 ControlStyles.SupportsTransparentBackColor |
                 ControlStyles.UserPaint, true);
    }

    [Category("VzxWidgets")]
    public Color SelectedColor
    {
        get => _selectedColor;
        set
        {
            if (_selectedColor != value)
            {
                _selectedColor = value;
                Invalidate();
                ColorChanged?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    [Category("VzxWidgets")]
    [DefaultValue(4)]
    public int BorderRadius
    {
        get => _borderRadius;
        set { _borderRadius = Math.Max(0, value); Invalidate(); }
    }

    protected override void OnClick(EventArgs e)
    {
        base.OnClick(e);
        using var cd = new ColorDialog
        {
            Color = _selectedColor,
            FullOpen = true
        };
        if (cd.ShowDialog() == DialogResult.OK)
        {
            SelectedColor = cd.Color;
        }
    }

    protected override void OnPaint(PaintEventArgs pevent)
    {
        var g = pevent.Graphics;
        GraphicsHelper.ApplyHighQuality(g);

        var rect = new RectangleF(0, 0, Width - 1, Height - 1);
        using var path = GraphicsHelper.GetRoundedRectangle(rect, _borderRadius);
        using var brush = new SolidBrush(_selectedColor);
        using var pen = new Pen(_borderColor, 1f);

        g.FillPath(brush, path);
        g.DrawPath(pen, path);
    }
}
