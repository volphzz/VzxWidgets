using System;
using System.Drawing;
using System.Windows.Forms;
using VzxWidgets.Controls;

namespace VzxWidgets.Demo;

public partial class Form1 : VzxForm
{
    public Form1()
    {
        InitializeComponent();
        BorderRadius = 16;
        BorderSize = 1;
        BorderColor = Color.FromArgb(45, 45, 62);
        HasDropShadow = true;

        SetupFullEvents();
    }

    private void SetupFullEvents()
    {
        // 1. TopBar & Drag
        if (formDrag != null)
        {
            formDrag.TargetControl = topBar;
            formDrag.TargetForm = this;
        }

        btnClose.Click += (s, e) => Close();
        btnMin.Click += (s, e) => WindowState = FormWindowState.Minimized;

        // 2. Funções (Aimbot / Silent)
        chkAimbot.CheckedChanged += (s, e) =>
        {
            if (chkAimbot.Checked)
                VzxToastManager.ShowSuccess(this, "Aimbot", "Aimbot calibrado e ativo!");
            else
                VzxToastManager.ShowInfo(this, "Aimbot", "Aimbot desativado.");
        };

        chkSilent.CheckedChanged += (s, e) =>
        {
            if (chkSilent.Checked)
                VzxToastManager.ShowWarning(this, "Silent Aim", "Silent Aim ativado. Use com cautela!");
            else
                VzxToastManager.ShowInfo(this, "Silent Aim", "Silent Aim desativado.");
        };

        btnTestToasts.Click += (s, e) =>
        {
            VzxToastManager.ShowSuccess(this, "ESP Box", "Caixas 2D renderizadas com sucesso.");
            VzxToastManager.ShowInfo(this, "Informação", "Configuração salva no perfil padrão.");
            VzxToastManager.ShowWarning(this, "Aviso de Segurança", "Taxa de polling elevada (1000Hz).");
            VzxToastManager.ShowError(this, "Driver Error", "Falha de comunicação com o dispositivo!");
        };

        // 3. Visual & EspPreview
        chkEspBox.CheckedChanged += (s, e) =>
        {
            if (espPreview != null) espPreview.ShowBox = chkEspBox.Checked;
            if (chkEspBox.Checked)
                VzxToastManager.ShowSuccess(this, "ESP Box", "ESP Box ativado com sucesso.");
            else
                VzxToastManager.ShowInfo(this, "ESP Box", "ESP Box desativado.");
        };

        colEspBox.ColorChanged += (s, e) =>
        {
            if (espPreview != null) espPreview.BoxColor = colEspBox.SelectedColor;
        };

        chkEspFill.CheckedChanged += (s, e) =>
        {
            if (espPreview != null) espPreview.ShowFillBox = chkEspFill.Checked;
        };

        colEspFill.ColorChanged += (s, e) =>
        {
            if (espPreview != null) espPreview.FillBoxColor = colEspFill.SelectedColor;
        };

        chkEspLine.CheckedChanged += (s, e) =>
        {
            if (espPreview != null) espPreview.ShowSnapline = chkEspLine.Checked;
        };

        colEspLine.ColorChanged += (s, e) =>
        {
            if (espPreview != null) espPreview.SnaplineColor = colEspLine.SelectedColor;
        };

        chkEspName.CheckedChanged += (s, e) =>
        {
            if (espPreview != null) espPreview.ShowName = chkEspName.Checked;
        };

        colEspName.ColorChanged += (s, e) =>
        {
            if (espPreview != null) espPreview.NameColor = colEspName.SelectedColor;
        };

        chkEspHealth.CheckedChanged += (s, e) =>
        {
            if (espPreview != null) espPreview.ShowHealthBar = chkEspHealth.Checked;
        };

        chkEspSkeleton.CheckedChanged += (s, e) =>
        {
            if (espPreview != null) espPreview.ShowSkeleton = chkEspSkeleton.Checked;
        };

        colEspSkeleton.ColorChanged += (s, e) =>
        {
            if (espPreview != null) espPreview.SkeletonColor = colEspSkeleton.SelectedColor;
        };

        // Dropdown de posição da linha
        cmbEspPos.Items.Clear();
        cmbEspPos.Items.Add("Top");
        cmbEspPos.Items.Add("Bottom");
        cmbEspPos.SelectedIndex = 1;
        cmbEspPos.SelectedIndexChanged += (s, e) =>
        {
            if (espPreview != null)
            {
                espPreview.LineOrigin = cmbEspPos.SelectedIndex == 0
                    ? VzxEspPreview.SnaplineOrigin.Top
                    : VzxEspPreview.SnaplineOrigin.Bottom;
            }
        };

        // Slider Max Distance
        trackMaxDist.ValueChanged += (s, e) =>
        {
            lblMaxDistVal.Text = $"{trackMaxDist.Value}m";
            if (espPreview != null)
            {
                espPreview.DistanceText = $"{trackMaxDist.Value}m";
            }
        };

        // Outros
        chkConectado.CheckedChanged += (s, e) =>
        {
            lblStatusVal.Text = chkConectado.Checked ? "Online" : "Offline";
            lblStatusVal.ForeColor = chkConectado.Checked ? Color.FromArgb(48, 209, 88) : Color.FromArgb(255, 69, 58);
            if (chkConectado.Checked)
                VzxToastManager.ShowSuccess(this, "Status", "Dispositivo conectado via ADB.");
            else
                VzxToastManager.ShowError(this, "Status", "Dispositivo desconectado!");
        };

        keyOpenMenu.KeyChanged += (s, e) =>
        {
            VzxToastManager.ShowInfo(this, "Keybind", $"Menu atalho alterado para: {VzxKeybind.FormatKeyName(keyOpenMenu.CurrentKey)}");
        };
    }
}
