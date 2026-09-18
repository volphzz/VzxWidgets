using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using VzxWidgets.Helpers;

namespace VzxWidgets.Controls;

[ToolboxItem(true)]
[DefaultEvent("SelectedIndexChanged")]
public class VzxComboBox : ComboBox
{
    private Color _borderColor = Color.FromArgb(55, 55, 75);
    private Color _borderFocusColor = Color.FromArgb(255, 90, 20);
    private Color _arrowColor = Color.FromArgb(180, 180, 200);
    private int _borderRadius = 8;
    private int _borderSize = 1;

    public VzxComboBox()
    {
        DrawMode = DrawMode.OwnerDrawFixed;
        DropDownStyle = ComboBoxStyle.DropDownList;
        BackColor = Color.FromArgb(28, 28, 38);
        ForeColor = Color.FromArgb(220, 220, 235);
        Font = new Font("Segoe UI", 9.5f);
        ItemHeight = 26;
        DoubleBuffered = true;
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

    [Category("VzxWidgets")]
    [DefaultValue(8)]
    public int BorderRadius
    {
        get => _borderRadius;
        set { _borderRadius = Math.Max(0, value); Invalidate(); }
    }

    protected override void OnDrawItem(DrawItemEventArgs e)
    {
        if (e.Index < 0) return;

        var g = e.Graphics;
        bool isSelected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;
        Color bg = isSelected ? Color.FromArgb(45, 45, 60) : BackColor;
        Color fg = isSelected ? Color.FromArgb(255, 120, 40) : ForeColor;

        using (var brushBg = new SolidBrush(bg))
        {
            g.FillRectangle(brushBg, e.Bounds);
        }

        string itemText = Items[e.Index]?.ToString() ?? "";
        TextRenderer.DrawText(g, itemText, Font, new Rectangle(e.Bounds.X + 8, e.Bounds.Y, e.Bounds.Width - 8, e.Bounds.Height),
            fg, TextFormatFlags.Left | TextFormatFlags.VerticalCenter);
    }

    protected override void WndProc(ref Message m)
    {
        base.WndProc(ref m);

        // Intercepta WM_PAINT para renderizar o visual customizado
        if (m.Msg == 0xF) // WM_PAINT
        {
            using var g = Graphics.FromHwnd(Handle);
            GraphicsHelper.ApplyHighQuality(g);

            var rectSurface = new RectangleF(0, 0, Width - 1, Height - 1);
            Color border = Focused ? _borderFocusColor : _borderColor;

            // Seta moderna no canto direito
            float arrowX = Width - 20;
            float arrowY = Height / 2f - 2;
            PointF[] arrow = {
                new PointF(arrowX, arrowY),
                new PointF(arrowX + 8, arrowY),
                new PointF(arrowX + 4, arrowY + 5)
            };

            using var brushArrow = new SolidBrush(_arrowColor);
            g.FillPolygon(brushArrow, arrow);

            // Borda elegante
            using var path = GraphicsHelper.GetRoundedRectangle(rectSurface, _borderRadius);
            using var penBorder = new Pen(border, _borderSize);
            g.DrawPath(penBorder, path);
        }
    }
}
