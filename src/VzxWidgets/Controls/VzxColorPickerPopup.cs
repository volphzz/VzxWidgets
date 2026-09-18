using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using VzxWidgets.Helpers;

namespace VzxWidgets.Controls;

/// <summary>
/// Popup flutuante moderno estilo Figma / Cheat UI para seleção avançada de cores HSV.
/// </summary>
public class VzxColorPickerPopup : UserControl
{
    private float _hue = 220f;       // 0 a 360
    private float _saturation = 0.8f; // 0 a 1
    private float _value = 0.9f;     // 0 a 1
    private int _alpha = 255;        // 0 a 255

    private bool _isDraggingSatVal = false;
    private bool _isDraggingHue = false;
    private bool _isDraggingAlpha = false;

    private readonly Rectangle _satValRect = new Rectangle(14, 34, 192, 130);
    private readonly Rectangle _hueRect = new Rectangle(14, 176, 192, 14);
    private readonly Rectangle _alphaRect = new Rectangle(14, 200, 192, 14);

    public event EventHandler? ColorChanged;

    public Color SelectedColor
    {
        get => ColorFromHsv(_hue, _saturation, _value, _alpha);
        set
        {
            ColorToHsv(value, out _hue, out _saturation, out _value);
            _alpha = value.A;
            Invalidate();
            ColorChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    public VzxColorPickerPopup()
    {
        DoubleBuffered = true;
        Size = new Size(220, 260);
        BackColor = Color.FromArgb(14, 14, 18);
        ForeColor = Color.White;
        Font = new Font("Segoe UI", 8.5f);

        SetStyle(ControlStyles.AllPaintingInWmPaint |
                 ControlStyles.OptimizedDoubleBuffer |
                 ControlStyles.ResizeRedraw |
                 ControlStyles.UserPaint, true);
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        base.OnMouseDown(e);
        if (_satValRect.Contains(e.Location))
        {
            _isDraggingSatVal = true;
            UpdateSatValFromMouse(e.X, e.Y);
        }
        else if (_hueRect.Contains(e.Location))
        {
            _isDraggingHue = true;
            UpdateHueFromMouse(e.X);
        }
        else if (_alphaRect.Contains(e.Location))
        {
            _isDraggingAlpha = true;
            UpdateAlphaFromMouse(e.X);
        }
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
        base.OnMouseMove(e);
        if (_isDraggingSatVal)
        {
            UpdateSatValFromMouse(e.X, e.Y);
        }
        else if (_isDraggingHue)
        {
            UpdateHueFromMouse(e.X);
        }
        else if (_isDraggingAlpha)
        {
            UpdateAlphaFromMouse(e.X);
        }
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
        base.OnMouseUp(e);
        _isDraggingSatVal = false;
        _isDraggingHue = false;
        _isDraggingAlpha = false;
    }

    private void UpdateSatValFromMouse(int x, int y)
    {
        float clampedX = Math.Clamp(x - _satValRect.X, 0, _satValRect.Width);
        float clampedY = Math.Clamp(y - _satValRect.Y, 0, _satValRect.Height);

        _saturation = clampedX / _satValRect.Width;
        _value = 1f - (clampedY / _satValRect.Height);

        Invalidate();
        ColorChanged?.Invoke(this, EventArgs.Empty);
    }

    private void UpdateHueFromMouse(int x)
    {
        float clampedX = Math.Clamp(x - _hueRect.X, 0, _hueRect.Width);
        _hue = (clampedX / _hueRect.Width) * 360f;
        if (_hue >= 360f) _hue = 359f;

        Invalidate();
        ColorChanged?.Invoke(this, EventArgs.Empty);
    }

    private void UpdateAlphaFromMouse(int x)
    {
        float clampedX = Math.Clamp(x - _alphaRect.X, 0, _alphaRect.Width);
        _alpha = (int)Math.Round((clampedX / _alphaRect.Width) * 255f);

        Invalidate();
        ColorChanged?.Invoke(this, EventArgs.Empty);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        var g = e.Graphics;
        GraphicsHelper.ApplyHighQuality(g);

        // Fundo do card
        var rectBorder = new RectangleF(0, 0, Width - 1, Height - 1);
        using (var pathCard = GraphicsHelper.GetRoundedRectangle(rectBorder, 12))
        using (var brushBg = new SolidBrush(BackColor))
        using (var penBorder = new Pen(Color.FromArgb(38, 38, 50), 1f))
        {
            g.FillPath(brushBg, pathCard);
            g.DrawPath(penBorder, pathCard);
        }

        // Título "Solid"
        TextRenderer.DrawText(g, "Solid ▾", Font, new Point(14, 12), Color.FromArgb(160, 160, 180));

        // 1. Área Saturation/Value (2D Gradient)
        DrawSatValBox(g);

        // 2. Slider Rainbow HUE
        DrawHueSlider(g);

        // 3. Slider Alpha (Opacidade)
        DrawAlphaSlider(g);

        // 4. Hex Box & %
        DrawFooterHex(g);
    }

    private void DrawSatValBox(Graphics g)
    {
        using var path = GraphicsHelper.GetRoundedRectangle(_satValRect, 6);
        g.SetClip(path);

        Color pureHue = ColorFromHsv(_hue, 1f, 1f, 255);

        // Gradiente horizontal (Branco para Cor Pura)
        using (var brushH = new LinearGradientBrush(_satValRect, Color.White, pureHue, LinearGradientMode.Horizontal))
        {
            g.FillRectangle(brushH, _satValRect);
        }

        // Gradiente vertical (Transparente para Preto)
        using (var brushV = new LinearGradientBrush(_satValRect, Color.Transparent, Color.Black, LinearGradientMode.Vertical))
        {
            g.FillRectangle(brushV, _satValRect);
        }

        g.ResetClip();

        // Borda suave
        using (var penBorder = new Pen(Color.FromArgb(50, 50, 65), 1f))
        {
            g.DrawPath(penBorder, path);
        }

        // Handle circular do Sat/Val
        float handleX = _satValRect.X + (_saturation * _satValRect.Width);
        float handleY = _satValRect.Y + ((1f - _value) * _satValRect.Height);

        using var penHandle = new Pen(Color.White, 2.2f);
        using var penShadow = new Pen(Color.FromArgb(80, 0, 0, 0), 1f);
        g.DrawEllipse(penShadow, handleX - 6.5f, handleY - 6.5f, 13, 13);
        g.DrawEllipse(penHandle, handleX - 5.5f, handleY - 5.5f, 11, 11);
    }

    private void DrawHueSlider(Graphics g)
    {
        using var path = GraphicsHelper.GetRoundedRectangle(_hueRect, _hueRect.Height / 2f);
        g.SetClip(path);

        // Arco-íris HUE
        using (var brush = new LinearGradientBrush(_hueRect, Color.Red, Color.Red, LinearGradientMode.Horizontal))
        {
            var blend = new ColorBlend(7)
            {
                Positions = new[] { 0.0f, 0.17f, 0.33f, 0.5f, 0.67f, 0.83f, 1.0f },
                Colors = new[] {
                    Color.Red,
                    Color.Yellow,
                    Color.Lime,
                    Color.Cyan,
                    Color.Blue,
                    Color.Magenta,
                    Color.Red
                }
            };
            brush.InterpolationColors = blend;
            g.FillRectangle(brush, _hueRect);
        }

        g.ResetClip();

        // Thumb do HUE (pílula vazada com contorno branco)
        float thumbX = _hueRect.X + ((_hue / 360f) * _hueRect.Width);
        var thumbRect = new RectangleF(thumbX - 4f, _hueRect.Y - 1f, 8f, _hueRect.Height + 2f);
        using (var pathThumb = GraphicsHelper.GetRoundedRectangle(thumbRect, 4f))
        using (var penThumb = new Pen(Color.White, 2f))
        using (var penShadow = new Pen(Color.FromArgb(100, 0, 0, 0), 1f))
        {
            g.DrawPath(penShadow, pathThumb);
            g.DrawPath(penThumb, pathThumb);
        }
    }

    private void DrawAlphaSlider(Graphics g)
    {
        using var path = GraphicsHelper.GetRoundedRectangle(_alphaRect, _alphaRect.Height / 2f);
        g.SetClip(path);

        Color baseColor = ColorFromHsv(_hue, _saturation, _value, 255);
        using (var brush = new LinearGradientBrush(_alphaRect, Color.FromArgb(0, baseColor), baseColor, LinearGradientMode.Horizontal))
        {
            g.FillRectangle(brush, _alphaRect);
        }

        g.ResetClip();

        // Thumb do Alpha
        float thumbX = _alphaRect.X + ((_alpha / 255f) * _alphaRect.Width);
        var thumbRect = new RectangleF(thumbX - 4f, _alphaRect.Y - 1f, 8f, _alphaRect.Height + 2f);
        using (var pathThumb = GraphicsHelper.GetRoundedRectangle(thumbRect, 4f))
        using (var penThumb = new Pen(Color.White, 2f))
        {
            g.DrawPath(penThumb, pathThumb);
        }
    }

    private void DrawFooterHex(Graphics g)
    {
        int y = 224;
        var rectHex = new Rectangle(14, y, 92, 26);
        using (var pathHex = GraphicsHelper.GetRoundedRectangle(rectHex, 6))
        using (var brushHex = new SolidBrush(Color.FromArgb(24, 24, 32)))
        using (var penHex = new Pen(Color.FromArgb(40, 40, 55), 1f))
        {
            g.FillPath(brushHex, pathHex);
            g.DrawPath(penHex, pathHex);
        }

        Color c = SelectedColor;
        string hexText = $"#{c.R:X2}{c.G:X2}{c.B:X2}";
        TextRenderer.DrawText(g, hexText, Font, rectHex, Color.FromArgb(220, 220, 235),
            TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

        // Porcentagem Alpha
        int alphaPercent = (int)Math.Round((_alpha / 255f) * 100);
        var rectPct = new Rectangle(114, y, 40, 26);
        TextRenderer.DrawText(g, $"{alphaPercent}%", Font, rectPct, Color.FromArgb(160, 160, 180),
            TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

        // "HEX ▾"
        var rectMode = new Rectangle(156, y, 50, 26);
        using (var pathMode = GraphicsHelper.GetRoundedRectangle(rectMode, 6))
        using (var brushMode = new SolidBrush(Color.FromArgb(24, 24, 32)))
        {
            g.FillPath(brushMode, pathMode);
        }
        TextRenderer.DrawText(g, "HEX ▾", Font, rectMode, Color.FromArgb(170, 170, 190),
            TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
    }

    private static Color ColorFromHsv(float h, float s, float v, int a)
    {
        int hi = (int)Math.Floor(h / 60) % 6;
        float f = (h / 60) - (float)Math.Floor(h / 60);

        v *= 255;
        int val = (int)Math.Clamp(v, 0, 255);
        int p = (int)Math.Clamp(v * (1 - s), 0, 255);
        int q = (int)Math.Clamp(v * (1 - (f * s)), 0, 255);
        int t = (int)Math.Clamp(v * (1 - ((1 - f) * s)), 0, 255);

        return hi switch
        {
            0 => Color.FromArgb(a, val, t, p),
            1 => Color.FromArgb(a, q, val, p),
            2 => Color.FromArgb(a, p, val, t),
            3 => Color.FromArgb(a, p, q, val),
            4 => Color.FromArgb(a, t, p, val),
            _ => Color.FromArgb(a, val, p, q)
        };
    }

    private static void ColorToHsv(Color c, out float h, out float s, out float v)
    {
        float r = c.R / 255f;
        float g = c.G / 255f;
        float b = c.B / 255f;

        float max = Math.Max(r, Math.Max(g, b));
        float min = Math.Min(r, Math.Min(g, b));

        v = max;
        float delta = max - min;
        s = max == 0 ? 0 : delta / max;

        if (delta == 0)
        {
            h = 0;
        }
        else if (max == r)
        {
            h = 60 * (((g - b) / delta) % 6);
        }
        else if (max == g)
        {
            h = 60 * (((b - r) / delta) + 2);
        }
        else
        {
            h = 60 * (((r - g) / delta) + 4);
        }

        if (h < 0) h += 360;
    }
}
