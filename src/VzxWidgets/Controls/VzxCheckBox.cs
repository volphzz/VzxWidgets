using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using VzxWidgets.Helpers;

namespace VzxWidgets.Controls;

[ToolboxItem(true)]
[DefaultEvent("CheckedChanged")]
public class VzxCheckBox : CheckBox
{
    private Color _checkedColor = Color.FromArgb(187, 200, 254);
    private Color _uncheckedColor = Color.FromArgb(45, 45, 58);
    private Color _boxBorderColor = Color.FromArgb(70, 70, 88);
    private int _boxSize = 18;
    private int _borderRadius = 5;

    // Animação de checkmark e escala
    private readonly System.Windows.Forms.Timer? _animTimer;
    private float _checkProgress = 0f;
    private float _targetProgress = 0f;

    public VzxCheckBox()
    {
        DoubleBuffered = true;
        Cursor = Cursors.Hand;
        ForeColor = Color.FromArgb(220, 220, 230);
        Font = new Font("Segoe UI", 9.5f);
        AutoSize = true;

        if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
        {
            _animTimer = new System.Windows.Forms.Timer { Interval = 15 };
            _animTimer.Tick += (s, e) =>
            {
                float diff = _targetProgress - _checkProgress;
                if (Math.Abs(diff) > 0.02f)
                {
                    _checkProgress += diff * 0.4f;
                    Invalidate();
                }
                else
                {
                    _checkProgress = _targetProgress;
                    _animTimer.Stop();
                    Invalidate();
                }
            };
        }
    }

    [Category("VzxWidgets")]
    public Color CheckedColor
    {
        get => _checkedColor;
        set { _checkedColor = value; Invalidate(); }
    }

    [Category("VzxWidgets")]
    public Color UncheckedColor
    {
        get => _uncheckedColor;
        set { _uncheckedColor = value; Invalidate(); }
    }

    [Category("VzxWidgets")]
    public Color BoxBorderColor
    {
        get => _boxBorderColor;
        set { _boxBorderColor = value; Invalidate(); }
    }

    [Category("VzxWidgets")]
    [DefaultValue(5)]
    public int BoxBorderRadius
    {
        get => _borderRadius;
        set { _borderRadius = Math.Max(0, value); Invalidate(); }
    }

    protected override void OnCheckedChanged(EventArgs e)
    {
        base.OnCheckedChanged(e);
        _targetProgress = Checked ? 1f : 0f;
        if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
        {
            _animTimer?.Start();
        }
        else
        {
            _checkProgress = _targetProgress;
            Invalidate();
        }
    }

    public override Size GetPreferredSize(Size proposedSize)
    {
        Size textSize = TextRenderer.MeasureText(string.IsNullOrEmpty(Text) ? " " : Text, Font);
        return new Size(_boxSize + 12 + textSize.Width, Math.Max(_boxSize, textSize.Height + 4));
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

        // Preencher o fundo com a cor do container para evitar ghosting / smearing
        Color parentBg = Parent?.BackColor ?? Color.FromArgb(14, 14, 18);
        using (var brushBg = new SolidBrush(parentBg))
        {
            g.FillRectangle(brushBg, ClientRectangle);
        }

        float yPos = (Height - _boxSize) / 2f;
        var rectBox = new RectangleF(1, yPos, _boxSize, _boxSize);

        float progress = (LicenseManager.UsageMode == LicenseUsageMode.Designtime) ? (Checked ? 1f : 0f) : _checkProgress;

        using var path = GraphicsHelper.GetRoundedRectangle(rectBox, _borderRadius);
        Color currentBg = LerpColor(_uncheckedColor, _checkedColor, progress);

        using (var brush = new SolidBrush(currentBg))
        {
            g.FillPath(brush, path);
        }

        // Borda quando desmarcado
        if (progress < 0.95f)
        {
            int borderAlpha = (int)(255 * (1f - progress));
            using var penBorder = new Pen(Color.FromArgb(borderAlpha, _boxBorderColor), 1.2f);
            g.DrawPath(penBorder, path);
        }

        // Checkmark animado vetorizado
        if (progress > 0.05f)
        {
            using var penCheck = new Pen(Color.FromArgb((int)(255 * progress), 18, 18, 26), 2.2f)
            {
                StartCap = LineCap.Round,
                EndCap = LineCap.Round,
                LineJoin = LineJoin.Round
            };

            var p1 = new PointF(rectBox.X + 4.5f, rectBox.Y + 9f);
            var p2 = new PointF(rectBox.X + 7.5f, rectBox.Y + 12.5f);
            var p3 = new PointF(rectBox.X + 13.5f, rectBox.Y + 5.5f);

            if (progress < 0.5f)
            {
                float t = progress / 0.5f;
                var currentP2 = new PointF(p1.X + (p2.X - p1.X) * t, p1.Y + (p2.Y - p1.Y) * t);
                g.DrawLine(penCheck, p1, currentP2);
            }
            else
            {
                g.DrawLine(penCheck, p1, p2);
                float t = (progress - 0.5f) / 0.5f;
                var currentP3 = new PointF(p2.X + (p3.X - p2.X) * t, p2.Y + (p3.Y - p2.Y) * t);
                g.DrawLine(penCheck, p2, currentP3);
            }
        }

        // Texto ao lado
        var textRect = new Rectangle(_boxSize + 8, 0, Width - _boxSize - 8, Height);
        TextRenderer.DrawText(g, Text, Font, textRect, ForeColor,
            TextFormatFlags.Left | TextFormatFlags.VerticalCenter);
    }
}
