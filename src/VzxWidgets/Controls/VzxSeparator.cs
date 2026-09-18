using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using VzxWidgets.Helpers;

namespace VzxWidgets.Controls;

[ToolboxItem(true)]
public class VzxSeparator : Control
{
    private Color _lineColor = Color.FromArgb(55, 55, 75);
    private int _thickness = 1;
    private bool _fadeEdges = true;
    private Orientation _orientation = Orientation.Horizontal;

    public VzxSeparator()
    {
        DoubleBuffered = true;
        Size = new Size(200, 10);
        SetStyle(ControlStyles.AllPaintingInWmPaint |
                 ControlStyles.OptimizedDoubleBuffer |
                 ControlStyles.ResizeRedraw |
                 ControlStyles.SupportsTransparentBackColor |
                 ControlStyles.UserPaint, true);
    }

    [Category("VzxWidgets")]
    public Color LineColor
    {
        get => _lineColor;
        set { _lineColor = value; Invalidate(); }
    }

    [Category("VzxWidgets")]
    [DefaultValue(1)]
    public int Thickness
    {
        get => _thickness;
        set { _thickness = Math.Max(1, value); Invalidate(); }
    }

    [Category("VzxWidgets")]
    [DefaultValue(true)]
    public bool FadeEdges
    {
        get => _fadeEdges;
        set { _fadeEdges = value; Invalidate(); }
    }

    [Category("VzxWidgets")]
    [DefaultValue(Orientation.Horizontal)]
    public Orientation Orientation
    {
        get => _orientation;
        set { _orientation = value; Invalidate(); }
    }

    protected override void OnPaint(PaintEventArgs pevent)
    {
        var g = pevent.Graphics;
        GraphicsHelper.ApplyHighQuality(g);

        if (_orientation == Orientation.Horizontal)
        {
            float y = (Height - _thickness) / 2f;
            var rect = new RectangleF(0, y, Width, _thickness);

            if (_fadeEdges && Width > 10)
            {
                var blend = new ColorBlend(3)
                {
                    Colors = new[] { Color.Transparent, _lineColor, Color.Transparent },
                    Positions = new[] { 0.0f, 0.5f, 1.0f }
                };
                using var brush = new LinearGradientBrush(rect, Color.Transparent, Color.Transparent, 0f)
                {
                    InterpolationColors = blend
                };
                g.FillRectangle(brush, rect);
            }
            else
            {
                using var brush = new SolidBrush(_lineColor);
                g.FillRectangle(brush, rect);
            }
        }
        else
        {
            float x = (Width - _thickness) / 2f;
            var rect = new RectangleF(x, 0, _thickness, Height);

            if (_fadeEdges && Height > 10)
            {
                var blend = new ColorBlend(3)
                {
                    Colors = new[] { Color.Transparent, _lineColor, Color.Transparent },
                    Positions = new[] { 0.0f, 0.5f, 1.0f }
                };
                using var brush = new LinearGradientBrush(rect, Color.Transparent, Color.Transparent, 90f)
                {
                    InterpolationColors = blend
                };
                g.FillRectangle(brush, rect);
            }
            else
            {
                using var brush = new SolidBrush(_lineColor);
                g.FillRectangle(brush, rect);
            }
        }
    }
}
