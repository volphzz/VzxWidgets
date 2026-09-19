using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using VzxWidgets.Helpers;

namespace VzxWidgets.Controls;

[ToolboxItem(true)]
public class VzxSegmentedControl : Control
{
    private string[] _items = new[] { "Horizontal", "Vertical" };
    private int _selectedIndex = 0;
    private Color _backColor = Color.FromArgb(18, 19, 26);
    private Color _selectedBackColor = Color.FromArgb(28, 30, 42);
    private Color _selectedTextColor = Color.White;
    private Color _unselectedTextColor = Color.FromArgb(140, 145, 165);
    private Color _borderColor = Color.FromArgb(36, 38, 52);
    private int _borderRadius = 6;

    public event EventHandler? SelectedIndexChanged;

    public VzxSegmentedControl()
    {
        DoubleBuffered = true;
        Size = new Size(160, 28);
        Cursor = Cursors.Hand;
        Font = new Font("Segoe UI Semibold", 8.5f, FontStyle.Bold);

        SetStyle(ControlStyles.AllPaintingInWmPaint |
                 ControlStyles.OptimizedDoubleBuffer |
                 ControlStyles.ResizeRedraw |
                 ControlStyles.SupportsTransparentBackColor |
                 ControlStyles.UserPaint, true);
    }

    [Category("VzxWidgets")]
    public string[] Items
    {
        get => _items;
        set
        {
            _items = value ?? Array.Empty<string>();
            if (_selectedIndex >= _items.Length) _selectedIndex = Math.Max(0, _items.Length - 1);
            Invalidate();
        }
    }

    [Category("VzxWidgets")]
    [DefaultValue(0)]
    public int SelectedIndex
    {
        get => _selectedIndex;
        set
        {
            if (value >= 0 && value < _items.Length && _selectedIndex != value)
            {
                _selectedIndex = value;
                Invalidate();
                SelectedIndexChanged?.Invoke(this, EventArgs.Empty);
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

    protected override void OnMouseClick(MouseEventArgs e)
    {
        base.OnMouseClick(e);
        if (_items.Length == 0) return;

        float itemWidth = (float)Width / _items.Length;
        int clickedIndex = (int)(e.X / itemWidth);
        clickedIndex = Math.Clamp(clickedIndex, 0, _items.Length - 1);

        if (_selectedIndex != clickedIndex)
        {
            _selectedIndex = clickedIndex;
            Invalidate();
            SelectedIndexChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    protected override void OnPaint(PaintEventArgs pevent)
    {
        var g = pevent.Graphics;
        GraphicsHelper.ApplyHighQuality(g);

        var rectTotal = new RectangleF(0, 0, Width - 1, Height - 1);
        using (var pathTotal = GraphicsHelper.GetRoundedRectangle(rectTotal, _borderRadius))
        using (var brushBg = new SolidBrush(_backColor))
        using (var penBorder = new Pen(_borderColor, 1f))
        {
            g.FillPath(brushBg, pathTotal);
            g.DrawPath(penBorder, pathTotal);
        }

        if (_items.Length == 0) return;

        float itemWidth = (float)Width / _items.Length;

        // Desenhar segmento ativo
        float selX = _selectedIndex * itemWidth + 2;
        var rectSel = new RectangleF(selX, 2, itemWidth - 4, Height - 5);
        using (var pathSel = GraphicsHelper.GetRoundedRectangle(rectSel, Math.Max(2, _borderRadius - 2)))
        using (var brushSel = new SolidBrush(_selectedBackColor))
        using (var penSelBorder = new Pen(Color.FromArgb(48, 52, 70), 1f))
        {
            g.FillPath(brushSel, pathSel);
            g.DrawPath(penSelBorder, pathSel);
        }

        // Desenhar textos
        for (int i = 0; i < _items.Length; i++)
        {
            var itemRect = new Rectangle((int)(i * itemWidth), 0, (int)itemWidth, Height);
            Color textCol = (i == _selectedIndex) ? _selectedTextColor : _unselectedTextColor;
            TextRenderer.DrawText(g, _items[i], Font, itemRect, textCol,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }
    }
}
