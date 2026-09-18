using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace VzxWidgets.Controls;

/// <summary>
/// Controle avançado e animado de ESP Preview com grade holográfica,
/// esqueleto humanoide vetorial, barra de vida dinâmica, caixa com gradiente e snapline.
/// </summary>
[ToolboxItem(true)]
public class VzxEspPreview : Control
{
    private readonly System.Windows.Forms.Timer animationTimer;

    private float animationValue;
    private bool animationIncreasing = true;

    private Color previewBackgroundColor = Color.FromArgb(13, 13, 17);
    private Color previewBorderColor = Color.FromArgb(45, 45, 52);
    private Color gridColor = Color.FromArgb(22, 255, 255, 255);

    private Color boxColor = Color.White;
    private Color fillBoxColor = Color.FromArgb(100, 187, 200, 254);
    private Color nameColor = Color.White;
    private Color distanceColor = Color.White;
    private Color healthHighColor = Color.FromArgb(0, 235, 35);
    private Color healthMediumColor = Color.FromArgb(255, 215, 0);
    private Color healthLowColor = Color.FromArgb(235, 25, 25);
    private Color skeletonColor = Color.White;
    private Color headCircleColor = Color.FromArgb(187, 200, 254);
    private Color snaplineColor = Color.FromArgb(187, 200, 254);

    private string playerName = "BOT";
    private string distanceText = "10m";

    private bool showPreviewBackground = true;
    private bool showGrid = true;
    private bool showBox = true;
    private bool showFillBox = true;
    private bool showName = true;
    private bool showDistance = true;
    private bool showHealthBar = true;
    private bool showSkeleton = true;
    private bool showHeadCircle = true;
    private bool showSnapline = true;
    private bool animatedPreview = true;

    private int healthValue = 85;
    private int boxThickness = 1;
    private int boxOutlineThickness = 2;
    private int borderRadius = 8;
    private int boxRounding = 4;
    private int healthBarHeight = 6;
    private int infoPanelRounding = 5;
    private int infoPanelHorizontalPadding = 12;
    private int infoPanelVerticalPadding = 6;

    private SnaplineOrigin snaplineOrigin = SnaplineOrigin.Top;

    public enum SnaplineOrigin
    {
        Top,
        Center,
        Bottom
    }

    public VzxEspPreview()
    {
        SetStyle(
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.OptimizedDoubleBuffer |
            ControlStyles.ResizeRedraw |
            ControlStyles.UserPaint |
            ControlStyles.SupportsTransparentBackColor,
            true);

        DoubleBuffered = true;
        Size = new Size(260, 380);
        MinimumSize = new Size(180, 250);
        Font = new Font("Segoe UI", 8.5f, FontStyle.Regular);
        BackColor = Color.Transparent;

        animationTimer = new System.Windows.Forms.Timer
        {
            Interval = 25
        };

        animationTimer.Tick += AnimationTimer_Tick;
        animationTimer.Enabled = true;
    }

    #region Preview

    [Category("VzxWidgets - ESP")]
    public Color PreviewBackgroundColor
    {
        get => previewBackgroundColor;
        set { previewBackgroundColor = value; Invalidate(); }
    }

    [Category("VzxWidgets - ESP")]
    public Color PreviewBorderColor
    {
        get => previewBorderColor;
        set { previewBorderColor = value; Invalidate(); }
    }

    [Category("VzxWidgets - ESP")]
    public Color GridColor
    {
        get => gridColor;
        set { gridColor = value; Invalidate(); }
    }

    [Category("VzxWidgets - ESP")]
    public bool ShowPreviewBackground
    {
        get => showPreviewBackground;
        set { showPreviewBackground = value; Invalidate(); }
    }

    [Category("VzxWidgets - ESP")]
    public bool ShowGrid
    {
        get => showGrid;
        set { showGrid = value; Invalidate(); }
    }

    [Category("VzxWidgets - ESP")]
    public int BorderRadius
    {
        get => borderRadius;
        set { borderRadius = ClampInt(value, 0, 40); Invalidate(); }
    }

