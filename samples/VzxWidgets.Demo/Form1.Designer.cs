namespace VzxWidgets.Demo;

partial class Form1
{
    private System.ComponentModel.IContainer components = null;

    private VzxWidgets.Controls.VzxCard mainCard;
    private System.Windows.Forms.Label lblTitle;
    private System.Windows.Forms.Label lblSub;
    private VzxWidgets.Controls.VzxButton btnPrimary;
    private VzxWidgets.Controls.VzxButton btnEmerald;
    private VzxWidgets.Controls.VzxButton btnOutline;
    private System.Windows.Forms.Label lblToggles;
    private VzxWidgets.Controls.VzxToggleSwitch toggle1;
    private System.Windows.Forms.Label lblToggleState;
    private VzxWidgets.Controls.VzxToggleSwitch toggle2;
    private System.Windows.Forms.Label lblToggleState2;
    private System.Windows.Forms.Label lblInput;
    private VzxWidgets.Controls.VzxTextBox txtUsername;
    private VzxWidgets.Controls.VzxTextBox txtToken;
    private VzxWidgets.Controls.VzxCard innerCard;
    private System.Windows.Forms.Label lblStatus;

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

        this.mainCard = new VzxWidgets.Controls.VzxCard();
        this.lblTitle = new System.Windows.Forms.Label();
        this.lblSub = new System.Windows.Forms.Label();
        this.btnPrimary = new VzxWidgets.Controls.VzxButton();
        this.btnEmerald = new VzxWidgets.Controls.VzxButton();
        this.btnOutline = new VzxWidgets.Controls.VzxButton();
        this.lblToggles = new System.Windows.Forms.Label();
        this.toggle1 = new VzxWidgets.Controls.VzxToggleSwitch();
        this.lblToggleState = new System.Windows.Forms.Label();
        this.toggle2 = new VzxWidgets.Controls.VzxToggleSwitch();
        this.lblToggleState2 = new System.Windows.Forms.Label();
        this.lblInput = new System.Windows.Forms.Label();
        this.txtUsername = new VzxWidgets.Controls.VzxTextBox();
        this.txtToken = new VzxWidgets.Controls.VzxTextBox();
        this.innerCard = new VzxWidgets.Controls.VzxCard();
        this.lblStatus = new System.Windows.Forms.Label();

        this.mainCard.SuspendLayout();
        this.innerCard.SuspendLayout();
        this.SuspendLayout();

