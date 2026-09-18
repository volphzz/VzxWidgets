using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using VzxWidgets.Helpers;

namespace VzxWidgets.Controls;

[ToolboxItem(true)]
[DefaultEvent("SelectedIndexChanged")]
public class VzxComboBox : Control
{
    private Color _backColor = Color.FromArgb(20, 20, 26);
    private Color _borderColor = Color.FromArgb(45, 45, 60);
    private Color _borderFocusColor = Color.FromArgb(187, 200, 254);
    private Color _arrowColor = Color.FromArgb(187, 200, 254);
    private Color _dropdownBackColor = Color.FromArgb(22, 22, 30);
    private Color _dropdownHoverColor = Color.FromArgb(35, 35, 48);
    private int _borderRadius = 8;
    private int _borderSize = 1;
    private int _selectedIndex = -1;
    private bool _isHovered = false;
    private bool _isDroppedDown = false;

    private readonly ToolStripDropDown _dropdown = new ToolStripDropDown();
    private readonly ToolStripControlHost _host;
    private readonly ListBox _listBox = new ListBox();

    public event EventHandler? SelectedIndexChanged;

    public class ComboBoxItemCollection : ObservableCollection<object>
    {
        public void AddRange(object[] items)
        {
            foreach (var item in items)
            {
                Add(item);
            }
        }
    }

    public ComboBoxItemCollection Items { get; } = new ComboBoxItemCollection();

    public VzxComboBox()
    {
        DoubleBuffered = true;
        Size = new Size(200, 32);
        Cursor = Cursors.Hand;
        ForeColor = Color.FromArgb(230, 230, 240);
        Font = new Font("Segoe UI", 9.5f);

        SetStyle(ControlStyles.Selectable |
                 ControlStyles.AllPaintingInWmPaint |
                 ControlStyles.OptimizedDoubleBuffer |
                 ControlStyles.ResizeRedraw |
                 ControlStyles.SupportsTransparentBackColor |
                 ControlStyles.UserPaint, true);

        // Configuração do ListBox popup
        _listBox.BorderStyle = BorderStyle.None;
        _listBox.BackColor = _dropdownBackColor;
        _listBox.ForeColor = ForeColor;
        _listBox.Font = Font;
        _listBox.DrawMode = DrawMode.OwnerDrawFixed;
        _listBox.ItemHeight = 30;
        _listBox.Cursor = Cursors.Hand;
        _listBox.DrawItem += ListBox_DrawItem;
        _listBox.Click += (s, e) =>
        {
            if (_listBox.SelectedIndex >= 0)
            {
                SelectedIndex = _listBox.SelectedIndex;
                _dropdown.Close();
            }
        };

        _host = new ToolStripControlHost(_listBox)
        {
            Margin = Padding.Empty,
            Padding = Padding.Empty,
            AutoSize = false
        };

        _dropdown.Items.Add(_host);
        _dropdown.DropShadowEnabled = true;
        _dropdown.Padding = Padding.Empty;
        _dropdown.Margin = Padding.Empty;
        _dropdown.BackColor = _dropdownBackColor;
        _dropdown.Closed += (s, e) => { _isDroppedDown = false; Invalidate(); };

        Items.CollectionChanged += (s, e) => SyncItems();
    }

