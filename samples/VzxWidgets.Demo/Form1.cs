using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace VzxWidgets.Demo;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void trackMaxDist_ValueChanged(object? sender, EventArgs e)
    {
        lblMaxDistVal.Text = $"{trackMaxDist.Value}m";
    }

    private void chkEspBox_CheckedChanged(object? sender, EventArgs e)
    {
        if (chkEspBox.Checked)
        {
            toastSuccess.Visible = true;
            toastSuccess.BringToFront();
        }
        else
        {
            toastInfo.Visible = true;
            toastInfo.BringToFront();
        }
    }

    private void pnlSkeletonView_Paint(object sender, PaintEventArgs e)
    {
        var g = e.Graphics;
        g.SmoothingMode = SmoothingMode.AntiAlias;

        int w = pnlSkeletonView.Width;
        int h = pnlSkeletonView.Height;

        // Fundo com gradiente sutil roxo
        using (var brush = new LinearGradientBrush(new Rectangle(0, 0, w, h),
            Color.FromArgb(30, 22, 45), Color.FromArgb(12, 10, 20), LinearGradientMode.Vertical))
        {
            g.FillRectangle(brush, 0, 0, w, h);
        }

        // Borda do ESP Box
        using (var penBox = new Pen(Color.FromArgb(155, 80, 255), 1.5f))
        {
            g.DrawRectangle(penBox, 1, 1, w - 2, h - 2);
        }

        // Tag "BOT"
        using var fontBot = new Font("Segoe UI Semibold", 8f, FontStyle.Bold);
        TextRenderer.DrawText(g, "BOT", fontBot, new Rectangle(0, 6, w, 16), Color.White,
            TextFormatFlags.HorizontalCenter);

        // Desenhar esqueleto estilizado
        using var penSkel = new Pen(Color.FromArgb(200, 200, 230), 1.2f)
        {
            StartCap = LineCap.Round,
            EndCap = LineCap.Round
        };

        float cx = w / 2f;

        // Cabeça
        g.DrawEllipse(penSkel, cx - 8, 30, 16, 16);

        // Coluna
        g.DrawLine(penSkel, cx, 46, cx, 150);

        // Ombros e Braços
        g.DrawLine(penSkel, cx - 35, 65, cx + 35, 65);
        g.DrawLine(penSkel, cx - 35, 65, cx - 45, 120);
        g.DrawLine(penSkel, cx + 35, 65, cx + 45, 120);
        g.DrawLine(penSkel, cx - 45, 120, cx - 40, 180);
        g.DrawLine(penSkel, cx + 45, 120, cx + 40, 180);

        // Pelve e Pernas
        g.DrawLine(penSkel, cx, 150, cx - 25, 240);
        g.DrawLine(penSkel, cx, 150, cx + 25, 240);
        g.DrawLine(penSkel, cx - 25, 240, cx - 20, 340);
        g.DrawLine(penSkel, cx + 25, 240, cx + 20, 340);

        // Snap line roxa de cima
        using var penSnap = new Pen(Color.FromArgb(155, 80, 255), 1.5f);
        g.DrawLine(penSnap, cx, 0, cx, 30);
    }
}
