using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using VzxWidgets.Helpers;

namespace VzxWidgets.Controls;

[ToolboxItem(true)]
public class VzxDotHeader : Control
{
    private Color _dotColor = Color.FromArgb(187, 200, 254); // Pastel lavender / ice-blue
    private Color _textColor = Color.FromArgb(220, 220, 235);
    private int _dotSize = 7;
    private bool _pulseGlow = true;

    // Animação de pulso do ponto
    private readonly System.Windows.Forms.Timer? _pulseTimer;
    private float _pulseFactor = 0.6f;
    private bool _pulseIncreasing = true;

    public VzxDotHeader()
    {
        DoubleBuffered = true;
        Size = new Size(140, 24);
        Font = new Font("Segoe UI Semibold", 9.5f, FontStyle.Bold);

        SetStyle(ControlStyles.AllPaintingInWmPaint |
                 ControlStyles.OptimizedDoubleBuffer |
                 ControlStyles.ResizeRedraw |
                 ControlStyles.SupportsTransparentBackColor |
                 ControlStyles.UserPaint, true);

        if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
        {
            _pulseTimer = new System.Windows.Forms.Timer { Interval = 40 };
            _pulseTimer.Tick += (s, e) =>
            {
                if (_pulseIncreasing)
                {
                    _pulseFactor += 0.04f;
                    if (_pulseFactor >= 1.0f)
                    {
                        _pulseFactor = 1.0f;
                        _pulseIncreasing = false;
                    }
                }
                else
                {
                    _pulseFactor -= 0.04f;
                    if (_pulseFactor <= 0.4f)
                    {
                        _pulseFactor = 0.4f;
                        _pulseIncreasing = true;
                    }
                }
                Invalidate();
            };
            _pulseTimer.Start();
        }
    }

    [Category("VzxWidgets")]
    public Color DotColor
    {
        get => _dotColor;
        set { _dotColor = value; Invalidate(); }
    }

    [Category("VzxWidgets")]
    public Color TextColor
    {
        get => _textColor;
        set { _textColor = value; Invalidate(); }
    }

    [Category("VzxWidgets")]
    [DefaultValue(7)]
    public int DotSize
    {
        get => _dotSize;
        set { _dotSize = Math.Max(2, value); Invalidate(); }
    }

    [Category("VzxWidgets")]
    [DefaultValue(true)]
    public bool PulseGlow
    {
        get => _pulseGlow;
        set
        {
            _pulseGlow = value;
            if (_pulseTimer != null)
            {
                _pulseTimer.Enabled = value;
            }
            Invalidate();
        }
    }

    protected override void OnPaint(PaintEventArgs pevent)
    {
        var g = pevent.Graphics;
        GraphicsHelper.ApplyHighQuality(g);

        // Limpar fundo com a cor do parent para evitar efeito ghosting/smear
        Color parentBg = Parent?.BackColor ?? Color.FromArgb(14, 14, 18);
        using (var brushBg = new SolidBrush(parentBg))
        {
            g.FillRectangle(brushBg, ClientRectangle);
        }

        float dotY = (Height - _dotSize) / 2f;

        // Halo suave pulsante (apenas em runtime se ativado)
        if (_pulseGlow && LicenseManager.UsageMode != LicenseUsageMode.Designtime)
        {
            float haloSize = _dotSize + (6f * _pulseFactor);
            float haloX = (_dotSize / 2f) - (haloSize / 2f);
            float haloY = (Height / 2f) - (haloSize / 2f);
            int haloAlpha = (int)(55 * _pulseFactor);

            using var brushHalo = new SolidBrush(Color.FromArgb(haloAlpha, _dotColor));
            g.FillEllipse(brushHalo, haloX, haloY, haloSize, haloSize);
        }

        // Ponto central
        using var brushDot = new SolidBrush(_dotColor);
        g.FillEllipse(brushDot, 0, dotY, _dotSize, _dotSize);

        // Texto
        var textRect = new Rectangle(_dotSize + 8, 0, Width - _dotSize - 8, Height);
        TextRenderer.DrawText(g, Text, Font, textRect, _textColor,
            TextFormatFlags.Left | TextFormatFlags.VerticalCenter);
    }
}
