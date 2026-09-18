using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using VzxWidgets.Helpers;

namespace VzxWidgets.Controls;

[DefaultEvent("Click")]
public class VzxButton : Button
{
    private int _borderRadius = 12;
    private int _borderSize = 0;
    private Color _borderColor = Color.FromArgb(70, 70, 90);
    private Color _hoverColor = Color.FromArgb(120, 118, 240);
    private Color _pressedColor = Color.FromArgb(74, 72, 200);

    private bool _isHovered = false;
    private bool _isPressed = false;

    public VzxButton()
    {
        FlatStyle = FlatStyle.Flat;
        FlatAppearance.BorderSize = 0;
        Size = new Size(160, 45);
        BackColor = Color.FromArgb(94, 92, 230);
        ForeColor = Color.White;
        Font = new Font("Segoe UI Semibold", 10f, FontStyle.Bold);
        Cursor = Cursors.Hand;
        DoubleBuffered = true;

        SetStyle(ControlStyles.AllPaintingInWmPaint |
                 ControlStyles.OptimizedDoubleBuffer |
                 ControlStyles.ResizeRedraw |
                 ControlStyles.SupportsTransparentBackColor |
                 ControlStyles.UserPaint, true);
    }

    [Category("VzxWidgets")]
    [DefaultValue(12)]
    public int BorderRadius
    {
        get => _borderRadius;
        set { _borderRadius = Math.Max(0, value); Invalidate(); }
    }

    [Category("VzxWidgets")]
    [DefaultValue(0)]
    public int BorderSize
    {
        get => _borderSize;
        set { _borderSize = Math.Max(0, value); Invalidate(); }
    }

    [Category("VzxWidgets")]
    public Color BorderColor
    {
        get => _borderColor;
        set { _borderColor = value; Invalidate(); }
    }

    [Category("VzxWidgets")]
    public Color HoverColor
    {
        get => _hoverColor;
        set { _hoverColor = value; Invalidate(); }
    }

    [Category("VzxWidgets")]
    public Color PressedColor
    {
        get => _pressedColor;
        set { _pressedColor = value; Invalidate(); }
    }

    protected override void OnMouseEnter(EventArgs e)
    {
        base.OnMouseEnter(e);
        _isHovered = true;
        Invalidate();
    }

    protected override void OnMouseLeave(EventArgs e)
    {
        base.OnMouseLeave(e);
        _isHovered = false;
        _isPressed = false;
        Invalidate();
    }

    protected override void OnMouseDown(MouseEventArgs mevent)
    {
        base.OnMouseDown(mevent);
        _isPressed = true;
        Invalidate();
    }

    protected override void OnMouseUp(MouseEventArgs mevent)
    {
        base.OnMouseUp(mevent);
        _isPressed = false;
        Invalidate();
    }

    protected override void OnPaint(PaintEventArgs pevent)
    {
        var g = pevent.Graphics;
        GraphicsHelper.ApplyHighQuality(g);

        var rectSurface = new RectangleF(0, 0, Width, Height);
        var rectBorder = new RectangleF(1, 1, Width - 2, Height - 2);

        Color currentBg = _isPressed ? _pressedColor : (_isHovered ? _hoverColor : BackColor);

        if (_borderRadius > 2)
        {
            using var pathSurface = GraphicsHelper.GetRoundedRectangle(rectSurface, _borderRadius);
            using var pathBorder = GraphicsHelper.GetRoundedRectangle(rectBorder, _borderRadius - 1);
            using var brushBg = new SolidBrush(currentBg);
            using var penBorder = new Pen(_borderColor, _borderSize);

            Region = new Region(pathSurface);
            g.FillPath(brushBg, pathSurface);

            if (_borderSize >= 1)
            {
                g.DrawPath(penBorder, pathBorder);
            }
        }
        else
        {
            Region = new Region(rectSurface);
            using var brushBg = new SolidBrush(currentBg);
            g.FillRectangle(brushBg, rectSurface);

            if (_borderSize >= 1)
            {
                using var penBorder = new Pen(_borderColor, _borderSize);
                g.DrawRectangle(penBorder, 0, 0, Width - 1, Height - 1);
            }
        }

        TextRenderer.DrawText(g, Text, Font, ClientRectangle, ForeColor,
            TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
    }
}
