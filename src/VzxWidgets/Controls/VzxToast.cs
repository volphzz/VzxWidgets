using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
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
[DefaultEvent("Closed")]
public class VzxToast : Control
{
    private ToastType _type = ToastType.Success;
    private string _title = "Notificação";
    private string _message = "Operação realizada com sucesso.";
    private Color _barColor = Color.FromArgb(48, 209, 88);
    private int _borderRadius = 10;
    private bool _closeHovered = false;

    // Animação & Auto-dismiss
    private readonly System.Windows.Forms.Timer _animTimer;
    private readonly System.Windows.Forms.Timer _progressTimer;
    private int _durationMs = 3500;
    private int _elapsedMs = 0;
    private bool _isClosing = false;
    private bool _isHovered = false;
    private int _targetX;
    private int _targetY;

    public event EventHandler? Closed;

    public VzxToast()
    {
        DoubleBuffered = true;
        Size = new Size(245, 62);
        BackColor = Color.FromArgb(20, 20, 27);
        ForeColor = Color.White;

        SetStyle(ControlStyles.AllPaintingInWmPaint |
                 ControlStyles.OptimizedDoubleBuffer |
                 ControlStyles.ResizeRedraw |
                 ControlStyles.SupportsTransparentBackColor |
                 ControlStyles.UserPaint, true);

        _animTimer = new System.Windows.Forms.Timer { Interval = 15 };
        _animTimer.Tick += AnimTimer_Tick;

        _progressTimer = new System.Windows.Forms.Timer { Interval = 30 };
        _progressTimer.Tick += ProgressTimer_Tick;
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
                ToastType.Info => Color.FromArgb(187, 200, 254),
                ToastType.Warning => Color.FromArgb(255, 149, 0),
                ToastType.Error => Color.FromArgb(255, 69, 58),
                _ => Color.FromArgb(187, 200, 254)
            };
            Invalidate();
        }
    }

    [Category("VzxWidgets")]
    [DefaultValue("Notificação")]
    public string Title
    {
        get => _title;
        set { _title = value; Invalidate(); }
    }

    [Category("VzxWidgets")]
    [DefaultValue("Operação realizada com sucesso.")]
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

    [Category("VzxWidgets")]
    [DefaultValue(10)]
    public int BorderRadius
    {
        get => _borderRadius;
        set { _borderRadius = Math.Max(0, value); Invalidate(); }
    }

    [Category("VzxWidgets")]
    [DefaultValue(3500)]
    public int DurationMs
    {
        get => _durationMs;
        set => _durationMs = value;
    }

    public void StartAnimation(int targetX, int targetY)
    {
        _targetX = targetX;
        _targetY = targetY;
        _elapsedMs = 0;
        _isClosing = false;
        _animTimer.Start();
        if (_durationMs > 0)
        {
            _progressTimer.Start();
        }
    }

    public void SlideTo(int targetX, int targetY)
    {
        _targetX = targetX;
        _targetY = targetY;
        if (!_animTimer.Enabled)
        {
            _animTimer.Start();
        }
    }

    public void CloseWithAnimation()
    {
        if (_isClosing) return;
        _isClosing = true;
        _progressTimer.Stop();
        if (Parent != null)
        {
            _targetX = Parent.ClientSize.Width + 20;
        }
        _animTimer.Start();
    }

    private void AnimTimer_Tick(object? sender, EventArgs e)
    {
        if (!_isClosing)
        {
            int dx = _targetX - Left;
            int dy = _targetY - Top;

            if (Math.Abs(dx) > 1 || Math.Abs(dy) > 1)
            {
                Left += (int)Math.Round(dx * 0.35);
                Top += (int)Math.Round(dy * 0.35);
            }
            else
            {
                Left = _targetX;
                Top = _targetY;
                _animTimer.Stop();
            }
        }
        else
        {
            // Desliza para fora à direita
            int dx = (Parent?.ClientSize.Width ?? (Left + 50)) - Left;
            Left += Math.Max(10, (int)Math.Round(dx * 0.35));

            if (Parent != null && Left >= Parent.ClientSize.Width)
            {
                _animTimer.Stop();
                _progressTimer.Stop();
                Closed?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    private void ProgressTimer_Tick(object? sender, EventArgs e)
    {
        if (!_isHovered && !_isClosing)
        {
            _elapsedMs += _progressTimer.Interval;
            Invalidate();

            if (_elapsedMs >= _durationMs)
            {
                CloseWithAnimation();
            }
        }
    }

    protected override void OnMouseEnter(EventArgs e)
    {
        base.OnMouseEnter(e);
        _isHovered = true;
    }

    protected override void OnMouseLeave(EventArgs e)
    {
        base.OnMouseLeave(e);
        _isHovered = false;
        _closeHovered = false;
        Invalidate();
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

    protected override void OnMouseDown(MouseEventArgs e)
    {
        base.OnMouseDown(e);
        if (e.X >= Width - 24 && e.Y <= 24)
        {
            CloseWithAnimation();
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
        var rectBar = new RectangleF(0, 6, 3.5f, Height - 12);
        using var brushBar = new SolidBrush(_barColor);
        g.FillRectangle(brushBar, rectBar);

        // Barra de progresso de auto-dismiss no rodapé
        if (_durationMs > 0 && !_isClosing)
        {
            float progress = 1f - Math.Clamp((float)_elapsedMs / _durationMs, 0f, 1f);
            float barW = (Width - 10) * progress;
            if (barW > 0)
            {
                using var brushProg = new SolidBrush(Color.FromArgb(60, _barColor));
                g.FillRectangle(brushProg, 5, Height - 3, barW, 2);
            }
        }

        // Ícone vetorial
        float iconX = 16;
        float iconY = Height / 2f - 1;
        using var penIcon = new Pen(_barColor, 2f)
        {
            StartCap = LineCap.Round,
            EndCap = LineCap.Round,
            LineJoin = LineJoin.Round
        };

        switch (_type)
        {
            case ToastType.Success:
                g.DrawLines(penIcon, new[] {
                    new PointF(iconX, iconY + 1),
                    new PointF(iconX + 3.5f, iconY + 4.5f),
                    new PointF(iconX + 9.5f, iconY - 3.5f)
                });
                break;

            case ToastType.Warning:
                g.DrawLine(penIcon, iconX + 4.5f, iconY - 6, iconX + 4.5f, iconY + 1);
                g.FillEllipse(brushBar, iconX + 3.5f, iconY + 4, 2.5f, 2.5f);
                break;

            case ToastType.Error:
                g.DrawLine(penIcon, iconX + 1, iconY - 4, iconX + 8, iconY + 4);
                g.DrawLine(penIcon, iconX + 8, iconY - 4, iconX + 1, iconY + 4);
                break;

            case ToastType.Info:
            default:
                g.FillEllipse(brushBar, iconX + 3.5f, iconY - 6, 3, 3);
                g.DrawLine(penIcon, iconX + 5f, iconY - 1, iconX + 5f, iconY + 6);
                break;
        }

        // Título
        using var titleFont = new Font("Segoe UI Semibold", 9.5f, FontStyle.Bold);
        TextRenderer.DrawText(g, _title, titleFont, new Rectangle(36, 11, Width - 60, 20), Color.White,
            TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);

        // Mensagem
        using var msgFont = new Font("Segoe UI", 8.5f);
        TextRenderer.DrawText(g, _message, msgFont, new Rectangle(36, 31, Width - 60, 20), Color.FromArgb(170, 170, 185),
            TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);

        // Botão Fechar "x"
        Color xColor = _closeHovered ? Color.White : Color.FromArgb(120, 120, 140);
        using var penX = new Pen(xColor, 1.3f) { StartCap = LineCap.Round, EndCap = LineCap.Round };
        float cx = Width - 14;
        float cy = 14;
        g.DrawLine(penX, cx - 3.5f, cy - 3.5f, cx + 3.5f, cy + 3.5f);
        g.DrawLine(penX, cx + 3.5f, cy - 3.5f, cx - 3.5f, cy + 3.5f);
    }
}
