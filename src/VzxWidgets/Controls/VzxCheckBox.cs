using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using VzxWidgets.Helpers;

namespace VzxWidgets.Controls;

[ToolboxItem(true)]
[DefaultEvent("CheckedChanged")]
public class VzxCheckBox : CheckBox
{
    private Color _checkedColor = Color.FromArgb(255, 90, 20); // Laranja neon/gaming
    private Color _uncheckedColor = Color.FromArgb(45, 45, 58);
    private Color _boxBorderColor = Color.FromArgb(70, 70, 88);
    private int _boxSize = 18;
    private int _borderRadius = 5;

    public VzxCheckBox()
    {
        DoubleBuffered = true;
        Cursor = Cursors.Hand;
        ForeColor = Color.FromArgb(220, 220, 230);
        Font = new Font("Segoe UI", 9.5f);
        AutoSize = true;
    }

    [Category("VzxWidgets")]
    public Color CheckedColor
    {
        get => _checkedColor;
        set { _checkedColor = value; Invalidate(); }
    }

    [Category("VzxWidgets")]
    public Color UncheckedColor
    {
        get => _uncheckedColor;
        set { _uncheckedColor = value; Invalidate(); }
    }

    [Category("VzxWidgets")]
    public Color BoxBorderColor
    {
        get => _boxBorderColor;
        set { _boxBorderColor = value; Invalidate(); }
    }

    [Category("VzxWidgets")]
    [DefaultValue(5)]
    public int BoxBorderRadius
    {
        get => _borderRadius;
        set { _borderRadius = Math.Max(0, value); Invalidate(); }
    }

    protected override void OnPaint(PaintEventArgs pevent)
    {
        var g = pevent.Graphics;
        GraphicsHelper.ApplyHighQuality(g);

        using (var clearBrush = new SolidBrush(Parent?.BackColor ?? BackColor))
        {
            g.FillRectangle(clearBrush, ClientRectangle);
        }

        int boxY = (Height - _boxSize) / 2;
        var rectBox = new RectangleF(1, boxY, _boxSize, _boxSize);

        if (Checked)
        {
            using var path = GraphicsHelper.GetRoundedRectangle(rectBox, _borderRadius);
            using var brushChecked = new SolidBrush(_checkedColor);
            g.FillPath(brushChecked, path);

            // Desenhar checkmark perfeito
            using var penCheck = new Pen(Color.White, 2.2f)
            {
                StartCap = LineCap.Round,
                EndCap = LineCap.Round,
                LineJoin = LineJoin.Round
            };

            var p1 = new PointF(rectBox.X + 4.5f, rectBox.Y + 9f);
            var p2 = new PointF(rectBox.X + 7.5f, rectBox.Y + 12.5f);
            var p3 = new PointF(rectBox.X + 13.5f, rectBox.Y + 5.5f);

            g.DrawLines(penCheck, new[] { p1, p2, p3 });
        }
        else
        {
            using var path = GraphicsHelper.GetRoundedRectangle(rectBox, _borderRadius);
            using var brushUnchecked = new SolidBrush(_uncheckedColor);
            using var penBorder = new Pen(_boxBorderColor, 1.2f);

            g.FillPath(brushUnchecked, path);
            g.DrawPath(penBorder, path);
        }

        // Texto ao lado
        var textRect = new Rectangle(_boxSize + 8, 0, Width - _boxSize - 8, Height);
        TextRenderer.DrawText(g, Text, Font, textRect, ForeColor,
            TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
    }
}
