using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using VzxWidgets.Helpers;

namespace VzxWidgets.Controls;

public enum ControlBoxType
{
    Close,
    Minimize,
    Maximize
}

[ToolboxItem(true)]
public class VzxControlBox : Control
{
    private ControlBoxType _type = ControlBoxType.Close;
    private Color _hoverColor = Color.FromArgb(255, 60, 50); // Vermelho para fechar
    private Color _iconColor = Color.FromArgb(170, 170, 185);
    private int _borderRadius = 6;
    private bool _isHovered = false;

    public VzxControlBox()
    {
        Size = new Size(32, 26);
        Cursor = Cursors.Hand;
        DoubleBuffered = true;
        SetStyle(ControlStyles.AllPaintingInWmPaint |
                 ControlStyles.OptimizedDoubleBuffer |
                 ControlStyles.ResizeRedraw |
                 ControlStyles.SupportsTransparentBackColor |
                 ControlStyles.UserPaint, true);
    }

    [Category("VzxWidgets")]
    [DefaultValue(ControlBoxType.Close)]
    public ControlBoxType BoxType
    {
        get => _type;
        set
        {
            _type = value;
            _hoverColor = _type == ControlBoxType.Close 
                ? Color.FromArgb(255, 60, 50) 
                : Color.FromArgb(50, 50, 65);
            Invalidate();
        }
    }

    [Category("VzxWidgets")]
    public Color IconColor
    {
        get => _iconColor;
        set { _iconColor = value; Invalidate(); }
    }

    [Category("VzxWidgets")]
    public Color HoverColor
    {
        get => _hoverColor;
        set { _hoverColor = value; Invalidate(); }
    }

    [Category("VzxWidgets")]
    [DefaultValue(6)]
    public int BorderRadius
    {
        get => _borderRadius;
        set { _borderRadius = Math.Max(0, value); Invalidate(); }
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
        var form = FindForm();
        if (form == null) return;

        switch (_type)
        {
            case ControlBoxType.Close:
                form.Close();
                break;
            case ControlBoxType.Minimize:
                form.WindowState = FormWindowState.Minimized;
                break;
            case ControlBoxType.Maximize:
                form.WindowState = form.WindowState == FormWindowState.Maximized 
                    ? FormWindowState.Normal 
                    : FormWindowState.Maximized;
                break;
        }
    }

    protected override void OnPaint(PaintEventArgs pevent)
    {
        var g = pevent.Graphics;
        GraphicsHelper.ApplyHighQuality(g);

        var rect = new RectangleF(0, 0, Width, Height);

        if (_isHovered)
        {
            using var path = GraphicsHelper.GetRoundedRectangle(rect, _borderRadius);
            using var brush = new SolidBrush(_hoverColor);
            g.FillPath(brush, path);
        }

        Color ic = _isHovered && _type == ControlBoxType.Close ? Color.White : _iconColor;
        using var penIcon = new Pen(ic, 1.6f) { StartCap = LineCap.Round, EndCap = LineCap.Round };

        float cx = Width / 2f;
        float cy = Height / 2f;

        switch (_type)
        {
            case ControlBoxType.Close:
                g.DrawLine(penIcon, cx - 4, cy - 4, cx + 4, cy + 4);
                g.DrawLine(penIcon, cx + 4, cy - 4, cx - 4, cy + 4);
                break;

            case ControlBoxType.Minimize:
                g.DrawLine(penIcon, cx - 4.5f, cy, cx + 4.5f, cy);
                break;

            case ControlBoxType.Maximize:
                g.DrawRectangle(penIcon, cx - 4, cy - 4, 8, 8);
                break;
        }
    }
}
