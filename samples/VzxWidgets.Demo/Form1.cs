using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using VzxWidgets.Controls;
using VzxWidgets.Helpers;

namespace VzxWidgets.Demo;

public partial class Form1 : VzxForm
{
    private VzxFormDrag _formDrag = null!;
    private Panel _sidebar = null!;
    private Panel _topBar = null!;
    private Panel _content = null!;

    public Form1()
    {
        InitializeComponent();

        Size = new Size(980, 710);
        StartPosition = FormStartPosition.CenterScreen;
        BackColor = Color.FromArgb(10, 11, 15);
        BorderRadius = 14;
        BorderSize = 1;
        BorderColor = Color.FromArgb(28, 30, 42);
        HasDropShadow = true;

        BuildFiveSharpUi();
    }

    private void BuildFiveSharpUi()
    {
        Controls.Clear();

        // 1. Sidebar à Esquerda (240px)
        _sidebar = new Panel
        {
            Dock = DockStyle.Left,
            Width = 240,
            BackColor = Color.FromArgb(10, 12, 17)
        };
        Controls.Add(_sidebar);

        // Logo FIVESHARP no topo da sidebar
        var pnlLogo = new Panel { Dock = DockStyle.Top, Height = 70, BackColor = Color.Transparent };
        pnlLogo.Paint += (s, e) =>
        {
            var g = e.Graphics;
            GraphicsHelper.ApplyHighQuality(g);

            using var fontLogo = new Font("Segoe UI Black", 16f, FontStyle.Bold);
            TextRenderer.DrawText(g, "FIVE", fontLogo, new Point(24, 20), Color.FromArgb(0, 168, 255));
            TextRenderer.DrawText(g, "SHARP", fontLogo, new Point(78, 20), Color.White);

            // Badge v3.8.6
            var rectVer = new RectangleF(160, 24, 46, 16);
            using var pathVer = GraphicsHelper.GetRoundedRectangle(rectVer, 4);
            using var penVer = new Pen(Color.FromArgb(0, 168, 255), 1f);
            g.DrawPath(penVer, pathVer);
            using var fontVer = new Font("Segoe UI Semibold", 7f, FontStyle.Bold);
            TextRenderer.DrawText(g, "v3.8.6", fontVer, Rectangle.Round(rectVer), Color.FromArgb(0, 168, 255),
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        };
        _sidebar.Controls.Add(pnlLogo);

        // Card de Perfil de Usuário no Rodapé da Sidebar
        var profileBadge = new VzxProfileBadge
        {
            Dock = DockStyle.Bottom,
            Height = 56,
            Username = "VOLPHX",
            BadgeText = "Lifetime",
            DaysText = "1000 dias",
            AccentColor = Color.FromArgb(0, 168, 255)
        };
        _sidebar.Controls.Add(profileBadge);

        // Menu Itens Container
        var pnlNav = new FlowLayoutPanel
        {
            Dock = DockStyle.Fill,
            FlowDirection = FlowDirection.TopDown,
            WrapContents = false,
            AutoScroll = false,
            Padding = new Padding(12, 6, 12, 6),
            BackColor = Color.Transparent
        };
        _sidebar.Controls.Add(pnlNav);

        AddSidebarCategory(pnlNav, "Jogador");
        AddSidebarItem(pnlNav, "Você", false);
        AddSidebarItem(pnlNav, "Jogadores", true); // Ativo com dot

        AddSidebarCategory(pnlNav, "Veículo");
        AddSidebarItem(pnlNav, "Atual", false);
        AddSidebarItem(pnlNav, "Veículos", false);

        AddSidebarCategory(pnlNav, "Combate");
        AddSidebarItem(pnlNav, "Mira", false);
        AddSidebarItem(pnlNav, "Armas", false);

        AddSidebarCategory(pnlNav, "Outros");
        AddSidebarItem(pnlNav, "Diversos", false);
        AddSidebarItem(pnlNav, "Recursos (141)", false);
        AddSidebarItem(pnlNav, "Statebags (217)", false);
        AddSidebarItem(pnlNav, "Lua Executor", false);

        // 2. Área Principal de Conteúdo
        var mainArea = new Panel
        {
            Dock = DockStyle.Fill,
            BackColor = Color.FromArgb(12, 13, 18)
        };
        Controls.Add(mainArea);
        mainArea.BringToFront();

        // 3. TopBar no Topo da Área Principal
        _topBar = new Panel
        {
            Dock = DockStyle.Top,
            Height = 50,
            BackColor = Color.FromArgb(12, 13, 18)
        };
        mainArea.Controls.Add(_topBar);

        // Window Controls (Min, Close)
        var btnClose = new VzxControlBox
        {
            BoxType = ControlBoxType.Close,
            Location = new Point(_topBar.Width - 40, 12),
            Anchor = AnchorStyles.Top | AnchorStyles.Right,
            Size = new Size(32, 26)
        };
        var btnMin = new VzxControlBox
        {
            BoxType = ControlBoxType.Minimize,
            Location = new Point(_topBar.Width - 76, 12),
            Anchor = AnchorStyles.Top | AnchorStyles.Right,
            Size = new Size(32, 26)
        };
        _topBar.Controls.Add(btnClose);
        _topBar.Controls.Add(btnMin);

        // Breadcrumb "Navegando por Jogadores"
        var lblBreadcrumb = new Label
        {
            Text = "Navegando por  Jogadores",
            Font = new Font("Segoe UI Semibold", 9.5f, FontStyle.Bold),
            ForeColor = Color.FromArgb(160, 165, 185),
            Location = new Point(14, 15),
            AutoSize = true
        };
        _topBar.Paint += (s, e) =>
        {
            var g = e.Graphics;
            GraphicsHelper.ApplyHighQuality(g);
            using var brushBlue = new SolidBrush(Color.FromArgb(0, 168, 255));
            using var fontBlue = new Font("Segoe UI Semibold", 9.5f, FontStyle.Bold);
            TextRenderer.DrawText(g, "Jogadores", fontBlue, new Point(116, 15), Color.FromArgb(0, 168, 255));
        };
        _topBar.Controls.Add(lblBreadcrumb);

        // Campo de Pesquisa Global na TopBar
        var txtSearchTop = new VzxTextBox
        {
            PlaceholderText = "Pesquisar",
            Location = new Point(480, 10),
            Size = new Size(200, 30),
            BorderRadius = 6,
            BorderSize = 1,
            BorderColor = Color.FromArgb(28, 30, 42),
            BorderFocusColor = Color.FromArgb(0, 168, 255),
            BackColor = Color.FromArgb(16, 17, 24)
        };
        _topBar.Controls.Add(txtSearchTop);

        // VzxFormDrag configurado para mover a janela
        _formDrag = new VzxFormDrag(components ?? new System.ComponentModel.Container())
        {
            TargetControl = _topBar,
            TargetForm = this
        };
        _formDrag.AddDragControl(pnlLogo);

        // 4. Painel de Conteúdo (Scrollable / Flow)
        _content = new Panel
        {
            Dock = DockStyle.Fill,
            AutoScroll = true,
            Padding = new Padding(16, 10, 16, 16),
            BackColor = Color.FromArgb(12, 13, 18)
        };
        mainArea.Controls.Add(_content);
        _content.BringToFront();

        // Linha de Busca de Peds com Filtro
        BuildSearchRow(_content);

        // Lista de Jogadores (Player Card selecionado)
        BuildPlayerCardRow(_content);

        // Grade de Botões de Ações Rápidas (Copiar Roupas, Clonar Ped, etc.)
        BuildActionGrid(_content);

        // Separador com título Wallhack com os marcadores de círculo interligados
        BuildWallhackHeader(_content);

        // Tabela de Configurações do ESP / Wallhack (VzxFiveRow)
        BuildWallhackRows(_content);
    }

    private void AddSidebarCategory(FlowLayoutPanel panel, string name)
    {
        var lblCat = new Label
        {
            Text = $"~  {name}",
            Font = new Font("Segoe UI Semibold", 8.5f, FontStyle.Bold),
            ForeColor = Color.FromArgb(0, 168, 255),
            Size = new Size(216, 26),
            Margin = new Padding(0, 10, 0, 2),
            TextAlign = ContentAlignment.MiddleLeft
        };
        panel.Controls.Add(lblCat);
    }

    private void AddSidebarItem(FlowLayoutPanel panel, string text, bool active)
    {
        var btn = new VzxButton
        {
            Text = $"     {text}",
            Size = new Size(216, 32),
            Margin = new Padding(0, 2, 0, 2),
            BorderRadius = 6,
            BorderSize = 0,
            BackColor = active ? Color.FromArgb(20, 24, 36) : Color.Transparent,
            ForeColor = active ? Color.FromArgb(0, 168, 255) : Color.FromArgb(160, 165, 185),
            HoverColor = Color.FromArgb(24, 28, 42),
            ShowActiveIndicator = active,
            ActiveIndicatorColor = Color.FromArgb(0, 168, 255),
            Font = new Font("Segoe UI Semibold", 8.5f, FontStyle.Bold)
        };
        panel.Controls.Add(btn);
    }

    private void BuildSearchRow(Panel container)
    {
        var pnl = new Panel { Location = new Point(16, 10), Size = new Size(container.Width - 32, 34), Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right };
        
        var txtSearch = new VzxTextBox
        {
            PlaceholderText = "Pesquisar  st",
            Texts = "Pesquisar  st",
            Location = new Point(0, 0),
            Size = new Size(340, 32),
            BorderRadius = 6,
            BorderSize = 1,
            BorderColor = Color.FromArgb(28, 30, 42),
            BorderFocusColor = Color.FromArgb(0, 168, 255),
            BackColor = Color.FromArgb(16, 17, 24)
        };
        pnl.Controls.Add(txtSearch);

        var btnFilter = new VzxButton
        {
            Text = "≡ Filtros",
            Location = new Point(350, 0),
            Size = new Size(80, 32),
            BorderRadius = 6,
            BorderSize = 0,
            BackColor = Color.FromArgb(0, 168, 255),
            ForeColor = Color.FromArgb(10, 12, 17),
            HoverColor = Color.FromArgb(50, 190, 255),
            Font = new Font("Segoe UI Semibold", 8.5f, FontStyle.Bold)
        };
        pnl.Controls.Add(btnFilter);

        var lblCount = new Label
        {
            Text = "74 Peds ▲",
            ForeColor = Color.FromArgb(140, 145, 165),
            Font = new Font("Segoe UI Semibold", 8.5f, FontStyle.Bold),
            Location = new Point(pnl.Width - 90, 6),
            Anchor = AnchorStyles.Top | AnchorStyles.Right,
            AutoSize = true
        };
        pnl.Controls.Add(lblCount);

        container.Controls.Add(pnl);
    }

    private void BuildPlayerCardRow(Panel container)
    {
        var card = new VzxCard
        {
            Location = new Point(16, 52),
            Size = new Size(container.Width - 32, 42),
            Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
            BorderRadius = 6,
            BorderSize = 1,
            BorderColor = Color.FromArgb(0, 140, 220),
            BackColor = Color.FromArgb(18, 24, 38)
        };

        card.Paint += (s, e) =>
        {
            var g = e.Graphics;
            GraphicsHelper.ApplyHighQuality(g);

            // Marcador rosa à esquerda
            using var brushPink = new SolidBrush(Color.FromArgb(235, 87, 140));
            g.FillRectangle(brushPink, 12, 12, 5, 18);

            // Nome e Distância
            using var font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold);
            TextRenderer.DrawText(g, "Stuart black 021 em ~246.188 metros.", font, new Point(28, 12), Color.White);

            // Símbolo masculino azul
            using var fontSymbol = new Font("Segoe UI", 11f, FontStyle.Bold);
            TextRenderer.DrawText(g, "♂", fontSymbol, new Point(card.Width - 30, 10), Color.FromArgb(0, 168, 255));
        };

        container.Controls.Add(card);
    }

