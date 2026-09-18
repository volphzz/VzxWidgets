using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using VzxWidgets.Helpers;

namespace VzxWidgets.Controls;

/// <summary>
/// Formulário moderno sem bordas (Borderless Form) totalmente customizável,
/// com suporte a cantos arredondados gerais ou individuais, bordas coloridas, 
/// sombra nativa DWM e redimensionamento suave pelo mouse.
/// </summary>
public class VzxForm : Form
{
    private int _borderRadius = 16;
    private int _borderSize = 1;
    private Color _borderColor = Color.FromArgb(45, 45, 60);
    private bool _hasDropShadow = true;

    // Controle individual dos cantos
    private bool _roundTopLeft = true;
    private bool _roundTopRight = true;
    private bool _roundBottomRight = true;
    private bool _roundBottomLeft = true;

    // Constantes do Windows para redimensionamento e sombra nativa
    private const int WM_NCHITTEST = 0x84;
    private const int HTLEFT = 10;
    private const int HTRIGHT = 11;
    private const int HTTOP = 12;
    private const int HTTOPLEFT = 13;
    private const int HTTOPRIGHT = 14;
    private const int HTBOTTOM = 15;
    private const int HTBOTTOMLEFT = 16;
    private const int HTBOTTOMRIGHT = 17;
    private const int CS_DROPSHADOW = 0x00020000;

    [DllImport("dwmapi.dll")]
    private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

    public VzxForm()
    {
        FormBorderStyle = FormBorderStyle.None;
        DoubleBuffered = true;
        StartPosition = FormStartPosition.CenterScreen;
        BackColor = Color.FromArgb(12, 12, 16);
        ForeColor = Color.White;
        Font = new Font("Segoe UI", 9F);

        SetStyle(ControlStyles.AllPaintingInWmPaint |
                 ControlStyles.OptimizedDoubleBuffer |
                 ControlStyles.ResizeRedraw |
                 ControlStyles.SupportsTransparentBackColor |
                 ControlStyles.UserPaint, true);
    }

    [Category("VzxWidgets")]
    [DefaultValue(16)]
    [Description("Raio de curvatura dos cantos arredondados.")]
    public int BorderRadius
    {
        get => _borderRadius;
        set
        {
            _borderRadius = Math.Max(0, value);
            UpdateRegion();
            Invalidate();
        }
    }

    [Category("VzxWidgets")]
    [DefaultValue(true)]
    [Description("Arredondar o canto superior esquerdo.")]
    public bool RoundTopLeft
    {
        get => _roundTopLeft;
        set { _roundTopLeft = value; UpdateRegion(); Invalidate(); }
    }

    [Category("VzxWidgets")]
    [DefaultValue(true)]
    [Description("Arredondar o canto superior direito.")]
    public bool RoundTopRight
    {
        get => _roundTopRight;
        set { _roundTopRight = value; UpdateRegion(); Invalidate(); }
    }

    [Category("VzxWidgets")]
    [DefaultValue(true)]
    [Description("Arredondar o canto inferior direito.")]
    public bool RoundBottomRight
    {
        get => _roundBottomRight;
        set { _roundBottomRight = value; UpdateRegion(); Invalidate(); }
    }

    [Category("VzxWidgets")]
    [DefaultValue(true)]
    [Description("Arredondar o canto inferior esquerdo.")]
    public bool RoundBottomLeft
    {
        get => _roundBottomLeft;
        set { _roundBottomLeft = value; UpdateRegion(); Invalidate(); }
    }

    [Category("VzxWidgets")]
    [DefaultValue(1)]
    [Description("Espessura do contorno da janela.")]
    public int BorderSize
    {
        get => _borderSize;
        set
        {
            _borderSize = Math.Max(0, value);
            Invalidate();
        }
    }

    [Category("VzxWidgets")]
    [Description("Cor do contorno da janela.")]
    public Color BorderColor
    {
        get => _borderColor;
        set
        {
            _borderColor = value;
            Invalidate();
        }
    }

    [Category("VzxWidgets")]
    [DefaultValue(true)]
    [Description("Ativa a sombra profunda realista do Windows (DWM DropShadow).")]
    public bool HasDropShadow
    {
        get => _hasDropShadow;
        set
        {
            _hasDropShadow = value;
            UpdateShadow();
        }
    }

    protected override CreateParams CreateParams
    {
        get
        {
            CreateParams cp = base.CreateParams;
            if (_hasDropShadow && !DesignMode)
            {
                cp.ClassStyle |= CS_DROPSHADOW;
            }
            return cp;
        }
    }

    protected override void OnHandleCreated(EventArgs e)
    {
        base.OnHandleCreated(e);
        UpdateShadow();
        UpdateRegion();
    }

    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
        UpdateRegion();
    }

    private void UpdateShadow()
    {
        if (DesignMode || !IsHandleCreated) return;
        try
        {
            int useImmersiveDarkMode = 1;
            DwmSetWindowAttribute(Handle, 20, ref useImmersiveDarkMode, sizeof(int));
        }
        catch { }
    }

    private void UpdateRegion()
    {
        float tl = _roundTopLeft ? _borderRadius : 0;
        float tr = _roundTopRight ? _borderRadius : 0;
        float br = _roundBottomRight ? _borderRadius : 0;
        float bl = _roundBottomLeft ? _borderRadius : 0;

        if (tl > 0 || tr > 0 || br > 0 || bl > 0)
        {
            var rect = new RectangleF(0, 0, Width, Height);
            using var path = GraphicsHelper.GetCustomRoundedRectangle(rect, tl, tr, br, bl);
            Region = new Region(path);
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

        if (_borderSize > 0)
        {
            var rectBorder = new RectangleF(0.5f, 0.5f, Width - 1f, Height - 1f);

            float tl = _roundTopLeft ? _borderRadius : 0;
            float tr = _roundTopRight ? _borderRadius : 0;
            float br = _roundBottomRight ? _borderRadius : 0;
            float bl = _roundBottomLeft ? _borderRadius : 0;

            if (tl > 0 || tr > 0 || br > 0 || bl > 0)
            {
                using var path = GraphicsHelper.GetCustomRoundedRectangle(rectBorder, tl, tr, br, bl);
                using var pen = new Pen(_borderColor, _borderSize);
                g.DrawPath(pen, path);
            }
            else
            {
                using var pen = new Pen(_borderColor, _borderSize);
                g.DrawRectangle(pen, 0, 0, Width - 1, Height - 1);
            }
        }
    }

    protected override void WndProc(ref Message m)
    {
        base.WndProc(ref m);

        if (m.Msg == WM_NCHITTEST && WindowState == FormWindowState.Normal)
        {
            int resizeBorder = 8;
            Point cursor = PointToClient(Cursor.Position);

            bool left = cursor.X <= resizeBorder;
            bool right = cursor.X >= Width - resizeBorder;
            bool top = cursor.Y <= resizeBorder;
            bool bottom = cursor.Y >= Height - resizeBorder;

            if (top && left) m.Result = (IntPtr)HTTOPLEFT;
            else if (top && right) m.Result = (IntPtr)HTTOPRIGHT;
            else if (bottom && left) m.Result = (IntPtr)HTBOTTOMLEFT;
            else if (bottom && right) m.Result = (IntPtr)HTBOTTOMRIGHT;
            else if (left) m.Result = (IntPtr)HTLEFT;
            else if (right) m.Result = (IntPtr)HTRIGHT;
            else if (top) m.Result = (IntPtr)HTTOP;
            else if (bottom) m.Result = (IntPtr)HTBOTTOM;
        }
    }
}
