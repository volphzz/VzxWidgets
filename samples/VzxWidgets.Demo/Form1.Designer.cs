namespace VzxWidgets.Demo;

partial class Form1
{
    private System.ComponentModel.IContainer components = null;

    // Top Header & Window Controls
    private VzxWidgets.Controls.VzxFormDrag formDrag;
    private System.Windows.Forms.Panel topBar;
    private System.Windows.Forms.Label lblLogo;
    private System.Windows.Forms.Label lblSubLogo;
    private VzxWidgets.Controls.VzxControlBox btnClose;
    private VzxWidgets.Controls.VzxControlBox btnMin;

    // Sidebar
    private System.Windows.Forms.Panel sidebar;
    private VzxWidgets.Controls.VzxButton btnTabAimbot;
    private VzxWidgets.Controls.VzxButton btnTabPlayers;
    private VzxWidgets.Controls.VzxButton btnTabWorld;
    private VzxWidgets.Controls.VzxButton btnTabSettings;
    private VzxWidgets.Controls.VzxButton btnTabConfig;

    // Content Area (Cards)
    private System.Windows.Forms.Panel contentPanel;
    private VzxWidgets.Controls.VzxCard cardLeft;
    private VzxWidgets.Controls.VzxCard cardRight;

    // Left Card Controls
    private System.Windows.Forms.Label lblRecoilTitle;
    private VzxWidgets.Controls.VzxCheckBox chkEnableRecoil;
    private VzxWidgets.Controls.VzxCheckBox chkReturnCrosshair;
    private System.Windows.Forms.Label lblSensitivity;
    private System.Windows.Forms.Label lblSensitivityVal;
    private VzxWidgets.Controls.VzxTrackBar trackSensitivity;
    private System.Windows.Forms.Label lblXAxis;
    private System.Windows.Forms.Label lblXAxisVal;
    private VzxWidgets.Controls.VzxTrackBar trackXAxis;
    private System.Windows.Forms.Label lblYAxis;
    private System.Windows.Forms.Label lblYAxisVal;
    private VzxWidgets.Controls.VzxTrackBar trackYAxis;
    private VzxWidgets.Controls.VzxSeparator sepLeft;
    private System.Windows.Forms.Label lblTargetTitle;
    private VzxWidgets.Controls.VzxCheckBox chkTargetPred;

    // Right Card Controls
    private System.Windows.Forms.Label lblTriggerTitle;
    private VzxWidgets.Controls.VzxCheckBox chkEnableTrigger;
    private System.Windows.Forms.Label lblDelay;
    private System.Windows.Forms.Label lblDelayVal;
    private VzxWidgets.Controls.VzxTrackBar trackDelay;
    private VzxWidgets.Controls.VzxCheckBox chkSmoke;
    private VzxWidgets.Controls.VzxSeparator sepRight;
    private System.Windows.Forms.Label lblModeTitle;
    private VzxWidgets.Controls.VzxComboBox cmbTriggerMode;
    private System.Windows.Forms.Label lblProgressTitle;
    private VzxWidgets.Controls.VzxProgressBar progCalibration;

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
        
        // TopBar & Controls
        this.topBar = new System.Windows.Forms.Panel();
        this.lblLogo = new System.Windows.Forms.Label();
        this.lblSubLogo = new System.Windows.Forms.Label();
        this.btnClose = new VzxWidgets.Controls.VzxControlBox();
        this.btnMin = new VzxWidgets.Controls.VzxControlBox();

        // Sidebar
        this.sidebar = new System.Windows.Forms.Panel();
        this.btnTabAimbot = new VzxWidgets.Controls.VzxButton();
        this.btnTabPlayers = new VzxWidgets.Controls.VzxButton();
        this.btnTabWorld = new VzxWidgets.Controls.VzxButton();
        this.btnTabSettings = new VzxWidgets.Controls.VzxButton();
        this.btnTabConfig = new VzxWidgets.Controls.VzxButton();

        // Content & Cards
        this.contentPanel = new System.Windows.Forms.Panel();
        this.cardLeft = new VzxWidgets.Controls.VzxCard();
        this.cardRight = new VzxWidgets.Controls.VzxCard();

