namespace VzxWidgets.Demo;

partial class Form1
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
    private System.Windows.Forms.Panel pnlSkeletonView;

    // Floating Toasts (Notificações Flutuantes idênticas ao print)
    private VzxWidgets.Controls.VzxToast toastSuccess;
    private VzxWidgets.Controls.VzxToast toastInfo;

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
        this.components = new System.ComponentModel.Container();
        this.formDrag = new VzxWidgets.Controls.VzxFormDrag();

        // TopBar
        this.topBar = new System.Windows.Forms.Panel();
        this.lblTitle = new System.Windows.Forms.Label();
        this.btnClose = new VzxWidgets.Controls.VzxControlBox();
        this.btnMin = new VzxWidgets.Controls.VzxControlBox();

        // Cards
        this.cardFuncoes = new VzxWidgets.Controls.VzxCard();
        this.cardVisual = new VzxWidgets.Controls.VzxCard();
        this.cardEspPreview = new VzxWidgets.Controls.VzxCard();
        this.cardOutros = new VzxWidgets.Controls.VzxCard();
        this.cardInfo = new VzxWidgets.Controls.VzxCard();

        // Funções Controls
        this.hdrFuncoes = new VzxWidgets.Controls.VzxDotHeader();
        this.chkAimbot = new VzxWidgets.Controls.VzxCheckBox();
        this.chkSilent = new VzxWidgets.Controls.VzxCheckBox();

        // Visual Controls
        this.hdrVisual = new VzxWidgets.Controls.VzxDotHeader();
        this.chkEspBox = new VzxWidgets.Controls.VzxCheckBox();
        this.colEspBox = new VzxWidgets.Controls.VzxColorButton();
        this.chkEspFill = new VzxWidgets.Controls.VzxCheckBox();
        this.colEspFill = new VzxWidgets.Controls.VzxColorButton();
        this.chkEspLine = new VzxWidgets.Controls.VzxCheckBox();
        this.colEspLine = new VzxWidgets.Controls.VzxColorButton();
        this.cmbEspPos = new VzxWidgets.Controls.VzxComboBox();
        this.chkEspName = new VzxWidgets.Controls.VzxCheckBox();
        this.colEspName = new VzxWidgets.Controls.VzxColorButton();
        this.chkEspHealth = new VzxWidgets.Controls.VzxCheckBox();
        this.chkEspSkeleton = new VzxWidgets.Controls.VzxCheckBox();
        this.colEspSkeleton = new VzxWidgets.Controls.VzxColorButton();
        this.lblMaxDist = new System.Windows.Forms.Label();
        this.lblMaxDistVal = new System.Windows.Forms.Label();
        this.trackMaxDist = new VzxWidgets.Controls.VzxTrackBar();

        // Outros Controls
        this.hdrOutros = new VzxWidgets.Controls.VzxDotHeader();
        this.chkConectado = new VzxWidgets.Controls.VzxCheckBox();
        this.lblOpenMenu = new System.Windows.Forms.Label();
        this.keyOpenMenu = new VzxWidgets.Controls.VzxKeybind();

        // Info Controls
        this.hdrInfo = new VzxWidgets.Controls.VzxDotHeader();
        this.lblAdb = new System.Windows.Forms.Label();
        this.lblAdbVal = new System.Windows.Forms.Label();
        this.lblStatus = new System.Windows.Forms.Label();
        this.lblStatusVal = new System.Windows.Forms.Label();

        // ESP Preview Controls
        this.hdrEspPreview = new VzxWidgets.Controls.VzxDotHeader();
        this.progHealth = new VzxWidgets.Controls.VzxProgressBar();
        this.pnlSkeletonView = new System.Windows.Forms.Panel();

        // Toasts
        this.toastSuccess = new VzxWidgets.Controls.VzxToast();
        this.toastInfo = new VzxWidgets.Controls.VzxToast();

        this.topBar.SuspendLayout();
        this.cardFuncoes.SuspendLayout();
        this.cardVisual.SuspendLayout();
        this.cardEspPreview.SuspendLayout();
        this.cardOutros.SuspendLayout();
        this.cardInfo.SuspendLayout();
        this.SuspendLayout();

        // 
        // formDrag
        // 
        this.formDrag.TargetControl = this.topBar;

        // 
        // topBar
        // 
        this.topBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(14)))));
        this.topBar.Controls.Add(this.lblTitle);
        this.topBar.Controls.Add(this.btnMin);
        this.topBar.Controls.Add(this.btnClose);
        this.topBar.Dock = System.Windows.Forms.DockStyle.Top;
        this.topBar.Location = new System.Drawing.Point(0, 0);
        this.topBar.Name = "topBar";
        this.topBar.Size = new System.Drawing.Size(860, 44);
        this.topBar.TabIndex = 0;

        // 
        // lblTitle
        // 
        this.lblTitle.AutoSize = true;
        this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Bold);
        this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(245)))));
        this.lblTitle.Location = new System.Drawing.Point(18, 11);
        this.lblTitle.Name = "lblTitle";
        this.lblTitle.Size = new System.Drawing.Size(63, 21);
        this.lblTitle.TabIndex = 0;
        this.lblTitle.Text = "Volphx";

        // 
        // btnMin
        // 
        this.btnMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.btnMin.BoxType = VzxWidgets.Controls.ControlBoxType.Minimize;
        this.btnMin.Location = new System.Drawing.Point(778, 9);
        this.btnMin.Name = "btnMin";
        this.btnMin.Size = new System.Drawing.Size(32, 26);
        this.btnMin.TabIndex = 1;

        // 
        // btnClose
        // 
        this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.btnClose.BoxType = VzxWidgets.Controls.ControlBoxType.Close;
        this.btnClose.Location = new System.Drawing.Point(816, 9);
        this.btnClose.Name = "btnClose";
        this.btnClose.Size = new System.Drawing.Size(32, 26);
        this.btnClose.TabIndex = 2;

        // 
        // cardFuncoes
        // 
        this.cardFuncoes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(18)))));
        this.cardFuncoes.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(36)))));
        this.cardFuncoes.BorderRadius = 12;
        this.cardFuncoes.Controls.Add(this.hdrFuncoes);
        this.cardFuncoes.Controls.Add(this.chkAimbot);
        this.cardFuncoes.Controls.Add(this.chkSilent);
        this.cardFuncoes.Location = new System.Drawing.Point(18, 56);
        this.cardFuncoes.Name = "cardFuncoes";
        this.cardFuncoes.Padding = new System.Windows.Forms.Padding(14);
        this.cardFuncoes.Size = new System.Drawing.Size(250, 310);
        this.cardFuncoes.TabIndex = 1;

        // 
        // hdrFuncoes
        // 
        this.hdrFuncoes.DotColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(80)))), ((int)(((byte)(255)))));
        this.hdrFuncoes.Location = new System.Drawing.Point(14, 14);
        this.hdrFuncoes.Name = "hdrFuncoes";
        this.hdrFuncoes.Size = new System.Drawing.Size(120, 24);
        this.hdrFuncoes.TabIndex = 0;
        this.hdrFuncoes.Text = "Funções";

        // 
        // chkAimbot
        // 
        this.chkAimbot.AutoSize = true;
        this.chkAimbot.Checked = true;
        this.chkAimbot.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(80)))), ((int)(((byte)(255)))));
        this.chkAimbot.CheckState = System.Windows.Forms.CheckState.Checked;
        this.chkAimbot.Location = new System.Drawing.Point(16, 52);
        this.chkAimbot.Name = "chkAimbot";
        this.chkAimbot.Size = new System.Drawing.Size(71, 21);
        this.chkAimbot.TabIndex = 1;
        this.chkAimbot.Text = "Aimbot";

        // 
        // chkSilent
        // 
        this.chkSilent.AutoSize = true;
        this.chkSilent.Checked = false;
        this.chkSilent.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(80)))), ((int)(((byte)(255)))));
        this.chkSilent.Location = new System.Drawing.Point(16, 88);
        this.chkSilent.Name = "chkSilent";
        this.chkSilent.Size = new System.Drawing.Size(59, 21);
        this.chkSilent.TabIndex = 2;
        this.chkSilent.Text = "Silent";

        // 
        // cardVisual
        // 
        this.cardVisual.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(18)))));
        this.cardVisual.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(36)))));
        this.cardVisual.BorderRadius = 12;
        this.cardVisual.Controls.Add(this.hdrVisual);
        this.cardVisual.Controls.Add(this.chkEspBox);
        this.cardVisual.Controls.Add(this.colEspBox);
        this.cardVisual.Controls.Add(this.chkEspFill);
        this.cardVisual.Controls.Add(this.colEspFill);
        this.cardVisual.Controls.Add(this.chkEspLine);
        this.cardVisual.Controls.Add(this.colEspLine);
        this.cardVisual.Controls.Add(this.cmbEspPos);
        this.cardVisual.Controls.Add(this.chkEspName);
        this.cardVisual.Controls.Add(this.colEspName);
        this.cardVisual.Controls.Add(this.chkEspHealth);
        this.cardVisual.Controls.Add(this.chkEspSkeleton);
        this.cardVisual.Controls.Add(this.colEspSkeleton);
        this.cardVisual.Controls.Add(this.lblMaxDist);
        this.cardVisual.Controls.Add(this.lblMaxDistVal);
        this.cardVisual.Controls.Add(this.trackMaxDist);
        this.cardVisual.Location = new System.Drawing.Point(282, 56);
        this.cardVisual.Name = "cardVisual";
        this.cardVisual.Padding = new System.Windows.Forms.Padding(14);
        this.cardVisual.Size = new System.Drawing.Size(270, 370);
        this.cardVisual.TabIndex = 2;

        // 
        // hdrVisual
        // 
        this.hdrVisual.DotColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(80)))), ((int)(((byte)(255)))));
        this.hdrVisual.Location = new System.Drawing.Point(14, 14);
        this.hdrVisual.Name = "hdrVisual";
        this.hdrVisual.Size = new System.Drawing.Size(120, 24);
        this.hdrVisual.TabIndex = 0;
        this.hdrVisual.Text = "Visual";

        // 
        // chkEspBox
        // 
        this.chkEspBox.AutoSize = true;
        this.chkEspBox.Checked = true;
        this.chkEspBox.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(80)))), ((int)(((byte)(255)))));
        this.chkEspBox.CheckState = System.Windows.Forms.CheckState.Checked;
        this.chkEspBox.Location = new System.Drawing.Point(16, 48);
        this.chkEspBox.Name = "chkEspBox";
        this.chkEspBox.Size = new System.Drawing.Size(76, 21);
        this.chkEspBox.TabIndex = 1;
        this.chkEspBox.Text = "ESP Box";
        this.chkEspBox.CheckedChanged += new System.EventHandler(this.chkEspBox_CheckedChanged);

        // 
        // colEspBox
        // 
        this.colEspBox.Location = new System.Drawing.Point(232, 50);
        this.colEspBox.Name = "colEspBox";
        this.colEspBox.SelectedColor = System.Drawing.Color.White;
        this.colEspBox.Size = new System.Drawing.Size(18, 14);
        this.colEspBox.TabIndex = 2;

        // 
        // chkEspFill
        // 
        this.chkEspFill.AutoSize = true;
        this.chkEspFill.Checked = true;
        this.chkEspFill.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(80)))), ((int)(((byte)(255)))));
        this.chkEspFill.CheckState = System.Windows.Forms.CheckState.Checked;
        this.chkEspFill.Location = new System.Drawing.Point(16, 78);
        this.chkEspFill.Name = "chkEspFill";
        this.chkEspFill.Size = new System.Drawing.Size(91, 21);
        this.chkEspFill.TabIndex = 3;
        this.chkEspFill.Text = "ESP Fillbox";

        // 
        // colEspFill
        // 
        this.colEspFill.Location = new System.Drawing.Point(232, 80);
        this.colEspFill.Name = "colEspFill";
        this.colEspFill.SelectedColor = System.Drawing.Color.White;
        this.colEspFill.Size = new System.Drawing.Size(18, 14);
        this.colEspFill.TabIndex = 4;

        // 
        // chkEspLine
        // 
        this.chkEspLine.AutoSize = true;
        this.chkEspLine.Checked = true;
        this.chkEspLine.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(80)))), ((int)(((byte)(255)))));
        this.chkEspLine.CheckState = System.Windows.Forms.CheckState.Checked;
        this.chkEspLine.Location = new System.Drawing.Point(16, 108);
        this.chkEspLine.Name = "chkEspLine";
        this.chkEspLine.Size = new System.Drawing.Size(78, 21);
        this.chkEspLine.TabIndex = 5;
        this.chkEspLine.Text = "ESP Line";

        // 
        // colEspLine
        // 
        this.colEspLine.Location = new System.Drawing.Point(232, 110);
        this.colEspLine.Name = "colEspLine";
        this.colEspLine.SelectedColor = System.Drawing.Color.White;
        this.colEspLine.Size = new System.Drawing.Size(18, 14);
        this.colEspLine.TabIndex = 6;

        // 
        // cmbEspPos
        // 
        this.cmbEspPos.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(80)))), ((int)(((byte)(255)))));
        this.cmbEspPos.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(48)))));
        this.cmbEspPos.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(80)))), ((int)(((byte)(255)))));
        this.cmbEspPos.Items.AddRange(new object[] { "Esp Top", "Esp Bottom", "Esp Crosshair" });
        this.cmbEspPos.Location = new System.Drawing.Point(16, 138);
        this.cmbEspPos.Name = "cmbEspPos";
        this.cmbEspPos.SelectedIndex = 0;
        this.cmbEspPos.Size = new System.Drawing.Size(234, 30);
        this.cmbEspPos.TabIndex = 7;

        // 
        // chkEspName
        // 
        this.chkEspName.AutoSize = true;
        this.chkEspName.Checked = true;
        this.chkEspName.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(80)))), ((int)(((byte)(255)))));
        this.chkEspName.CheckState = System.Windows.Forms.CheckState.Checked;
        this.chkEspName.Location = new System.Drawing.Point(16, 180);
        this.chkEspName.Name = "chkEspName";
        this.chkEspName.Size = new System.Drawing.Size(90, 21);
        this.chkEspName.TabIndex = 8;
        this.chkEspName.Text = "ESP Name";

        // 
        // colEspName
        // 
        this.colEspName.Location = new System.Drawing.Point(232, 182);
        this.colEspName.Name = "colEspName";
        this.colEspName.SelectedColor = System.Drawing.Color.White;
        this.colEspName.Size = new System.Drawing.Size(18, 14);
        this.colEspName.TabIndex = 9;

        // 
        // chkEspHealth
        // 
        this.chkEspHealth.AutoSize = true;
        this.chkEspHealth.Checked = true;
        this.chkEspHealth.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(80)))), ((int)(((byte)(255)))));
        this.chkEspHealth.CheckState = System.Windows.Forms.CheckState.Checked;
        this.chkEspHealth.Location = new System.Drawing.Point(16, 210);
        this.chkEspHealth.Name = "chkEspHealth";
        this.chkEspHealth.Size = new System.Drawing.Size(92, 21);
        this.chkEspHealth.TabIndex = 10;
        this.chkEspHealth.Text = "ESP Health";

        // 
        // chkEspSkeleton
        // 
        this.chkEspSkeleton.AutoSize = true;
        this.chkEspSkeleton.Checked = true;
        this.chkEspSkeleton.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(80)))), ((int)(((byte)(255)))));
        this.chkEspSkeleton.CheckState = System.Windows.Forms.CheckState.Checked;
        this.chkEspSkeleton.Location = new System.Drawing.Point(16, 240);
        this.chkEspSkeleton.Name = "chkEspSkeleton";
        this.chkEspSkeleton.Size = new System.Drawing.Size(104, 21);
        this.chkEspSkeleton.TabIndex = 11;
        this.chkEspSkeleton.Text = "ESP Skeleton";

        // 
        // colEspSkeleton
        // 
        this.colEspSkeleton.Location = new System.Drawing.Point(232, 242);
        this.colEspSkeleton.Name = "colEspSkeleton";
        this.colEspSkeleton.SelectedColor = System.Drawing.Color.White;
        this.colEspSkeleton.Size = new System.Drawing.Size(18, 14);
        this.colEspSkeleton.TabIndex = 12;

        // 
        // lblMaxDist
        // 
        this.lblMaxDist.AutoSize = true;
        this.lblMaxDist.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
        this.lblMaxDist.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(225)))));
        this.lblMaxDist.Location = new System.Drawing.Point(16, 280);
        this.lblMaxDist.Name = "lblMaxDist";
        this.lblMaxDist.Size = new System.Drawing.Size(77, 15);
        this.lblMaxDist.TabIndex = 13;
        this.lblMaxDist.Text = "Max Distance";

        // 
        // lblMaxDistVal
        // 
        this.lblMaxDistVal.Font = new System.Drawing.Font("Segoe UI", 8.5F);
        this.lblMaxDistVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(180)))));
        this.lblMaxDistVal.Location = new System.Drawing.Point(160, 280);
        this.lblMaxDistVal.Name = "lblMaxDistVal";
        this.lblMaxDistVal.Size = new System.Drawing.Size(90, 15);
        this.lblMaxDistVal.TabIndex = 14;
        this.lblMaxDistVal.Text = "50m";
        this.lblMaxDistVal.TextAlign = System.Drawing.ContentAlignment.TopRight;

        // 
        // trackMaxDist
        // 
        this.trackMaxDist.Location = new System.Drawing.Point(16, 302);
        this.trackMaxDist.Maximum = 200;
        this.trackMaxDist.Name = "trackMaxDist";
        this.trackMaxDist.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(80)))), ((int)(((byte)(255)))));
        this.trackMaxDist.ShowDiamondThumb = false;
        this.trackMaxDist.Size = new System.Drawing.Size(234, 20);
        this.trackMaxDist.TabIndex = 15;
        this.trackMaxDist.Value = 50;
        this.trackMaxDist.ValueChanged += new System.EventHandler(this.trackMaxDist_ValueChanged);

        // 
        // cardOutros
        // 
        this.cardOutros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(18)))));
        this.cardOutros.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(36)))));
        this.cardOutros.BorderRadius = 12;
        this.cardOutros.Controls.Add(this.hdrOutros);
        this.cardOutros.Controls.Add(this.chkConectado);
        this.cardOutros.Controls.Add(this.lblOpenMenu);
        this.cardOutros.Controls.Add(this.keyOpenMenu);
        this.cardOutros.Location = new System.Drawing.Point(18, 380);
        this.cardOutros.Name = "cardOutros";
        this.cardOutros.Padding = new System.Windows.Forms.Padding(14);
        this.cardOutros.Size = new System.Drawing.Size(250, 155);
        this.cardOutros.TabIndex = 3;

        // 
        // hdrOutros
        // 
        this.hdrOutros.DotColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(80)))), ((int)(((byte)(255)))));
        this.hdrOutros.Location = new System.Drawing.Point(14, 12);
        this.hdrOutros.Name = "hdrOutros";
        this.hdrOutros.Size = new System.Drawing.Size(120, 24);
        this.hdrOutros.TabIndex = 0;
        this.hdrOutros.Text = "Outros";

        // 
        // chkConectado
        // 
        this.chkConectado.AutoSize = true;
        this.chkConectado.Checked = true;
        this.chkConectado.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(80)))), ((int)(((byte)(255)))));
        this.chkConectado.CheckState = System.Windows.Forms.CheckState.Checked;
        this.chkConectado.Location = new System.Drawing.Point(16, 44);
        this.chkConectado.Name = "chkConectado";
        this.chkConectado.Size = new System.Drawing.Size(90, 21);
        this.chkConectado.TabIndex = 1;
        this.chkConectado.Text = "Conectado";

        // 
        // lblOpenMenu
        // 
        this.lblOpenMenu.AutoSize = true;
        this.lblOpenMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(180)))));
        this.lblOpenMenu.Location = new System.Drawing.Point(16, 86);
        this.lblOpenMenu.Name = "lblOpenMenu";
        this.lblOpenMenu.Size = new System.Drawing.Size(70, 15);
        this.lblOpenMenu.TabIndex = 2;
        this.lblOpenMenu.Text = "Open menu";

        // 
        // keyOpenMenu
        // 
        this.keyOpenMenu.CurrentKey = System.Windows.Forms.Keys.Insert;
        this.keyOpenMenu.Location = new System.Drawing.Point(140, 80);
        this.keyOpenMenu.Name = "keyOpenMenu";
        this.keyOpenMenu.Size = new System.Drawing.Size(86, 28);
        this.keyOpenMenu.TabIndex = 3;

        // 
        // cardInfo
        // 
        this.cardInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(18)))));
        this.cardInfo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(36)))));
        this.cardInfo.BorderRadius = 12;
        this.cardInfo.Controls.Add(this.hdrInfo);
        this.cardInfo.Controls.Add(this.lblAdb);
        this.cardInfo.Controls.Add(this.lblAdbVal);
        this.cardInfo.Controls.Add(this.lblStatus);
        this.cardInfo.Controls.Add(this.lblStatusVal);
        this.cardInfo.Location = new System.Drawing.Point(282, 436);
        this.cardInfo.Name = "cardInfo";
        this.cardInfo.Padding = new System.Windows.Forms.Padding(14);
        this.cardInfo.Size = new System.Drawing.Size(270, 99);
        this.cardInfo.TabIndex = 4;

        // 
        // hdrInfo
        // 
        this.hdrInfo.DotColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(80)))), ((int)(((byte)(255)))));
        this.hdrInfo.Location = new System.Drawing.Point(14, 10);
        this.hdrInfo.Name = "hdrInfo";
        this.hdrInfo.Size = new System.Drawing.Size(120, 24);
        this.hdrInfo.TabIndex = 0;
        this.hdrInfo.Text = "Informação";

        // 
        // lblAdb
        // 
        this.lblAdb.AutoSize = true;
        this.lblAdb.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold);
        this.lblAdb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
        this.lblAdb.Location = new System.Drawing.Point(26, 40);
        this.lblAdb.Name = "lblAdb";
        this.lblAdb.Size = new System.Drawing.Size(32, 15);
        this.lblAdb.TabIndex = 1;
        this.lblAdb.Text = "Adb:";

        // 
        // lblAdbVal
        // 
        this.lblAdbVal.AutoSize = true;
        this.lblAdbVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(160)))));
        this.lblAdbVal.Location = new System.Drawing.Point(80, 40);
        this.lblAdbVal.Name = "lblAdbVal";
        this.lblAdbVal.Size = new System.Drawing.Size(36, 15);
        this.lblAdbVal.TabIndex = 2;
        this.lblAdbVal.Text = "None";

        // 
        // lblStatus
        // 
        this.lblStatus.AutoSize = true;
        this.lblStatus.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold);
        this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
        this.lblStatus.Location = new System.Drawing.Point(26, 62);
        this.lblStatus.Name = "lblStatus";
        this.lblStatus.Size = new System.Drawing.Size(43, 15);
        this.lblStatus.TabIndex = 3;
        this.lblStatus.Text = "Status:";

        // 
        // lblStatusVal
        // 
        this.lblStatusVal.AutoSize = true;
        this.lblStatusVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(160)))));
        this.lblStatusVal.Location = new System.Drawing.Point(80, 62);
        this.lblStatusVal.Name = "lblStatusVal";
        this.lblStatusVal.Size = new System.Drawing.Size(36, 15);
        this.lblStatusVal.TabIndex = 4;
        this.lblStatusVal.Text = "None";

        // 
        // cardEspPreview
        // 
        this.cardEspPreview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(18)))));
        this.cardEspPreview.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(36)))));
        this.cardEspPreview.BorderRadius = 12;
        this.cardEspPreview.Controls.Add(this.hdrEspPreview);
        this.cardEspPreview.Controls.Add(this.progHealth);
        this.cardEspPreview.Controls.Add(this.pnlSkeletonView);
        this.cardEspPreview.Location = new System.Drawing.Point(568, 56);
        this.cardEspPreview.Name = "cardEspPreview";
        this.cardEspPreview.Padding = new System.Windows.Forms.Padding(14);
        this.cardEspPreview.Size = new System.Drawing.Size(274, 479);
        this.cardEspPreview.TabIndex = 5;

        // 
        // hdrEspPreview
        // 
        this.hdrEspPreview.DotColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(80)))), ((int)(((byte)(255)))));
        this.hdrEspPreview.Location = new System.Drawing.Point(14, 14);
        this.hdrEspPreview.Name = "hdrEspPreview";
        this.hdrEspPreview.Size = new System.Drawing.Size(120, 24);
        this.hdrEspPreview.TabIndex = 0;
        this.hdrEspPreview.Text = "ESP Preview";

        // 
        // progHealth
        // 
        this.progHealth.BorderRadius = 4;
        this.progHealth.GradientEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(209)))), ((int)(((byte)(88)))));
        this.progHealth.GradientStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(209)))), ((int)(((byte)(88)))));
        this.progHealth.Location = new System.Drawing.Point(36, 44);
        this.progHealth.Name = "progHealth";
        this.progHealth.ShowPercentage = false;
        this.progHealth.Size = new System.Drawing.Size(202, 6);
        this.progHealth.TabIndex = 1;
        this.progHealth.Value = 85;

        // 
        // pnlSkeletonView
        // 
        this.pnlSkeletonView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(18)))), ((int)(((byte)(38)))));
        this.pnlSkeletonView.Location = new System.Drawing.Point(36, 60);
        this.pnlSkeletonView.Name = "pnlSkeletonView";
        this.pnlSkeletonView.Size = new System.Drawing.Size(202, 380);
        this.pnlSkeletonView.TabIndex = 2;
        this.pnlSkeletonView.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlSkeletonView_Paint);

        // 
        // toastSuccess
        // 
        this.toastSuccess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        this.toastSuccess.BarColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(209)))), ((int)(((byte)(88)))));
        this.toastSuccess.Location = new System.Drawing.Point(590, 400);
        this.toastSuccess.Message = "ESP Box ativado.";
        this.toastSuccess.Name = "toastSuccess";
        this.toastSuccess.Size = new System.Drawing.Size(245, 60);
        this.toastSuccess.TabIndex = 6;
        this.toastSuccess.Title = "ESP Box";
        this.toastSuccess.Type = VzxWidgets.Controls.ToastType.Success;

        // 
        // toastInfo
        // 
        this.toastInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        this.toastInfo.BarColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(80)))), ((int)(((byte)(255)))));
        this.toastInfo.Location = new System.Drawing.Point(590, 468);
        this.toastInfo.Message = "ESP Box desativado.";
        this.toastInfo.Name = "toastInfo";
        this.toastInfo.Size = new System.Drawing.Size(245, 60);
        this.toastInfo.TabIndex = 7;
        this.toastInfo.Title = "ESP Box";
        this.toastInfo.Type = VzxWidgets.Controls.ToastType.Info;

        // 
        // Form1
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(8)))), ((int)(((byte)(10)))));
        this.ClientSize = new System.Drawing.Size(860, 550);
        this.Controls.Add(this.toastInfo);
        this.Controls.Add(this.toastSuccess);
        this.Controls.Add(this.cardEspPreview);
        this.Controls.Add(this.cardInfo);
        this.Controls.Add(this.cardOutros);
        this.Controls.Add(this.cardVisual);
        this.Controls.Add(this.cardFuncoes);
        this.Controls.Add(this.topBar);
        this.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.ForeColor = System.Drawing.Color.White;
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        this.Name = "Form1";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "Volphx - VzxWidgets";
        this.topBar.ResumeLayout(false);
        this.topBar.PerformLayout();
        this.cardFuncoes.ResumeLayout(false);
        this.cardFuncoes.PerformLayout();
        this.cardVisual.ResumeLayout(false);
        this.cardVisual.PerformLayout();
        this.cardEspPreview.ResumeLayout(false);
        this.cardOutros.ResumeLayout(false);
        this.cardOutros.PerformLayout();
        this.cardInfo.ResumeLayout(false);
        this.cardInfo.PerformLayout();
        this.ResumeLayout(false);
    }

    #endregion
}
