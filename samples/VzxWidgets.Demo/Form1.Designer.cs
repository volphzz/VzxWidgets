namespace VzxWidgets.Demo;

partial class Form1 : VzxWidgets.Controls.VzxForm
{
    private System.ComponentModel.IContainer components = null;

    // TopBar & Window Controls
    private VzxWidgets.Controls.VzxFormDrag formDrag;
    private System.Windows.Forms.Panel topBar;
    private System.Windows.Forms.Label lblTitle;
    private VzxWidgets.Controls.VzxControlBox btnClose;
    private VzxWidgets.Controls.VzxControlBox btnMin;

    // Main Layout Cards
    private VzxWidgets.Controls.VzxCard cardFuncoes;
    private VzxWidgets.Controls.VzxCard cardVisual;
    private VzxWidgets.Controls.VzxCard cardEspPreview;
    private VzxWidgets.Controls.VzxCard cardOutros;
    private VzxWidgets.Controls.VzxCard cardInfo;

    // Funções
    private VzxWidgets.Controls.VzxDotHeader hdrFuncoes;
    private VzxWidgets.Controls.VzxCheckBox chkAimbot;
    private VzxWidgets.Controls.VzxCheckBox chkSilent;

    // Visual
    private VzxWidgets.Controls.VzxDotHeader hdrVisual;
    private VzxWidgets.Controls.VzxCheckBox chkEspBox;
    private VzxWidgets.Controls.VzxColorButton colEspBox;
    private VzxWidgets.Controls.VzxCheckBox chkEspFill;
    private VzxWidgets.Controls.VzxColorButton colEspFill;
    private VzxWidgets.Controls.VzxCheckBox chkEspLine;
    private VzxWidgets.Controls.VzxColorButton colEspLine;
    private VzxWidgets.Controls.VzxComboBox cmbEspPos;
    private VzxWidgets.Controls.VzxCheckBox chkEspName;
    private VzxWidgets.Controls.VzxColorButton colEspName;
    private VzxWidgets.Controls.VzxCheckBox chkEspHealth;
    private VzxWidgets.Controls.VzxCheckBox chkEspSkeleton;
    private VzxWidgets.Controls.VzxColorButton colEspSkeleton;
    private System.Windows.Forms.Label lblMaxDist;
    private System.Windows.Forms.Label lblMaxDistVal;
    private VzxWidgets.Controls.VzxTrackBar trackMaxDist;

    // Outros
    private VzxWidgets.Controls.VzxDotHeader hdrOutros;
    private VzxWidgets.Controls.VzxCheckBox chkConectado;
    private System.Windows.Forms.Label lblOpenMenu;
    private VzxWidgets.Controls.VzxKeybind keyOpenMenu;

    // Informação
    private VzxWidgets.Controls.VzxDotHeader hdrInfo;
    private System.Windows.Forms.Label lblAdb;
    private System.Windows.Forms.Label lblAdbVal;
    private System.Windows.Forms.Label lblStatus;
    private System.Windows.Forms.Label lblStatusVal;

