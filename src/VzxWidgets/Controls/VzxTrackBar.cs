using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using VzxWidgets.Helpers;

namespace VzxWidgets.Controls;

[ToolboxItem(true)]
[DefaultEvent("ValueChanged")]
public class VzxTrackBar : Control
{
    private int _minimum = 0;
    private int _maximum = 100;
    private int _value = 50;
    private Color _trackColor = Color.FromArgb(40, 40, 52);
    private Color _progressColor = Color.FromArgb(187, 200, 254); // Pastel lavender
    private Color _thumbColor = Color.White;
    private int _trackHeight = 6;
    private int _thumbSize = 12;
    private bool _isDragging = false;
    private bool _showDiamondThumb = true;

    public event EventHandler? ValueChanged;

    public VzxTrackBar()
    {
        DoubleBuffered = true;
        Size = new Size(200, 24);
        Cursor = Cursors.Hand;
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
        set { _minimum = value; if (_value < _minimum) _value = _minimum; Invalidate(); }
    }

    [Category("VzxWidgets")]
    [DefaultValue(100)]
    public int Maximum
    {
        get => _maximum;
        set { _maximum = Math.Max(_minimum + 1, value); if (_value > _maximum) _value = _maximum; Invalidate(); }
    }

    [Category("VzxWidgets")]
    [DefaultValue(50)]
    public int Value
    {
        get => _value;
        set
        {
            int clamped = Math.Clamp(value, _minimum, _maximum);
            if (_value != clamped)
            {
                _value = clamped;
                Invalidate();
                ValueChanged?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    [Category("VzxWidgets")]
    public Color TrackColor
    {
        get => _trackColor;
        set { _trackColor = value; Invalidate(); }
    }

    [Category("VzxWidgets")]
    public Color ProgressColor
    {
        get => _progressColor;
        set { _progressColor = value; Invalidate(); }
    }

    [Category("VzxWidgets")]
    public Color ThumbColor
    {
        get => _thumbColor;
        set { _thumbColor = value; Invalidate(); }
    }

    [Category("VzxWidgets")]
    [DefaultValue(6)]
    public int TrackHeight
    {
        get => _trackHeight;
        set { _trackHeight = Math.Max(2, value); Invalidate(); }
    }

    [Category("VzxWidgets")]
    [DefaultValue(true)]
    public bool ShowDiamondThumb
    {
        get => _showDiamondThumb;
        set { _showDiamondThumb = value; Invalidate(); }
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        base.OnMouseDown(e);
        if (e.Button == MouseButtons.Left)
        {
            _isDragging = true;
            UpdateValueFromMouse(e.X);
        }
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
        base.OnMouseMove(e);
        if (_isDragging)
        {
            UpdateValueFromMouse(e.X);
        }
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
        base.OnMouseUp(e);
        _isDragging = false;
    }

    private void UpdateValueFromMouse(int mouseX)
    {
        float margin = _thumbSize / 2f;
        float trackWidth = Width - _thumbSize;
        float clampedX = Math.Clamp(mouseX - margin, 0, trackWidth);
        float percent = clampedX / trackWidth;
        Value = _minimum + (int)Math.Round(percent * (_maximum - _minimum));
    }

    protected override void OnPaint(PaintEventArgs pevent)
    {
        var g = pevent.Graphics;
        GraphicsHelper.ApplyHighQuality(g);

        float trackY = (Height - _trackHeight) / 2f;
        float trackWidth = Width - _thumbSize;
        float thumbX = ((float)(_value - _minimum) / (_maximum - _minimum)) * trackWidth + (_thumbSize / 2f);

        // Track Fundo
        var rectTrack = new RectangleF(_thumbSize / 2f, trackY, trackWidth, _trackHeight);
        using (var pathTrack = GraphicsHelper.GetRoundedRectangle(rectTrack, _trackHeight / 2f))
        using (var brushTrack = new SolidBrush(_trackColor))
        {
            g.FillPath(brushTrack, pathTrack);
        }

        // Progresso Ativo (com gradiente se desejar)
        float activeWidth = thumbX - (_thumbSize / 2f);
        if (activeWidth > 0)
        {
            var rectActive = new RectangleF(_thumbSize / 2f, trackY, activeWidth, _trackHeight);
            using var pathActive = GraphicsHelper.GetRoundedRectangle(rectActive, _trackHeight / 2f);
            using var brushActive = new SolidBrush(_progressColor);
            g.FillPath(brushActive, pathActive);
        }

        // Thumb (Gamer Diamond ou Pílula)
        float thumbCenterY = Height / 2f;
        if (_showDiamondThumb)
        {
            // Diamante estilo CS2/Apex Cheat UI
            float half = _thumbSize / 2f;
            PointF[] diamond = {
                new PointF(thumbX, thumbCenterY - half),
                new PointF(thumbX + half, thumbCenterY),
                new PointF(thumbX, thumbCenterY + half),
                new PointF(thumbX - half, thumbCenterY)
            };
            using var brushThumb = new SolidBrush(_thumbColor);
            g.FillPolygon(brushThumb, diamond);
        }
        else
        {
            var rectThumb = new RectangleF(thumbX - (_thumbSize / 2f), thumbCenterY - (_thumbSize / 2f), _thumbSize, _thumbSize);
            using var brushThumb = new SolidBrush(_thumbColor);
            g.FillEllipse(brushThumb, rectThumb);
        }
    }
}
