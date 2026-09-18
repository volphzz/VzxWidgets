using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using VzxWidgets.Helpers;

namespace VzxWidgets.Controls;

public enum ToastType
{
    Success, // Verde
    Info,    // Roxo/Azul
    Warning, // Laranja
    Error    // Vermelho
}

[ToolboxItem(true)]
public class VzxToast : Control
{
    private ToastType _type = ToastType.Success;
    private string _title = "ESP Box";
    private string _message = "ESP Box ativado.";
    private Color _barColor = Color.FromArgb(48, 209, 88); // Verde
    private int _borderRadius = 10;
    private bool _closeHovered = false;

    public event EventHandler? Closed;

    public VzxToast()
    {
        DoubleBuffered = true;
        Size = new Size(240, 62);
        BackColor = Color.FromArgb(24, 24, 32);
        ForeColor = Color.White;
        SetStyle(ControlStyles.AllPaintingInWmPaint |
                 ControlStyles.OptimizedDoubleBuffer |
                 ControlStyles.ResizeRedraw |
                 ControlStyles.SupportsTransparentBackColor |
                 ControlStyles.UserPaint, true);
    }

    [Category("VzxWidgets")]
    [DefaultValue(ToastType.Success)]
    public ToastType Type
    {
        get => _type;
        set
        {
            _type = value;
            _barColor = _type switch
            {
                ToastType.Success => Color.FromArgb(48, 209, 88),
                ToastType.Info => Color.FromArgb(155, 80, 255),
                ToastType.Warning => Color.FromArgb(255, 149, 0),
                ToastType.Error => Color.FromArgb(255, 69, 58),
                _ => Color.FromArgb(155, 80, 255)
            };
            Invalidate();
        }
    }

    [Category("VzxWidgets")]
    [DefaultValue("ESP Box")]
    public string Title
    {
        get => _title;
        set { _title = value; Invalidate(); }
    }

    [Category("VzxWidgets")]
    [DefaultValue("ESP Box ativado.")]
    public string Message
    {
        get => _message;
        set { _message = value; Invalidate(); }
    }

    [Category("VzxWidgets")]
    public Color BarColor
    {
        get => _barColor;
        set { _barColor = value; Invalidate(); }
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
        base.OnMouseMove(e);
        bool inClose = e.X >= Width - 24 && e.Y <= 24;
        if (_closeHovered != inClose)
        {
            _closeHovered = inClose;
            Cursor = inClose ? Cursors.Hand : Cursors.Default;
            Invalidate();
        }
    }

    protected override void OnMouseClick(MouseEventArgs e)
    {
        base.OnMouseClick(e);
        if (e.X >= Width - 24 && e.Y <= 24)
        {
            Closed?.Invoke(this, EventArgs.Empty);
            Visible = false;
        }
    }

    protected override void OnPaint(PaintEventArgs pevent)
    {
        var g = pevent.Graphics;
        GraphicsHelper.ApplyHighQuality(g);

        var rect = new RectangleF(0, 0, Width - 1, Height - 1);
        using var path = GraphicsHelper.GetRoundedRectangle(rect, _borderRadius);
        using var brushBg = new SolidBrush(BackColor);
        using var penBorder = new Pen(Color.FromArgb(42, 42, 54), 1f);

        g.FillPath(brushBg, path);
        g.DrawPath(penBorder, path);

        // Barra lateral colorida
        var rectBar = new RectangleF(0, 4, 3.5f, Height - 8);
        using var brushBar = new SolidBrush(_barColor);
        g.FillRectangle(brushBar, rectBar);

        // Ícone
        float iconX = 16;
        float iconY = Height / 2f;
        using var penIcon = new Pen(_barColor, 2f) { StartCap = System.Drawing.Drawing2D.LineCap.Round, EndCap = System.Drawing.Drawing2D.LineCap.Round };

        if (_type == ToastType.Success)
        {
            g.DrawLines(penIcon, new[] {
                new PointF(iconX, iconY + 1),
                new PointF(iconX + 3.5f, iconY + 4.5f),
                new PointF(iconX + 9.5f, iconY - 3.5f)
            });
        }
        else // Info "i"
        {
            g.FillEllipse(brushBar, iconX + 3, iconY - 6, 3, 3);
            g.DrawLine(penIcon, iconX + 4.5f, iconY - 1, iconX + 4.5f, iconY + 6);
        }

        // Título
        using var titleFont = new Font("Segoe UI Semibold", 9.5f, FontStyle.Bold);
        TextRenderer.DrawText(g, _title, titleFont, new Rectangle(36, 11, Width - 60, 20), Color.White,
            TextFormatFlags.Left | TextFormatFlags.VerticalCenter);

        // Mensagem
        using var msgFont = new Font("Segoe UI", 8.5f);
        TextRenderer.DrawText(g, _message, msgFont, new Rectangle(36, 31, Width - 60, 20), Color.FromArgb(170, 170, 185),
            TextFormatFlags.Left | TextFormatFlags.VerticalCenter);

        // Botão Fechar "x"
        Color xColor = _closeHovered ? Color.White : Color.FromArgb(120, 120, 140);
        using var penX = new Pen(xColor, 1.2f);
        float cx = Width - 14;
        float cy = 14;
        g.DrawLine(penX, cx - 3, cy - 3, cx + 3, cy + 3);
        g.DrawLine(penX, cx + 3, cy - 3, cx - 3, cy + 3);
    }
}