    [Category("VzxWidgets - ESP")]
    public bool AnimatedPreview
    {
        get => animatedPreview;
        set
        {
            animatedPreview = value;
            animationTimer.Enabled = value;
            Invalidate();
        }
    }

    #endregion

    #region Box

    [Category("VzxWidgets - ESP")]
    public bool ShowBox
    {
        get => showBox;
        set { showBox = value; Invalidate(); }
    }

    [Category("VzxWidgets - ESP")]
    public bool ShowFillBox
    {
        get => showFillBox;
        set { showFillBox = value; Invalidate(); }
    }

    [Category("VzxWidgets - ESP")]
    public Color BoxColor
    {
        get => boxColor;
        set { boxColor = value; Invalidate(); }
    }

    [Category("VzxWidgets - ESP")]
    public Color FillBoxColor
    {
        get => fillBoxColor;
        set { fillBoxColor = value; Invalidate(); }
    }

    [Category("VzxWidgets - ESP")]
    public int BoxThickness
    {
        get => boxThickness;
        set { boxThickness = ClampInt(value, 1, 10); Invalidate(); }
    }

    [Category("VzxWidgets - ESP")]
    public int BoxOutlineThickness
    {
        get => boxOutlineThickness;
        set { boxOutlineThickness = ClampInt(value, 0, 10); Invalidate(); }
    }

    [Category("VzxWidgets - ESP")]
    public int BoxRounding
    {
        get => boxRounding;
        set { boxRounding = ClampInt(value, 0, 30); Invalidate(); }
    }

    #endregion

    #region Informações

    [Category("VzxWidgets - ESP")]
    public bool ShowName
    {
        get => showName;
        set { showName = value; Invalidate(); }
    }

    [Category("VzxWidgets - ESP")]
    public bool ShowDistance
    {
        get => showDistance;
        set { showDistance = value; Invalidate(); }
    }

    [Category("VzxWidgets - ESP")]
    public string PlayerName
    {
        get => playerName;
        set { playerName = value ?? string.Empty; Invalidate(); }
    }

    [Category("VzxWidgets - ESP")]
    public string DistanceText
    {
        get => distanceText;
        set { distanceText = value ?? string.Empty; Invalidate(); }
    }

    [Category("VzxWidgets - ESP")]
    public Color NameColor
    {
        get => nameColor;
        set { nameColor = value; Invalidate(); }
    }

    [Category("VzxWidgets - ESP")]
    public Color DistanceColor
    {
        get => distanceColor;
        set { distanceColor = value; Invalidate(); }
    }

    [Category("VzxWidgets - ESP")]
    public int InfoPanelRounding
    {
        get => infoPanelRounding;
        set { infoPanelRounding = ClampInt(value, 0, 30); Invalidate(); }
    }

    [Category("VzxWidgets - ESP")]
    public int InfoPanelHorizontalPadding
    {
        get => infoPanelHorizontalPadding;
        set { infoPanelHorizontalPadding = ClampInt(value, 0, 30); Invalidate(); }
    }

    [Category("VzxWidgets - ESP")]
    public int InfoPanelVerticalPadding
    {
        get => infoPanelVerticalPadding;
        set { infoPanelVerticalPadding = ClampInt(value, 0, 20); Invalidate(); }
    }

    #endregion

    #region Vida

    [Category("VzxWidgets - ESP")]
    public bool ShowHealthBar
    {
        get => showHealthBar;
        set { showHealthBar = value; Invalidate(); }
    }

    [Category("VzxWidgets - ESP")]
    public int HealthValue
    {
        get => healthValue;
        set { healthValue = ClampInt(value, 0, 100); Invalidate(); }
    }

    [Category("VzxWidgets - ESP")]
    public int HealthBarHeight
    {
        get => healthBarHeight;
        set { healthBarHeight = ClampInt(value, 2, 20); Invalidate(); }
    }

