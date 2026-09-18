using System.Drawing;
using System.Drawing.Drawing2D;

namespace VzxWidgets.Helpers;

public static class GraphicsHelper
{
    public static GraphicsPath GetRoundedRectangle(RectangleF rect, float radius)
    {
        return GetCustomRoundedRectangle(rect, radius, radius, radius, radius);
    }

    public static GraphicsPath GetCustomRoundedRectangle(RectangleF rect, float tl, float tr, float br, float bl)
    {
        var path = new GraphicsPath();

        // Se nenhum canto tiver curva
        if (tl <= 0.5f && tr <= 0.5f && br <= 0.5f && bl <= 0.5f)
        {
            path.AddRectangle(rect);
            return path;
        }

        float maxDiameter = Math.Min(rect.Width, rect.Height);

        // Top Left
        if (tl > 0.5f)
        {
            float dTl = Math.Min(tl * 2f, maxDiameter);
            path.AddArc(rect.X, rect.Y, dTl, dTl, 180, 90);
        }
        else
        {
            path.AddLine(rect.X, rect.Y, rect.X, rect.Y);
        }

        // Top Right
        if (tr > 0.5f)
        {
            float dTr = Math.Min(tr * 2f, maxDiameter);
            path.AddArc(rect.Right - dTr, rect.Y, dTr, dTr, 270, 90);
        }
        else
        {
            path.AddLine(rect.Right, rect.Y, rect.Right, rect.Y);
        }

        // Bottom Right
        if (br > 0.5f)
        {
            float dBr = Math.Min(br * 2f, maxDiameter);
            path.AddArc(rect.Right - dBr, rect.Bottom - dBr, dBr, dBr, 0, 90);
        }
        else
        {
            path.AddLine(rect.Right, rect.Bottom, rect.Right, rect.Bottom);
        }

        // Bottom Left
        if (bl > 0.5f)
        {
            float dBl = Math.Min(bl * 2f, maxDiameter);
            path.AddArc(rect.X, rect.Bottom - dBl, dBl, dBl, 90, 90);
        }
        else
        {
            path.AddLine(rect.X, rect.Bottom, rect.X, rect.Bottom);
        }

        path.CloseFigure();
        return path;
    }

    public static void ApplyHighQuality(Graphics g)
    {
        g.SmoothingMode = SmoothingMode.AntiAlias;
        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
        g.PixelOffsetMode = PixelOffsetMode.HighQuality;
        g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
    }
}
