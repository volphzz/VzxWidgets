using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using VzxWidgets.Helpers;

namespace VzxWidgets.Controls;

[ToolboxItem(true)]
[DefaultEvent("KeyChanged")]
public class VzxKeybind : Control
{
    private Keys _currentKey = Keys.Insert;
    private bool _isListening = false;
    private Color _boxBackColor = Color.FromArgb(24, 24, 32);
    private Color _borderColor = Color.FromArgb(48, 48, 64);
    private Color _activeBorderColor = Color.FromArgb(187, 200, 254);
    private Color _hoverBorderColor = Color.FromArgb(187, 200, 254);
    private int _borderRadius = 6;
    private bool _isHovered = false;

    // Animação de pulso respiratório (Breathing neon glow)
    private readonly System.Windows.Forms.Timer? _pulseTimer;
    private float _pulseAlpha = 0.5f;
    private bool _pulseIncreasing = true;

    public event EventHandler? KeyChanged;

    public VzxKeybind()
    {
        DoubleBuffered = true;
        Size = new Size(88, 28);
        Cursor = Cursors.Hand;
        ForeColor = Color.FromArgb(220, 220, 235);
        Font = new Font("Segoe UI Semibold", 8.5f, FontStyle.Bold);

        SetStyle(ControlStyles.Selectable |
                 ControlStyles.AllPaintingInWmPaint |
                 ControlStyles.OptimizedDoubleBuffer |
                 ControlStyles.ResizeRedraw |
                 ControlStyles.SupportsTransparentBackColor |
                 ControlStyles.UserPaint, true);

        if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
        {
            _pulseTimer = new System.Windows.Forms.Timer { Interval = 30 };
            _pulseTimer.Tick += (s, e) =>
            {
                if (_pulseIncreasing)
                {
                    _pulseAlpha += 0.05f;
                    if (_pulseAlpha >= 1.0f)
                    {
                        _pulseAlpha = 1.0f;
                        _pulseIncreasing = false;
                    }
                }
                else
                {
                    _pulseAlpha -= 0.05f;
                    if (_pulseAlpha <= 0.35f)
                    {
                        _pulseAlpha = 0.35f;
                        _pulseIncreasing = true;
                    }
                }
                Invalidate();
            };
        }
    }

