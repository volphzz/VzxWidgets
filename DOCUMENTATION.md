# 📚 Documentação Técnica Completa - VzxWidgets (v1.1.0)

Guia definitivo de configuração, propriedades, eventos e exemplos práticos para todos os componentes da biblioteca **VzxWidgets**.

---

## 🎨 Índice de Componentes
1. [VzxForm (Janela Sem Bordas com Cantos Arredondados e Sombra)](#1-vzxform)
2. [VzxFormDrag (Arrastar Janela)](#2-vzxformdrag)
3. [VzxToastManager & VzxToast (Sistema de Notificações Internas)](#3-vzxtoastmanager--vzxtoast)
4. [VzxButton (Botão com Gradiente e Abas)](#4-vzxbutton)
5. [VzxCheckBox (Caixa de Seleção com Vetor Animado)](#5-vzxcheckbox)
6. [VzxToggleSwitch (Interruptor Fluent / iOS Deslizante)](#6-vzxtoggleswitch)
7. [VzxTrackBar (Slider Gamer com Thumb Dinâmico)](#7-vzxtrackbar)
8. [VzxProgressBar (Barra de Progresso com Gradiente)](#8-vzxprogressbar)
9. [VzxCard (Container Dark com Borda Suave)](#9-vzxcard)
10. [VzxColorButton & VzxColorPickerPopup (Seletor HSV)](#10-vzxcolorbutton)
11. [VzxKeybind (Capturador de Teclas e Botões de Mouse)](#11-vzxkeybind)
12. [VzxEspPreview (Simulador de ESP 2D / Esqueleto de Jogador)](#12-vzxesppreview)
13. [VzxComboBox (Dropdown Estilizado)](#13-vzxcombobox)
14. [VzxDotHeader (Título de Seção com Halo Neon Pulsante)](#14-vzxdotheader)
15. [VzxControlBox (Fechar e Minimizar Minimalistas)](#15-vzxcontrolbox)
16. [VzxTextBox (Campo de Texto com Placeholder)](#16-vzxtextbox)
17. [VzxSeparator (Linha Divisória com Fade)](#17-vzxseparator)

---

## 1. VzxForm
Formulário borderless nativo de alta performance com cantos curvos individuais, drop shadow via DWM (Desktop Window Manager) do Windows e redimensionamento por bordas (`WM_NCHITTEST`).

### ⚙️ Propriedades Principais
| Propriedade | Tipo | Padrão | Descrição |
|---|---|---|---|
| `BorderRadius` | `int` | `14` | Raio geral dos cantos arredondados. |
| `RoundTopLeft` | `bool` | `true` | Habilita canto superior esquerdo curvo. |
| `RoundTopRight` | `bool` | `true` | Habilita canto superior direito curvo. |
| `RoundBottomLeft`| `bool` | `true` | Habilita canto inferior esquerdo curvo. |
| `RoundBottomRight`| `bool` | `true` | Habilita canto inferior direito curvo. |
| `BorderSize` | `int` | `1` | Espessura da borda da janela. |
| `BorderColor` | `Color`| `#2D2D3E` | Cor da borda externa. |
| `HasDropShadow` | `bool` | `true` | Ativa sombra nativa do Windows ao redor da janela. |
| `EnableResize` | `bool` | `true` | Permite arrastar as bordas com o cursor para redimensionar. |

### 💻 Exemplo de Implementação:
```csharp
using VzxWidgets.Controls;

public partial class MainForm : VzxForm
{
    public MainForm()
    {
        InitializeComponent();
        BorderRadius = 16;
        BorderSize = 1;
        BorderColor = Color.FromArgb(45, 45, 62);
        HasDropShadow = true;
        BackColor = Color.FromArgb(8, 8, 10);
    }
}
```

---

## 2. VzxFormDrag
Componente não-visual para arrastar janelas borderless com duplo clique para maximizar/restaurar e ajuste dinâmico de opacidade durante o arraste.

### ⚙️ Propriedades Principais
| Propriedade | Tipo | Descrição |
|---|---|---|
| `TargetForm` | `Form` | O formulário que será movido. |
| `TargetControl` | `Control` | O controle gatilho do arraste (ex: `topBar` ou painel do título). |
| `EnableDoubleClickMaximize` | `bool` | Permite maximizar com 2 cliques rápidos (padrão: `true`). |
| `DragOpacity` | `double` | Opacidade da janela durante o arraste (ex: `0.95`). |

### 💻 Exemplo de Implementação:
```csharp
formDrag.TargetForm = this;
formDrag.TargetControl = topBar;
formDrag.EnableDoubleClickMaximize = false;
```

---

## 3. VzxToastManager & VzxToast
Sistema de notificações empilhadas dinamicamente **100% contidas dentro da janela do menu**, com animação suave de slide-in, barra de tempo no rodapé, pausa ao passar o mouse (`Hover Pause`) e fechamento animado.

### ⚙️ Métodos do `VzxToastManager`
```csharp
// 🟢 Notificação de Sucesso (Verde)
VzxToastManager.ShowSuccess(this, "Título", "Mensagem descritiva", durationMs: 3500);

// 🟣 Notificação Informativa (#BBC8FE)
VzxToastManager.ShowInfo(this, "Configuração", "Perfil salvo com sucesso.");

// 🟠 Notificação de Alerta (Laranja)
VzxToastManager.ShowWarning(this, "Aviso", "Memória em 80%.");

// 🔴 Notificação de Erro (Vermelho)
VzxToastManager.ShowError(this, "Falha", "Não foi possível conectar ao driver.");
```

### ⚙️ Configurações Globais
| Configuração | Padrão | Descrição |
|---|---|---|
| `VzxToastManager.DefaultPosition` | `BottomRight` | Posição no menu (`BottomRight`, `TopRight`, `BottomLeft`, `TopLeft`). |
| `VzxToastManager.Spacing` | `8` | Espaçamento vertical entre notificações na pilha. |
| `VzxToastManager.MarginX` | `18` | Distância da borda lateral do formulário. |
| `VzxToastManager.MarginY` | `18` | Distância da borda vertical do formulário. |
| `VzxToastManager.DefaultDurationMs` | `3500` | Tempo de exibição em milissegundos. |

---

## 4. VzxButton
Botão avançado com gradiente suave em duas cores, ângulo ajustável, barra lateral de aba ativa (`ShowActiveIndicator`), hover fade com interpolação de cores e cantos curvos.

### ⚙️ Propriedades Principais
| Propriedade | Tipo | Padrão | Descrição |
|---|---|---|---|
| `BorderRadius` | `int` | `12` | Raio dos cantos arredondados. |
| `BorderSize` | `int` | `0` | Espessura da borda. |
| `BorderColor` | `Color` | `#46465A` | Cor da borda. |
| `UseGradient` | `bool` | `false` | Habilita gradiente de 2 cores. |
| `GradientEndColor`| `Color` | `#91A5F5` | Cor secundária do gradiente. |
| `GradientAngle` | `float` | `45f` | Ângulo de inclinação do gradiente. |
| `HoverColor` | `Color` | `#CDD7FF` | Cor alvo na transição suave de hover. |
| `PressedColor` | `Color` | `#91A0EB` | Cor enquanto pressionado. |
| `ShowActiveIndicator` | `bool` | `false` | Exibe uma barra lateral neon (estilo aba/categoria ativa). |
| `ActiveIndicatorColor`| `Color` | `#BBC8FE` | Cor da barra lateral indicadora. |

### 💻 Exemplo de Implementação:
```csharp
var btnAimbotTab = new VzxButton
{
    Text = "Aimbot",
    Size = new Size(180, 40),
    BorderRadius = 8,
    BackColor = Color.FromArgb(22, 22, 30),
    ForeColor = Color.White,
    ShowActiveIndicator = true,
    ActiveIndicatorColor = Color.FromArgb(187, 200, 254)
};
```

---

## 5. VzxCheckBox
Caixa de seleção com cantos suaves, fundo escuro, desenho vetorial animado do checkmark e dimensionamento automático de texto (`AutoSize` sem truncar).

### ⚙️ Propriedades Principais
| Propriedade | Tipo | Padrão | Descrição |
|---|---|---|---|
| `Checked` | `bool` | `false` | Estado marcado / desmarcado. |
| `CheckedColor` | `Color` | `#BBC8FE` | Cor do fundo e vetor quando marcado. |
| `UncheckedColor` | `Color` | `#2D2D3A` | Cor de fundo quando desmarcado. |
| `BoxBorderColor` | `Color` | `#464658` | Cor da borda do quadrado. |
| `BoxBorderRadius`| `int` | `5` | Raio dos cantos da caixa. |

### 💻 Exemplo de Implementação:
```csharp
chkEspBox.CheckedColor = Color.FromArgb(187, 200, 254);
chkEspBox.CheckedChanged += (s, e) =>
{
    espPreview.ShowBox = chkEspBox.Checked;
};
```

---

## 6. VzxToggleSwitch
Interruptor moderno com animação contínua de deslizamento (60 FPS) e interpolação de cor de fundo (`Color.Lerp`).

### ⚙️ Propriedades Principais
| Propriedade | Tipo | Padrão | Descrição |
|---|---|---|---|
| `Checked` | `bool` | `false` | Estado ligado / desligado. |
| `OnBackColor` | `Color` | `#BBC8FE` | Cor do fundo ligado. |
| `OnToggleColor`| `Color` | `#12121A` | Cor do círculo móvel ligado. |
| `OffBackColor` | `Color` | `#2D2D3C` | Cor do fundo desligado. |
| `OffToggleColor`| `Color`| `#A0A0AF` | Cor do círculo móvel desligado. |

### 💻 Exemplo de Implementação:
```csharp
vzxToggle.CheckedChanged += (s, e) =>
{
    Console.WriteLine($"Status: {vzxToggle.Checked}");
};
```

---

## 7. VzxTrackBar (Seekbar / Slider)
Slider com pista fina, trilha ativa em destaque, animação de escala do botão (+35% em hover/drag) com aura de glow neon.

### ⚙️ Propriedades Principais
| Propriedade | Tipo | Padrão | Descrição |
|---|---|---|---|
| `Minimum` | `int` | `0` | Valor mínimo. |
| `Maximum` | `int` | `100` | Valor máximo. |
| `Value` | `int` | `50` | Valor atual do slider. |
| `ProgressColor` | `Color` | `#BBC8FE` | Cor da trilha percorrida e borda do thumb. |
| `TrackColor` | `Color` | `#282834` | Cor da pista inativa. |
| `ThumbColor` | `Color` | `White` | Cor do preenchimento interno do thumb. |
| `ShowDiamondThumb` | `bool`| `true` | Formato diamante moderno (`true`) ou circular (`false`). |
| `TrackHeight` | `int` | `6` | Espessura da linha do slider. |
| `ThumbSize` | `int` | `12` | Tamanho base do marcador. |

### 💻 Exemplo de Implementação:
```csharp
trackDist.Minimum = 10;
trackDist.Maximum = 300;
trackDist.Value = 150;
trackDist.ValueChanged += (s, e) =>
{
    lblDist.Text = $"{trackDist.Value}m";
};
```

---

## 8. VzxProgressBar
Barra de progresso curva com suporte a gradiente horizontal de preenchimento e percentual textual centralizado.

### ⚙️ Propriedades Principais
| Propriedade | Tipo | Padrão | Descrição |
|---|---|---|---|
| `Minimum` | `int` | `0` | Valor mínimo. |
| `Maximum` | `int` | `100` | Valor máximo. |
| `Value` | `int` | `65` | Valor atual. |
| `StartColor` | `Color` | `#BBC8FE` | Cor inicial do gradiente de preenchimento. |
| `EndColor` | `Color` | `#91A5F5` | Cor final do gradiente de preenchimento. |
| `BackColorTrack`| `Color` | `#232330` | Cor de fundo da trilha. |
| `BorderRadius` | `int` | `8` | Raio dos cantos arredondados. |
| `ShowPercentage`| `bool` | `true` | Exibe o texto "X%" no centro da barra. |

---

## 9. VzxCard
Painel container dark profundo com cantos curvos isolados (`Region` otimizada no resize) que organiza widgets sem ghosting ou flickering.

### ⚙️ Propriedades Principais
| Propriedade | Tipo | Padrão | Descrição |
|---|---|---|---|
| `BorderRadius` | `int` | `14` | Raio dos cantos curvos. |
| `BorderSize` | `int` | `1` | Espessura da borda. |
| `BorderColor` | `Color` | `#1C1C24` | Cor sutil da borda. |
| `BackColor` | `Color` | `#0E0E12` | Cor de fundo do cartão. |
| `Padding` | `Padding` | `14, 14, 14, 14` | Margem interna para os controles filhos. |

---

## 10. VzxColorButton
Botão seletor de cor com popup popover moderno estilo Figma (Matriz 2D Sat/Val, barra Hue arco-íris, slider Alpha de opacidade e caixa Hex).

### ⚙️ Propriedades e Eventos
| Membro | Tipo | Descrição |
|---|---|---|
| `SelectedColor` | `Color` | Cor atualmente selecionada. |
| `BorderRadius` | `int` | Raio dos cantos do botão quadrado. |
| `ColorChanged` | `event EventHandler` | Disparado imediatamente ao escolher uma nova cor no picker. |

### 💻 Exemplo de Implementação:
```csharp
colEspBox.SelectedColor = Color.White;
colEspBox.ColorChanged += (s, e) =>
{
    espPreview.BoxColor = colEspBox.SelectedColor;
};
```

---

## 11. VzxKeybind
Capturador de atalhos de teclado e botões de mouse para menus de jogos. Exibe efeito de pulso luminoso ("breathing pulse") em `#BBC8FE` enquanto aguarda a tecla.

### ⚙️ Propriedades e Eventos
| Membro | Tipo | Descrição |
|---|---|---|
| `CurrentKey` | `Keys` | Tecla ou botão de mouse vinculado. |
| `ActiveBorderColor` | `Color` | Cor da borda e texto pulsante durante a captura (`#BBC8FE`). |
| `KeyChanged` | `event EventHandler` | Disparado assim que uma nova tecla ou botão é registrado. |

### 🖱️ Botões e Teclas Suportados:
- **Teclado**: Todas as teclas (Letras, Números, `F1-F24`, `Tab`, `Caps`, `Shift`, `Ctrl`, `Alt`, `Space`, `Enter`, `Esc`, `Insert`, `Delete`, `PgUp`, `PgDn`, `Setas`).
- **Mouse**: `Mouse 1` (LButton), `Mouse 2` (RButton), `Mouse 3` (Scroll/MButton), `Mouse 4` (XButton1), `Mouse 5` (XButton2).
- **Limpar**: Pressionar `Escape` redefine para `[ None ]`.

### 💻 Exemplo de Implementação:
```csharp
keyOpenMenu.CurrentKey = Keys.Insert;
keyOpenMenu.KeyChanged += (s, e) =>
{
    string nomeLegivel = VzxKeybind.FormatKeyName(keyOpenMenu.CurrentKey);
    VzxToastManager.ShowInfo(this, "Atalho", $"Menu reconfigurado para: {nomeLegivel}");
};
```

---

## 12. VzxEspPreview
Simulador 2D interativo de Player ESP (Box, Skeleton, Snapline, Health Bar, Tags de Nome e Distância) com animação suave de respiração (ciclo senoidal).

### ⚙️ Propriedades Principais
| Categoria | Propriedade | Tipo | Descrição |
|---|---|---|---|
| **Box** | `ShowBox` | `bool` | Exibe a caixa 2D ao redor do jogador. |
| **Box** | `ShowFillBox` | `bool` | Exibe o preenchimento translúcido interno da caixa. |
| **Box** | `BoxColor` | `Color` | Cor da linha da caixa. |
| **Box** | `FillBoxColor` | `Color` | Cor do preenchimento da caixa. |
| **Esqueleto** | `ShowSkeleton` | `bool` | Exibe as conexões ósseas do player. |
| **Esqueleto** | `SkeletonColor` | `Color` | Cor dos ossos. |
| **Linha** | `ShowSnapline` | `bool` | Exibe a linha de mira (Snapline). |
| **Linha** | `SnaplineColor` | `Color` | Cor da snapline. |
| **Linha** | `LineOrigin` | `SnaplineOrigin` | Origem da snapline (`Top`, `Center`, `Bottom`). |
| **Vida** | `ShowHealthBar` | `bool` | Exibe a barra de vida lateral com gradiente. |
| **Vida** | `HealthValue` | `int` | Valor de vida (0 a 100). |
| **Tags** | `ShowName` / `PlayerName` | `bool` / `string` | Tag de nome acima do player. |
| **Tags** | `ShowDistance` / `DistanceText` | `bool` / `string` | Tag de distância do alvo (ex: "50m"). |
| **Animação** | `AnimatedPreview` | `bool` | Ativa movimento suave contínuo de respiração do esqueleto. |

### 💻 Exemplo de Implementação:
```csharp
espPreview.ShowBox = true;
espPreview.ShowSkeleton = true;
espPreview.ShowSnapline = true;
espPreview.LineOrigin = VzxEspPreview.SnaplineOrigin.Bottom;
espPreview.DistanceText = "85m";
espPreview.BoxColor = Color.FromArgb(187, 200, 254);
```

---

## 13. VzxComboBox
Dropdown customizado estilo Dark Minimalist com indicador chevron vetorial e popup estilizado.

### ⚙️ Propriedades Principais
| Propriedade | Tipo | Padrão | Descrição |
|---|---|---|---|
| `BorderFocusColor` | `Color` | `#BBC8FE` | Cor da borda quando aberto. |
| `ArrowColor` | `Color` | `#BBC8FE` | Cor da setinha indicadora. |
| `BorderRadius` | `int` | `8` | Arredondamento do campo. |
| `SelectedIndex` | `int` | `-1` | Índice do item selecionado. |
| `SelectedIndexChanged` | `event` | - | Evento de alteração de item. |

---

## 14. VzxDotHeader
Título de cabeçalho de seção com ponto indicador neon acompanhado de um halo de luz pulsante contínuo.

### ⚙️ Propriedades Principais
| Propriedade | Tipo | Padrão | Descrição |
|---|---|---|---|
| `Text` | `string` | `"Seção"` | Texto do título. |
| `DotColor` | `Color` | `#BBC8FE` | Cor do ponto e do halo pulsante. |
| `TextColor` | `Color` | `#DCDCEB` | Cor da tipografia. |
| `DotSize` | `int` | `7` | Diâmetro do ponto em pixels. |
| `PulseGlow` | `bool` | `true` | Ativa/desativa a respiração luminosa ao redor do ponto. |

---

## 15. VzxControlBox
Botões de controle de janela com renderização anti-aliased para fechar, minimizar ou maximizar janelas borderless.

### ⚙️ Propriedades Principais
| Propriedade | Tipo | Descrição |
|---|---|---|
| `BoxType` | `ControlBoxType` | `Close`, `Minimize` ou `Maximize`. |
| `IconColor` | `Color` | Cor do ícone em repouso (`#A0A0B4`). |
| `HoverColor` | `Color` | Cor de destaque no hover (ex: vermelho `#FF3C32` para Close). |

---

## 16. VzxTextBox
Campo de texto com bordas arredondadas, iluminação no foco do cursor e suporte a placeholder automático.

### ⚙️ Propriedades Principais
| Propriedade | Tipo | Descrição |
|---|---|---|
| `PlaceholderText` | `string` | Texto dica enquanto o campo está vazio. |
| `BorderFocusColor` | `Color` | Cor da borda durante a digitação (`#BBC8FE`). |
| `BorderRadius` | `int` | Cantos curvos do campo. |
| `PasswordChar` | `bool` | Oculta os caracteres para digitação de senhas/chaves. |

---

## 17. VzxSeparator
Linha divisória horizontal ou vertical com desvanecimento suave transparente nas extremidades (`FadeEdges`).

### ⚙️ Propriedades Principais
| Propriedade | Tipo | Descrição |
|---|---|---|
| `LineColor` | `Color` | Cor da linha divisória. |
| `FadeEdges` | `bool` | Aplica fade suave nas duas pontas da linha. |
| `IsVertical` | `bool` | Alterna entre divisória horizontal ou vertical. |
| `Thickness` | `int` | Espessura do traço em pixels. |

---

## 📦 Como Instalar e Usar no Projeto

Adicione o pacote ao seu projeto C#:
```powershell
dotnet add package VzxWidgets
```
Todos os componentes são registrados automaticamente na **Toolbox** do Visual Studio e podem ser arrastados diretamente para o formulário.
