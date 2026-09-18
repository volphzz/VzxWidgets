# 🚀 VzxWidgets

Uma biblioteca moderna de componentes WinForms (.NET 8.0 Windows) inspirada em soluções como **Guna UI** e **Bunifu**, desenvolvida para transformar interfaces clássicas do Windows em designs modernos, fluidos e elegantes.

![.NET](https://img.shields.io/badge/.NET-8.0--windows-purple.svg)
![License](https://img.shields.io/badge/license-MIT-blue.svg)
![NuGet](https://img.shields.io/badge/nuget-v1.0.0-orange.svg)

---

## ✨ Recursos

- 🎨 **Renderização Anti-Aliased de Alta Precisão**: Curvas suaves sem serrilhados através de GDI+ com double-buffering nativo (zero cintilação/flickering).
- 🔘 **`VzxButton`**:
  - Cantos arredondados configuráveis (`BorderRadius`).
  - Suporte a **Gradientes de Duas Cores** com ângulo ajustável (`UseGradient`, `GradientEndColor`, `GradientAngle`).
  - Indicador lateral de aba ativa (`ShowActiveIndicator`, `ActiveIndicatorColor`) perfeito para menus estilo Dark Gaming / Cheat UI.
  - Cores customizáveis de hover e press.
- 🎚️ **`VzxTrackBar` (Seekbar / Slider Gamer)**:
  - Controle deslizante com pista fina, trilha ativa em gradiente e "thumb" estilo diamante ou circular.
  - Totalmente compatível com evento `ValueChanged`.
- ☑️ **`VzxCheckBox`**:
  - Caixa de seleção moderna com cantos arredondados, fundo escuro e checkmark animado em laranja/neon.
- 📊 **`VzxProgressBar`**:
  - Barra de progresso curva com suporte a gradiente horizontal e exibição de porcentagem centralizada.
- ➖ **`VzxSeparator`**:
  - Linha divisória com desvanecimento suave nas pontas (`FadeEdges`) horizontal ou vertical.
- 🔽 **`VzxComboBox` (Dropdown Dark)**:
  - Dropdown totalmente estilizado em tema escuro com setinha minimalista e seleção customizada.
- 🛑 **`VzxControlBox`**:
  - Botões minimalistas de Fechar, Minimizar e Maximizar para formulários sem bordas.
- 🖱️ **`VzxFormDrag`**:
  - Componente que permite arrastar formulários sem bordas (`FormBorderStyle.None`) clicando em qualquer painel.
- 🎛️ **`VzxToggleSwitch`**:
  - Interruptor moderno estilo iOS / Windows 11 Fluent Design.
- 🃏 **`VzxCard`**:
  - Painel container com cantos curvos e bordas elegantes para agrupamento de widgets.
- 👁️ **`VzxEspPreview`**:
  - Visualizador 2D interativo e animado de Player ESP (Box, Skeleton, Head, Health Bar, Linhas, Distância e Nome) com respiração/animação contínua e customização total de cores e visibilidade.
- 🪟 **`VzxForm`**:
  - Janela moderna sem bordas com cantos arredondados independentes (`RoundTopLeft`, `RoundTopRight`, `RoundBottomLeft`, `RoundBottomRight`), drop shadow nativo via DWM e redimensionamento por bordas.
- 🎨 **`VzxColorButton`**:
  - Botão seletor de cor com preview quadrado e popup popover moderno com canvas Sat/Val, barra Hue, Alpha e Hex input.
- ⌨️ **`VzxKeybind`**:
  - Capturador elegante de atalhos de teclado com visual escuro minimalista.
- 🟣 **`VzxDotHeader`**:
  - Título de seção com ponto indicador neon e tipografia elegante.
- 🔔 **`VzxToastManager` & `VzxToast`**:
  - Sistema global de notificações flutuantes tipo Windows 11 / Cheat UI:
    - Chamada simples: `VzxToastManager.ShowSuccess(this, "ESP", "Ativado!");`
    - Empilhamento automático (BottomRight, TopRight, etc.), animação suave de slide-in e fade-out.
    - Temporizador com barra de tempo inferior, pausa ao passar o mouse (`Hover Pause`) e fechamento manual com clique.
- 📝 **`VzxTextBox`**:
  - Campo de texto estilizado com suporte a placeholder automático (`PlaceholderText`) e borda iluminada.

---

## 📦 Instalação via NuGet

Quando publicado, instale facilmente no seu projeto WinForms:

```bash
dotnet add package VzxWidgets
```

Ou pelo Gerenciador de Pacotes do Visual Studio:
```powershell
Install-Package VzxWidgets
```

---

## 🛠️ Como Usar no Visual Studio

1. Abra a sua aplicação Windows Forms no Visual Studio.
2. Adicione a referência ao **VzxWidgets** via NuGet ou adicione a `.dll` na sua **Caixa de Ferramentas (Toolbox)**:
   - Clique com o botão direito na Toolbox -> *Escolher Itens...* -> Selecione `VzxWidgets.dll`.
3. Arraste os controles (`VzxButton`, `VzxToggleSwitch`, `VzxCard`, `VzxTextBox`) diretamente para a tela de design!

### Exemplo em Código C#:

```csharp
using VzxWidgets.Controls;

// Criando um botão moderno
var btn = new VzxButton
{
    Text = "Acessar Sistema",
    Size = new Size(160, 45),
    BorderRadius = 14,
    BackColor = Color.FromArgb(94, 92, 230),
    HoverColor = Color.FromArgb(120, 118, 240)
};

// Criando um toggle switch estilo iOS
var toggle = new VzxToggleSwitch
{
    Checked = true,
    OnBackColor = Color.FromArgb(48, 209, 88)
};
```

---

## 🚀 Publicação no GitHub e NuGet

O repositório já inclui workflow automatizado do GitHub Actions em `.github/workflows/publish.yml`. Para publicar automaticamente no [NuGet.org](https://www.nuget.org):
1. Suba o código para o GitHub.
2. Crie uma API Key no NuGet.org e adicione nos Segredos do seu repositório GitHub com o nome `NUGET_API_KEY`.
3. Toda release ou push com tag `v*` publicará o pacote automaticamente.

---

## 📜 Licença

Distribuído sob a licença MIT. Veja `LICENSE` para mais detalhes.
Criado por **VOLPHX**.