    [Category("VzxWidgets - ESP")]
    public Color HealthHighColor
    {
        get => healthHighColor;
        set { healthHighColor = value; Invalidate(); }
    }

    [Category("VzxWidgets - ESP")]
    public Color HealthMediumColor
    {
        get => healthMediumColor;
        set { healthMediumColor = value; Invalidate(); }
    }

    [Category("VzxWidgets - ESP")]
    public Color HealthLowColor
    {
        get => healthLowColor;
        set { healthLowColor = value; Invalidate(); }
    }

    #endregion

    #region Skeleton e linha

    [Category("VzxWidgets - ESP")]
    public bool ShowSkeleton
    {
        get => showSkeleton;
        set { showSkeleton = value; Invalidate(); }
    }

    [Category("VzxWidgets - ESP")]
    public bool ShowHeadCircle
    {
        get => showHeadCircle;
        set { showHeadCircle = value; Invalidate(); }
    }

    [Category("VzxWidgets - ESP")]
    public Color SkeletonColor
    {
        get => skeletonColor;
        set { skeletonColor = value; Invalidate(); }
    }

    [Category("VzxWidgets - ESP")]
    public Color HeadCircleColor
    {
        get => headCircleColor;
        set { headCircleColor = value; Invalidate(); }
    }

    [Category("VzxWidgets - ESP")]
    public bool ShowSnapline
    {
        get => showSnapline;
        set { showSnapline = value; Invalidate(); }
    }

    [Category("VzxWidgets - ESP")]
    public Color SnaplineColor
    {
        get => snaplineColor;
        set { snaplineColor = value; Invalidate(); }
    }

    [Category("VzxWidgets - ESP")]
    public SnaplineOrigin LineOrigin
    {
        get => snaplineOrigin;
        set { snaplineOrigin = value; Invalidate(); }
    }

    #endregion

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        Graphics g = e.Graphics;
        g.SmoothingMode = SmoothingMode.AntiAlias;
        g.PixelOffsetMode = PixelOffsetMode.HighQuality;
        g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

        Rectangle outer = new Rectangle(0, 0, Width - 1, Height - 1);

        if (showPreviewBackground)
        {
            using (GraphicsPath path = CreateRoundedRectangle(outer, borderRadius))
            using (SolidBrush brush = new SolidBrush(previewBackgroundColor))
            using (Pen pen = new Pen(previewBorderColor, 1f))
            {
                g.FillPath(brush, path);
                g.DrawPath(pen, path);
            }
        }

        if (showGrid)
            DrawGrid(g);

