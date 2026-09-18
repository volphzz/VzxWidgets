using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using VzxWidgets.Helpers;

namespace VzxWidgets.Controls;

/// <summary>
/// Formulário moderno sem bordas (Borderless Form) totalmente customizável,
/// com suporte a cantos arredondados, bordas coloridas, sombra DWM e redimensionamento nativo pelo mouse.
/// </summary>
public class VzxForm : Form
{
    private int _borderRadius = 16;
    private int _borderSize = 1;
    private Color _borderColor = Color.FromArgb(45, 45, 60);
    private bool _hasDropShadow = true;

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
    [DefaultValue(1)]
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
            // Ativa DWM Dark Mode title se compatível no Windows 10/11
            int useImmersiveDarkMode = 1;
            DwmSetWindowAttribute(Handle, 20, ref useImmersiveDarkMode, sizeof(int));
        }
        catch { }
    }

    private void UpdateRegion()
    {
        if (_borderRadius > 2)
        {
            var rect = new RectangleF(0, 0, Width, Height);
            using var path = GraphicsHelper.GetRoundedRectangle(rect, _borderRadius);
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

            if (_borderRadius > 2)
            {
                using var path = GraphicsHelper.GetRoundedRectangle(rectBorder, _borderRadius);
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

    // Permite redimensionar a janela arrastando pelas bordas e quinas com o mouse
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