    private void BuildActionGrid(Panel container)
    {
        string[] actions = new[]
        {
            "Copiar Roupas", "Clonar Ped", "Teleportar", "Espiar",
            "Fake H", "Virar Amigo", "Puxar jogador", "Explodir jogador"
        };

        int startY = 104;
        int btnW = (container.Width - 32 - (3 * 8)) / 4;
        int btnH = 34;

        for (int i = 0; i < actions.Length; i++)
        {
            int row = i / 4;
            int col = i % 4;
            int x = 16 + col * (btnW + 8);
            int y = startY + row * (btnH + 8);

            var btn = new VzxButton
            {
                Text = actions[i],
                Location = new Point(x, y),
                Size = new Size(btnW, btnH),
                BorderRadius = 6,
                BorderSize = 1,
                BorderColor = Color.FromArgb(32, 34, 46),
                BackColor = Color.FromArgb(18, 19, 26),
                ForeColor = Color.FromArgb(200, 205, 220),
                HoverColor = Color.FromArgb(28, 30, 42),
                Font = new Font("Segoe UI Semibold", 8f, FontStyle.Bold)
            };
            container.Controls.Add(btn);
        }
    }

    private void BuildWallhackHeader(Panel container)
    {
        int y = 196;
        var pnl = new Panel
        {
            Location = new Point(16, y),
            Size = new Size(container.Width - 32, 28),
            Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
            BackColor = Color.Transparent
        };

        pnl.Paint += (s, e) =>
        {
            var g = e.Graphics;
            GraphicsHelper.ApplyHighQuality(g);

            float cx = pnl.Width / 2f;
            using var penLine = new Pen(Color.FromArgb(0, 168, 255), 1.2f);
            using var brushCircle = new SolidBrush(Color.FromArgb(0, 168, 255));

            // Linha e círculo esquerda
            g.DrawLine(penLine, 20, 14, cx - 60, 14);
            g.FillEllipse(brushCircle, cx - 64, 11, 6, 6);

            // Título Wallhack
            using var font = new Font("Segoe UI Semibold", 9.5f, FontStyle.Bold);
            TextRenderer.DrawText(g, "Wallhack", font, new Rectangle((int)cx - 50, 0, 100, 28), Color.FromArgb(0, 168, 255),
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

            // Círculo e linha direita
            g.FillEllipse(brushCircle, cx + 58, 11, 6, 6);
            g.DrawLine(penLine, cx + 64, 14, pnl.Width - 20, 14);
        };

        container.Controls.Add(pnl);
    }

    private void BuildWallhackRows(Panel container)
    {
        int startY = 230;

        var rowEsqueleto = new VzxFiveRow
        {
            Title = "  Esqueleto",
            OptionLabel = "Tipo de Esqueleto",
            Options = new[] { "Simples", "Complexo" },
            Checked = true,
            ColorSlots = new[] { Color.White, Color.White, Color.White },
            Location = new Point(16, startY),
            Size = new Size(container.Width - 32, 44),
            Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
        };
        container.Controls.Add(rowEsqueleto);

        var rowBarra = new VzxFiveRow
        {
            Title = "  Barra de Vida",
            OptionLabel = "Tipo da Barra",
            Options = new[] { "Horizontal", "Vertical" },
            Checked = true,
            ColorSlots = new[] { Color.White, Color.FromArgb(0, 230, 80) },
            Location = new Point(16, startY + 50),
            Size = new Size(container.Width - 32, 44),
            Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
        };
        container.Controls.Add(rowBarra);

        var rowCabeca = new VzxFiveRow
        {
            Title = "  Cabeça",
            OptionLabel = "Tipo da Cabeça",
            Options = new[] { "Círculo", "Letra X" },
            Checked = true,
            ColorSlots = new[] { Color.FromArgb(255, 40, 40), Color.White, Color.White },
            Location = new Point(16, startY + 100),
            Size = new Size(container.Width - 32, 44),
            Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
        };
        container.Controls.Add(rowCabeca);

        var rowTexto = new VzxFiveRow
        {
            Title = "  Texto",
            OptionLabel = "Tipo",
            Options = new[] { "Nome & Distância", "+ Voz" },
            Checked = true,
            ColorSlots = new[] { Color.White },
            Location = new Point(16, startY + 150),
            Size = new Size(container.Width - 32, 44),
            Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
        };
        container.Controls.Add(rowTexto);

        var rowFundo = new VzxFiveRow
        {
            Title = "  Fundo",
            OptionLabel = "Tipo do Fundo",
            Options = new[] { "Padrão", "Arredondado" },
            Checked = true,
            ColorSlots = new[] { Color.White, Color.FromArgb(20, 20, 30) },
            Location = new Point(16, startY + 200),
            Size = new Size(container.Width - 32, 44),
            Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
        };
        container.Controls.Add(rowFundo);
    }
}
