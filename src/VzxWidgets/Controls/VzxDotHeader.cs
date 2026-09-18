using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using VzxWidgets.Helpers;

namespace VzxWidgets.Controls;

[ToolboxItem(true)]
public class VzxDotHeader : Control
{
    private Color _dotColor = Color.FromArgb(155, 80, 255); // Roxo neon
    private Color _textColor = Color.FromArgb(220, 220, 235);
    private int _dotSize = 7;

    public VzxDotHeader()
    {
        DoubleBuffered = true;
        Size = new Size(120, 24);
        Font = new Font("Segoe UI Semibold", 9.5f, FontStyle.Bold);
        SetStyle(ControlStyles.AllPaintingInWmPaint |
                 ControlStyles.OptimizedDoubleBuffer |
                 ControlStyles.ResizeRedraw |
                 ControlStyles.SupportsTransparentBackColor |
                 ControlStyles.UserPaint, true);
    }

    [Category("VzxWidgets")]
    public Color DotColor
    {
        get => _dotColor;
        set { _dotColor = value; Invalidate(); }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        var g = e.Graphics;
        GraphicsHelper.ApplyHighQuality(g);

        float dotY = (Height - _dotSize) / 2f;
        var rectDot = new RectangleF(0, dotY, _dotSize, _dotSize);

        using (var brushDot = new SolidBrush(_dotColor))
        {
            g.FillEllipse(brushDot, rectDot);
        }

        var textRect = new Rectangle(_dotSize + 7, 0, Width - _dotSize - 7, Height);
        TextRenderer.DrawText(g, Text, Font, textRect, _textColor,
            TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
    }
}
