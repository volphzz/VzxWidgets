using System;
using System.ComponentModel;
using System.Drawing;
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
        // Garante que todas as teclas (Tab, Arrows, Enter, etc.) sejam capturadas
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
            Focus();
            Invalidate();
            return;
        }

        // Se já está escutando e o usuário clica com botões do mouse:
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
            Invalidate();
        }
    }

    protected override void OnLostFocus(EventArgs e)
    {
        base.OnLostFocus(e);
        if (_isListening)
        {
            _isListening = false;
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
            Keys.D0 => "0",
            Keys.D1 => "1",
            Keys.D2 => "2",
            Keys.D3 => "3",
            Keys.D4 => "4",
            Keys.D5 => "5",
            Keys.D6 => "6",
            Keys.D7 => "7",
            Keys.D8 => "8",
            Keys.D9 => "9",
            Keys.NumPad0 => "Num 0",
            Keys.NumPad1 => "Num 1",
            Keys.NumPad2 => "Num 2",
            Keys.NumPad3 => "Num 3",
            Keys.NumPad4 => "Num 4",
            Keys.NumPad5 => "Num 5",
            Keys.NumPad6 => "Num 6",
            Keys.NumPad7 => "Num 7",
            Keys.NumPad8 => "Num 8",
            Keys.NumPad9 => "Num 9",
            _ => key.ToString()
        };
    }

    protected override void OnPaint(PaintEventArgs pevent)
    {
        var g = pevent.Graphics;
        GraphicsHelper.ApplyHighQuality(g);

        var rect = new RectangleF(0, 0, Width - 1, Height - 1);
        using var path = GraphicsHelper.GetRoundedRectangle(rect, _borderRadius);
        using var brush = new SolidBrush(_boxBackColor);

        Color border = _isListening
            ? _activeBorderColor
            : (_isHovered ? _hoverBorderColor : _borderColor);

        using var pen = new Pen(border, _isListening ? 1.5f : 1.1f);

        g.FillPath(brush, path);
        g.DrawPath(pen, path);

        string display = _isListening ? "[ ... ]" : $"[ {FormatKeyName(_currentKey)} ]";
        Color textColor = _isListening ? _activeBorderColor : ForeColor;

        TextRenderer.DrawText(g, display, Font, ClientRectangle, textColor,
            TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
    }
}
