using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace VzxWidgets.Controls;

/// <summary>
/// Gerenciador estático central de notificações Toast (Empilhamento automático, posições configuráveis e animações).
/// </summary>
public static class VzxToastManager
{
    private static readonly List<VzxToastForm> _activeToasts = new();
    private static readonly object _lock = new();

    public static ToastPosition DefaultPosition { get; set; } = ToastPosition.BottomRight;
    public static int Spacing { get; set; } = 8;
    public static int MarginX { get; set; } = 20;
    public static int MarginY { get; set; } = 20;
    public static int DefaultDurationMs { get; set; } = 3500;

    /// <summary>
    /// Exibe uma notificação de sucesso (verde).
    /// </summary>
    public static void ShowSuccess(Form? parent, string title, string message, int durationMs = -1)
    {
        Show(parent, ToastType.Success, title, message, durationMs);
    }

    /// <summary>
    /// Exibe uma notificação de informação (roxo/azul).
    /// </summary>
    public static void ShowInfo(Form? parent, string title, string message, int durationMs = -1)
    {
        Show(parent, ToastType.Info, title, message, durationMs);
    }

    /// <summary>
    /// Exibe uma notificação de aviso (laranja).
    /// </summary>
    public static void ShowWarning(Form? parent, string title, string message, int durationMs = -1)
    {
        Show(parent, ToastType.Warning, title, message, durationMs);
    }

    /// <summary>
    /// Exibe uma notificação de erro (vermelho).
    /// </summary>
    public static void ShowError(Form? parent, string title, string message, int durationMs = -1)
    {
        Show(parent, ToastType.Error, title, message, durationMs);
    }

    /// <summary>
    /// Exibe uma notificação customizada.
    /// </summary>
    public static void Show(Form? parent, ToastType type, string title, string message, int durationMs = -1)
    {
        if (durationMs <= 0) durationMs = DefaultDurationMs;

        Action action = () =>
        {
            lock (_lock)
            {
                var toast = new VzxToastForm(type, title, message, durationMs);
                
                toast.ToastClosed += (s, e) =>
                {
                    lock (_lock)
                    {
                        if (s is VzxToastForm closedToast)
                        {
                            _activeToasts.Remove(closedToast);
                            RepositionToasts(parent);
                        }
                    }
                };

                _activeToasts.Add(toast);
                RepositionToasts(parent, toast);
            }
        };

        if (parent != null && parent.InvokeRequired)
        {
            parent.BeginInvoke(action);
        }
        else if (Application.OpenForms.Count > 0 && Application.OpenForms[0]!.InvokeRequired)
        {
            Application.OpenForms[0]!.BeginInvoke(action);
        }
        else
        {
            action();
        }
    }

    private static void RepositionToasts(Form? parent, VzxToastForm? newToast = null)
    {
        // Define os limites base (tela de trabalho ou janela do parent)
        Rectangle bounds;
        if (parent != null && !parent.IsDisposed && parent.Visible)
        {
            bounds = parent.Bounds;
        }
        else
        {
            bounds = Screen.PrimaryScreen?.WorkingArea ?? new Rectangle(0, 0, 1920, 1080);
        }

        int currentY = 0;
        int targetX = 0;

        for (int i = 0; i < _activeToasts.Count; i++)
        {
            var t = _activeToasts[i];
            
            switch (DefaultPosition)
            {
                case ToastPosition.BottomRight:
                    targetX = bounds.Right - t.Width - MarginX;
                    // O mais recente fica embaixo, empilhando pra cima
                    int offsetFromBottom = MarginY + ((_activeToasts.Count - 1 - i) * (t.Height + Spacing));
                    currentY = bounds.Bottom - t.Height - offsetFromBottom;
                    break;

                case ToastPosition.TopRight:
                    targetX = bounds.Right - t.Width - MarginX;
                    currentY = bounds.Top + MarginY + (i * (t.Height + Spacing));
                    break;

                case ToastPosition.BottomLeft:
                    targetX = bounds.Left + MarginX;
                    int offsetBL = MarginY + ((_activeToasts.Count - 1 - i) * (t.Height + Spacing));
                    currentY = bounds.Bottom - t.Height - offsetBL;
                    break;

                case ToastPosition.TopLeft:
                    targetX = bounds.Left + MarginX;
                    currentY = bounds.Top + MarginY + (i * (t.Height + Spacing));
                    break;

                case ToastPosition.BottomCenter:
                    targetX = bounds.Left + (bounds.Width - t.Width) / 2;
                    int offsetBC = MarginY + ((_activeToasts.Count - 1 - i) * (t.Height + Spacing));
                    currentY = bounds.Bottom - t.Height - offsetBC;
                    break;

                case ToastPosition.TopCenter:
                    targetX = bounds.Left + (bounds.Width - t.Width) / 2;
                    currentY = bounds.Top + MarginY + (i * (t.Height + Spacing));
                    break;
            }

            if (t == newToast)
            {
                t.ShowToast(targetX, currentY);
            }
            else
            {
                t.UpdateTargetPosition(targetX, currentY);
            }
        }
    }
}
