using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using VzxWidgets.Helpers;

namespace VzxWidgets.Controls;

[ToolboxItem(true)]
public class VzxProfileBadge : Control
{
    private string _username = "VOLPHX";
    private string _badgeText = "Lifetime";
    private string _daysText = "1000 dias";
    private Image? _avatarImage = null;
    private Color _backColor = Color.FromArgb(16, 17, 24);
    private Color _borderColor = Color.FromArgb(32, 34, 46);
    private Color _accentColor = Color.FromArgb(0, 168, 255);
    private bool _gearHovered = false;

    public event EventHandler? SettingsClicked;

    public VzxProfileBadge()
    {
        DoubleBuffered = true;
        Size = new Size(200, 52);
        Cursor = Cursors.Default;
        Font = new Font("Segoe UI", 9f);
        ForeColor = Color.White;

        SetStyle(ControlStyles.AllPaintingInWmPaint |
                 ControlStyles.OptimizedDoubleBuffer |
                 ControlStyles.ResizeRedraw |
                 ControlStyles.SupportsTransparentBackColor |
                 ControlStyles.UserPaint, true);
    }

    [Category("VzxWidgets")]
    [DefaultValue("VOLPHX")]
    public string Username
    {
        get => _username;
        set { _username = value; Invalidate(); }
    }

    [Category("VzxWidgets")]
    [DefaultValue("Lifetime")]
    public string BadgeText
    {
        get => _badgeText;
        set { _badgeText = value; Invalidate(); }
    }

    [Category("VzxWidgets")]
    [DefaultValue("1000 dias")]
    public string DaysText
    {
        get => _daysText;
        set { _daysText = value; Invalidate(); }
    }

    [Category("VzxWidgets")]
    public Image? AvatarImage
    {
        get => _avatarImage;
        set { _avatarImage = value; Invalidate(); }
    }

    [Category("VzxWidgets")]
    public Color AccentColor
    {
        get => _accentColor;
        set { _accentColor = value; Invalidate(); }
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
        base.OnMouseMove(e);
        bool inGear = e.X >= Width - 32 && e.Y >= 8 && e.Y <= 40;
        if (_gearHovered != inGear)
        {
            _gearHovered = inGear;
            Cursor = inGear ? Cursors.Hand : Cursors.Default;
            Invalidate();
        }
    }

    protected override void OnMouseLeave(EventArgs e)
    {
        base.OnMouseLeave(e);
        if (_gearHovered)
        {
            _gearHovered = false;
            Cursor = Cursors.Default;
            Invalidate();
        }
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        base.OnMouseDown(e);
        if (_gearHovered && e.Button == MouseButtons.Left)
        {
            SettingsClicked?.Invoke(this, EventArgs.Empty);
        }
    }

    protected override void OnPaint(PaintEventArgs pevent)
    {
        var g = pevent.Graphics;
        GraphicsHelper.ApplyHighQuality(g);

        var rectCard = new RectangleF(0, 0, Width - 1, Height - 1);
        using (var path = GraphicsHelper.GetRoundedRectangle(rectCard, 10))
        using (var brushBg = new SolidBrush(_backColor))
        using (var penBorder = new Pen(_borderColor, 1f))
        {
            g.FillPath(brushBg, path);
            g.DrawPath(penBorder, path);
        }

        // Avatar esquerdo circular (anel metálico estilizado)
        float avatarX = 8;
        float avatarY = (Height - 38) / 2f;
        var rectAvatar = new RectangleF(avatarX, avatarY, 38, 38);

        using (var pathAvatar = new GraphicsPath())
        {
            pathAvatar.AddEllipse(rectAvatar);
            if (_avatarImage != null)
            {
                using var brushImg = new TextureBrush(_avatarImage);
                g.FillPath(brushImg, pathAvatar);
            }
            else
            {
                using var brushGrad = new LinearGradientBrush(rectAvatar, Color.FromArgb(50, 52, 68), Color.FromArgb(20, 21, 29), 45f);
                g.FillPath(brushGrad, pathAvatar);
            }

            // Anel metálico
            using var penRing = new Pen(Color.FromArgb(90, 95, 120), 1.5f);
            g.DrawEllipse(penRing, rectAvatar);
        }

        // Nome do Usuário
        using var fontUser = new Font("Segoe UI Semibold", 9.5f, FontStyle.Bold);
        TextRenderer.DrawText(g, _username, fontUser, new Point((int)avatarX + 44, (int)avatarY + 1), Color.White);

        // Badge Lifetime e dias
        float badgeX = avatarX + 44;
        float badgeY = avatarY + 20;

        // Ícone pequeno de louro / escudo
        using var penIcon = new Pen(_accentColor, 1.2f);
        g.DrawLine(penIcon, badgeX, badgeY + 7, badgeX + 4, badgeY + 11);
        g.DrawLine(penIcon, badgeX + 4, badgeY + 11, badgeX + 9, badgeY + 5);

        using var fontBadge = new Font("Segoe UI", 7.5f, FontStyle.Bold);
        TextRenderer.DrawText(g, _badgeText, fontBadge, new Point((int)badgeX + 11, (int)badgeY + 1), Color.FromArgb(170, 180, 200));

        // Pílula com contagem de dias
        int daysW = 58;
        var rectDays = new RectangleF(badgeX + 54, badgeY, daysW, 15);
        using (var pathDays = GraphicsHelper.GetRoundedRectangle(rectDays, 4))
        using (var brushDays = new SolidBrush(Color.FromArgb(32, 36, 50)))
        {
            g.FillPath(brushDays, pathDays);
        }
        using var fontDays = new Font("Segoe UI", 7.5f);
        TextRenderer.DrawText(g, _daysText, fontDays, Rectangle.Round(rectDays), Color.FromArgb(210, 220, 240),
            TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

        // Ícone de Engrenagem (Configurações) na direita
        float gearX = Width - 20;
        float gearY = Height / 2f;
        Color gearCol = _gearHovered ? _accentColor : Color.FromArgb(110, 115, 135);
        using var penGear = new Pen(gearCol, 1.5f);
        g.DrawEllipse(penGear, gearX - 5, gearY - 5, 10, 10);
        using var brushGearCenter = new SolidBrush(gearCol);
        g.FillEllipse(brushGearCenter, gearX - 1.5f, gearY - 1.5f, 3, 3);
    }
}
