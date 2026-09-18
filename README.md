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
  - Cores customizáveis de estado normal, hover e clique (`HoverColor`, `PressedColor`).
  - Suporte a bordas delineadas com espessura e cor ajustáveis (`BorderSize`, `BorderColor`).
- 🎚️ **`VzxToggleSwitch`**:
  - Interruptor moderno estilo iOS / Windows 11 Fluent Design.
  - Evento nativo `CheckedChanged`.
  - Cores dinâmicas para ligado/desligado (`OnBackColor`, `OffBackColor`, `OnToggleColor`, etc.).
- 🃏 **`VzxCard`**:
  - Painel container com cantos curvos e bordas elegantes para agrupamento de widgets.
- 📝 **`VzxTextBox`**:
  - Campo de texto estilizado com suporte a placeholder automático (`PlaceholderText`).
  - Borda reativa que muda de cor ao receber foco (`BorderFocusColor`).

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
