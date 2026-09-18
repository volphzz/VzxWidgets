using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using VzxWidgets.Helpers;

namespace VzxWidgets.Controls;

[ToolboxItem(true)]
[DefaultEvent("ColorChanged")]
public class VzxColorButton : Control
{
    private Color _selectedColor = Color.White;
    private Color _borderColor = Color.FromArgb(60, 60, 80);
    private int _borderRadius = 4;

    private readonly ToolStripDropDown _dropdown = new ToolStripDropDown();
    private readonly VzxColorPickerPopup _picker = new VzxColorPickerPopup();

    public event EventHandler? ColorChanged;

    public VzxColorButton()
    {
        DoubleBuffered = true;
        Size = new Size(18, 14);
        Cursor = Cursors.Hand;

        SetStyle(ControlStyles.AllPaintingInWmPaint |
                 ControlStyles.OptimizedDoubleBuffer |
                 ControlStyles.ResizeRedraw |
                 ControlStyles.SupportsTransparentBackColor |
                 ControlStyles.UserPaint, true);

        // Configurar Popup moderno
        var host = new ToolStripControlHost(_picker)
        {
            Margin = Padding.Empty,
            Padding = Padding.Empty,
            AutoSize = false
        };

        _dropdown.Items.Add(host);
        _dropdown.DropShadowEnabled = true;
        _dropdown.Padding = Padding.Empty;
        _dropdown.Margin = Padding.Empty;
        _dropdown.BackColor = Color.FromArgb(14, 14, 18);

        _picker.ColorChanged += (s, e) =>
        {
            _selectedColor = _picker.SelectedColor;
            Invalidate();
            ColorChanged?.Invoke(this, EventArgs.Empty);
        };
    }

    [Category("VzxWidgets")]
    public Color SelectedColor
    {
        get => _selectedColor;
        set
        {
            if (_selectedColor != value)
            {
                _selectedColor = value;
                _picker.SelectedColor = value;
                Invalidate();
                ColorChanged?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    [Category("VzxWidgets")]
    [DefaultValue(4)]
    public int BorderRadius
    {
        get => _borderRadius;
        set { _borderRadius = Math.Max(0, value); Invalidate(); }
    }

    protected override void OnClick(EventArgs e)
    {
        base.OnClick(e);
        _picker.SelectedColor = _selectedColor;
        _dropdown.Show(this, new Point(Width - _picker.Width, Height + 4));
    }

    protected override void OnPaint(PaintEventArgs pevent)
    {
        var g = pevent.Graphics;
        GraphicsHelper.ApplyHighQuality(g);

        var rect = new RectangleF(0, 0, Width - 1, Height - 1);
        using var path = GraphicsHelper.GetRoundedRectangle(rect, _borderRadius);
        using var brush = new SolidBrush(_selectedColor);
        using var pen = new Pen(_borderColor, 1f);

        g.FillPath(brush, path);
        g.DrawPath(pen, path);
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            _dropdown.Dispose();
            _picker.Dispose();
        }
        base.Dispose(disposing);
    }
}
