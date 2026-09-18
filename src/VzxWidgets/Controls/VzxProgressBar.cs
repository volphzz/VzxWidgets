using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using VzxWidgets.Helpers;

namespace VzxWidgets.Controls;

[ToolboxItem(true)]
public class VzxProgressBar : Control
{
    private int _minimum = 0;
    private int _maximum = 100;
    private int _value = 65;
    private Color _startColor = Color.FromArgb(187, 200, 254);
    private Color _endColor = Color.FromArgb(145, 165, 245);
    private Color _backColorTrack = Color.FromArgb(35, 35, 48);
    private int _borderRadius = 8;
    private bool _showPercentage = true;

    public VzxProgressBar()
    {
        DoubleBuffered = true;
        Size = new Size(240, 22);
        ForeColor = Color.White;
        Font = new Font("Segoe UI Semibold", 8.5f, FontStyle.Bold);
        SetStyle(ControlStyles.AllPaintingInWmPaint |
                 ControlStyles.OptimizedDoubleBuffer |
                 ControlStyles.ResizeRedraw |
                 ControlStyles.SupportsTransparentBackColor |
                 ControlStyles.UserPaint, true);
    }

    [Category("VzxWidgets")]
    [DefaultValue(0)]
    public int Minimum
    {
        get => _minimum;
        set { _minimum = value; Invalidate(); }
    }

    [Category("VzxWidgets")]
    [DefaultValue(100)]
    public int Maximum
    {
        get => _maximum;
        set { _maximum = Math.Max(_minimum + 1, value); Invalidate(); }
    }

    [Category("VzxWidgets")]
    [DefaultValue(65)]
    public int Value
    {
        get => _value;
        set { _value = Math.Clamp(value, _minimum, _maximum); Invalidate(); }
    }

    [Category("VzxWidgets")]
    public Color GradientStartColor
    {
        get => _startColor;
        set { _startColor = value; Invalidate(); }
    }

    [Category("VzxWidgets")]
    public Color GradientEndColor
    {
        get => _endColor;
        set { _endColor = value; Invalidate(); }
    }

    [Category("VzxWidgets")]
    public Color TrackColor
    {
        get => _backColorTrack;
        set { _backColorTrack = value; Invalidate(); }
    }

    [Category("VzxWidgets")]
    [DefaultValue(8)]
    public int BorderRadius
    {
        get => _borderRadius;
        set { _borderRadius = Math.Max(0, value); Invalidate(); }
    }

    [Category("VzxWidgets")]
    [DefaultValue(true)]
    public bool ShowPercentage
    {
        get => _showPercentage;
        set { _showPercentage = value; Invalidate(); }
    }

    protected override void OnPaint(PaintEventArgs pevent)
    {
        var g = pevent.Graphics;
        GraphicsHelper.ApplyHighQuality(g);

        var rectTrack = new RectangleF(0, 0, Width, Height);

        // Fundo
        using (var pathTrack = GraphicsHelper.GetRoundedRectangle(rectTrack, _borderRadius))
        using (var brushTrack = new SolidBrush(_backColorTrack))
        {
            g.FillPath(brushTrack, pathTrack);
        }

        // Barra Ativa com Gradiente
        float progressWidth = ((float)(_value - _minimum) / (_maximum - _minimum)) * Width;
        if (progressWidth > 4)
        {
            var rectProgress = new RectangleF(0, 0, progressWidth, Height);
            using var pathProgress = GraphicsHelper.GetRoundedRectangle(rectProgress, _borderRadius);
            using var brushGradient = new LinearGradientBrush(rectTrack, _startColor, _endColor, LinearGradientMode.Horizontal);
            g.FillPath(brushGradient, pathProgress);
        }

        // Texto de Porcentagem
        if (_showPercentage)
        {
            int percent = (int)Math.Round(((float)(_value - _minimum) / (_maximum - _minimum)) * 100);
            string text = $"{percent}%";
            TextRenderer.DrawText(g, text, Font, ClientRectangle, ForeColor,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }
    }
}
