# 📡 Software Radar API

> 🌐 **Language / Idioma:** [🇧🇷 Português](README-PT.md) | [🇪🇸 Español](README-ES.md) | 🇺🇸 English

A REST API built with **ASP.NET Core** that scans and returns all installed programs on a Windows machine — via Registry and Start Menu — in JSON format.

---

## 🚀 Features

- Scans installed programs from the **Windows Registry**
- Scans shortcuts from the **Start Menu**
- Returns program name and executable path
- Search programs by name
- Swagger UI for easy testing
- Fast and lightweight

---

## 🛠️ Tech Stack

- [.NET 10](https://dotnet.microsoft.com/)
- ASP.NET Core Web API
- Windows Registry (`Microsoft.Win32`)
- `IWshRuntimeLibrary` (COM)
- Swagger / OpenAPI

> ⚠️ **Windows only** — This API uses Windows-specific APIs (Registry and WSH).

---

## 📋 Requirements

- Windows 10 or later
- [.NET 10 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/10.0)
- Visual Studio 2022+ or VS Code

---

## ⚙️ Installation

### 1. Clone the repository

```bash
git clone https://github.com/HederGabriel/installed-software-radar-api.git
cd installed-software-radar-api
```

### 2. Restore dependencies

```bash
dotnet restore
```

### 3. Run the API

```bash
dotnet run
```

The API will start at:

```
https://localhost:7239
http://localhost:5257
```

---

## 📖 Swagger UI

After running, open your browser and go to:

```
https://localhost:7239/swagger
```

You can test all endpoints directly from the browser.

---

## 📡 Endpoints

| Method | Route | Description |
|--------|-------|-------------|
| `GET` | `/api/apps` | Returns all installed programs |
| `GET` | `/api/apps/search?name={query}` | Search programs by name |

---

## 🔍 Example Responses

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
"No program found with the name 'notfound'."
```

---

## 📁 Project Structure

```
📁 installed-software-radar-api
 ├── 📁 Controllers
 │   └── AppsController.cs       # API endpoints
 ├── 📁 Services
 │   └── SoftwareScannerService.cs  # Scan logic
 ├── Program.cs                  # App configuration
 ├── appsettings.json
 └── README.md
```

---

## 🤝 Contributing

Contributions are welcome! Feel free to open an issue or submit a pull request.

1. Fork the project
2. Create your feature branch (`git checkout -b feature/my-feature`)
3. Commit your changes (`git commit -m 'Add my feature'`)
4. Push to the branch (`git push origin feature/my-feature`)
5. Open a Pull Request

---

## 📄 License

This project is licensed under the [MIT License](LICENSE).

---

## 👤 Author

Made by **[Heder Gabriel](https://github.com/HederGabriel)**
