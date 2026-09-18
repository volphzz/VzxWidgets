using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace VzxWidgets.Controls;

public enum ToastPosition
{
    BottomRight,
    TopRight,
    BottomLeft,
    TopLeft
}

/// <summary>
/// Gerenciador central de notificações Toast integradas internamente à janela/container (Strictly Inside Menu).
/// </summary>
public static class VzxToastManager
{
    private static readonly Dictionary<Control, List<VzxToast>> _activeContainers = new();
    private static readonly object _lock = new();

    public static ToastPosition DefaultPosition { get; set; } = ToastPosition.BottomRight;
    public static int Spacing { get; set; } = 8;
    public static int MarginX { get; set; } = 18;
    public static int MarginY { get; set; } = 18;
    public static int DefaultDurationMs { get; set; } = 3500;

    /// <summary>
    /// Exibe uma notificação de sucesso (verde).
    /// </summary>
    public static void ShowSuccess(Control? parent, string title, string message, int durationMs = -1)
    {
        Show(parent, ToastType.Success, title, message, durationMs);
    }

    /// <summary>
    /// Exibe uma notificação de informação (roxo).
    /// </summary>
    public static void ShowInfo(Control? parent, string title, string message, int durationMs = -1)
    {
        Show(parent, ToastType.Info, title, message, durationMs);
    }

    /// <summary>
    /// Exibe uma notificação de aviso (laranja).
    /// </summary>
    public static void ShowWarning(Control? parent, string title, string message, int durationMs = -1)
    {
        Show(parent, ToastType.Warning, title, message, durationMs);
    }

    /// <summary>
    /// Exibe uma notificação de erro (vermelho).
    /// </summary>
    public static void ShowError(Control? parent, string title, string message, int durationMs = -1)
    {
        Show(parent, ToastType.Error, title, message, durationMs);
    }

    /// <summary>
    /// Exibe uma notificação customizada.
    /// </summary>
    public static void Show(Control? parent, ToastType type, string title, string message, int durationMs = -1)
    {
        if (durationMs <= 0) durationMs = DefaultDurationMs;

        Control? target = parent;
        if (target == null)
        {
            if (Application.OpenForms.Count > 0)
                target = Application.OpenForms[0];
            else
                return;
        }

        if (target!.InvokeRequired)
        {
            target.BeginInvoke(new Action(() => Show(target, type, title, message, durationMs)));
            return;
        }

        // Se for um Form ou qualquer controle pai
        Control container = target is Form f ? f : target;

        lock (_lock)
        {
            if (!_activeContainers.TryGetValue(container, out var list))
            {
                list = new List<VzxToast>();
                _activeContainers[container] = list;

                container.Resize += (s, e) => Reposition(container);
                container.Disposed += (s, e) =>
                {
                    lock (_lock)
                    {
                        _activeContainers.Remove(container);
                    }
                };
            }

            var toast = new VzxToast
            {
                Type = type,
                Title = title,
                Message = message,
                DurationMs = durationMs
            };

            toast.Closed += (s, e) =>
            {
                lock (_lock)
                {
                    if (s is VzxToast t)
                    {
                        list.Remove(t);
                        container.Controls.Remove(t);
                        t.Dispose();
                        Reposition(container);
                    }
                }
            };

            list.Add(toast);
            container.Controls.Add(toast);
            toast.BringToFront();

            Reposition(container, toast);
        }
    }

    private static void Reposition(Control container, VzxToast? newToast = null)
    {
        if (!_activeContainers.TryGetValue(container, out var list)) return;

        int clientW = container.ClientSize.Width;
        int clientH = container.ClientSize.Height;

        for (int i = 0; i < list.Count; i++)
        {
            var t = list[i];
            int targetX = 0;
            int targetY = 0;

            switch (DefaultPosition)
            {
                case ToastPosition.BottomRight:
                    targetX = clientW - t.Width - MarginX;
                    // O mais recente fica embaixo, empilhando pra cima
                    int offsetBR = MarginY + ((list.Count - 1 - i) * (t.Height + Spacing));
                    targetY = clientH - t.Height - offsetBR;
                    break;

                case ToastPosition.TopRight:
                    targetX = clientW - t.Width - MarginX;
                    targetY = MarginY + (i * (t.Height + Spacing));
                    break;

                case ToastPosition.BottomLeft:
                    targetX = MarginX;
                    int offsetBL = MarginY + ((list.Count - 1 - i) * (t.Height + Spacing));
                    targetY = clientH - t.Height - offsetBL;
                    break;

                case ToastPosition.TopLeft:
                    targetX = MarginX;
                    targetY = MarginY + (i * (t.Height + Spacing));
                    break;
            }

            if (t == newToast)
            {
                // Começa na borda direita dentro do menu e faz slide-in
                t.Location = new Point(clientW, targetY);
                t.StartAnimation(targetX, targetY);
            }
            else
            {
                t.SlideTo(targetX, targetY);
            }
        }
    }
}
