# 📡 Software Radar API

> 🌐 **Language / Idioma:** 🇧🇷 Português | [🇪🇸 Español](README-ES.md) | [🇺🇸 English](README.md)

Uma API REST construída com **ASP.NET Core** que escaneia e retorna todos os programas instalados em uma máquina Windows — via Registro do sistema e Menu Iniciar — em formato JSON.

---

## 🚀 Funcionalidades

- Escaneia programas instalados via **Registro do Windows**
- Escaneia atalhos do **Menu Iniciar**
- Retorna o nome do programa e o caminho do executável
- Busca programas por nome
- Interface Swagger para testes fáceis
- Rápida e leve

---

## 🛠️ Tecnologias

- [.NET 10](https://dotnet.microsoft.com/)
- ASP.NET Core Web API
- Windows Registry (`Microsoft.Win32`)
- `IWshRuntimeLibrary` (COM)
- Swagger / OpenAPI

> ⚠️ **Somente Windows** — Esta API utiliza APIs específicas do Windows (Registry e WSH).

---

## 📋 Requisitos

- Windows 10 ou superior
- [.NET 10 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/10.0)
- Visual Studio 2022+ ou VS Code

---

## ⚙️ Instalação

### 1. Clone o repositório

```bash
git clone https://github.com/HederGabriel/installed-software-radar-api.git
cd installed-software-radar-api
```

### 2. Restaure as dependências

```bash
dotnet restore
```

### 3. Execute a API

```bash
dotnet run
```

A API estará disponível em:

```
https://localhost:7239
http://localhost:5257
```

---

## 📖 Swagger UI

Após executar, abra o navegador e acesse:

```
https://localhost:7239/swagger
```

Você pode testar todos os endpoints diretamente pelo navegador.

---

## 📡 Endpoints

| Método | Rota | Descrição |
|--------|------|-----------|
| `GET` | `/api/apps` | Retorna todos os programas instalados |
| `GET` | `/api/apps/search?name={query}` | Busca programas por nome |

---

## 🔍 Exemplos de Resposta

### `GET /api/apps`

```json
{
  "Google Chrome": "C:\\Program Files\\Google\\Chrome\\Application\\chrome.exe",
  "Visual Studio Code": "C:\\Users\\user\\AppData\\Local\\Programs\\Microsoft VS Code\\Code.exe",
  "VLC media player": "C:\\Program Files\\VideoLAN\\VLC\\vlc.exe"
}
```

### `GET /api/apps/search?name=chrome`

```json
{
  "Google Chrome": "C:\\Program Files\\Google\\Chrome\\Application\\chrome.exe"
}
```

### `GET /api/apps/search?name=notfound` → `404`

```json
"Nenhum programa encontrado com o nome 'notfound'."
```

---

## 📁 Estrutura do Projeto

```
📁 installed-software-radar-api
 ├── 📁 Controllers
 │   └── AppsController.cs          # Endpoints da API
 ├── 📁 Services
 │   └── SoftwareScannerService.cs  # Lógica de escaneamento
 ├── Program.cs                     # Configuração da aplicação
 ├── appsettings.json
 └── README.md
```

---

## 🤝 Contribuindo

Contribuições são bem-vindas! Sinta-se à vontade para abrir uma issue ou enviar um pull request.

1. Faça um fork do projeto
2. Crie sua branch de funcionalidade (`git checkout -b feature/minha-feature`)
3. Faça o commit das suas alterações (`git commit -m 'Adiciona minha feature'`)
4. Envie para a branch (`git push origin feature/minha-feature`)
5. Abra um Pull Request

---

## 📄 Licença

Este projeto está licenciado sob a [Licença MIT](LICENSE).

---

## 👤 Autor

Desenvolvido por **[Heder Gabriel](https://github.com/HederGabriel)**