        DrawHeader(g);
        DrawEsp(g);
    }

    private void DrawHeader(Graphics g)
    {
        const string header = "ESP Preview";

        using (SolidBrush indicator = new SolidBrush(Color.FromArgb(165, 110, 255)))
        using (SolidBrush textBrush = new SolidBrush(Color.FromArgb(215, 215, 220)))
        using (Pen separator = new Pen(Color.FromArgb(25, 255, 255, 255), 1f))
        {
            g.FillEllipse(indicator, 14, 18, 6, 6);
            g.DrawString(header, Font, textBrush, 27, 13);
            g.DrawLine(separator, 12, 42, Width - 12, 42);
        }
    }

    private void DrawGrid(Graphics g)
    {
        using (Pen pen = new Pen(gridColor, 1f))
        {
            for (int x = 18; x < Width; x += 22)
                g.DrawLine(pen, x, 48, x, Height - 12);

            for (int y = 52; y < Height; y += 22)
                g.DrawLine(pen, 12, y, Width - 12, y);
        }
    }

    private void DrawEsp(Graphics g)
    {
        float move = animatedPreview ? animationValue : 0f;

        int boxHeight = Math.Max(150, Height - 170);
        boxHeight = Math.Min(boxHeight, Height - 145);

        int boxWidth = (int)(boxHeight * 0.65f);
        boxWidth = Math.Min(boxWidth, Width - 100);

        int boxX = (Width - boxWidth) / 2;
        int boxY = 105 + (int)move;

        Rectangle box = new Rectangle(boxX, boxY, boxWidth, boxHeight);

        if (showSnapline)
            DrawSnapline(g, box);

        if (showFillBox)
            DrawGradientFill(g, box);

        if (showBox)
            DrawRoundedEspBox(g, box);

        if (showSkeleton)
            DrawSkeleton(g, box);

        if (showHeadCircle)
            DrawHeadCircle(g, box);

        DrawPlayerInfoPanel(g, box);
    }

    private void DrawRoundedEspBox(Graphics g, Rectangle box)
    {
        using (GraphicsPath path = CreateRoundedRectangle(box, boxRounding))
        {
            if (boxOutlineThickness > 0)
            {
                using (Pen outline = new Pen(
                    Color.FromArgb(230, 0, 0, 0),
                    boxThickness + boxOutlineThickness))
                {
                    g.DrawPath(outline, path);
                }
            }

            using (Pen main = new Pen(boxColor, boxThickness))
            {
                g.DrawPath(main, path);
            }
        }
    }

    private void DrawGradientFill(Graphics g, Rectangle box)
    {
        Rectangle inner = new Rectangle(
            box.X + 1,
            box.Y + 1,
            Math.Max(1, box.Width - 2),
            Math.Max(1, box.Height - 2));

        Color top = Color.FromArgb(25, fillBoxColor);
        Color bottom = Color.FromArgb(191, fillBoxColor);

        using (LinearGradientBrush brush = new LinearGradientBrush(
            inner,
            top,
            bottom,
            LinearGradientMode.Vertical))
        using (GraphicsPath path = CreateRoundedRectangle(inner, Math.Max(0, boxRounding - 1)))
        {
            g.FillPath(brush, path);
        }
    }

    private void DrawPlayerInfoPanel(Graphics g, Rectangle box)
    {
        string infoText = BuildInfoText();

        bool hasInfo = !string.IsNullOrEmpty(infoText);
        bool hasHealth = showHealthBar;

        if (!hasInfo && !hasHealth)
            return;

        SizeF textSize = hasInfo
            ? g.MeasureString(infoText, Font)
            : SizeF.Empty;

        float panelWidth = Math.Max(
            Math.Max(75f, box.Width),
            textSize.Width + infoPanelHorizontalPadding * 2f);

        float panelHeight = hasInfo
            ? textSize.Height + infoPanelVerticalPadding * 2f
            : 0f;

        float centerX = box.X + box.Width / 2f;
        float panelBottomY = box.Y - 10f;
        float panelTopY = panelBottomY - panelHeight;

        float healthBottomY = hasInfo
            ? panelTopY - 5f
            : box.Y - 10f;

        float healthTopY = healthBottomY - healthBarHeight;

        RectangleF panel = new RectangleF(
            centerX - panelWidth / 2f,
            panelTopY,
            panelWidth,
            panelHeight);

        if (showHealthBar)
            DrawHorizontalHealthBar(g, panel.X, healthTopY, panelWidth, healthBarHeight);

        if (!hasInfo)
            return;

        RectangleF shadow = panel;
        shadow.Offset(1.5f, 2f);

        using (GraphicsPath shadowPath = CreateRoundedRectangle(Rectangle.Round(shadow), infoPanelRounding))
        using (GraphicsPath panelPath = CreateRoundedRectangle(Rectangle.Round(panel), infoPanelRounding))
        using (SolidBrush shadowBrush = new SolidBrush(Color.FromArgb(120, 0, 0, 0)))
        using (SolidBrush backgroundBrush = new SolidBrush(Color.FromArgb(225, 5, 5, 5)))
        using (Pen borderPen = new Pen(Color.FromArgb(220, 25, 25, 25), 1f))
        {
            g.FillPath(shadowBrush, shadowPath);
            g.FillPath(backgroundBrush, panelPath);
            g.DrawPath(borderPen, panelPath);
        }

        float textX = panel.X + (panel.Width - textSize.Width) / 2f;
        float textY = panel.Y + (panel.Height - textSize.Height) / 2f;

        DrawInfoText(g, textX, textY);
    }

    private string BuildInfoText()
    {
        if (showName && showDistance)
            return playerName + "  |  " + distanceText;

        if (showName)
            return playerName;

        if (showDistance)
            return distanceText;

        return string.Empty;
    }

    private void DrawInfoText(Graphics g, float x, float y)
    {
        string separator = "  |  ";

        if (showName && showDistance)
        {
            DrawOutlinedText(g, playerName, nameColor, new PointF(x, y));

            float nameWidth = g.MeasureString(playerName, Font).Width;
            DrawOutlinedText(g, separator, Color.White, new PointF(x + nameWidth, y));

            float separatorWidth = g.MeasureString(separator, Font).Width;
            DrawOutlinedText(
                g,
                distanceText,
                distanceColor,
                new PointF(x + nameWidth + separatorWidth, y));

            return;
        }

        if (showName)
            DrawOutlinedText(g, playerName, nameColor, new PointF(x, y));
        else if (showDistance)
            DrawOutlinedText(g, distanceText, distanceColor, new PointF(x, y));
    }

    private void DrawHorizontalHealthBar(
        Graphics g,
        float x,
        float y,
        float width,
        float height)
    {
        float percentage = healthValue / 100f;
        float filledWidth = width * percentage;
        float rounding = height / 2f;

        RectangleF shadowRect = new RectangleF(x - 1.5f, y - 1.5f, width + 3f, height + 3f);
        RectangleF backgroundRect = new RectangleF(x, y, width, height);
        RectangleF filledRect = new RectangleF(x, y, Math.Max(0f, filledWidth), height);

        using (GraphicsPath shadowPath = CreateRoundedRectangle(Rectangle.Round(shadowRect), (int)(rounding + 1.5f)))
        using (GraphicsPath backgroundPath = CreateRoundedRectangle(Rectangle.Round(backgroundRect), (int)rounding))
        using (SolidBrush shadowBrush = new SolidBrush(Color.FromArgb(150, 0, 0, 0)))
        using (SolidBrush backgroundBrush = new SolidBrush(Color.FromArgb(235, 18, 18, 18)))
        using (Pen borderPen = new Pen(Color.FromArgb(245, 0, 0, 0), 1f))
        {
            g.FillPath(shadowBrush, shadowPath);
            g.FillPath(backgroundBrush, backgroundPath);

            if (filledRect.Width > 0f)
            {
                Color healthColor = GetHealthColor(percentage);
                int visibleWidth = Math.Max((int)height, (int)filledRect.Width);
                visibleWidth = Math.Min((int)width, visibleWidth);

                Rectangle visibleRect = new Rectangle(
                    (int)x,
                    (int)y,
                    visibleWidth,
                    (int)height);

                using (GraphicsPath fillPath = CreateRoundedRectangle(visibleRect, (int)rounding))
                using (SolidBrush fillBrush = new SolidBrush(healthColor))
                {
                    g.FillPath(fillBrush, fillPath);
                }

                float highlightStart = x + Math.Min(rounding, visibleWidth / 2f);
                float highlightEnd = x + visibleWidth - Math.Min(rounding, visibleWidth / 2f);

                if (highlightEnd > highlightStart)
                {
                    using (Pen highlight = new Pen(Color.FromArgb(70, 255, 255, 255), 1f))
                    {
                        g.DrawLine(highlight, highlightStart, y + 1f, highlightEnd, y + 1f);
                    }
                }
            }

            g.DrawPath(borderPen, backgroundPath);
        }
    }

    private Color GetHealthColor(float percentage)
    {
        if (percentage >= 0.6f)
            return healthHighColor;

        if (percentage >= 0.3f)
            return healthMediumColor;

        return healthLowColor;
    }

    private void DrawSkeleton(Graphics g, Rectangle box)
    {
        float cx = box.X + box.Width / 2f;

        float headY = box.Y + box.Height * 0.10f;
        float neckY = box.Y + box.Height * 0.18f;
        float shoulderY = box.Y + box.Height * 0.24f;
        float chestY = box.Y + box.Height * 0.38f;
        float hipY = box.Y + box.Height * 0.60f;

        PointF head = new PointF(cx, headY);
        PointF neck = new PointF(cx, neckY);
        PointF chest = new PointF(cx, chestY);
        PointF hip = new PointF(cx, hipY);

        PointF leftShoulder = new PointF(cx - box.Width * 0.18f, shoulderY);
        PointF rightShoulder = new PointF(cx + box.Width * 0.18f, shoulderY);

        PointF leftElbow = new PointF(cx - box.Width * 0.24f, box.Y + box.Height * 0.40f);
        PointF rightElbow = new PointF(cx + box.Width * 0.24f, box.Y + box.Height * 0.40f);

        PointF leftWrist = new PointF(cx - box.Width * 0.28f, box.Y + box.Height * 0.50f);
        PointF rightWrist = new PointF(cx + box.Width * 0.28f, box.Y + box.Height * 0.50f);

        PointF leftFoot = new PointF(cx - box.Width * 0.22f, box.Bottom - 5);
        PointF rightFoot = new PointF(cx + box.Width * 0.22f, box.Bottom - 5);

        using (Pen outline = CreateRoundPen(Color.FromArgb(230, 0, 0, 0), 2.7f))
        using (Pen main = CreateRoundPen(skeletonColor, 1f))
        {
            DrawSkeletonBody(g, outline, head, neck, chest, hip, leftShoulder, rightShoulder, leftElbow, rightElbow, leftWrist, rightWrist, leftFoot, rightFoot);
            DrawSkeletonBody(g, main, head, neck, chest, hip, leftShoulder, rightShoulder, leftElbow, rightElbow, leftWrist, rightWrist, leftFoot, rightFoot);
        }
    }

    private static void DrawSkeletonBody(
        Graphics g,
        Pen pen,
        PointF head,
        PointF neck,
        PointF chest,
        PointF hip,
        PointF leftShoulder,
        PointF rightShoulder,
        PointF leftElbow,
        PointF rightElbow,
        PointF leftWrist,
        PointF rightWrist,
        PointF leftFoot,
        PointF rightFoot)
    {
        DrawSkeletonLine(g, pen, head, neck);
        DrawSkeletonLine(g, pen, neck, chest);
        DrawSkeletonLine(g, pen, chest, hip);
        DrawSkeletonLine(g, pen, neck, leftShoulder);
        DrawSkeletonLine(g, pen, neck, rightShoulder);
        DrawSkeletonLine(g, pen, leftShoulder, leftElbow);
        DrawSkeletonLine(g, pen, leftElbow, leftWrist);
        DrawSkeletonLine(g, pen, rightShoulder, rightElbow);
        DrawSkeletonLine(g, pen, rightElbow, rightWrist);
        DrawSkeletonLine(g, pen, hip, leftFoot);
        DrawSkeletonLine(g, pen, hip, rightFoot);
    }

    private void DrawHeadCircle(Graphics g, Rectangle box)
    {
        float distance = 10f;
        float radius = 50f / Math.Max(distance, 1f);
        radius = Math.Max(1.5f, Math.Min(20f, radius));

        float cx = box.X + box.Width / 2f;
        float cy = box.Y + box.Height * 0.10f;

        RectangleF circle = new RectangleF(
            cx - radius,
            cy - radius,
            radius * 2f,
            radius * 2f);

        using (Pen outline = new Pen(Color.FromArgb(230, 0, 0, 0), boxThickness + boxOutlineThickness))
        using (Pen main = new Pen(headCircleColor, boxThickness))
        {
            g.DrawEllipse(outline, circle);
            g.DrawEllipse(main, circle);
        }
    }

    private void DrawSnapline(Graphics g, Rectangle box)
    {
        PointF start;

        switch (snaplineOrigin)
        {
            case SnaplineOrigin.Top:
                start = new PointF(Width / 2f, 25f);
                break;

            case SnaplineOrigin.Bottom:
                start = new PointF(Width / 2f, Height - 25f);
                break;

            default:
                start = new PointF(Width / 2f, Height / 2f);
                break;
        }

        PointF end = new PointF(box.X + box.Width / 2f, box.Y);

        using (Pen outline = CreateRoundPen(Color.FromArgb(180, 0, 0, 0), 2.7f))
        using (Pen main = CreateRoundPen(snaplineColor, 1f))
        {
            g.DrawLine(outline, start, end);
            g.DrawLine(main, start, end);
        }

        if (snaplineOrigin == SnaplineOrigin.Top ||
            snaplineOrigin == SnaplineOrigin.Bottom)
        {
            using (SolidBrush shadow = new SolidBrush(Color.Black))
            using (SolidBrush center = new SolidBrush(Color.Lime))
            {
                g.FillEllipse(shadow, start.X - 4.1f, start.Y - 4.1f, 8.2f, 8.2f);
                g.FillEllipse(center, start.X - 3f, start.Y - 3f, 6f, 6f);
            }
        }
    }

    private static Pen CreateRoundPen(Color color, float width)
    {
        return new Pen(color, width)
        {
            StartCap = LineCap.Round,
            EndCap = LineCap.Round
        };
    }

    private static void DrawSkeletonLine(Graphics g, Pen pen, PointF start, PointF end)
    {
        g.DrawLine(pen, start, end);
    }

    private void DrawOutlinedText(Graphics g, string text, Color color, PointF position)
    {
        if (string.IsNullOrEmpty(text))
            return;

        using (SolidBrush outline = new SolidBrush(Color.FromArgb(230, 0, 0, 0)))
        using (SolidBrush main = new SolidBrush(color))
        {
            g.DrawString(text, Font, outline, position.X - 1f, position.Y);
            g.DrawString(text, Font, outline, position.X + 1f, position.Y);
            g.DrawString(text, Font, outline, position.X, position.Y - 1f);
            g.DrawString(text, Font, outline, position.X, position.Y + 1f);
            g.DrawString(text, Font, main, position);
        }
    }

    private void AnimationTimer_Tick(object? sender, EventArgs e)
    {
        const float speed = 0.15f;
        const float limit = 3f;

        if (animationIncreasing)
        {
            animationValue += speed;

            if (animationValue >= limit)
                animationIncreasing = false;
        }
        else
        {
            animationValue -= speed;

            if (animationValue <= -limit)
                animationIncreasing = true;
        }

        Invalidate();
    }

    private static GraphicsPath CreateRoundedRectangle(Rectangle rectangle, int radius)
    {
        GraphicsPath path = new GraphicsPath();

        if (rectangle.Width <= 0 || rectangle.Height <= 0)
            return path;

        radius = Math.Max(0, Math.Min(radius, Math.Min(rectangle.Width, rectangle.Height) / 2));

        if (radius == 0)
        {
            path.AddRectangle(rectangle);
            path.CloseFigure();
            return path;
        }

        int diameter = radius * 2;
        Rectangle arc = new Rectangle(rectangle.X, rectangle.Y, diameter, diameter);

        path.AddArc(arc, 180, 90);

        arc.X = rectangle.Right - diameter;
        path.AddArc(arc, 270, 90);

        arc.Y = rectangle.Bottom - diameter;
        path.AddArc(arc, 0, 90);

        arc.X = rectangle.Left;
        path.AddArc(arc, 90, 90);

        path.CloseFigure();
        return path;
    }

    private static int ClampInt(int value, int minimum, int maximum)
    {
        if (value < minimum)
            return minimum;

        if (value > maximum)
            return maximum;

        return value;
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            animationTimer.Stop();
            animationTimer.Tick -= AnimationTimer_Tick;
            animationTimer.Dispose();
        }

        base.Dispose(disposing);
    }
}
