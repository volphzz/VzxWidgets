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

        AutoScaleMode = AutoScaleMode.None;
        ClientSize = new Size(1020, 720);
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

        // Menu Itens Container com scroll suave
        var pnlNav = new Panel
        {
            Dock = DockStyle.Fill,
            AutoScroll = true,
            Padding = new Padding(12, 6, 12, 6),
            BackColor = Color.Transparent
        };
        _sidebar.Controls.Add(pnlNav);

        int curY = 6;
        void AddCategory(string name)
        {
            var lblCat = new Label
            {
                Text = $"~  {name}",
                Font = new Font("Segoe UI Semibold", 8.5f, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 168, 255),
                Location = new Point(14, curY),
                Size = new Size(200, 22),
                TextAlign = ContentAlignment.MiddleLeft
            };
            pnlNav.Controls.Add(lblCat);
            curY += 26;
        }

        void AddItem(string text, bool active)
        {
            var pnlItem = new Panel
            {
                Location = new Point(12, curY),
                Size = new Size(206, 32),
                BackColor = active ? Color.FromArgb(20, 26, 40) : Color.Transparent,
                Cursor = Cursors.Hand
            };

            pnlItem.Paint += (s, e) =>
            {
                var g = e.Graphics;
                GraphicsHelper.ApplyHighQuality(g);

                if (active)
                {
                    using var path = GraphicsHelper.GetRoundedRectangle(new RectangleF(0, 0, pnlItem.Width - 1, pnlItem.Height - 1), 6);
                    using var pen = new Pen(Color.FromArgb(0, 168, 255), 1f);
                    g.DrawPath(pen, path);

                    // Indicador circular à direita
                    using var brushDot = new SolidBrush(Color.FromArgb(0, 168, 255));
                    g.FillEllipse(brushDot, pnlItem.Width - 18, 12, 7, 7);
                }

                Color textCol = active ? Color.FromArgb(0, 168, 255) : Color.FromArgb(160, 165, 185);
                using var font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold);
                TextRenderer.DrawText(g, text, font, new Point(14, 7), textCol);
            };

            pnlNav.Controls.Add(pnlItem);
            curY += 36;
        }

        AddCategory("Jogador");
        AddItem("Você", false);
        AddItem("Jogadores", true);

        AddCategory("Veículo");
        AddItem("Atual", false);
        AddItem("Veículos", false);

        AddCategory("Combate");
        AddItem("Mira", false);
        AddItem("Armas", false);

        AddCategory("Outros");
        AddItem("Diversos", false);
        AddItem("Recursos (141)", false);
        AddItem("Statebags (217)", false);
        AddItem("Lua Executor", false);

        // 2. Área Principal
        var mainArea = new Panel
        {
            Dock = DockStyle.Fill,
            BackColor = Color.FromArgb(12, 13, 18)
        };
        Controls.Add(mainArea);
        mainArea.BringToFront();

        // 3. TopBar
        _topBar = new Panel
        {
            Dock = DockStyle.Top,
            Height = 50,
            BackColor = Color.FromArgb(12, 13, 18)
        };
        mainArea.Controls.Add(_topBar);

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

        // Breadcrumb
        _topBar.Paint += (s, e) =>
        {
            var g = e.Graphics;
            GraphicsHelper.ApplyHighQuality(g);

            using var fontGray = new Font("Segoe UI Semibold", 9.5f, FontStyle.Bold);
            using var fontBlue = new Font("Segoe UI Semibold", 9.5f, FontStyle.Bold);
            TextRenderer.DrawText(g, "Navegando por", fontGray, new Point(16, 15), Color.FromArgb(160, 165, 185));
            TextRenderer.DrawText(g, "Jogadores", fontBlue, new Point(122, 15), Color.FromArgb(0, 168, 255));
        };

        // Pesquisar Global
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

        _formDrag = new VzxFormDrag(components ?? new System.ComponentModel.Container())
        {
            TargetControl = _topBar,
            TargetForm = this
        };
        _formDrag.AddDragControl(pnlLogo);

        // 4. Painel de Conteúdo
        _content = new Panel
        {
            Dock = DockStyle.Fill,
            AutoScroll = true,
            Padding = new Padding(16, 10, 16, 16),
            BackColor = Color.FromArgb(12, 13, 18)
        };
        mainArea.Controls.Add(_content);
        _content.BringToFront();

        // 5. Linha de Busca de Peds
        BuildSearchRow(_content);

        // 6. Player Card Selecionado (Stuart black 021)
        BuildPlayerCardRow(_content);

        // 7. Grade de Ações Rápidas (4x2 botões)
        BuildActionGrid(_content);

        // 8. Header Wallhack Neon
        BuildWallhackHeader(_content);

        // 9. Linhas Modulares Wallhack
        BuildWallhackRows(_content);
    }

    private void BuildSearchRow(Panel container)
    {
        var pnl = new Panel
        {
            Location = new Point(16, 10),
            Size = new Size(container.Width - 32, 34),
            Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
        };

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
        var card = new Panel
        {
            Location = new Point(16, 52),
            Size = new Size(container.Width - 32, 42),
            Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
            BackColor = Color.FromArgb(18, 24, 38)
        };

        card.Paint += (s, e) =>
        {
            var g = e.Graphics;
            GraphicsHelper.ApplyHighQuality(g);

            var rectBorder = new RectangleF(0, 0, card.Width - 1, card.Height - 1);
            using var path = GraphicsHelper.GetRoundedRectangle(rectBorder, 6);
            using var brushBg = new SolidBrush(card.BackColor);
            using var penBorder = new Pen(Color.FromArgb(0, 140, 220), 1.2f);

            g.FillPath(brushBg, path);
            g.DrawPath(penBorder, path);

            // Marcador rosa estilizado à esquerda
            using var brushPink = new SolidBrush(Color.FromArgb(235, 87, 140));
            g.FillRectangle(brushPink, 14, 11, 5, 20);

            // Ícone mouse / teclado
            using var fontIcon = new Font("Segoe UI", 8f);
            TextRenderer.DrawText(g, "⌨", fontIcon, new Point(24, 12), Color.FromArgb(180, 190, 210));

            // Nome e Distância
            using var font = new Font("Segoe UI Semibold", 9.5f, FontStyle.Bold);
            TextRenderer.DrawText(g, "Stuart black 021 em ~246.188 metros.", font, new Point(44, 11), Color.White);

            // Símbolo masculino azul
            using var fontSymbol = new Font("Segoe UI", 12f, FontStyle.Bold);
            TextRenderer.DrawText(g, "♂", fontSymbol, new Point(card.Width - 32, 8), Color.FromArgb(0, 168, 255));
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

            var btn = new Button
            {
                Text = actions[i],
                Location = new Point(x, y),
                Size = new Size(btnW, btnH),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(18, 19, 26),
                ForeColor = Color.FromArgb(200, 205, 220),
                Font = new Font("Segoe UI Semibold", 8f, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btn.FlatAppearance.BorderColor = Color.FromArgb(32, 34, 46);
            btn.FlatAppearance.BorderSize = 1;
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(26, 28, 40);

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
