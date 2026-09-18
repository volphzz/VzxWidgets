using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using VzxWidgets.Helpers;

namespace VzxWidgets.Controls;

[ToolboxItem(true)]
[DefaultEvent("_TextChanged")]
public class VzxTextBox : UserControl
{
    private Color _borderColor = Color.FromArgb(70, 70, 90);
    private Color _borderFocusColor = Color.FromArgb(187, 200, 254);
    private int _borderSize = 2;
    private int _borderRadius = 8;
    private bool _isFocused = false;
    private string _placeholderText = "";
    private Color _placeholderColor = Color.DarkGray;
    private bool _isPlaceholder = false;

    private readonly TextBox _textBox = new TextBox();

    public event EventHandler? _TextChanged;

    public VzxTextBox()
    {
        _textBox.BorderStyle = BorderStyle.None;
        _textBox.BackColor = Color.FromArgb(32, 32, 45);
        _textBox.ForeColor = Color.White;
        _textBox.Font = new Font("Segoe UI", 10f);
        _textBox.Location = new Point(10, 8);
        _textBox.Size = new Size(Width - 20, Height - 16);
        _textBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

        _textBox.Enter += (s, e) => { _isFocused = true; Invalidate(); RemovePlaceholder(); };
        _textBox.Leave += (s, e) => { _isFocused = false; Invalidate(); SetPlaceholder(); };
        _textBox.TextChanged += (s, e) => _TextChanged?.Invoke(this, e);

        Controls.Add(_textBox);

        BackColor = Color.FromArgb(32, 32, 45);
        Padding = new Padding(10, 8, 10, 8);
        Size = new Size(250, 38);
        DoubleBuffered = true;
    }

    [Category("VzxWidgets")]
    public string Texts
    {
        get => _isPlaceholder ? "" : _textBox.Text;
        set
        {
            _textBox.Text = value;
            SetPlaceholder();
        }
    }

    [Category("VzxWidgets")]
    public string PlaceholderText
    {
        get => _placeholderText;
        set
        {
            _placeholderText = value;
            SetPlaceholder();
        }
    }

    [Category("VzxWidgets")]
    [DefaultValue(8)]
    public int BorderRadius
    {
        get => _borderRadius;
        set { _borderRadius = Math.Max(0, value); UpdateRegion(); Invalidate(); }
    }

    [Category("VzxWidgets")]
    [DefaultValue(2)]
    public int BorderSize
    {
        get => _borderSize;
        set { _borderSize = Math.Max(1, value); Invalidate(); }
    }

    [Category("VzxWidgets")]
    public Color BorderColor
    {
        get => _borderColor;
        set { _borderColor = value; Invalidate(); }
    }

    [Category("VzxWidgets")]
    public Color BorderFocusColor
    {
        get => _borderFocusColor;
        set { _borderFocusColor = value; Invalidate(); }
    }

    private void SetPlaceholder()
    {
        if (string.IsNullOrWhiteSpace(_textBox.Text) && !string.IsNullOrEmpty(_placeholderText))
        {
            _isPlaceholder = true;
            _textBox.Text = _placeholderText;
            _textBox.ForeColor = _placeholderColor;
        }
    }

    private void RemovePlaceholder()
    {
        if (_isPlaceholder)
        {
            _isPlaceholder = false;
            _textBox.Text = "";
            _textBox.ForeColor = Color.White;
        }
    }

    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
        UpdateRegion();
    }

    private void UpdateRegion()
    {
        if (Width <= 0 || Height <= 0) return;
        if (_borderRadius > 2)
        {
            var rectSurface = new RectangleF(0, 0, Width, Height);
            using var pathSurface = GraphicsHelper.GetRoundedRectangle(rectSurface, _borderRadius);
            Region = new Region(pathSurface);
        }
        else
        {
            Region = null;
        }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        var g = e.Graphics;
        GraphicsHelper.ApplyHighQuality(g);

        Color border = _isFocused ? _borderFocusColor : _borderColor;
        var rectBorder = new RectangleF(1, 1, Width - 2, Height - 2);

        if (_borderRadius > 2)
        {
            using var pathBorder = GraphicsHelper.GetRoundedRectangle(rectBorder, _borderRadius - 1);
            using var penBorder = new Pen(border, _borderSize);
            g.DrawPath(penBorder, pathBorder);
        }
        else
        {
            using var penBorder = new Pen(border, _borderSize);
            g.DrawRectangle(penBorder, 0, 0, Width - 1, Height - 1);
        }
    }
}