    // ESP Preview Card
    private VzxWidgets.Controls.VzxDotHeader hdrEspPreview;
    private VzxWidgets.Controls.VzxProgressBar progHealth;
    private VzxWidgets.Controls.VzxEspPreview espPreview;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        formDrag = new VzxWidgets.Controls.VzxFormDrag(components);
        topBar = new Panel();
        lblTitle = new Label();
        btnMin = new VzxWidgets.Controls.VzxControlBox();
        btnClose = new VzxWidgets.Controls.VzxControlBox();
        cardFuncoes = new VzxWidgets.Controls.VzxCard();
        btnTestToasts = new VzxWidgets.Controls.VzxButton();
        hdrFuncoes = new VzxWidgets.Controls.VzxDotHeader();
        chkAimbot = new VzxWidgets.Controls.VzxCheckBox();
        chkSilent = new VzxWidgets.Controls.VzxCheckBox();
        cardVisual = new VzxWidgets.Controls.VzxCard();
        hdrVisual = new VzxWidgets.Controls.VzxDotHeader();
        chkEspBox = new VzxWidgets.Controls.VzxCheckBox();
        colEspBox = new VzxWidgets.Controls.VzxColorButton();
        chkEspFill = new VzxWidgets.Controls.VzxCheckBox();
        colEspFill = new VzxWidgets.Controls.VzxColorButton();
        chkEspLine = new VzxWidgets.Controls.VzxCheckBox();
        colEspLine = new VzxWidgets.Controls.VzxColorButton();
        cmbEspPos = new VzxWidgets.Controls.VzxComboBox();
        chkEspName = new VzxWidgets.Controls.VzxCheckBox();
        colEspName = new VzxWidgets.Controls.VzxColorButton();
        chkEspHealth = new VzxWidgets.Controls.VzxCheckBox();
        chkEspSkeleton = new VzxWidgets.Controls.VzxCheckBox();
        colEspSkeleton = new VzxWidgets.Controls.VzxColorButton();
        lblMaxDist = new Label();
        lblMaxDistVal = new Label();
        trackMaxDist = new VzxWidgets.Controls.VzxTrackBar();
        cardEspPreview = new VzxWidgets.Controls.VzxCard();
        hdrEspPreview = new VzxWidgets.Controls.VzxDotHeader();
        progHealth = new VzxWidgets.Controls.VzxProgressBar();
        espPreview = new VzxWidgets.Controls.VzxEspPreview();
        cardOutros = new VzxWidgets.Controls.VzxCard();
        hdrOutros = new VzxWidgets.Controls.VzxDotHeader();
        chkConectado = new VzxWidgets.Controls.VzxCheckBox();
        lblOpenMenu = new Label();
        keyOpenMenu = new VzxWidgets.Controls.VzxKeybind();
        cardInfo = new VzxWidgets.Controls.VzxCard();
        hdrInfo = new VzxWidgets.Controls.VzxDotHeader();
        lblAdb = new Label();
        lblAdbVal = new Label();
        lblStatus = new Label();
        lblStatusVal = new Label();
        vzxFormDrag1 = new VzxWidgets.Controls.VzxFormDrag(components);
        topBar.SuspendLayout();
        cardFuncoes.SuspendLayout();
        cardVisual.SuspendLayout();
        cardEspPreview.SuspendLayout();
        cardOutros.SuspendLayout();
        cardInfo.SuspendLayout();
        SuspendLayout();
        // 
        // formDrag
        // 
        formDrag.TargetControl = topBar;
        formDrag.TargetForm = null;
        // 
        // topBar
        // 
        topBar.BackColor = Color.FromArgb(10, 10, 14);
        topBar.Controls.Add(lblTitle);
        topBar.Controls.Add(btnMin);
        topBar.Controls.Add(btnClose);
        topBar.Dock = DockStyle.Top;
        topBar.Location = new Point(0, 0);
        topBar.Name = "topBar";
        topBar.Size = new Size(860, 44);
        topBar.TabIndex = 0;
        // 
        // lblTitle
        // 
        lblTitle.AutoSize = true;
        lblTitle.Font = new Font("Segoe UI", 11.5F, FontStyle.Bold);
        lblTitle.ForeColor = Color.FromArgb(235, 235, 245);
        lblTitle.Location = new Point(18, 11);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(64, 21);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "Volphx";
        // 
        // btnMin
        // 
        btnMin.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnMin.BoxType = VzxWidgets.Controls.ControlBoxType.Minimize;
        btnMin.HoverColor = Color.FromArgb(50, 50, 65);
        btnMin.IconColor = Color.FromArgb(170, 170, 185);
        btnMin.Location = new Point(778, 9);
        btnMin.Name = "btnMin";
        btnMin.Size = new Size(32, 26);
        btnMin.TabIndex = 1;
        // 
        // btnClose
        // 
        btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnClose.HoverColor = Color.FromArgb(255, 60, 50);
        btnClose.IconColor = Color.FromArgb(170, 170, 185);
        btnClose.Location = new Point(816, 9);
        btnClose.Name = "btnClose";
        btnClose.Size = new Size(32, 26);
        btnClose.TabIndex = 2;
        // 
        // cardFuncoes
        // 
        cardFuncoes.BackColor = Color.FromArgb(14, 14, 18);
        cardFuncoes.BorderColor = Color.FromArgb(28, 28, 36);
        cardFuncoes.BorderRadius = 12;
        cardFuncoes.Controls.Add(btnTestToasts);
        cardFuncoes.Controls.Add(hdrFuncoes);
        cardFuncoes.Controls.Add(chkAimbot);
        cardFuncoes.Controls.Add(chkSilent);
        cardFuncoes.Location = new Point(18, 56);
        cardFuncoes.Name = "cardFuncoes";
        cardFuncoes.Padding = new Padding(14);
        cardFuncoes.Size = new Size(250, 310);
        cardFuncoes.TabIndex = 1;
        // 
        // btnTestToasts
        // 
        btnTestToasts.BackColor = Color.FromArgb(140, 70, 240);
        btnTestToasts.BorderColor = Color.FromArgb(170, 100, 255);
        btnTestToasts.BorderRadius = 8;
        btnTestToasts.BorderSize = 1;
        btnTestToasts.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
        btnTestToasts.ForeColor = Color.White;
        btnTestToasts.GradientEndColor = Color.FromArgb(90, 40, 180);
        btnTestToasts.HoverColor = Color.FromArgb(160, 90, 255);
        btnTestToasts.Location = new Point(16, 140);
        btnTestToasts.Name = "btnTestToasts";
        btnTestToasts.PressedColor = Color.FromArgb(120, 50, 220);
        btnTestToasts.Size = new Size(218, 36);
        btnTestToasts.TabIndex = 3;
        btnTestToasts.Text = "🔔 Disparar Toasts (Stack)";
        btnTestToasts.UseGradient = true;
        // 
        // hdrFuncoes
        // 
        hdrFuncoes.DotColor = Color.FromArgb(155, 80, 255);
        hdrFuncoes.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
        hdrFuncoes.Location = new Point(14, 14);
        hdrFuncoes.Name = "hdrFuncoes";
        hdrFuncoes.Size = new Size(120, 24);
        hdrFuncoes.TabIndex = 0;
        hdrFuncoes.Text = "Funções";
        // 
        // chkAimbot
        // 
        chkAimbot.AutoSize = false;
        chkAimbot.BoxBorderColor = Color.FromArgb(70, 70, 88);
        chkAimbot.Checked = true;
        chkAimbot.CheckedColor = Color.FromArgb(155, 80, 255);
        chkAimbot.CheckState = CheckState.Checked;
        chkAimbot.Font = new Font("Segoe UI", 9.5F);
        chkAimbot.ForeColor = Color.FromArgb(220, 220, 230);
        chkAimbot.Location = new Point(16, 52);
        chkAimbot.Name = "chkAimbot";
        chkAimbot.Size = new Size(200, 22);
        chkAimbot.TabIndex = 1;
        chkAimbot.Text = "Aimbot";
        chkAimbot.UncheckedColor = Color.FromArgb(45, 45, 58);
        // 
        // chkSilent
        // 
        chkSilent.AutoSize = false;
        chkSilent.BoxBorderColor = Color.FromArgb(70, 70, 88);
        chkSilent.CheckedColor = Color.FromArgb(155, 80, 255);
        chkSilent.Font = new Font("Segoe UI", 9.5F);
        chkSilent.ForeColor = Color.FromArgb(220, 220, 230);
        chkSilent.Location = new Point(16, 88);
        chkSilent.Name = "chkSilent";
        chkSilent.Size = new Size(200, 22);
        chkSilent.TabIndex = 2;
        chkSilent.Text = "Silent Aim";
        chkSilent.UncheckedColor = Color.FromArgb(45, 45, 58);
        // 
        // cardVisual
        // 
        cardVisual.BackColor = Color.FromArgb(14, 14, 18);
        cardVisual.BorderColor = Color.FromArgb(28, 28, 36);
        cardVisual.BorderRadius = 12;
        cardVisual.Controls.Add(hdrVisual);
        cardVisual.Controls.Add(chkEspBox);
        cardVisual.Controls.Add(colEspBox);
        cardVisual.Controls.Add(chkEspFill);
        cardVisual.Controls.Add(colEspFill);
        cardVisual.Controls.Add(chkEspLine);
        cardVisual.Controls.Add(colEspLine);
        cardVisual.Controls.Add(cmbEspPos);
        cardVisual.Controls.Add(chkEspName);
        cardVisual.Controls.Add(colEspName);
        cardVisual.Controls.Add(chkEspHealth);
        cardVisual.Controls.Add(chkEspSkeleton);
        cardVisual.Controls.Add(colEspSkeleton);
        cardVisual.Controls.Add(lblMaxDist);
        cardVisual.Controls.Add(lblMaxDistVal);
        cardVisual.Controls.Add(trackMaxDist);
        cardVisual.Location = new Point(282, 56);
        cardVisual.Name = "cardVisual";
        cardVisual.Padding = new Padding(14);
        cardVisual.Size = new Size(270, 370);
        cardVisual.TabIndex = 2;
        // 
        // hdrVisual
        // 
        hdrVisual.DotColor = Color.FromArgb(155, 80, 255);
        hdrVisual.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
        hdrVisual.Location = new Point(14, 14);
        hdrVisual.Name = "hdrVisual";
        hdrVisual.Size = new Size(120, 24);
        hdrVisual.TabIndex = 0;
        hdrVisual.Text = "Visual";
        // 
        // chkEspBox
        // 
        chkEspBox.AutoSize = false;
        chkEspBox.BoxBorderColor = Color.FromArgb(70, 70, 88);
        chkEspBox.Checked = true;
        chkEspBox.CheckedColor = Color.FromArgb(155, 80, 255);
        chkEspBox.CheckState = CheckState.Checked;
        chkEspBox.Font = new Font("Segoe UI", 9.5F);
        chkEspBox.ForeColor = Color.FromArgb(220, 220, 230);
        chkEspBox.Location = new Point(16, 48);
        chkEspBox.Name = "chkEspBox";
        chkEspBox.Size = new Size(190, 22);
        chkEspBox.TabIndex = 1;
        chkEspBox.Text = "ESP Box";
        chkEspBox.UncheckedColor = Color.FromArgb(45, 45, 58);
        chkEspBox.CheckedChanged += chkEspBox_CheckedChanged;
        // 
        // colEspBox
        // 
        colEspBox.Location = new Point(232, 50);
        colEspBox.Name = "colEspBox";
        colEspBox.SelectedColor = Color.White;
        colEspBox.Size = new Size(18, 14);
        colEspBox.TabIndex = 2;
        // 
        // chkEspFill
        // 
        chkEspFill.AutoSize = false;
        chkEspFill.BoxBorderColor = Color.FromArgb(70, 70, 88);
        chkEspFill.Checked = true;
        chkEspFill.CheckedColor = Color.FromArgb(155, 80, 255);
        chkEspFill.CheckState = CheckState.Checked;
        chkEspFill.Font = new Font("Segoe UI", 9.5F);
        chkEspFill.ForeColor = Color.FromArgb(220, 220, 230);
        chkEspFill.Location = new Point(16, 78);
        chkEspFill.Name = "chkEspFill";
        chkEspFill.Size = new Size(190, 22);
        chkEspFill.TabIndex = 3;
        chkEspFill.Text = "ESP Fillbox";
        chkEspFill.UncheckedColor = Color.FromArgb(45, 45, 58);
        // 
        // colEspFill
        // 
        colEspFill.Location = new Point(232, 80);
        colEspFill.Name = "colEspFill";
        colEspFill.SelectedColor = Color.White;
        colEspFill.Size = new Size(18, 14);
        colEspFill.TabIndex = 4;
        // 
        // chkEspLine
        // 
        chkEspLine.AutoSize = false;
        chkEspLine.BoxBorderColor = Color.FromArgb(70, 70, 88);
        chkEspLine.Checked = true;
        chkEspLine.CheckedColor = Color.FromArgb(155, 80, 255);
        chkEspLine.CheckState = CheckState.Checked;
        chkEspLine.Font = new Font("Segoe UI", 9.5F);
        chkEspLine.ForeColor = Color.FromArgb(220, 220, 230);
        chkEspLine.Location = new Point(16, 108);
        chkEspLine.Name = "chkEspLine";
        chkEspLine.Size = new Size(190, 22);
        chkEspLine.TabIndex = 5;
        chkEspLine.Text = "ESP Line";
        chkEspLine.UncheckedColor = Color.FromArgb(45, 45, 58);
        // 
        // colEspLine
        // 
        colEspLine.Location = new Point(232, 110);
        colEspLine.Name = "colEspLine";
        colEspLine.SelectedColor = Color.White;
        colEspLine.Size = new Size(18, 14);
        colEspLine.TabIndex = 6;
        // 
        // cmbEspPos
        // 
        cmbEspPos.ArrowColor = Color.FromArgb(155, 80, 255);
        cmbEspPos.BorderColor = Color.FromArgb(36, 36, 48);
        cmbEspPos.BorderFocusColor = Color.FromArgb(155, 80, 255);
        cmbEspPos.Font = new Font("Segoe UI", 9.5F);
        cmbEspPos.ForeColor = Color.FromArgb(230, 230, 240);
        cmbEspPos.Location = new Point(16, 138);
        cmbEspPos.Name = "cmbEspPos";
        cmbEspPos.Size = new Size(234, 30);
        cmbEspPos.TabIndex = 7;
        // 
        // chkEspName
        // 
        chkEspName.AutoSize = false;
        chkEspName.BoxBorderColor = Color.FromArgb(70, 70, 88);
        chkEspName.Checked = true;
        chkEspName.CheckedColor = Color.FromArgb(155, 80, 255);
        chkEspName.CheckState = CheckState.Checked;
        chkEspName.Font = new Font("Segoe UI", 9.5F);
        chkEspName.ForeColor = Color.FromArgb(220, 220, 230);
        chkEspName.Location = new Point(16, 180);
        chkEspName.Name = "chkEspName";
        chkEspName.Size = new Size(190, 22);
        chkEspName.TabIndex = 8;
        chkEspName.Text = "ESP Name";
        chkEspName.UncheckedColor = Color.FromArgb(45, 45, 58);
        // 
        // colEspName
        // 
        colEspName.Location = new Point(232, 182);
        colEspName.Name = "colEspName";
        colEspName.SelectedColor = Color.White;
        colEspName.Size = new Size(18, 14);
        colEspName.TabIndex = 9;
        // 
        // chkEspHealth
        // 
        chkEspHealth.AutoSize = false;
        chkEspHealth.BoxBorderColor = Color.FromArgb(70, 70, 88);
        chkEspHealth.Checked = true;
        chkEspHealth.CheckedColor = Color.FromArgb(155, 80, 255);
        chkEspHealth.CheckState = CheckState.Checked;
        chkEspHealth.Font = new Font("Segoe UI", 9.5F);
        chkEspHealth.ForeColor = Color.FromArgb(220, 220, 230);
        chkEspHealth.Location = new Point(16, 210);
        chkEspHealth.Name = "chkEspHealth";
        chkEspHealth.Size = new Size(190, 22);
        chkEspHealth.TabIndex = 10;
        chkEspHealth.Text = "ESP Health";
        chkEspHealth.UncheckedColor = Color.FromArgb(45, 45, 58);
        // 
        // chkEspSkeleton
        // 
        chkEspSkeleton.AutoSize = false;
        chkEspSkeleton.BoxBorderColor = Color.FromArgb(70, 70, 88);
        chkEspSkeleton.Checked = true;
        chkEspSkeleton.CheckedColor = Color.FromArgb(155, 80, 255);
        chkEspSkeleton.CheckState = CheckState.Checked;
        chkEspSkeleton.Font = new Font("Segoe UI", 9.5F);
        chkEspSkeleton.ForeColor = Color.FromArgb(220, 220, 230);
        chkEspSkeleton.Location = new Point(16, 240);
        chkEspSkeleton.Name = "chkEspSkeleton";
        chkEspSkeleton.Size = new Size(190, 22);
        chkEspSkeleton.TabIndex = 11;
        chkEspSkeleton.Text = "ESP Skeleton";
        chkEspSkeleton.UncheckedColor = Color.FromArgb(45, 45, 58);
        // 
        // colEspSkeleton
        // 
        colEspSkeleton.Location = new Point(232, 242);
        colEspSkeleton.Name = "colEspSkeleton";
        colEspSkeleton.SelectedColor = Color.White;
        colEspSkeleton.Size = new Size(18, 14);
        colEspSkeleton.TabIndex = 12;
        // 
        // lblMaxDist
        // 
        lblMaxDist.AutoSize = true;
        lblMaxDist.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        lblMaxDist.ForeColor = Color.FromArgb(210, 210, 225);
        lblMaxDist.Location = new Point(16, 280);
        lblMaxDist.Name = "lblMaxDist";
        lblMaxDist.Size = new Size(82, 15);
        lblMaxDist.TabIndex = 13;
        lblMaxDist.Text = "Max Distance";
        // 
        // lblMaxDistVal
        // 
        lblMaxDistVal.Font = new Font("Segoe UI", 8.5F);
        lblMaxDistVal.ForeColor = Color.FromArgb(160, 160, 180);
        lblMaxDistVal.Location = new Point(160, 280);
        lblMaxDistVal.Name = "lblMaxDistVal";
        lblMaxDistVal.Size = new Size(90, 15);
        lblMaxDistVal.TabIndex = 14;
        lblMaxDistVal.Text = "50m";
        lblMaxDistVal.TextAlign = ContentAlignment.TopRight;
        // 
        // trackMaxDist
        // 
        trackMaxDist.Location = new Point(16, 302);
        trackMaxDist.Maximum = 200;
        trackMaxDist.Name = "trackMaxDist";
        trackMaxDist.ProgressColor = Color.FromArgb(155, 80, 255);
        trackMaxDist.ShowDiamondThumb = false;
        trackMaxDist.Size = new Size(234, 20);
        trackMaxDist.TabIndex = 15;
        trackMaxDist.ThumbColor = Color.White;
        trackMaxDist.TrackColor = Color.FromArgb(40, 40, 52);
        trackMaxDist.ValueChanged += trackMaxDist_ValueChanged;
        // 
        // cardEspPreview
        // 
        cardEspPreview.BackColor = Color.FromArgb(14, 14, 18);
        cardEspPreview.BorderColor = Color.FromArgb(28, 28, 36);
        cardEspPreview.BorderRadius = 12;
        
        
        cardEspPreview.Controls.Add(espPreview);
        cardEspPreview.Location = new Point(568, 56);
        cardEspPreview.Name = "cardEspPreview";
        cardEspPreview.Padding = new Padding(14);
        cardEspPreview.Size = new Size(274, 479);
        cardEspPreview.TabIndex = 5;
        // 
        // hdrEspPreview
        // 
        hdrEspPreview.DotColor = Color.FromArgb(155, 80, 255);
        hdrEspPreview.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
        hdrEspPreview.Location = new Point(14, 14);
        hdrEspPreview.Name = "hdrEspPreview";
        hdrEspPreview.Size = new Size(120, 24);
        hdrEspPreview.TabIndex = 0;
        hdrEspPreview.Text = "ESP Preview";
        // 
        // progHealth
        // 
        progHealth.BorderRadius = 4;
        progHealth.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
        progHealth.ForeColor = Color.White;
        progHealth.GradientEndColor = Color.FromArgb(48, 209, 88);
        progHealth.GradientStartColor = Color.FromArgb(48, 209, 88);
        progHealth.Location = new Point(36, 44);
        progHealth.Name = "progHealth";
        progHealth.ShowPercentage = false;
        progHealth.Size = new Size(202, 6);
        progHealth.TabIndex = 1;
        progHealth.TrackColor = Color.FromArgb(35, 35, 48);
        progHealth.Value = 85;
        // 
        // espPreview
        // 
        espPreview.Dock = System.Windows.Forms.DockStyle.Fill;
        espPreview.Location = new Point(14, 14);
        espPreview.Name = "espPreview";
        espPreview.Size = new Size(246, 451);
        espPreview.TabIndex = 0;
        espPreview.ShowFillBox = true;
        espPreview.ShowSkeleton = true;
        espPreview.AnimatedPreview = true;
        // 
        // cardOutros
        // 
        cardOutros.BackColor = Color.FromArgb(14, 14, 18);
        cardOutros.BorderColor = Color.FromArgb(28, 28, 36);
        cardOutros.BorderRadius = 12;
        cardOutros.Controls.Add(hdrOutros);
        cardOutros.Controls.Add(chkConectado);
        cardOutros.Controls.Add(lblOpenMenu);
        cardOutros.Controls.Add(keyOpenMenu);
        cardOutros.Location = new Point(18, 380);
        cardOutros.Name = "cardOutros";
        cardOutros.Padding = new Padding(14);
        cardOutros.Size = new Size(250, 155);
        cardOutros.TabIndex = 3;
        // 
        // hdrOutros
        // 
        hdrOutros.DotColor = Color.FromArgb(155, 80, 255);
        hdrOutros.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
        hdrOutros.Location = new Point(14, 12);
        hdrOutros.Name = "hdrOutros";
        hdrOutros.Size = new Size(120, 24);
        hdrOutros.TabIndex = 0;
        hdrOutros.Text = "Outros";
        // 
        // chkConectado
        // 
        chkConectado.AutoSize = false;
        chkConectado.BoxBorderColor = Color.FromArgb(70, 70, 88);
        chkConectado.Checked = true;
        chkConectado.CheckedColor = Color.FromArgb(155, 80, 255);
        chkConectado.CheckState = CheckState.Checked;
        chkConectado.Font = new Font("Segoe UI", 9.5F);
        chkConectado.ForeColor = Color.FromArgb(220, 220, 230);
        chkConectado.Location = new Point(16, 44);
        chkConectado.Name = "chkConectado";
        chkConectado.Size = new Size(200, 22);
        chkConectado.TabIndex = 1;
        chkConectado.Text = "Conectado";
        chkConectado.UncheckedColor = Color.FromArgb(45, 45, 58);
        // 
        // lblOpenMenu
        // 
        lblOpenMenu.AutoSize = true;
        lblOpenMenu.ForeColor = Color.FromArgb(160, 160, 180);
        lblOpenMenu.Location = new Point(16, 86);
        lblOpenMenu.Name = "lblOpenMenu";
        lblOpenMenu.Size = new Size(70, 15);
        lblOpenMenu.TabIndex = 2;
        lblOpenMenu.Text = "Open menu";
        // 
        // keyOpenMenu
        // 
        keyOpenMenu.CurrentKey = Keys.Insert;
        keyOpenMenu.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
        keyOpenMenu.ForeColor = Color.FromArgb(220, 220, 235);
        keyOpenMenu.Location = new Point(140, 80);
        keyOpenMenu.Name = "keyOpenMenu";
        keyOpenMenu.Size = new Size(86, 28);
        keyOpenMenu.TabIndex = 3;
        // 
        // cardInfo
        // 
        cardInfo.BackColor = Color.FromArgb(14, 14, 18);
        cardInfo.BorderColor = Color.FromArgb(28, 28, 36);
        cardInfo.BorderRadius = 12;
        cardInfo.Controls.Add(hdrInfo);
        cardInfo.Controls.Add(lblAdb);
        cardInfo.Controls.Add(lblAdbVal);
        cardInfo.Controls.Add(lblStatus);
        cardInfo.Controls.Add(lblStatusVal);
        cardInfo.Location = new Point(282, 436);
        cardInfo.Name = "cardInfo";
        cardInfo.Padding = new Padding(14);
        cardInfo.Size = new Size(270, 99);
        cardInfo.TabIndex = 4;
        // 
        // hdrInfo
        // 
        hdrInfo.DotColor = Color.FromArgb(155, 80, 255);
        hdrInfo.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
        hdrInfo.Location = new Point(14, 10);
        hdrInfo.Name = "hdrInfo";
        hdrInfo.Size = new Size(120, 24);
        hdrInfo.TabIndex = 0;
        hdrInfo.Text = "Informação";
        // 
        // lblAdb
        // 
        lblAdb.AutoSize = true;
        lblAdb.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
        lblAdb.ForeColor = Color.FromArgb(200, 200, 220);
        lblAdb.Location = new Point(26, 40);
        lblAdb.Name = "lblAdb";
        lblAdb.Size = new Size(32, 15);
        lblAdb.TabIndex = 1;
        lblAdb.Text = "Adb:";
        // 
        // lblAdbVal
        // 
        lblAdbVal.AutoSize = true;
        lblAdbVal.ForeColor = Color.FromArgb(140, 140, 160);
        lblAdbVal.Location = new Point(80, 40);
        lblAdbVal.Name = "lblAdbVal";
        lblAdbVal.Size = new Size(36, 15);
        lblAdbVal.TabIndex = 2;
        lblAdbVal.Text = "None";
        // 
        // lblStatus
        // 
        lblStatus.AutoSize = true;
        lblStatus.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
        lblStatus.ForeColor = Color.FromArgb(200, 200, 220);
        lblStatus.Location = new Point(26, 62);
        lblStatus.Name = "lblStatus";
        lblStatus.Size = new Size(43, 15);
        lblStatus.TabIndex = 3;
        lblStatus.Text = "Status:";
        // 
        // lblStatusVal
        // 
        lblStatusVal.AutoSize = true;
        lblStatusVal.ForeColor = Color.FromArgb(140, 140, 160);
        lblStatusVal.Location = new Point(80, 62);
        lblStatusVal.Name = "lblStatusVal";
        lblStatusVal.Size = new Size(36, 15);
        lblStatusVal.TabIndex = 4;
        lblStatusVal.Text = "None";
        // 
        // 
        // vzxFormDrag1
        // 
        vzxFormDrag1.TargetControl = null;
        vzxFormDrag1.TargetForm = null;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(8, 8, 10);
        ClientSize = new Size(860, 550);
        Controls.Add(cardEspPreview);
        Controls.Add(cardInfo);
        Controls.Add(cardOutros);
        Controls.Add(cardVisual);
        Controls.Add(cardFuncoes);
        Controls.Add(topBar);
        Name = "Form1";
        Text = "Volphx - VzxWidgets";
        topBar.ResumeLayout(false);
        topBar.PerformLayout();
        cardFuncoes.ResumeLayout(false);
        cardFuncoes.PerformLayout();
        cardVisual.ResumeLayout(false);
        cardVisual.PerformLayout();
        cardEspPreview.ResumeLayout(false);
        cardOutros.ResumeLayout(false);
        cardOutros.PerformLayout();
        cardInfo.ResumeLayout(false);
        cardInfo.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private Controls.VzxButton btnTestToasts;
    private Controls.VzxFormDrag vzxFormDrag1;
}
