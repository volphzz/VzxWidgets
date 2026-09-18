using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using VzxWidgets.Helpers;

namespace VzxWidgets.Controls;

[ToolboxItem(true)]
public class VzxCard : Panel
{
    private int _borderRadius = 14;
    private int _borderSize = 1;
    private Color _borderColor = Color.FromArgb(38, 38, 50);

    public VzxCard()
    {
        DoubleBuffered = true;
        BackColor = Color.FromArgb(14, 14, 18);
        Padding = new Padding(14);
        SetStyle(ControlStyles.AllPaintingInWmPaint |
                 ControlStyles.OptimizedDoubleBuffer |
                 ControlStyles.ResizeRedraw |
                 ControlStyles.UserPaint, true);
    }

    [Category("VzxWidgets")]
    [DefaultValue(14)]
    public int BorderRadius
    {
        get => _borderRadius;
        set
        {
            _borderRadius = Math.Max(0, value);
            UpdateRegion();
            Invalidate();
        }
    }

    [Category("VzxWidgets")]
    [DefaultValue(1)]
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

    protected override void OnResize(EventArgs eventargs)
    {
        base.OnResize(eventargs);
        UpdateRegion();
    }

    private void UpdateRegion()
    {
        if (Width <= 0 || Height <= 0) return;

        if (_borderRadius > 2)
        {
            using var path = GraphicsHelper.GetRoundedRectangle(new RectangleF(0, 0, Width, Height), _borderRadius);
            Region = new Region(path);
        }
        else
        {
            Region = new Region(new RectangleF(0, 0, Width, Height));
        }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        var g = e.Graphics;
        GraphicsHelper.ApplyHighQuality(g);

        var rectSurface = new RectangleF(0, 0, Width, Height);
        var rectBorder = new RectangleF(0.5f, 0.5f, Width - 1f, Height - 1f);

        if (_borderRadius > 2)
        {
            using var pathSurface = GraphicsHelper.GetRoundedRectangle(rectSurface, _borderRadius);
            using var pathBorder = GraphicsHelper.GetRoundedRectangle(rectBorder, _borderRadius - 1);
            using var brushBg = new SolidBrush(BackColor);
            using var penBorder = new Pen(_borderColor, _borderSize);

            g.FillPath(brushBg, pathSurface);

            if (_borderSize >= 1)
            {
                g.DrawPath(penBorder, pathBorder);
            }
        }
        else
        {
            using var brushBg = new SolidBrush(BackColor);
            g.FillRectangle(brushBg, rectSurface);

            if (_borderSize >= 1)
            {
                using var penBorder = new Pen(_borderColor, _borderSize);
                g.DrawRectangle(penBorder, 0, 0, Width - 1, Height - 1);
            }
        }
    }
}
