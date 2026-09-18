using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using VzxWidgets.Helpers;

namespace VzxWidgets.Controls;

[ToolboxItem(true)]
[DefaultEvent("Click")]
public class VzxButton : Button
{
    private int _borderRadius = 12;
    private int _borderSize = 0;
    private Color _borderColor = Color.FromArgb(70, 70, 90);
    private Color _hoverColor = Color.FromArgb(205, 215, 255);
    private Color _pressedColor = Color.FromArgb(145, 160, 235);

    // Gradiente opcional
    private bool _useGradient = false;
    private Color _gradientEndColor = Color.FromArgb(145, 165, 245);
    private float _gradientAngle = 45f;

    // Indicador lateral (estilo Sidebar Cheat/Tabs como Aimbot / Players)
    private bool _showActiveIndicator = false;
    private Color _activeIndicatorColor = Color.FromArgb(187, 200, 254);

    private bool _isHovered = false;
    private bool _isPressed = false;

    public VzxButton()
    {
        FlatStyle = FlatStyle.Flat;
        FlatAppearance.BorderSize = 0;
        Size = new Size(160, 42);
        BackColor = Color.FromArgb(187, 200, 254);
        ForeColor = Color.FromArgb(16, 16, 24);
        Font = new Font("Segoe UI Semibold", 9.5f, FontStyle.Bold);
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

    [Category("VzxWidgets")]
    [DefaultValue(false)]
    public bool UseGradient
    {
        get => _useGradient;
        set { _useGradient = value; Invalidate(); }
    }

    [Category("VzxWidgets")]
    public Color GradientEndColor
    {
        get => _gradientEndColor;
        set { _gradientEndColor = value; Invalidate(); }
    }

    [Category("VzxWidgets")]
    [DefaultValue(45f)]
    public float GradientAngle
    {
        get => _gradientAngle;
        set { _gradientAngle = value; Invalidate(); }
    }

    [Category("VzxWidgets")]
    [DefaultValue(false)]
    public bool ShowActiveIndicator
    {
        get => _showActiveIndicator;
        set { _showActiveIndicator = value; Invalidate(); }
    }

    [Category("VzxWidgets")]
    public Color ActiveIndicatorColor
    {
        get => _activeIndicatorColor;
        set { _activeIndicatorColor = value; Invalidate(); }
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

            Region = new Region(pathSurface);

            if (_useGradient && !_isPressed && !_isHovered)
            {
                using var brushGrad = new LinearGradientBrush(rectSurface, BackColor, _gradientEndColor, _gradientAngle);
                g.FillPath(brushGrad, pathSurface);
            }
            else
            {
                using var brushBg = new SolidBrush(currentBg);
                g.FillPath(brushBg, pathSurface);
            }

            if (_borderSize >= 1)
            {
                using var penBorder = new Pen(_borderColor, _borderSize);
                g.DrawPath(penBorder, pathBorder);
            }
        }
        else
        {
            Region = new Region(rectSurface);
            if (_useGradient && !_isPressed && !_isHovered)
            {
                using var brushGrad = new LinearGradientBrush(rectSurface, BackColor, _gradientEndColor, _gradientAngle);
                g.FillRectangle(brushGrad, rectSurface);
            }
            else
            {
                using var brushBg = new SolidBrush(currentBg);
                g.FillRectangle(brushBg, rectSurface);
            }

            if (_borderSize >= 1)
            {
                using var penBorder = new Pen(_borderColor, _borderSize);
                g.DrawRectangle(penBorder, 0, 0, Width - 1, Height - 1);
            }
        }

        // Indicador lateral para abas (ex: Aimbot)
        if (_showActiveIndicator)
        {
            var rectInd = new RectangleF(0, Height * 0.2f, 3.5f, Height * 0.6f);
            using var brushInd = new SolidBrush(_activeIndicatorColor);
            g.FillRectangle(brushInd, rectInd);
        }

        // Ícone se houver
        if (Image != null)
        {
            int iconX = 12;
            int iconY = (Height - Image.Height) / 2;
            g.DrawImage(Image, iconX, iconY, Image.Width, Image.Height);
        }

        // Texto centralizado
        TextRenderer.DrawText(g, Text, Font, ClientRectangle, ForeColor,
            TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
    }
}