        // Left Controls
        this.lblRecoilTitle = new System.Windows.Forms.Label();
        this.chkEnableRecoil = new VzxWidgets.Controls.VzxCheckBox();
        this.chkReturnCrosshair = new VzxWidgets.Controls.VzxCheckBox();
        this.lblSensitivity = new System.Windows.Forms.Label();
        this.lblSensitivityVal = new System.Windows.Forms.Label();
        this.trackSensitivity = new VzxWidgets.Controls.VzxTrackBar();
        this.lblXAxis = new System.Windows.Forms.Label();
        this.lblXAxisVal = new System.Windows.Forms.Label();
        this.trackXAxis = new VzxWidgets.Controls.VzxTrackBar();
        this.lblYAxis = new System.Windows.Forms.Label();
        this.lblYAxisVal = new System.Windows.Forms.Label();
        this.trackYAxis = new VzxWidgets.Controls.VzxTrackBar();
        this.sepLeft = new VzxWidgets.Controls.VzxSeparator();
        this.lblTargetTitle = new System.Windows.Forms.Label();
        this.chkTargetPred = new VzxWidgets.Controls.VzxCheckBox();

        // Right Controls
        this.lblTriggerTitle = new System.Windows.Forms.Label();
        this.chkEnableTrigger = new VzxWidgets.Controls.VzxCheckBox();
        this.lblDelay = new System.Windows.Forms.Label();
        this.lblDelayVal = new System.Windows.Forms.Label();
        this.trackDelay = new VzxWidgets.Controls.VzxTrackBar();
        this.chkSmoke = new VzxWidgets.Controls.VzxCheckBox();
        this.sepRight = new VzxWidgets.Controls.VzxSeparator();
        this.lblModeTitle = new System.Windows.Forms.Label();
        this.cmbTriggerMode = new VzxWidgets.Controls.VzxComboBox();
        this.lblProgressTitle = new System.Windows.Forms.Label();
        this.progCalibration = new VzxWidgets.Controls.VzxProgressBar();

        this.topBar.SuspendLayout();
        this.sidebar.SuspendLayout();
        this.contentPanel.SuspendLayout();
        this.cardLeft.SuspendLayout();
        this.cardRight.SuspendLayout();
        this.SuspendLayout();

        // 
        // formDrag
        // 
        this.formDrag.TargetControl = this.topBar;

