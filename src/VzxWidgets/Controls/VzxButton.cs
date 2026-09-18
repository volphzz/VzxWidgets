using System;
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

    private bool _isPressed = false;

    // Animação de transição suave de hover
    private readonly System.Windows.Forms.Timer _animTimer;
    private float _hoverFactor = 0f;
    private float _targetHover = 0f;

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

        _animTimer = new System.Windows.Forms.Timer { Interval = 15 };
        _animTimer.Tick += (s, e) =>
        {
            float diff = _targetHover - _hoverFactor;
            if (Math.Abs(diff) > 0.02f)
            {
                _hoverFactor += diff * 0.35f;
                Invalidate();
            }
            else
            {
                _hoverFactor = _targetHover;
                _animTimer.Stop();
                Invalidate();
            }
        };
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
        _targetHover = 1.0f;
        _animTimer.Start();
    }

    protected override void OnMouseLeave(EventArgs e)
    {
        base.OnMouseLeave(e);
        _isPressed = false;
        _targetHover = 0.0f;
        _animTimer.Start();
    }

    protected override void OnMouseDown(MouseEventArgs mevent)
    {
        base.OnMouseDown(mevent);
        if (mevent.Button == MouseButtons.Left)
        {
            _isPressed = true;
            Invalidate();
        }
    }

    protected override void OnMouseUp(MouseEventArgs mevent)
    {
        base.OnMouseUp(mevent);
        _isPressed = false;
        Invalidate();
    }

    private static Color LerpColor(Color c1, Color c2, float t)
    {
        t = Math.Clamp(t, 0f, 1f);
        int a = (int)(c1.A + (c2.A - c1.A) * t);
        int r = (int)(c1.R + (c2.R - c1.R) * t);
        int g = (int)(c1.G + (c2.G - c1.G) * t);
        int b = (int)(c1.B + (c2.B - c1.B) * t);
        return Color.FromArgb(a, r, g, b);
    }

    protected override void OnPaint(PaintEventArgs pevent)
    {
        var g = pevent.Graphics;
        GraphicsHelper.ApplyHighQuality(g);

        var rectSurface = new RectangleF(0, 0, Width, Height);
        var rectBorder = new RectangleF(1, 1, Width - 2, Height - 2);

        // Preenchimento de fundo suave
        Color currentStart = _isPressed ? _pressedColor : LerpColor(BackColor, _hoverColor, _hoverFactor);
        Color currentEnd = _isPressed ? _pressedColor : LerpColor(_gradientEndColor, _hoverColor, _hoverFactor);

        if (_borderRadius > 2)
        {
            using var pathSurface = GraphicsHelper.GetRoundedRectangle(rectSurface, _borderRadius);
            using var pathBorder = GraphicsHelper.GetRoundedRectangle(rectBorder, _borderRadius - 1);

            // Desenhar fundo
            if (_useGradient)
            {
                using var brushGrad = new LinearGradientBrush(rectSurface, currentStart, currentEnd, _gradientAngle);
                g.FillPath(brushGrad, pathSurface);
            }
            else
            {
                using var brushSolid = new SolidBrush(currentStart);
                g.FillPath(brushSolid, pathSurface);
            }

            // Desenhar borda
            if (_borderSize >= 1)
            {
                using var penBorder = new Pen(_borderColor, _borderSize);
                penBorder.Alignment = PenAlignment.Inset;
                g.DrawPath(penBorder, pathBorder);
            }

            // Indicador lateral de aba ativa
            if (_showActiveIndicator)
            {
                using var pathIndicator = GraphicsHelper.GetRoundedRectangle(new RectangleF(0, 6, 4, Height - 12), 2);
                using var brushIndicator = new SolidBrush(_activeIndicatorColor);
                g.FillPath(brushIndicator, pathIndicator);
            }
        }
        else
        {
            if (_useGradient)
            {
                using var brushGrad = new LinearGradientBrush(rectSurface, currentStart, currentEnd, _gradientAngle);
                g.FillRectangle(brushGrad, rectSurface);
            }
            else
            {
                using var brushSolid = new SolidBrush(currentStart);
                g.FillRectangle(brushSolid, rectSurface);
            }

            if (_borderSize >= 1)
            {
                using var penBorder = new Pen(_borderColor, _borderSize);
                penBorder.Alignment = PenAlignment.Inset;
                g.DrawRectangle(penBorder, 0, 0, Width - 1, Height - 1);
            }

            if (_showActiveIndicator)
            {
                using var brushIndicator = new SolidBrush(_activeIndicatorColor);
                g.FillRectangle(brushIndicator, 0, 4, 4, Height - 8);
            }
        }

        // Texto e ícone centralizados
        TextRenderer.DrawText(g, Text, Font, ClientRectangle, ForeColor,
            TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
    }
}
