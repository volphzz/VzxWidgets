using System.Drawing;
using System.Windows.Forms;
using VzxWidgets.Controls;

namespace VzxWidgets.Demo;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        SetupModernDemo();
    }

    private void SetupModernDemo()
    {
        Text = "VzxWidgets - Modern UI Showcase (Estilo Guna UI)";
        Size = new Size(860, 600);
        StartPosition = FormStartPosition.CenterScreen;
        BackColor = Color.FromArgb(18, 18, 24);
        ForeColor = Color.White;

        // Card Principal / Container
        var mainCard = new VzxCard
        {
            Location = new Point(40, 30),
            Size = new Size(760, 490),
            BorderRadius = 20,
            BorderSize = 1,
            BorderColor = Color.FromArgb(55, 55, 75),
            BackColor = Color.FromArgb(25, 25, 35)
        };
        Controls.Add(mainCard);

        // Titulo Header
        var lblTitle = new Label
        {
            Text = "VzxWidgets • Suite Moderna para WinForms",
            Font = new Font("Segoe UI", 16f, FontStyle.Bold),
            ForeColor = Color.FromArgb(240, 240, 255),
            Location = new Point(25, 20),
            AutoSize = true
        };
        mainCard.Controls.Add(lblTitle);

        var lblSub = new Label
        {
            Text = "Controles com bordas curvas, aceleracao grafica GDI+ e anti-aliasing ativo.",
            Font = new Font("Segoe UI", 9.5f),
            ForeColor = Color.FromArgb(140, 140, 160),
            Location = new Point(27, 55),
            AutoSize = true
        };
        mainCard.Controls.Add(lblSub);

        // Secao 1: Botoes Estilizados
        var btnPrimary = new VzxButton
        {
            Text = "Botao Primario",
            Location = new Point(30, 110),
            Size = new Size(160, 42),
            BorderRadius = 14,
            BackColor = Color.FromArgb(94, 92, 230),
            HoverColor = Color.FromArgb(120, 118, 240),
            PressedColor = Color.FromArgb(70, 68, 190)
        };
        mainCard.Controls.Add(btnPrimary);

        var btnEmerald = new VzxButton
        {
            Text = "Acao Sucesso",
            Location = new Point(210, 110),
            Size = new Size(160, 42),
            BorderRadius = 14,
            BackColor = Color.FromArgb(48, 209, 88),
            HoverColor = Color.FromArgb(70, 220, 105),
            PressedColor = Color.FromArgb(35, 170, 70),
            ForeColor = Color.Black
        };
        mainCard.Controls.Add(btnEmerald);

        var btnOutline = new VzxButton
        {
            Text = "Estilo Outline",
            Location = new Point(390, 110),
            Size = new Size(160, 42),
            BorderRadius = 14,
            BorderSize = 2,
            BorderColor = Color.FromArgb(255, 69, 58),
            BackColor = Color.FromArgb(25, 25, 35),
            HoverColor = Color.FromArgb(45, 30, 35),
            PressedColor = Color.FromArgb(60, 30, 40),
            ForeColor = Color.FromArgb(255, 69, 58)
        };
        mainCard.Controls.Add(btnOutline);

        // Secao 2: Toggle Switches
        var lblToggles = new Label
        {
            Text = "Interruptores Fluent / iOS:",
            Font = new Font("Segoe UI Semibold", 10.5f, FontStyle.Bold),
            ForeColor = Color.FromArgb(200, 200, 220),
            Location = new Point(30, 185),
            AutoSize = true
        };
        mainCard.Controls.Add(lblToggles);

        var toggle1 = new VzxToggleSwitch
        {
            Location = new Point(30, 220),
            Checked = true
        };
        mainCard.Controls.Add(toggle1);

        var lblToggleState = new Label
        {
            Text = "Ativado (True)",
            Font = new Font("Segoe UI", 9.5f),
            ForeColor = Color.FromArgb(170, 170, 190),
            Location = new Point(95, 224),
            AutoSize = true
        };
        mainCard.Controls.Add(lblToggleState);

        toggle1.CheckedChanged += (s, e) =>
        {
            lblToggleState.Text = toggle1.Checked ? "Ativado (True)" : "Desativado (False)";
        };

        var toggle2 = new VzxToggleSwitch
        {
            Location = new Point(230, 220),
            Checked = false,
            OnBackColor = Color.FromArgb(48, 209, 88)
        };
        mainCard.Controls.Add(toggle2);

        var lblToggleState2 = new Label
        {
            Text = "Modo Turbo",
            Font = new Font("Segoe UI", 9.5f),
            ForeColor = Color.FromArgb(170, 170, 190),
            Location = new Point(295, 224),
            AutoSize = true
        };
        mainCard.Controls.Add(lblToggleState2);

        // Secao 3: Campos de Texto Modernos
        var lblInput = new Label
        {
            Text = "Campos de Entrada (Placeholder e Efeito Foco):",
            Font = new Font("Segoe UI Semibold", 10.5f, FontStyle.Bold),
            ForeColor = Color.FromArgb(200, 200, 220),
            Location = new Point(30, 280),
            AutoSize = true
        };
        mainCard.Controls.Add(lblInput);

        var txtUsername = new VzxTextBox
        {
            Location = new Point(30, 315),
            Size = new Size(320, 38),
            PlaceholderText = "Digite seu nome de usuario...",
            BorderRadius = 10,
            BorderFocusColor = Color.FromArgb(94, 92, 230)
        };
        mainCard.Controls.Add(txtUsername);

        var txtToken = new VzxTextBox
        {
            Location = new Point(370, 315),
            Size = new Size(320, 38),
            PlaceholderText = "Token de API ou chave privada...",
            BorderRadius = 10,
            BorderFocusColor = Color.FromArgb(48, 209, 88)
        };
        mainCard.Controls.Add(txtToken);

        // Card Interno de Status
        var innerCard = new VzxCard
        {
            Location = new Point(30, 380),
            Size = new Size(690, 80),
            BorderRadius = 12,
            BorderSize = 1,
            BorderColor = Color.FromArgb(60, 60, 80),
            BackColor = Color.FromArgb(32, 32, 45)
        };
        mainCard.Controls.Add(innerCard);

        var lblStatus = new Label
        {
            Text = "Pronto para integrar ao Visual Studio! Arraste os componentes ou use via codigo.",
            Font = new Font("Segoe UI", 10f, FontStyle.Italic),
            ForeColor = Color.FromArgb(160, 170, 220),
            Location = new Point(20, 25),
            AutoSize = true
        };
        innerCard.Controls.Add(lblStatus);
    }
}