        // 
        // topBar
        // 
        this.topBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(18)))));
        this.topBar.Controls.Add(this.lblLogo);
        this.topBar.Controls.Add(this.lblSubLogo);
        this.topBar.Controls.Add(this.btnMin);
        this.topBar.Controls.Add(this.btnClose);
        this.topBar.Dock = System.Windows.Forms.DockStyle.Top;
        this.topBar.Location = new System.Drawing.Point(0, 0);
        this.topBar.Name = "topBar";
        this.topBar.Size = new System.Drawing.Size(920, 48);
        this.topBar.TabIndex = 0;

        // 
        // lblLogo
        // 
        this.lblLogo.AutoSize = true;
        this.lblLogo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
        this.lblLogo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(95)))), ((int)(((byte)(25)))));
        this.lblLogo.Location = new System.Drawing.Point(18, 12);
        this.lblLogo.Name = "lblLogo";
        this.lblLogo.Size = new System.Drawing.Size(107, 21);
        this.lblLogo.TabIndex = 0;
        this.lblLogo.Text = "◈ VzxWidgets";

        // 
        // lblSubLogo
        // 
        this.lblSubLogo.AutoSize = true;
        this.lblSubLogo.Font = new System.Drawing.Font("Segoe UI", 8.5F);
        this.lblSubLogo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(145)))));
        this.lblSubLogo.Location = new System.Drawing.Point(130, 16);
        this.lblSubLogo.Name = "lblSubLogo";
        this.lblSubLogo.Size = new System.Drawing.Size(91, 15);
        this.lblSubLogo.TabIndex = 1;
        this.lblSubLogo.Text = "external edition";

        // 
        // btnMin
        // 
        this.btnMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.btnMin.BoxType = VzxWidgets.Controls.ControlBoxType.Minimize;
        this.btnMin.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnMin.Location = new System.Drawing.Point(836, 10);
        this.btnMin.Name = "btnMin";
        this.btnMin.Size = new System.Drawing.Size(32, 26);
        this.btnMin.TabIndex = 2;

        // 
        // btnClose
        // 
        this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.btnClose.BoxType = VzxWidgets.Controls.ControlBoxType.Close;
        this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnClose.Location = new System.Drawing.Point(874, 10);
        this.btnClose.Name = "btnClose";
        this.btnClose.Size = new System.Drawing.Size(32, 26);
        this.btnClose.TabIndex = 3;

        // 
        // sidebar
        // 
        this.sidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(12)))), ((int)(((byte)(16)))));
        this.sidebar.Controls.Add(this.btnTabAimbot);
        this.sidebar.Controls.Add(this.btnTabPlayers);
        this.sidebar.Controls.Add(this.btnTabWorld);
        this.sidebar.Controls.Add(this.btnTabSettings);
        this.sidebar.Controls.Add(this.btnTabConfig);
        this.sidebar.Dock = System.Windows.Forms.DockStyle.Left;
        this.sidebar.Location = new System.Drawing.Point(0, 48);
        this.sidebar.Name = "sidebar";
        this.sidebar.Size = new System.Drawing.Size(110, 552);
        this.sidebar.TabIndex = 1;

        // 
        // btnTabAimbot
        // 
        this.btnTabAimbot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(34)))));
        this.btnTabAimbot.BorderRadius = 8;
        this.btnTabAimbot.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnTabAimbot.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
        this.btnTabAimbot.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(105)))), ((int)(((byte)(30)))));
        this.btnTabAimbot.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(44)))));
        this.btnTabAimbot.Location = new System.Drawing.Point(8, 20);
        this.btnTabAimbot.Name = "btnTabAimbot";
        this.btnTabAimbot.ShowActiveIndicator = true;
        this.btnTabAimbot.Size = new System.Drawing.Size(94, 46);
        this.btnTabAimbot.TabIndex = 0;
        this.btnTabAimbot.Text = "Targeting";
        this.btnTabAimbot.UseVisualStyleBackColor = false;

        // 
        // btnTabPlayers
        // 
        this.btnTabPlayers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(12)))), ((int)(((byte)(16)))));
        this.btnTabPlayers.BorderRadius = 8;
        this.btnTabPlayers.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnTabPlayers.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
        this.btnTabPlayers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(145)))));
        this.btnTabPlayers.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(30)))));
        this.btnTabPlayers.Location = new System.Drawing.Point(8, 74);
        this.btnTabPlayers.Name = "btnTabPlayers";
        this.btnTabPlayers.Size = new System.Drawing.Size(94, 46);
        this.btnTabPlayers.TabIndex = 1;
        this.btnTabPlayers.Text = "Visuals";
        this.btnTabPlayers.UseVisualStyleBackColor = false;

        // 
        // btnTabWorld
        // 
        this.btnTabWorld.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(12)))), ((int)(((byte)(16)))));
        this.btnTabWorld.BorderRadius = 8;
        this.btnTabWorld.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnTabWorld.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
        this.btnTabWorld.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(145)))));
        this.btnTabWorld.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(30)))));
        this.btnTabWorld.Location = new System.Drawing.Point(8, 128);
        this.btnTabWorld.Name = "btnTabWorld";
        this.btnTabWorld.Size = new System.Drawing.Size(94, 46);
        this.btnTabWorld.TabIndex = 2;
        this.btnTabWorld.Text = "World";
        this.btnTabWorld.UseVisualStyleBackColor = false;

        // 
        // btnTabSettings
        // 
        this.btnTabSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(12)))), ((int)(((byte)(16)))));
        this.btnTabSettings.BorderRadius = 8;
        this.btnTabSettings.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnTabSettings.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
        this.btnTabSettings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(145)))));
        this.btnTabSettings.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(30)))));
        this.btnTabSettings.Location = new System.Drawing.Point(8, 182);
        this.btnTabSettings.Name = "btnTabSettings";
        this.btnTabSettings.Size = new System.Drawing.Size(94, 46);
        this.btnTabSettings.TabIndex = 3;
        this.btnTabSettings.Text = "Settings";
        this.btnTabSettings.UseVisualStyleBackColor = false;

        // 
        // btnTabConfig
        // 
        this.btnTabConfig.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(12)))), ((int)(((byte)(16)))));
        this.btnTabConfig.BorderRadius = 8;
        this.btnTabConfig.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnTabConfig.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
        this.btnTabConfig.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(145)))));
        this.btnTabConfig.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(30)))));
        this.btnTabConfig.Location = new System.Drawing.Point(8, 236);
        this.btnTabConfig.Name = "btnTabConfig";
        this.btnTabConfig.Size = new System.Drawing.Size(94, 46);
        this.btnTabConfig.TabIndex = 4;
        this.btnTabConfig.Text = "Profiles";
        this.btnTabConfig.UseVisualStyleBackColor = false;

        // 
        // contentPanel
        // 
        this.contentPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(22)))));
        this.contentPanel.Controls.Add(this.cardLeft);
        this.contentPanel.Controls.Add(this.cardRight);
        this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
        this.contentPanel.Location = new System.Drawing.Point(110, 48);
        this.contentPanel.Name = "contentPanel";
        this.contentPanel.Padding = new System.Windows.Forms.Padding(20);
        this.contentPanel.Size = new System.Drawing.Size(810, 552);
        this.contentPanel.TabIndex = 2;

        // 
        // cardLeft
        // 
        this.cardLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(19)))), ((int)(((byte)(26)))));
        this.cardLeft.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(48)))));
        this.cardLeft.BorderRadius = 14;
        this.cardLeft.Controls.Add(this.lblRecoilTitle);
        this.cardLeft.Controls.Add(this.chkEnableRecoil);
        this.cardLeft.Controls.Add(this.chkReturnCrosshair);
        this.cardLeft.Controls.Add(this.lblSensitivity);
        this.cardLeft.Controls.Add(this.lblSensitivityVal);
        this.cardLeft.Controls.Add(this.trackSensitivity);
        this.cardLeft.Controls.Add(this.lblXAxis);
        this.cardLeft.Controls.Add(this.lblXAxisVal);
        this.cardLeft.Controls.Add(this.trackXAxis);
        this.cardLeft.Controls.Add(this.lblYAxis);
        this.cardLeft.Controls.Add(this.lblYAxisVal);
        this.cardLeft.Controls.Add(this.trackYAxis);
        this.cardLeft.Controls.Add(this.sepLeft);
        this.cardLeft.Controls.Add(this.lblTargetTitle);
        this.cardLeft.Controls.Add(this.chkTargetPred);
        this.cardLeft.Location = new System.Drawing.Point(20, 20);
        this.cardLeft.Name = "cardLeft";
        this.cardLeft.Padding = new System.Windows.Forms.Padding(16);
        this.cardLeft.Size = new System.Drawing.Size(370, 500);
        this.cardLeft.TabIndex = 0;

        // 
        // lblRecoilTitle
        // 
        this.lblRecoilTitle.AutoSize = true;
        this.lblRecoilTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
        this.lblRecoilTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(170)))));
        this.lblRecoilTitle.Location = new System.Drawing.Point(16, 16);
        this.lblRecoilTitle.Name = "lblRecoilTitle";
        this.lblRecoilTitle.Size = new System.Drawing.Size(77, 17);
        this.lblRecoilTitle.TabIndex = 0;
        this.lblRecoilTitle.Text = "Recoil core";

        // 
        // chkEnableRecoil
        // 
        this.chkEnableRecoil.AutoSize = true;
        this.chkEnableRecoil.Checked = true;
        this.chkEnableRecoil.CheckState = System.Windows.Forms.CheckState.Checked;
        this.chkEnableRecoil.Location = new System.Drawing.Point(18, 50);
        this.chkEnableRecoil.Name = "chkEnableRecoil";
        this.chkEnableRecoil.Size = new System.Drawing.Size(107, 21);
        this.chkEnableRecoil.TabIndex = 1;
        this.chkEnableRecoil.Text = "Enable recoil";

        // 
        // chkReturnCrosshair
        // 
        this.chkReturnCrosshair.AutoSize = true;
        this.chkReturnCrosshair.Checked = true;
        this.chkReturnCrosshair.CheckState = System.Windows.Forms.CheckState.Checked;
        this.chkReturnCrosshair.Location = new System.Drawing.Point(18, 86);
        this.chkReturnCrosshair.Name = "chkReturnCrosshair";
        this.chkReturnCrosshair.Size = new System.Drawing.Size(124, 21);
        this.chkReturnCrosshair.TabIndex = 2;
        this.chkReturnCrosshair.Text = "Return crosshair";

        // 
        // lblSensitivity
        // 
        this.lblSensitivity.AutoSize = true;
        this.lblSensitivity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(160)))));
        this.lblSensitivity.Location = new System.Drawing.Point(16, 130);
        this.lblSensitivity.Name = "lblSensitivity";
        this.lblSensitivity.Size = new System.Drawing.Size(64, 15);
        this.lblSensitivity.TabIndex = 3;
        this.lblSensitivity.Text = "Sensitivity";

        // 
        // lblSensitivityVal
        // 
        this.lblSensitivityVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(105)))), ((int)(((byte)(30)))));
        this.lblSensitivityVal.Location = new System.Drawing.Point(260, 130);
        this.lblSensitivityVal.Name = "lblSensitivityVal";
        this.lblSensitivityVal.Size = new System.Drawing.Size(90, 15);
        this.lblSensitivityVal.TabIndex = 4;
        this.lblSensitivityVal.Text = "( 100% )";
        this.lblSensitivityVal.TextAlign = System.Drawing.ContentAlignment.TopRight;

        // 
        // trackSensitivity
        // 
        this.trackSensitivity.Location = new System.Drawing.Point(16, 152);
        this.trackSensitivity.Name = "trackSensitivity";
        this.trackSensitivity.Size = new System.Drawing.Size(335, 24);
        this.trackSensitivity.TabIndex = 5;
        this.trackSensitivity.Value = 100;
        this.trackSensitivity.ValueChanged += new System.EventHandler(this.trackSensitivity_ValueChanged);

        // 
        // lblXAxis
        // 
        this.lblXAxis.AutoSize = true;
        this.lblXAxis.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(160)))));
        this.lblXAxis.Location = new System.Drawing.Point(16, 192);
        this.lblXAxis.Name = "lblXAxis";
        this.lblXAxis.Size = new System.Drawing.Size(40, 15);
        this.lblXAxis.TabIndex = 6;
        this.lblXAxis.Text = "X-Axis";

        // 
        // lblXAxisVal
        // 
        this.lblXAxisVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(105)))), ((int)(((byte)(30)))));
        this.lblXAxisVal.Location = new System.Drawing.Point(260, 192);
        this.lblXAxisVal.Name = "lblXAxisVal";
        this.lblXAxisVal.Size = new System.Drawing.Size(90, 15);
        this.lblXAxisVal.TabIndex = 7;
        this.lblXAxisVal.Text = "( 70% )";
        this.lblXAxisVal.TextAlign = System.Drawing.ContentAlignment.TopRight;

        // 
        // trackXAxis
        // 
        this.trackXAxis.Location = new System.Drawing.Point(16, 214);
        this.trackXAxis.Name = "trackXAxis";
        this.trackXAxis.Size = new System.Drawing.Size(335, 24);
        this.trackXAxis.TabIndex = 8;
        this.trackXAxis.Value = 70;
        this.trackXAxis.ValueChanged += new System.EventHandler(this.trackXAxis_ValueChanged);

        // 
        // lblYAxis
        // 
        this.lblYAxis.AutoSize = true;
        this.lblYAxis.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(160)))));
        this.lblYAxis.Location = new System.Drawing.Point(16, 254);
        this.lblYAxis.Name = "lblYAxis";
        this.lblYAxis.Size = new System.Drawing.Size(39, 15);
        this.lblYAxis.TabIndex = 9;
        this.lblYAxis.Text = "Y-Axis";

        // 
        // lblYAxisVal
        // 
        this.lblYAxisVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(105)))), ((int)(((byte)(30)))));
        this.lblYAxisVal.Location = new System.Drawing.Point(260, 254);
        this.lblYAxisVal.Name = "lblYAxisVal";
        this.lblYAxisVal.Size = new System.Drawing.Size(90, 15);
        this.lblYAxisVal.TabIndex = 10;
        this.lblYAxisVal.Text = "( 50% )";
        this.lblYAxisVal.TextAlign = System.Drawing.ContentAlignment.TopRight;

        // 
        // trackYAxis
        // 
        this.trackYAxis.Location = new System.Drawing.Point(16, 276);
        this.trackYAxis.Name = "trackYAxis";
        this.trackYAxis.Size = new System.Drawing.Size(335, 24);
        this.trackYAxis.TabIndex = 11;
        this.trackYAxis.Value = 50;
        this.trackYAxis.ValueChanged += new System.EventHandler(this.trackYAxis_ValueChanged);

        // 
        // sepLeft
        // 
        this.sepLeft.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
        this.sepLeft.Location = new System.Drawing.Point(16, 320);
        this.sepLeft.Name = "sepLeft";
        this.sepLeft.Size = new System.Drawing.Size(335, 10);
        this.sepLeft.TabIndex = 12;

        // 
        // lblTargetTitle
        // 
        this.lblTargetTitle.AutoSize = true;
        this.lblTargetTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
        this.lblTargetTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(170)))));
        this.lblTargetTitle.Location = new System.Drawing.Point(16, 345);
        this.lblTargetTitle.Name = "lblTargetTitle";
        this.lblTargetTitle.Size = new System.Drawing.Size(123, 17);
        this.lblTargetTitle.TabIndex = 13;
        this.lblTargetTitle.Text = "Target acquisition";

        // 
        // chkTargetPred
        // 
        this.chkTargetPred.AutoSize = true;
        this.chkTargetPred.Checked = true;
        this.chkTargetPred.CheckState = System.Windows.Forms.CheckState.Checked;
        this.chkTargetPred.Location = new System.Drawing.Point(18, 380);
        this.chkTargetPred.Name = "chkTargetPred";
        this.chkTargetPred.Size = new System.Drawing.Size(125, 21);
        this.chkTargetPred.TabIndex = 14;
        this.chkTargetPred.Text = "Target prediction";

        // 
        // cardRight
        // 
        this.cardRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(19)))), ((int)(((byte)(26)))));
        this.cardRight.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(48)))));
        this.cardRight.BorderRadius = 14;
        this.cardRight.Controls.Add(this.lblTriggerTitle);
        this.cardRight.Controls.Add(this.chkEnableTrigger);
        this.cardRight.Controls.Add(this.lblDelay);
        this.cardRight.Controls.Add(this.lblDelayVal);
        this.cardRight.Controls.Add(this.trackDelay);
        this.cardRight.Controls.Add(this.chkSmoke);
        this.cardRight.Controls.Add(this.sepRight);
        this.cardRight.Controls.Add(this.lblModeTitle);
        this.cardRight.Controls.Add(this.cmbTriggerMode);
        this.cardRight.Controls.Add(this.lblProgressTitle);
        this.cardRight.Controls.Add(this.progCalibration);
        this.cardRight.Location = new System.Drawing.Point(410, 20);
        this.cardRight.Name = "cardRight";
        this.cardRight.Padding = new System.Windows.Forms.Padding(16);
        this.cardRight.Size = new System.Drawing.Size(370, 500);
        this.cardRight.TabIndex = 1;

        // 
        // lblTriggerTitle
        // 
        this.lblTriggerTitle.AutoSize = true;
        this.lblTriggerTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
        this.lblTriggerTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(170)))));
        this.lblTriggerTitle.Location = new System.Drawing.Point(16, 16);
        this.lblTriggerTitle.Name = "lblTriggerTitle";
        this.lblTriggerTitle.Size = new System.Drawing.Size(107, 17);
        this.lblTriggerTitle.TabIndex = 0;
        this.lblTriggerTitle.Text = "Trigger discipline";

        // 
        // chkEnableTrigger
        // 
        this.chkEnableTrigger.AutoSize = true;
        this.chkEnableTrigger.Checked = true;
        this.chkEnableTrigger.CheckState = System.Windows.Forms.CheckState.Checked;
        this.chkEnableTrigger.Location = new System.Drawing.Point(18, 50);
        this.chkEnableTrigger.Name = "chkEnableTrigger";
        this.chkEnableTrigger.Size = new System.Drawing.Size(112, 21);
        this.chkEnableTrigger.TabIndex = 1;
        this.chkEnableTrigger.Text = "Enable trigger";

        // 
        // lblDelay
        // 
        this.lblDelay.AutoSize = true;
        this.lblDelay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(160)))));
        this.lblDelay.Location = new System.Drawing.Point(16, 94);
        this.lblDelay.Name = "lblDelay";
        this.lblDelay.Size = new System.Drawing.Size(107, 15);
        this.lblDelay.TabIndex = 2;
        this.lblDelay.Text = "Delay before firing";

        // 
        // lblDelayVal
        // 
        this.lblDelayVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(105)))), ((int)(((byte)(30)))));
        this.lblDelayVal.Location = new System.Drawing.Point(260, 94);
        this.lblDelayVal.Name = "lblDelayVal";
        this.lblDelayVal.Size = new System.Drawing.Size(90, 15);
        this.lblDelayVal.TabIndex = 3;
        this.lblDelayVal.Text = "( 12 ms )";
        this.lblDelayVal.TextAlign = System.Drawing.ContentAlignment.TopRight;

        // 
        // trackDelay
        // 
        this.trackDelay.Location = new System.Drawing.Point(16, 118);
        this.trackDelay.Maximum = 100;
        this.trackDelay.Name = "trackDelay";
        this.trackDelay.Size = new System.Drawing.Size(335, 24);
        this.trackDelay.TabIndex = 4;
        this.trackDelay.Value = 12;
        this.trackDelay.ValueChanged += new System.EventHandler(this.trackDelay_ValueChanged);

        // 
        // chkSmoke
        // 
        this.chkSmoke.AutoSize = true;
        this.chkSmoke.Checked = true;
        this.chkSmoke.CheckState = System.Windows.Forms.CheckState.Checked;
        this.chkSmoke.Location = new System.Drawing.Point(18, 160);
        this.chkSmoke.Name = "chkSmoke";
        this.chkSmoke.Size = new System.Drawing.Size(157, 21);
        this.chkSmoke.TabIndex = 5;
        this.chkSmoke.Text = "Disable through smoke";

        // 
        // sepRight
        // 
        this.sepRight.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
        this.sepRight.Location = new System.Drawing.Point(16, 204);
        this.sepRight.Name = "sepRight";
        this.sepRight.Size = new System.Drawing.Size(335, 10);
        this.sepRight.TabIndex = 6;

        // 
        // lblModeTitle
        // 
        this.lblModeTitle.AutoSize = true;
        this.lblModeTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
        this.lblModeTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(170)))));
        this.lblModeTitle.Location = new System.Drawing.Point(16, 230);
        this.lblModeTitle.Name = "lblModeTitle";
        this.lblModeTitle.Size = new System.Drawing.Size(89, 17);
        this.lblModeTitle.TabIndex = 7;
        this.lblModeTitle.Text = "Trigger mode";

        // 
        // cmbTriggerMode
        // 
        this.cmbTriggerMode.Items.AddRange(new object[] {
            "Tap fire",
            "Burst fire",
            "Full auto",
            "Smart prediction"
        });
        this.cmbTriggerMode.Location = new System.Drawing.Point(16, 260);
        this.cmbTriggerMode.Name = "cmbTriggerMode";
        this.cmbTriggerMode.SelectedIndex = 0;
        this.cmbTriggerMode.Size = new System.Drawing.Size(335, 32);
        this.cmbTriggerMode.TabIndex = 8;

        // 
        // lblProgressTitle
        // 
        this.lblProgressTitle.AutoSize = true;
        this.lblProgressTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
        this.lblProgressTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(170)))));
        this.lblProgressTitle.Location = new System.Drawing.Point(16, 320);
        this.lblProgressTitle.Name = "lblProgressTitle";
        this.lblProgressTitle.Size = new System.Drawing.Size(107, 17);
        this.lblProgressTitle.TabIndex = 9;
        this.lblProgressTitle.Text = "Shot calibration";

        // 
        // progCalibration
        // 
        this.progCalibration.Location = new System.Drawing.Point(16, 350);
        this.progCalibration.Name = "progCalibration";
        this.progCalibration.Size = new System.Drawing.Size(335, 24);
        this.progCalibration.TabIndex = 10;
        this.progCalibration.Value = 78;

        // 
        // Form1
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(18)))));
        this.ClientSize = new System.Drawing.Size(920, 600);
        this.Controls.Add(this.contentPanel);
        this.Controls.Add(this.sidebar);
        this.Controls.Add(this.topBar);
        this.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.ForeColor = System.Drawing.Color.White;
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        this.Name = "Form1";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "InFamous External - VzxWidgets";
        this.topBar.ResumeLayout(false);
        this.topBar.PerformLayout();
        this.sidebar.ResumeLayout(false);
        this.contentPanel.ResumeLayout(false);
        this.cardLeft.ResumeLayout(false);
        this.cardLeft.PerformLayout();
        this.cardRight.ResumeLayout(false);
        this.cardRight.PerformLayout();
        this.ResumeLayout(false);
    }

    #endregion
}
