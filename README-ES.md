# 📡 Software Radar API

> 🌐 **Language / Idioma:** [🇧🇷 Português](README-PT.md) | 🇪🇸 Español | [🇺🇸 English](README.md)

Una API REST construida con **ASP.NET Core** que escanea y devuelve todos los programas instalados en una máquina Windows — a través del Registro del sistema y el Menú Inicio — en formato JSON.

---

## 🚀 Funcionalidades

- Escanea programas instalados desde el **Registro de Windows**
- Escanea accesos directos del **Menú Inicio**
- Devuelve el nombre del programa y la ruta del ejecutable
- Búsqueda de programas por nombre
- Interfaz Swagger para pruebas fáciles
- Rápida y ligera

---

## 🛠️ Tecnologías

- [.NET 10](https://dotnet.microsoft.com/)
- ASP.NET Core Web API
- Windows Registry (`Microsoft.Win32`)
- `IWshRuntimeLibrary` (COM)
- Swagger / OpenAPI

> ⚠️ **Solo Windows** — Esta API utiliza APIs específicas de Windows (Registry y WSH).

---

## 📋 Requisitos

- Windows 10 o superior
- [.NET 10 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/10.0)
- Visual Studio 2022+ o VS Code

---

## ⚙️ Instalación

### 1. Clonar el repositorio

```bash
git clone https://github.com/HederGabriel/installed-software-radar-api.git
cd installed-software-radar-api
```

### 2. Restaurar dependencias

```bash
dotnet restore
```

### 3. Ejecutar la API

```bash
dotnet run
```

La API estará disponible en:

```
https://localhost:7239
http://localhost:5257
```

---

## 📖 Swagger UI

Después de ejecutar, abre el navegador y accede a:

```
https://localhost:7239/swagger
```

Puedes probar todos los endpoints directamente desde el navegador.

---

## 📡 Endpoints

| Método | Ruta | Descripción |
|--------|------|-------------|
| `GET` | `/api/apps` | Devuelve todos los programas instalados |
| `GET` | `/api/apps/search?name={query}` | Busca programas por nombre |

---

## 🔍 Ejemplos de Respuesta

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
"No se encontró ningún programa con el nombre 'notfound'."
```

---

## 📁 Estructura del Proyecto

```
📁 installed-software-radar-api
 ├── 📁 Controllers
 │   └── AppsController.cs          # Endpoints de la API
 ├── 📁 Services
 │   └── SoftwareScannerService.cs  # Lógica de escaneo
 ├── Program.cs                     # Configuración de la aplicación
 ├── appsettings.json
 └── README.md
```

---

## 🤝 Contribuciones

¡Las contribuciones son bienvenidas! No dudes en abrir un issue o enviar un pull request.

1. Haz un fork del proyecto
2. Crea tu rama de funcionalidad (`git checkout -b feature/mi-feature`)
3. Confirma tus cambios (`git commit -m 'Agrega mi feature'`)
4. Envía a la rama (`git push origin feature/mi-feature`)
5. Abre un Pull Request

---

## 📄 Licencia

Este proyecto está licenciado bajo la [Licencia MIT](LICENSE).

---

## 👤 Autor

Desarrollado por **[Heder Gabriel](https://github.com/HederGabriel)**
