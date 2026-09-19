using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using VzxWidgets.Helpers;

namespace VzxWidgets.Controls;

[ToolboxItem(true)]
public class VzxFiveRow : Control
{
    private string _title = "Esqueleto";
    private string _optionLabel = "Tipo de Esqueleto";
    private string[] _options = new[] { "Simples", "Complexo" };
    private int _selectedOption = 1;
    private bool _checked = true;
    private Color[] _colors = new[] { Color.White, Color.White, Color.White };
    private Color _backColor = Color.FromArgb(16, 17, 24);
    private Color _borderColor = Color.FromArgb(28, 30, 42);

    private readonly VzxToggleSwitch _toggle = new VzxToggleSwitch();
    private readonly VzxSegmentedControl _segmented = new VzxSegmentedControl();

    public event EventHandler? CheckedChanged;
    public event EventHandler? OptionChanged;
    public event EventHandler<int>? ColorSlotClicked;

    public VzxFiveRow()
    {
        DoubleBuffered = true;
        Size = new Size(580, 42);
        Font = new Font("Segoe UI", 9f);
        ForeColor = Color.White;

        SetStyle(ControlStyles.AllPaintingInWmPaint |
                 ControlStyles.OptimizedDoubleBuffer |
                 ControlStyles.ResizeRedraw |
                 ControlStyles.SupportsTransparentBackColor |
                 ControlStyles.UserPaint, true);

        // Toggle Switch à esquerda
        _toggle.Size = new Size(40, 22);
        _toggle.Checked = _checked;
        _toggle.OnBackColor = Color.FromArgb(0, 168, 255);
        _toggle.OffBackColor = Color.FromArgb(35, 38, 50);
        _toggle.CheckedChanged += (s, e) =>
        {
            _checked = _toggle.Checked;
            CheckedChanged?.Invoke(this, EventArgs.Empty);
        };
        Controls.Add(_toggle);

        // Segmented Control à direita com largura fixa adequada
        _segmented.Size = new Size(160, 28);
        _segmented.Items = _options;
        _segmented.SelectedIndex = _selectedOption;
        _segmented.SelectedIndexChanged += (s, e) =>
        {
            _selectedOption = _segmented.SelectedIndex;
            OptionChanged?.Invoke(this, EventArgs.Empty);
        };
        Controls.Add(_segmented);

        LayoutControls();
    }

    [Category("VzxWidgets")]
    public string Title
    {
        get => _title;
        set { _title = value; Invalidate(); }
    }

    [Category("VzxWidgets")]
    public string OptionLabel
    {
        get => _optionLabel;
        set { _optionLabel = value; Invalidate(); }
    }

    [Category("VzxWidgets")]
    public string[] Options
    {
        get => _options;
        set
        {
            _options = value ?? Array.Empty<string>();
            _segmented.Items = _options;
            LayoutControls();
        }
    }

    [Category("VzxWidgets")]
    public bool Checked
    {
        get => _checked;
        set
        {
            _checked = value;
            _toggle.Checked = value;
            Invalidate();
        }
    }

    [Category("VzxWidgets")]
    public Color[] ColorSlots
    {
        get => _colors;
        set { _colors = value ?? Array.Empty<Color>(); LayoutControls(); Invalidate(); }
    }

    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
        LayoutControls();
    }

    private void LayoutControls()
    {
        int yCenter = (Height - _toggle.Height) / 2;
        _toggle.Location = new Point(135, yCenter);

        int segY = (Height - _segmented.Height) / 2;
        int colorsRightMargin = (_colors.Length * 20) + 14;
        _segmented.Location = new Point(Width - _segmented.Width - colorsRightMargin, segY);
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        base.OnMouseDown(e);
        if (_colors.Length == 0) return;

        int startX = Width - (_colors.Length * 20) - 8;
        for (int i = 0; i < _colors.Length; i++)
        {
            int slotX = startX + (i * 20);
            int slotY = (Height - 14) / 2;
            var rectSlot = new Rectangle(slotX, slotY, 14, 14);

            if (rectSlot.Contains(e.Location))
            {
                ColorSlotClicked?.Invoke(this, i);
                break;
            }
        }
    }

    protected override void OnPaint(PaintEventArgs pevent)
    {
        var g = pevent.Graphics;
        GraphicsHelper.ApplyHighQuality(g);

        var rectCard = new RectangleF(0, 0, Width - 1, Height - 1);
        using (var path = GraphicsHelper.GetRoundedRectangle(rectCard, 8))
        using (var brushBg = new SolidBrush(_backColor))
        using (var penBorder = new Pen(_borderColor, 1f))
        {
            g.FillPath(brushBg, path);
            g.DrawPath(penBorder, path);
        }

        // Título à esquerda
        var rectTitle = new Rectangle(14, 0, 115, Height);
        using var fontTitle = new Font("Segoe UI Semibold", 9f, FontStyle.Bold);
        TextRenderer.DrawText(g, _title, fontTitle, rectTitle, Color.FromArgb(220, 225, 235),
            TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);

        // Label da Opção no centro/direita
        int labelX = _toggle.Right + 12;
        int labelW = Math.Max(50, _segmented.Left - labelX - 8);
        var rectOpt = new Rectangle(labelX, 0, labelW, Height);
        using var fontOpt = new Font("Segoe UI", 8.5f);
        TextRenderer.DrawText(g, _optionLabel, fontOpt, rectOpt, Color.FromArgb(160, 165, 185),
            TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);

        // Quadradinhos de cores empilhados à direita
        int startX = Width - (_colors.Length * 20) - 8;
        for (int i = 0; i < _colors.Length; i++)
        {
            int slotX = startX + (i * 20);
            int slotY = (Height - 14) / 2;
            var rectSlot = new RectangleF(slotX, slotY, 14, 14);

            using (var pathSlot = GraphicsHelper.GetRoundedRectangle(rectSlot, 3))
            using (var brushSlot = new SolidBrush(_colors[i]))
            using (var penSlot = new Pen(Color.FromArgb(50, 55, 70), 1f))
            {
                g.FillPath(brushSlot, pathSlot);
                g.DrawPath(penSlot, pathSlot);
            }
        }
    }
}