    [Category("VzxWidgets")]
    public Keys CurrentKey
    {
        get => _currentKey;
        set
        {
            if (_currentKey != value)
            {
                _currentKey = value;
                Invalidate();
                KeyChanged?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    [Category("VzxWidgets")]
    [DefaultValue(6)]
    public int BorderRadius
    {
        get => _borderRadius;
        set { _borderRadius = Math.Max(0, value); Invalidate(); }
    }

    [Category("VzxWidgets")]
    public Color BoxBackColor
    {
        get => _boxBackColor;
        set { _boxBackColor = value; Invalidate(); }
    }

    [Category("VzxWidgets")]
    public Color ActiveBorderColor
    {
        get => _activeBorderColor;
        set { _activeBorderColor = value; Invalidate(); }
    }

    protected override bool IsInputKey(Keys keyData)
    {
        if (_isListening) return true;
        return base.IsInputKey(keyData);
    }

    protected override void OnPreviewKeyDown(PreviewKeyDownEventArgs e)
    {
        if (_isListening)
        {
            e.IsInputKey = true;
        }
        base.OnPreviewKeyDown(e);
    }

    protected override void OnMouseEnter(EventArgs e)
    {
        base.OnMouseEnter(e);
        _isHovered = true;
        Invalidate();
    }

    protected override void OnMouseLeave(EventArgs e)
    {
        base.OnMouseLeave(e);
        _isHovered = false;
        Invalidate();
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        base.OnMouseDown(e);

        if (!_isListening)
        {
            _isListening = true;
            _pulseAlpha = 1.0f;
            _pulseIncreasing = false;
            _pulseTimer?.Start();
            Focus();
            Invalidate();
            return;
        }

        Keys mouseKey = Keys.None;
        if (e.Button == MouseButtons.Right)
            mouseKey = Keys.RButton;
        else if (e.Button == MouseButtons.Middle)
            mouseKey = Keys.MButton;
        else if (e.Button == MouseButtons.XButton1)
            mouseKey = Keys.XButton1;
        else if (e.Button == MouseButtons.XButton2)
            mouseKey = Keys.XButton2;

        if (mouseKey != Keys.None)
        {
            CurrentKey = mouseKey;
            _isListening = false;
            _pulseTimer?.Stop();
            Invalidate();
        }
    }

    protected override void OnKeyDown(KeyEventArgs e)
    {
        base.OnKeyDown(e);

        if (_isListening)
        {
            e.Handled = true;
            e.SuppressKeyPress = true;

            if (e.KeyCode == Keys.Escape)
            {
                CurrentKey = Keys.None;
            }
            else
            {
                CurrentKey = e.KeyCode;
            }

            _isListening = false;
            _pulseTimer?.Stop();
            Invalidate();
        }
    }

    protected override void OnLostFocus(EventArgs e)
    {
        base.OnLostFocus(e);
        if (_isListening)
        {
            _isListening = false;
            _pulseTimer?.Stop();
            Invalidate();
        }
    }

    public static string FormatKeyName(Keys key)
    {
        return key switch
        {
            Keys.None => "[ None ]",
            Keys.Next => "PgDn",
            Keys.Prior => "PgUp",
            Keys.Capital => "Caps",
            Keys.Return => "Enter",
            Keys.Back => "Backspace",
            Keys.Escape => "Esc",
            Keys.Space => "Space",
            Keys.Delete => "Del",
            Keys.Insert => "Ins",
            Keys.Tab => "Tab",
            Keys.ShiftKey or Keys.LShiftKey or Keys.RShiftKey => "Shift",
            Keys.ControlKey or Keys.LControlKey or Keys.RControlKey => "Ctrl",
            Keys.Menu or Keys.LMenu or Keys.RMenu => "Alt",
            Keys.LButton => "Mouse 1",
            Keys.RButton => "Mouse 2",
            Keys.MButton => "Mouse 3",
            Keys.XButton1 => "Mouse 4",
            Keys.XButton2 => "Mouse 5",
            Keys.Up => "Up",
            Keys.Down => "Down",
            Keys.Left => "Left",
            Keys.Right => "Right",
            Keys.Oemtilde => "~",
            Keys.OemQuestion => "?",
            Keys.OemQuotes => "\"",
            Keys.OemOpenBrackets => "[",
            Keys.OemCloseBrackets => "]",
            Keys.OemPeriod => ".",
            Keys.Oemcomma => ",",
            Keys.Oemplus => "+",
            Keys.OemMinus => "-",
            _ => key.ToString()
        };
    }

    protected override void OnPaint(PaintEventArgs pevent)
    {
        var g = pevent.Graphics;
        GraphicsHelper.ApplyHighQuality(g);

        // Preencher o fundo com a cor do parent
        Color parentBg = Parent?.BackColor ?? Color.FromArgb(14, 14, 18);
        using (var brushParent = new SolidBrush(parentBg))
        {
            g.FillRectangle(brushParent, ClientRectangle);
        }

        var rect = new RectangleF(0, 0, Width - 1, Height - 1);
        using var path = GraphicsHelper.GetRoundedRectangle(rect, _borderRadius);
        using var brush = new SolidBrush(_boxBackColor);

        g.FillPath(brush, path);

        if (_isListening && LicenseManager.UsageMode != LicenseUsageMode.Designtime)
        {
            float glowAlpha = Math.Clamp(_pulseAlpha * 0.4f, 0f, 1f);
            using (var brushGlow = new SolidBrush(Color.FromArgb((int)(255 * glowAlpha), _activeBorderColor)))
            {
                using var pathGlow = GraphicsHelper.GetRoundedRectangle(new RectangleF(-1, -1, Width + 1, Height + 1), _borderRadius + 1);
                g.DrawPath(new Pen(brushGlow, 2f), pathGlow);
            }

            int borderAlpha = (int)(255 * _pulseAlpha);
            using var pen = new Pen(Color.FromArgb(borderAlpha, _activeBorderColor), 1.6f);
            g.DrawPath(pen, path);

            string displayListen = "[ ... ]";
            Color textCol = Color.FromArgb((int)(255 * _pulseAlpha), _activeBorderColor);
            TextRenderer.DrawText(g, displayListen, Font, ClientRectangle, textCol,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }
        else
        {
            Color border = _isHovered ? _hoverBorderColor : _borderColor;
            using var pen = new Pen(border, 1.1f);
            g.DrawPath(pen, path);

            string display = $"[ {FormatKeyName(_currentKey)} ]";
            TextRenderer.DrawText(g, display, Font, ClientRectangle, ForeColor,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && _pulseTimer != null)
        {
            _pulseTimer.Stop();
            _pulseTimer.Dispose();
        }
        base.Dispose(disposing);
    }
}
