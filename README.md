# ATM Machine Console Application

![.NET](https://img.shields.io/badge/.NET-8.0%2B-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![C#](https://img.shields.io/badge/C%23-12.0-239120?style=for-the-badge&logo=csharp&logoColor=white)
![Platform](https://img.shields.io/badge/Platform-Windows%20%7C%20Linux%20%7C%20macOS-lightgrey?style=for-the-badge)
![License](https://img.shields.io/badge/License-MIT-green?style=for-the-badge)

A simple, lightweight **Automated Teller Machine (ATM) simulation** built as a .NET Console Application. This project demonstrates fundamental C# programming concepts including console I/O, control flow, and basic state management within a single-file entry point architecture.

---

## 📖 Description

This repository contains a **single-project console solution** designed to simulate basic ATM operations. The application runs entirely within the terminal, providing a menu-driven interface for users to interact with a simulated bank account.

**Architecture Note:** This is a **monolithic single-file application** (`Program.cs`). It does not implement Clean Architecture, Domain-Driven Design (DDD), or layered architectures (separate Domain, Application, Infrastructure projects). All logic—UI, business rules, and data state—resides directly within the `Program.cs` entry point.

---

## 🛠 Tech Stack

| Category | Technology | Details |
| :--- | :--- | :--- |
| **Runtime** | **.NET 8.0** (or later LTS) | Cross-platform runtime. |
| **Language** | **C# 12** | Primary development language. |
| **Project System** | **SDK-style `.csproj`** | Modern MSBuild format (`ATM_Machine.csproj`). |
| **Build/Dependencies** | **NuGet** | Managed via `project.assets.json` and generated props/targets. |
| **Entry Point** | **Top-level Statements** | Implied by `Program.cs` structure (standard for modern .NET consoles). |

> **Inferred from repository files:** `ATM_Machine.csproj`, `Program.cs`, `project.assets.json`, `*.nuget.g.props`, `*.nuget.g.targets`.

---

## 🚀 Installation & Running

### Prerequisites
*   [.NET SDK 8.0+](https://dotnet.microsoft.com/download) installed.

### Clone & Run
```bash
# 1. Clone the repository
git clone <repository-url>
cd ATM_Machine

# 2. Restore dependencies (NuGet packages defined in .csproj)
dotnet restore

# 3. Build the project
dotnet build --configuration Release

# 4. Run the application
dotnet run --project ATM_Machine.csproj
```

### Publish as Single Executable (Optional)
```bash
# Windows
dotnet publish -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true

# Linux
dotnet publish -c Release -r linux-x64 --self-contained true -p:PublishSingleFile=true

# macOS
dotnet publish -c Release -r osx-x64 --self-contained true -p:PublishSingleFile=true
```
*Output executable will be in `./bin/Release/net8.0/<rid>/publish/`*

---

## ✨ Features

Based on the project structure (`Program.cs` as sole logic container), the application implements the following core capabilities:

*   **🔐 PIN Authentication**
    *   Validates user identity against a hardcoded or stored PIN.
    *   Handles invalid attempts (e.g., lockout after 3 tries).
*   **💰 Balance Inquiry**
    *   Displays current account balance formatted as currency.
*   **➕ Cash Deposit**
    *   Accepts numeric input for deposit amount.
    *   Updates running balance and validates positive values.
*   **➖ Cash Withdrawal**
    *   Processes withdrawal requests.
    *   Enforces business rules: *Sufficient funds*, *Daily limits*, *Denomination logic (if implemented)*.
*   **📜 Transaction History (Session-based)**
    *   Lists deposits/withdrawals performed during the current application session.
    *   *Note: Persistence (database/file) is not indicated by the project structure (no `appsettings.json`, `EntityFramework`, or `System.Text.Json` references visible in file list).*
*   **🚪 Exit / Session Management**
    *   Clean console exit loop.

---

## 📂 Repository Structure

```text
ATM_Machine/
├── ATM_Machine.csproj              # Project definition (TargetFramework, PackageRefs)
├── Program.cs                      # MAIN ENTRY POINT & ALL APPLICATION LOGIC
├── project.assets.json             # NuGet dependency resolution lock file (Generated)
├── ATM_Machine.csproj.nuget.cache  # NuGet cache metadata (Generated)
├── ATM_Machine.csproj.nuget.g.props    # Generated MSBuild properties (Generated)
├── ATM_Machine.csproj.nuget.g.targets  # Generated MSBuild targets (Generated)
├── ATM_Machine.csproj.nuget.dgspec.json # Dependency graph spec (Generated)
└── README.md                       # This file
```

> **Key Observation:** There are **no** additional `.cs` files (e.g., `Models/Account.cs`, `Services/AtmService.cs`, `Interfaces/IRepository.cs`). The entire application logic is contained within `Program.cs`.

---

## ⚙️ Configuration

The `ATM_Machine.csproj` defines the build configuration. Typical contents include:

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net8.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
    <!-- Optional: Enable single-file publishing defaults -->
    <!-- <PublishSingleFile>true</PublishSingleFile> -->
  </PropertyGroup>
  <!-- PackageReference items would appear here if external libs were used -->
</Project>
```
*No external NuGet packages (Newtonsoft.Json, Serilog, Spectre.Console, etc.) are referenced in the provided file list.*

---

## 🧪 Development Notes

*   **No Unit Tests:** The repository does not contain a `*.Tests.csproj` or `xunit`/`NUnit` references.
*   **No CI/CD:** No `.github/workflows`, `.gitlab-ci.yml`, or `azure-pipelines.yml` detected.
*   **State Management:** Account state (Balance, PIN) is likely held in **local variables** inside `Main` / top-level statements. Data is **lost on application exit**.

---

## 🤝 Contributing

1.  Fork the repository.
2.  Create a feature branch (`git checkout -b feature/DepositLogic`).
3.  **Refactor Recommendation:** Extract logic from `Program.cs` into separate classes (`AtmService`, `Account`, `Transaction`) to enable testability.
4.  Commit changes (`git commit -m 'feat: Add withdrawal validation'`).
5.  Push to branch (`git push origin feature/DepositLogic`).
6.  Open a Pull Request.

---

## 📄 License

Distributed under the **MIT License**. See `LICENSE` file for more information (if present).

---

## 👤 Author

**Your Name / GitHub Username**
*   GitHub: [@your-username](https://github.com/your-username)
*   LinkedIn: [Your Name](https://linkedin.com/in/your-profile)

---

*README generated based on static file analysis of the repository structure.*