using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using VzxWidgets.Helpers;

namespace VzxWidgets.Controls;

[ToolboxItem(true)]
[DefaultEvent("CheckedChanged")]
public class VzxToggleSwitch : Control
{
    private bool _checked = false;
    private Color _onBackColor = Color.FromArgb(187, 200, 254);
    private Color _onToggleColor = Color.FromArgb(18, 18, 26);
    private Color _offBackColor = Color.FromArgb(45, 45, 60);
    private Color _offToggleColor = Color.FromArgb(160, 160, 175);

    // Animação suave 60fps
    private readonly System.Windows.Forms.Timer _animTimer;
    private float _animProgress = 0f; // 0.0 (off) a 1.0 (on)
    private float _targetProgress = 0f;

    public event EventHandler? CheckedChanged;

    public VzxToggleSwitch()
    {
        Size = new Size(50, 26);
        MinimumSize = new Size(36, 18);
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
            float diff = _targetProgress - _animProgress;
            if (Math.Abs(diff) > 0.01f)
            {
                _animProgress += diff * 0.35f;
                Invalidate();
            }
            else
            {
                _animProgress = _targetProgress;
                _animTimer.Stop();
                Invalidate();
            }
        };
    }

    [Category("VzxWidgets")]
    [DefaultValue(false)]
    public bool Checked
    {
        get => _checked;
        set
        {
            if (_checked != value)
            {
                _checked = value;
                _targetProgress = _checked ? 1f : 0f;
                _animTimer.Start();
                CheckedChanged?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    [Category("VzxWidgets")]
    public Color OnBackColor
    {
        get => _onBackColor;
        set { _onBackColor = value; Invalidate(); }
    }

    [Category("VzxWidgets")]
    public Color OnToggleColor
    {
        get => _onToggleColor;
        set { _onToggleColor = value; Invalidate(); }
    }

    [Category("VzxWidgets")]
    public Color OffBackColor
    {
        get => _offBackColor;
        set { _offBackColor = value; Invalidate(); }
    }

    [Category("VzxWidgets")]
    public Color OffToggleColor
    {
        get => _offToggleColor;
        set { _offToggleColor = value; Invalidate(); }
    }

    protected override void OnMouseClick(MouseEventArgs e)
    {
        base.OnMouseClick(e);
        if (e.Button == MouseButtons.Left)
        {
            Checked = !Checked;
        }
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

        int toggleSize = Height - 6;
        var rectSurface = new RectangleF(0, 0, Width - 1, Height - 1);

        using var pathBg = GraphicsHelper.GetRoundedRectangle(rectSurface, Height / 2f);

        Color currentBg = LerpColor(_offBackColor, _onBackColor, _animProgress);
        using (var brush = new SolidBrush(currentBg))
        {
            g.FillPath(brush, pathBg);
        }

        // Borda sutil
        using (var penBorder = new Pen(Color.FromArgb(40, 40, 56), 1f))
        {
            g.DrawPath(penBorder, pathBg);
        }

        float minX = 3f;
        float maxX = Width - toggleSize - 3f;
        float toggleX = minX + (maxX - minX) * _animProgress;

        var rectToggle = new RectangleF(toggleX, 3, toggleSize, toggleSize);
        Color currentToggle = LerpColor(_offToggleColor, _onToggleColor, _animProgress);

        using (var brushToggle = new SolidBrush(currentToggle))
        {
            g.FillEllipse(brushToggle, rectToggle);
        }
    }
}