    [Category("VzxWidgets")]
    [DefaultValue(-1)]
    public int SelectedIndex
    {
        get => _selectedIndex;
        set
        {
            if (value >= -1 && value < Items.Count && _selectedIndex != value)
            {
                _selectedIndex = value;
                Invalidate();
                SelectedIndexChanged?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    [Browsable(false)]
    public object? SelectedItem => (_selectedIndex >= 0 && _selectedIndex < Items.Count) ? Items[_selectedIndex] : null;

    [Browsable(false)]
    public string SelectedText => SelectedItem?.ToString() ?? "";

    [Category("VzxWidgets")]
    [DefaultValue(8)]
    public int BorderRadius
    {
        get => _borderRadius;
        set { _borderRadius = Math.Max(0, value); Invalidate(); }
    }

    [Category("VzxWidgets")]
    [DefaultValue(1)]
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

    [Category("VzxWidgets")]
    public Color ArrowColor
    {
        get => _arrowColor;
        set { _arrowColor = value; Invalidate(); }
    }

    private void SyncItems()
    {
        _listBox.Items.Clear();
        foreach (var it in Items)
        {
            _listBox.Items.Add(it);
        }
        if (_selectedIndex >= Items.Count)
        {
            _selectedIndex = Items.Count - 1;
        }
        Invalidate();
    }

    private void ListBox_DrawItem(object? sender, DrawItemEventArgs e)
    {
        if (e.Index < 0) return;

        var g = e.Graphics;
        g.SmoothingMode = SmoothingMode.AntiAlias;

        bool isHovered = (e.State & DrawItemState.Selected) == DrawItemState.Selected;
        Color bg = isHovered ? _dropdownHoverColor : _dropdownBackColor;
        Color fg = isHovered ? _borderFocusColor : ForeColor;

        using (var brush = new SolidBrush(bg))
        {
            g.FillRectangle(brush, e.Bounds);
        }

        string text = _listBox.Items[e.Index]?.ToString() ?? "";
        var textRect = new Rectangle(e.Bounds.X + 12, e.Bounds.Y, e.Bounds.Width - 16, e.Bounds.Height);
        TextRenderer.DrawText(g, text, Font, textRect, fg,
            TextFormatFlags.Left | TextFormatFlags.VerticalCenter);
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

    protected override void OnClick(EventArgs e)
    {
        base.OnClick(e);
        Focus();
        ToggleDropdown();
    }

    private void ToggleDropdown()
    {
        if (_isDroppedDown)
        {
            _dropdown.Close();
        }
        else
        {
            if (Items.Count == 0) return;

            int visibleItems = Math.Min(Items.Count, 8);
            int dropHeight = visibleItems * _listBox.ItemHeight + 4;
            _listBox.Size = new Size(Width, dropHeight);
            _host.Size = new Size(Width, dropHeight);
            _dropdown.Size = new Size(Width, dropHeight);

            _isDroppedDown = true;
            Invalidate();
            _dropdown.Show(this, new Point(0, Height + 2));
        }
    }

    protected override void OnPaint(PaintEventArgs pevent)
    {
        var g = pevent.Graphics;
        GraphicsHelper.ApplyHighQuality(g);

        var rectSurface = new RectangleF(0, 0, Width - 1, Height - 1);
        Color border = (_isDroppedDown || Focused) ? _borderFocusColor : _borderColor;

        // Fundo com cantos arredondados
        using (var path = GraphicsHelper.GetRoundedRectangle(rectSurface, _borderRadius))
        {
            using var brushBg = new SolidBrush(_backColor);
            using var penBorder = new Pen(border, _borderSize);

            g.FillPath(brushBg, path);
            g.DrawPath(penBorder, path);
        }

        // Chevron moderno em V (sem aquela seta Windows 95 feia)
        float arrowX = Width - 22;
        float arrowY = Height / 2f;
        Color chevronCol = (_isDroppedDown || _isHovered) ? _arrowColor : Color.FromArgb(140, 140, 160);

        using (var penChevron = new Pen(chevronCol, 2f)
        {
            StartCap = LineCap.Round,
            EndCap = LineCap.Round,
            LineJoin = LineJoin.Round
        })
        {
            if (_isDroppedDown)
            {
                // Seta apontando para cima
                g.DrawLines(penChevron, new[] {
                    new PointF(arrowX, arrowY + 2),
                    new PointF(arrowX + 4.5f, arrowY - 2.5f),
                    new PointF(arrowX + 9, arrowY + 2)
                });
            }
            else
            {
                // Seta apontando para baixo
                g.DrawLines(penChevron, new[] {
                    new PointF(arrowX, arrowY - 2),
                    new PointF(arrowX + 4.5f, arrowY + 2.5f),
                    new PointF(arrowX + 9, arrowY - 2)
                });
            }
        }

        // Texto Selecionado
        string displayText = SelectedText;
        if (string.IsNullOrEmpty(displayText) && Items.Count > 0)
        {
            displayText = Items[0]?.ToString() ?? "";
        }

        var textRect = new Rectangle(12, 0, Width - 38, Height);
        TextRenderer.DrawText(g, displayText, Font, textRect, ForeColor,
            TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            _dropdown.Dispose();
            _host.Dispose();
            _listBox.Dispose();
        }
        base.Dispose(disposing);
    }
}
