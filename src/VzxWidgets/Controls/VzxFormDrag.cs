using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace VzxWidgets.Controls;

/// <summary>
/// Componente altamente customizável para arrastar janelas sem bordas (Borderless Form).
/// Suporta múltiplos controles vinculados, translucidez durante o arrasto,
/// duplo clique para maximizar/restaurar e controle de cursores.
/// </summary>
[ToolboxItem(true)]
public class VzxFormDrag : Component
{
    [DllImport("user32.dll")]
    private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
    [DllImport("user32.dll")]
    private static extern bool ReleaseCapture();

    private Form? _targetForm;
    private Control? _targetControl;
    private bool _enabled = true;
    private bool _maximizeOnDoubleClick = true;
    private bool _useDragOpacity = false;
    private double _dragOpacity = 0.85;
    private double _normalOpacity = 1.0;
    private Cursor _dragCursor = Cursors.SizeAll;
    private bool _changeCursorOnDrag = false;
    private Cursor _originalCursor = Cursors.Default;

    public VzxFormDrag()
    {
    }

    public VzxFormDrag(IContainer container)
    {
        container.Add(this);
    }

    [Category("VzxWidgets")]
    [DefaultValue(true)]
    [Description("Ativa ou desativa a possibilidade de arrastar a janela.")]
    public bool Enabled
    {
        get => _enabled;
        set => _enabled = value;
    }

    [Category("VzxWidgets")]
    [Description("Formulário que será movido. Se não for especificado, será detectado automaticamente a partir do controle.")]
    public Form? TargetForm
    {
        get => _targetForm;
        set => _targetForm = value;
    }

    [Category("VzxWidgets")]
    [Description("Controle principal que responderá ao clique e arrasto (ex: TopBar, HeaderPanel, Label de título).")]
    public Control? TargetControl
    {
        get => _targetControl;
        set
        {
            if (_targetControl != null)
            {
                UnbindControl(_targetControl);
            }
            _targetControl = value;
            if (_targetControl != null)
            {
                BindControl(_targetControl);
            }
        }
    }

    [Category("VzxWidgets")]
    [DefaultValue(true)]
    [Description("Permite maximizar ou restaurar a janela dando duplo clique no controle de arrasto.")]
    public bool MaximizeOnDoubleClick
    {
        get => _maximizeOnDoubleClick;
        set => _maximizeOnDoubleClick = value;
    }

    [Category("VzxWidgets")]
    [DefaultValue(false)]
    [Description("Se ativado, torna a janela levemente translúcida/transparente enquanto está sendo arrastada.")]
    public bool UseDragOpacity
    {
        get => _useDragOpacity;
        set => _useDragOpacity = value;
    }

    [Category("VzxWidgets")]
    [DefaultValue(0.85)]
    [Description("Nível de opacidade da janela durante o arrasto (de 0.1 a 1.0).")]
    public double DragOpacity
    {
        get => _dragOpacity;
        set => _dragOpacity = Math.Clamp(value, 0.1, 1.0);
    }

    [Category("VzxWidgets")]
    [DefaultValue(false)]
    [Description("Altera o cursor do mouse para SizeAll ou Hand enquanto arrasta.")]
    public bool ChangeCursorOnDrag
    {
        get => _changeCursorOnDrag;
        set => _changeCursorOnDrag = value;
    }

    /// <summary>
    /// Vincula múltiplos controles adicionais para também permitirem arrastar a janela (ex: Labels, PictureBoxes no topo).
    /// </summary>
    public void AddDragControl(Control control)
    {
        BindControl(control);
    }

    public void RemoveDragControl(Control control)
    {
        UnbindControl(control);
    }

    private void BindControl(Control c)
    {
        c.MouseDown += Control_MouseDown;
        c.MouseUp += Control_MouseUp;
        if (_maximizeOnDoubleClick)
        {
            c.DoubleClick += Control_DoubleClick;
        }
    }

    private void UnbindControl(Control c)
    {
        c.MouseDown -= Control_MouseDown;
        c.MouseUp -= Control_MouseUp;
        c.DoubleClick -= Control_DoubleClick;
    }

    private void Control_MouseDown(object? sender, MouseEventArgs e)
    {
        if (!_enabled || e.Button != MouseButtons.Left) return;

        var sourceControl = sender as Control;
        var form = _targetForm ?? sourceControl?.FindForm();
        if (form == null) return;

        if (_useDragOpacity)
        {
            _normalOpacity = form.Opacity;
            form.Opacity = _dragOpacity;
        }

        if (_changeCursorOnDrag && sourceControl != null)
        {
            _originalCursor = sourceControl.Cursor;
            sourceControl.Cursor = _dragCursor;
        }

        ReleaseCapture();
        SendMessage(form.Handle, 0xA1, 0x2, 0); // WM_NCLBUTTONDOWN + HT_CAPTION

        // Após o término da mensagem síncrona do Windows (mouse solto)
        ResetFormState(form, sourceControl);
    }

    private void Control_MouseUp(object? sender, MouseEventArgs e)
    {
        var sourceControl = sender as Control;
        var form = _targetForm ?? sourceControl?.FindForm();
        if (form != null)
        {
            ResetFormState(form, sourceControl);
        }
    }

    private void ResetFormState(Form form, Control? control)
    {
        if (_useDragOpacity)
        {
            form.Opacity = _normalOpacity;
        }
        if (_changeCursorOnDrag && control != null)
        {
            control.Cursor = _originalCursor;
        }
    }

    private void Control_DoubleClick(object? sender, EventArgs e)
    {
        if (!_enabled || !_maximizeOnDoubleClick) return;

        var form = _targetForm ?? (sender as Control)?.FindForm();
        if (form != null)
        {
            form.WindowState = form.WindowState == FormWindowState.Maximized 
                ? FormWindowState.Normal 
                : FormWindowState.Maximized;
        }
    }
}
