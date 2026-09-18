using System;
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
    private Color _progressColor = Color.FromArgb(187, 200, 254);
    private Color _thumbColor = Color.White;
    private int _trackHeight = 6;
    private int _thumbSize = 12;
    private bool _isDragging = false;
    private bool _isHovered = false;
    private bool _showDiamondThumb = true;

    // Animação de escala do Thumb
    private readonly System.Windows.Forms.Timer _animTimer;
    private float _thumbScale = 1.0f;
    private float _targetScale = 1.0f;

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

        _animTimer = new System.Windows.Forms.Timer { Interval = 15 };
        _animTimer.Tick += (s, e) =>
        {
            float diff = _targetScale - _thumbScale;
            if (Math.Abs(diff) > 0.02f)
            {
                _thumbScale += diff * 0.35f;
                Invalidate();
            }
            else
            {
                _thumbScale = _targetScale;
                _animTimer.Stop();
                Invalidate();
            }
        };
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
        set { _maximum = value; Invalidate(); }
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
        set { _trackHeight = value; Invalidate(); }
    }

    [Category("VzxWidgets")]
    [DefaultValue(12)]
    public int ThumbSize
    {
        get => _thumbSize;
        set { _thumbSize = value; Invalidate(); }
    }

    [Category("VzxWidgets")]
    [DefaultValue(true)]
    public bool ShowDiamondThumb
    {
        get => _showDiamondThumb;
        set { _showDiamondThumb = value; Invalidate(); }
    }

    protected override void OnMouseEnter(EventArgs e)
    {
        base.OnMouseEnter(e);
        _isHovered = true;
        _targetScale = 1.35f;
        _animTimer.Start();
    }

    protected override void OnMouseLeave(EventArgs e)
    {
        base.OnMouseLeave(e);
        _isHovered = false;
        if (!_isDragging)
        {
            _targetScale = 1.0f;
            _animTimer.Start();
        }
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        base.OnMouseDown(e);
        if (e.Button == MouseButtons.Left)
        {
            _isDragging = true;
            _targetScale = 1.45f;
            _animTimer.Start();
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
        if (_isDragging)
        {
            _isDragging = false;
            _targetScale = _isHovered ? 1.35f : 1.0f;
            _animTimer.Start();
        }
    }

    private void UpdateValueFromMouse(int mouseX)
    {
        float margin = _thumbSize;
        float trackWidth = Width - (margin * 2);
        if (trackWidth <= 0) return;

        float percent = (mouseX - margin) / trackWidth;
        percent = Math.Clamp(percent, 0f, 1f);
        Value = _minimum + (int)Math.Round(percent * (_maximum - _minimum));
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        var g = e.Graphics;
        GraphicsHelper.ApplyHighQuality(g);

        float margin = _thumbSize;
        float trackWidth = Width - (margin * 2);
        float trackY = (Height - _trackHeight) / 2f;

        // Fundo da barra
        var rectTrack = new RectangleF(margin, trackY, trackWidth, _trackHeight);
        using var pathTrack = GraphicsHelper.GetRoundedRectangle(rectTrack, _trackHeight / 2f);
        using var brushTrack = new SolidBrush(_trackColor);
        g.FillPath(brushTrack, pathTrack);

        // Barra de progresso ativo
        float percent = (_maximum > _minimum) ? (float)(_value - _minimum) / (_maximum - _minimum) : 0f;
        float activeWidth = trackWidth * percent;

        if (activeWidth > 0)
        {
            var rectActive = new RectangleF(margin, trackY, activeWidth, _trackHeight);
            using var pathActive = GraphicsHelper.GetRoundedRectangle(rectActive, _trackHeight / 2f);
            using var brushActive = new SolidBrush(_progressColor);
            g.FillPath(brushActive, pathActive);
        }

        // Thumb interativo
        float thumbX = margin + activeWidth;
        float thumbY = Height / 2f;
        float currentSize = _thumbSize * _thumbScale;
        float halfSize = currentSize / 2f;

        // Glow translúcido animado
        if (_thumbScale > 1.05f)
        {
            float glowSize = currentSize + 8f;
            using var brushGlow = new SolidBrush(Color.FromArgb(40, _progressColor));
            g.FillEllipse(brushGlow, thumbX - (glowSize / 2f), thumbY - (glowSize / 2f), glowSize, glowSize);
        }

        if (_showDiamondThumb)
        {
            PointF[] diamond = {
                new PointF(thumbX, thumbY - halfSize),
                new PointF(thumbX + halfSize, thumbY),
                new PointF(thumbX, thumbY + halfSize),
                new PointF(thumbX - halfSize, thumbY)
            };

            using var brushThumb = new SolidBrush(_thumbColor);
            using var penThumb = new Pen(_progressColor, 1.5f);
            g.FillPolygon(brushThumb, diamond);
            g.DrawPolygon(penThumb, diamond);
        }
        else
        {
            var rectThumb = new RectangleF(thumbX - halfSize, thumbY - halfSize, currentSize, currentSize);
            using var brushThumb = new SolidBrush(_thumbColor);
            using var penThumb = new Pen(_progressColor, 1.5f);
            g.FillEllipse(brushThumb, rectThumb);
            g.DrawEllipse(penThumb, rectThumb);
        }
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            _animTimer.Stop();
            _animTimer.Dispose();
        }
        base.Dispose(disposing);
    }
}