        // 
        // mainCard
        // 
        this.mainCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(35)))));
        this.mainCard.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(75)))));
        this.mainCard.BorderRadius = 20;
        this.mainCard.BorderSize = 1;
        this.mainCard.Controls.Add(this.lblTitle);
        this.mainCard.Controls.Add(this.lblSub);
        this.mainCard.Controls.Add(this.btnPrimary);
        this.mainCard.Controls.Add(this.btnEmerald);
        this.mainCard.Controls.Add(this.btnOutline);
        this.mainCard.Controls.Add(this.lblToggles);
        this.mainCard.Controls.Add(this.toggle1);
        this.mainCard.Controls.Add(this.lblToggleState);
        this.mainCard.Controls.Add(this.toggle2);
        this.mainCard.Controls.Add(this.lblToggleState2);
        this.mainCard.Controls.Add(this.lblInput);
        this.mainCard.Controls.Add(this.txtUsername);
        this.mainCard.Controls.Add(this.txtToken);
        this.mainCard.Controls.Add(this.innerCard);
        this.mainCard.Location = new System.Drawing.Point(40, 30);
        this.mainCard.Name = "mainCard";
        this.mainCard.Padding = new System.Windows.Forms.Padding(15);
        this.mainCard.Size = new System.Drawing.Size(760, 490);
        this.mainCard.TabIndex = 0;

        // 
        // lblTitle
        // 
        this.lblTitle.AutoSize = true;
        this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
        this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
        this.lblTitle.Location = new System.Drawing.Point(25, 20);
        this.lblTitle.Name = "lblTitle";
        this.lblTitle.Size = new System.Drawing.Size(430, 30);
        this.lblTitle.TabIndex = 0;
        this.lblTitle.Text = "VzxWidgets • Suite Moderna para WinForms";

        // 
        // lblSub
        // 
        this.lblSub.AutoSize = true;
        this.lblSub.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        this.lblSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(160)))));
        this.lblSub.Location = new System.Drawing.Point(27, 55);
        this.lblSub.Name = "lblSub";
        this.lblSub.Size = new System.Drawing.Size(465, 17);
        this.lblSub.TabIndex = 1;
        this.lblSub.Text = "Controles com bordas curvas, aceleracao grafica GDI+ e anti-aliasing ativo.";

        // 
        // btnPrimary
        // 
        this.btnPrimary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(92)))), ((int)(((byte)(230)))));
        this.btnPrimary.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(90)))));
        this.btnPrimary.BorderRadius = 14;
        this.btnPrimary.BorderSize = 0;
        this.btnPrimary.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnPrimary.FlatAppearance.BorderSize = 0;
        this.btnPrimary.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnPrimary.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
        this.btnPrimary.ForeColor = System.Drawing.Color.White;
        this.btnPrimary.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(118)))), ((int)(((byte)(240)))));
        this.btnPrimary.Location = new System.Drawing.Point(30, 110);
        this.btnPrimary.Name = "btnPrimary";
        this.btnPrimary.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(68)))), ((int)(((byte)(190)))));
        this.btnPrimary.Size = new System.Drawing.Size(160, 42);
        this.btnPrimary.TabIndex = 2;
        this.btnPrimary.Text = "Botao Primario";
        this.btnPrimary.UseVisualStyleBackColor = false;

        // 
        // btnEmerald
        // 
        this.btnEmerald.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(209)))), ((int)(((byte)(88)))));
        this.btnEmerald.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(90)))));
        this.btnEmerald.BorderRadius = 14;
        this.btnEmerald.BorderSize = 0;
        this.btnEmerald.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnEmerald.FlatAppearance.BorderSize = 0;
        this.btnEmerald.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnEmerald.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
        this.btnEmerald.ForeColor = System.Drawing.Color.Black;
        this.btnEmerald.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(220)))), ((int)(((byte)(105)))));
        this.btnEmerald.Location = new System.Drawing.Point(210, 110);
        this.btnEmerald.Name = "btnEmerald";
        this.btnEmerald.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(170)))), ((int)(((byte)(70)))));
        this.btnEmerald.Size = new System.Drawing.Size(160, 42);
        this.btnEmerald.TabIndex = 3;
        this.btnEmerald.Text = "Acao Sucesso";
        this.btnEmerald.UseVisualStyleBackColor = false;

        // 
        // btnOutline
        // 
        this.btnOutline.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(35)))));
        this.btnOutline.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(69)))), ((int)(((byte)(58)))));
        this.btnOutline.BorderRadius = 14;
        this.btnOutline.BorderSize = 2;
        this.btnOutline.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnOutline.FlatAppearance.BorderSize = 0;
        this.btnOutline.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnOutline.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
        this.btnOutline.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(69)))), ((int)(((byte)(58)))));
        this.btnOutline.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(30)))), ((int)(((byte)(35)))));
        this.btnOutline.Location = new System.Drawing.Point(390, 110);
        this.btnOutline.Name = "btnOutline";
        this.btnOutline.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
        this.btnOutline.Size = new System.Drawing.Size(160, 42);
        this.btnOutline.TabIndex = 4;
        this.btnOutline.Text = "Estilo Outline";
        this.btnOutline.UseVisualStyleBackColor = false;

        // 
        // lblToggles
        // 
        this.lblToggles.AutoSize = true;
        this.lblToggles.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold);
        this.lblToggles.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
        this.lblToggles.Location = new System.Drawing.Point(30, 185);
        this.lblToggles.Name = "lblToggles";
        this.lblToggles.Size = new System.Drawing.Size(183, 19);
        this.lblToggles.TabIndex = 5;
        this.lblToggles.Text = "Interruptores Fluent / iOS:";

        // 
        // toggle1
        // 
        this.toggle1.Checked = true;
        this.toggle1.Cursor = System.Windows.Forms.Cursors.Hand;
        this.toggle1.Location = new System.Drawing.Point(30, 220);
        this.toggle1.MinimumSize = new System.Drawing.Size(40, 20);
        this.toggle1.Name = "toggle1";
        this.toggle1.OffBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(65)))));
        this.toggle1.OffToggleColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(175)))));
        this.toggle1.OnBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(92)))), ((int)(((byte)(230)))));
        this.toggle1.OnToggleColor = System.Drawing.Color.White;
        this.toggle1.Size = new System.Drawing.Size(55, 28);
        this.toggle1.TabIndex = 6;
        this.toggle1.CheckedChanged += new System.EventHandler(this.toggle1_CheckedChanged);

        // 
        // lblToggleState
        // 
        this.lblToggleState.AutoSize = true;
        this.lblToggleState.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        this.lblToggleState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(190)))));
        this.lblToggleState.Location = new System.Drawing.Point(95, 224);
        this.lblToggleState.Name = "lblToggleState";
        this.lblToggleState.Size = new System.Drawing.Size(89, 17);
        this.lblToggleState.TabIndex = 7;
        this.lblToggleState.Text = "Ativado (True)";

        // 
        // toggle2
        // 
        this.toggle2.Checked = false;
        this.toggle2.Cursor = System.Windows.Forms.Cursors.Hand;
        this.toggle2.Location = new System.Drawing.Point(230, 220);
        this.toggle2.MinimumSize = new System.Drawing.Size(40, 20);
        this.toggle2.Name = "toggle2";
        this.toggle2.OffBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(65)))));
        this.toggle2.OffToggleColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(175)))));
        this.toggle2.OnBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(209)))), ((int)(((byte)(88)))));
        this.toggle2.OnToggleColor = System.Drawing.Color.White;
        this.toggle2.Size = new System.Drawing.Size(55, 28);
        this.toggle2.TabIndex = 8;

        // 
        // lblToggleState2
        // 
        this.lblToggleState2.AutoSize = true;
        this.lblToggleState2.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        this.lblToggleState2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(190)))));
        this.lblToggleState2.Location = new System.Drawing.Point(295, 224);
        this.lblToggleState2.Name = "lblToggleState2";
        this.lblToggleState2.Size = new System.Drawing.Size(81, 17);
        this.lblToggleState2.TabIndex = 9;
        this.lblToggleState2.Text = "Modo Turbo";

        // 
        // lblInput
        // 
        this.lblInput.AutoSize = true;
        this.lblInput.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold);
        this.lblInput.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
        this.lblInput.Location = new System.Drawing.Point(30, 280);
        this.lblInput.Name = "lblInput";
        this.lblInput.Size = new System.Drawing.Size(306, 19);
        this.lblInput.TabIndex = 10;
        this.lblInput.Text = "Campos de Entrada (Placeholder e Efeito Foco):";

        // 
        // txtUsername
        // 
        this.txtUsername.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(45)))));
        this.txtUsername.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(90)))));
        this.txtUsername.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(92)))), ((int)(((byte)(230)))));
        this.txtUsername.BorderRadius = 10;
        this.txtUsername.BorderSize = 2;
        this.txtUsername.Location = new System.Drawing.Point(30, 315);
        this.txtUsername.Name = "txtUsername";
        this.txtUsername.Padding = new System.Windows.Forms.Padding(10, 8, 10, 8);
        this.txtUsername.PlaceholderText = "Digite seu nome de usuario...";
        this.txtUsername.Size = new System.Drawing.Size(320, 38);
        this.txtUsername.TabIndex = 11;
        this.txtUsername.Texts = "";

        // 
        // txtToken
        // 
        this.txtToken.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(45)))));
        this.txtToken.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(90)))));
        this.txtToken.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(209)))), ((int)(((byte)(88)))));
        this.txtToken.BorderRadius = 10;
        this.txtToken.BorderSize = 2;
        this.txtToken.Location = new System.Drawing.Point(370, 315);
        this.txtToken.Name = "txtToken";
        this.txtToken.Padding = new System.Windows.Forms.Padding(10, 8, 10, 8);
        this.txtToken.PlaceholderText = "Token de API ou chave privada...";
        this.txtToken.Size = new System.Drawing.Size(320, 38);
        this.txtToken.TabIndex = 12;
        this.txtToken.Texts = "";

        // 
        // innerCard
        // 
        this.innerCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(45)))));
        this.innerCard.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
        this.innerCard.BorderRadius = 12;
        this.innerCard.BorderSize = 1;
        this.innerCard.Controls.Add(this.lblStatus);
        this.innerCard.Location = new System.Drawing.Point(30, 380);
        this.innerCard.Name = "innerCard";
        this.innerCard.Padding = new System.Windows.Forms.Padding(15);
        this.innerCard.Size = new System.Drawing.Size(690, 80);
        this.innerCard.TabIndex = 13;

        // 
        // lblStatus
        // 
        this.lblStatus.AutoSize = true;
        this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic);
        this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(170)))), ((int)(((byte)(220)))));
        this.lblStatus.Location = new System.Drawing.Point(20, 25);
        this.lblStatus.Name = "lblStatus";
        this.lblStatus.Size = new System.Drawing.Size(534, 19);
        this.lblStatus.TabIndex = 0;
        this.lblStatus.Text = "Pronto para o Visual Studio Designer! Abra o Form1 no modo Design e veja os componentes!";

        // 
        // Form1
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(24)))));
        this.ClientSize = new System.Drawing.Size(844, 551);
        this.Controls.Add(this.mainCard);
        this.ForeColor = System.Drawing.Color.White;
        this.Name = "Form1";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "VzxWidgets - Modern UI Showcase (Estilo Guna UI)";
        this.mainCard.ResumeLayout(false);
        this.mainCard.PerformLayout();
        this.innerCard.ResumeLayout(false);
        this.innerCard.PerformLayout();
        this.ResumeLayout(false);
    }

    #endregion
}
