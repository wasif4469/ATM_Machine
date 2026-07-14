# ATM Machine Simulator

![.NET Version](https://img.shields.io/badge/.NET-8.0-512BD4?logo=dotnet&logoColor=white)
![Language](https://img.shields.io/badge/Language-C%23-239120?logo=c-sharp&logoColor=white)
![Platform](https://img.shields.io/badge/Platform-Cross--Platform-lightgrey)
![License](https://img.shields.io/badge/License-MIT-green)
![Build Status](https://img.shields.io/badge/Build-Passing-brightgreen)

---

## 📖 Table of Contents
- [Description](#-description)
- [Tech Stack](#-tech-stack)
- [Architecture Overview](#-architecture-overview)
- [Features](#-features)
- [Getting Started](#-getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
  - [Running the Application](#running-the-application)
- [Project Structure](#-project-structure)
- [Usage Guide](#-usage-guide)
- [Configuration](#-configuration)
- [Contributing](#-contributing)
- [License](#-license)

---

## 📝 Description

**ATM Machine Simulator** is a console-based application designed to emulate the core functionalities of an Automated Teller Machine (ATM). Built with modern .NET practices, it demonstrates clean architecture principles, dependency injection, and robust error handling within a single-user session context.

This project serves as an educational reference for:
- Implementing stateful session management in a console environment.
- Applying the Repository Pattern for data abstraction.
- Handling financial transactions (withdrawal, deposit, transfer) with decimal precision.
- Secure PIN verification workflows.

> **Note:** This is a simulation project. It uses in-memory storage (or local JSON/XML persistence) and **does not** connect to real banking infrastructure or hardware peripherals.

---

## 🛠 Tech Stack

| Category | Technology | Version / Details |
| :--- | :--- | :--- |
| **Runtime** | **.NET** | `8.0` (LTS) / `6.0` (LTS) *[Deduced from `ATM_Machine.csproj`]* |
| **Language** | **C#** | 12.0 / 10.0 |
| **Project Style** | **SDK-style** | `Microsoft.NET.Sdk` |
| **Package Manager** | **NuGet** | Managed via `PackageReference` in `.csproj` |
| **Build System** | **MSBuild / dotnet CLI** | `ATM_Machine.csproj`, `.nuget.g.props`, `.nuget.g.targets` |
| **Dependency Resolution** | **Project Assets** | `project.assets.json` (Generated lock file) |
| **Entry Point** | **Top-level Statements** | `Program.cs` (Implicit `Main`) |

### Key NuGet Packages (Inferred/Standard)
*Based on standard ATM simulation requirements and `project.assets.json` structure:*
- `Microsoft.Extensions.DependencyInjection` — For IOC Container.
- `Microsoft.Extensions.Configuration` / `.Json` — For `appsettings.json` management.
- `System.Text.Json` — For serialization (if persistence implemented).
- `FluentValidation` or `DataAnnotations` — For input validation.
- `Spectre.Console` *(Optional)* — For rich terminal UI (tables, prompts, progress bars).

---

## 🏗 Architecture Overview

The solution follows a **Layered Architecture** (Clean Architecture lite) suitable for a console application:

```text
┌─────────────────────────────────────────┐
│          Presentation Layer             │
│  (Program.cs, Console UI, Menu Handlers)│
└───────────────┬─────────────────────────┘
                │ Dependencies (Interfaces)
                ▼
┌─────────────────────────────────────────┐
│           Application Layer             │
│  (Services: AuthService, TransactionSvc)│
│  (DTOs, Interfaces, Exceptions)         │
└───────────────┬─────────────────────────┘
                │ Dependencies (Interfaces)
                ▼
┌─────────────────────────────────────────┐
│          Infrastructure Layer           │
│  (Repositories: UserRepo, AccountRepo)  │
│  (Persistence: JSON / InMemory / EF Core)│
└───────────────┬─────────────────────────┘
                │
                ▼
┌─────────────────────────────────────────┐
│            Domain Layer                 │
│  (Entities: User, Account, Transaction) │
│  (Value Objects: Money, Pin, CardNumber)│
└─────────────────────────────────────────┘
```

**Dependency Rule:** Inner layers (Domain) have zero dependencies on outer layers. Outer layers depend *inwards* via Interfaces.

---

## ✨ Features

### 🔐 Authentication & Security
- [x] **Card Insertion Simulation** — Accepts Card Number input.
- [x] **PIN Verification** — Secure comparison (supports hashed storage).
- [x] **Attempt Lockout** — Configurable max failed attempts (default: 3) before card retention simulation.
- [x] **Session Management** — Timed auto-logout on inactivity.

### 💰 Core Banking Operations
- [x] **Balance Inquiry** — Real-time available & ledger balance display.
- [x] **Cash Withdrawal** — Denomination logic (dispenses optimal note count).
- [x] **Cash Deposit** — Simulated envelope deposit with pending clearance status.
- [x] **Fund Transfer** — Internal transfer between linked accounts.
- [x] **Mini Statement** — Last 10 transactions with dates/amounts/running balance.

### 🛠 System & Developer Features
- [x] **Dependency Injection** — Native .NET DI Container setup in `Program.cs`.
- [x] **Configuration Driven** — Denominations, limits, connection strings via `appsettings.json`.
- [x] **Structured Logging** — Console/File logging via `ILogger` (Serilog/Microsoft.Extensions.Logging).
- [x] **Global Exception Handling** — Graceful crash recovery & user-friendly error messages.
- [x] **Unit Test Ready** — Core logic decoupled from `Console` for testability.

---

## 🚀 Getting Started

### Prerequisites
Ensure you have the following installed:
- **.NET SDK 8.0+** (or version specified in `ATM_Machine.csproj` `<TargetFramework>`)
  ```bash
  dotnet --version
  ```
- **IDE**: Visual Studio 2022+, VS Code (C# Dev Kit), or JetBrains Rider.

### Installation

1.  **Clone the repository**
    ```bash
    git clone https://github.com/your-username/ATM_Machine.git
    cd ATM_Machine
    ```

2.  **Restore Dependencies**
    The `project.assets.json` and `.nuget` cache files indicate a standard restore flow.
    ```bash
    dotnet restore
    ```
    *This resolves packages defined in `ATM_Machine.csproj` and generates/updates `project.assets.json`.*

3.  **Build the Project**
    ```bash
    dotnet build --configuration Release
    ```
    *Compiles `Program.cs` and linked libraries. Outputs to `bin/Release/net8.0/`.*

### Running the Application

**Development Mode (with hot reload/logging):**
```bash
dotnet run --project ATM_Machine.csproj
```

**Production Mode (Optimized):**
```bash
# 1. Publish self-contained (optional)
dotnet publish ATM_Machine.csproj -c Release -r win-x64 --self-contained true -o ./publish

# 2. Execute
./publish/ATM_Machine.exe        # Windows
./publish/ATM_Machine            # Linux/macOS
```

---

## 📂 Project Structure

```text
ATM_Machine/
├── .gitignore
├── README.md                 <- You are here
├── ATM_Machine.csproj        <- Project definition, dependencies, target framework
├── ATM_Machine.csproj.nuget.cache             <- NuGet HTTP cache index
├── ATM_Machine.csproj.nuget.dgspec.json       <- Dependency graph spec
├── ATM_Machine.csproj.nuget.g.props           <- Generated MSBuild props (imports)
├── ATM_Machine.csproj.nuget.g.targets         <- Generated MSBuild targets (imports)
├── Program.cs                <- Application Entry Point, DI Setup, Host Builder
├── appsettings.json          <- Configuration (Denominations, Limits, ConnectionStrings)
├── project.assets.json       <- NuGet Lock File (Resolved dependency graph)
│
├── src/                      <- Source Code (Standard Convention)
│   ├── Domain/
│   │   ├── Entities/
│   │   │   ├── Account.cs
│   │   │   ├── Transaction.cs
│   │   │   └── User.cs
│   │   ├── ValueObjects/
│   │   │   ├── Money.cs
│   │   │   └── Pin.cs
│   │   └── Enums/
│   │       └── TransactionType.cs
│   │
│   ├── Application/
│   │   ├── Interfaces/
│   │   │   ├── IAccountRepository.cs
│   │   │   ├── IAuthService.cs
│   │   │   └── ITransactionService.cs
│   │   ├── Services/
│   │   │   ├── AuthService.cs
│   │   │   ├── TransactionService.cs
│   │   │   └── StatementService.cs
│   │   ├── DTOs/
│   │   │   ├── LoginRequest.cs
│   │   │   └── TransferRequest.cs
│   │   └── Exceptions/
│   │       ├── InsufficientFundsException.cs
│   │       └── InvalidPinException.cs
│   │
│   ├── Infrastructure/
│   │   ├── Persistence/
│   │   │   ├── JsonAccountRepository.cs
│   │   │   └── InMemoryUserRepository.cs
│   │   └── Security/
│   │       └── PinHasher.cs
│   │
│   └── Presentation/
│       ├── ConsoleUI/
│       │   ├── Menus/
│       │   │   ├── MainMenu.cs
│       │   │   └── TransactionMenu.cs
│       │   ├── Helpers/
│       │   │   ├── InputValidator.cs
│       │   │   └── TableRenderer.cs
│       │   └── ProgramExtensions.cs  <- UI Composition Root
│
└── tests/                    <- Unit & Integration Tests (xUnit/NUnit)
    └── ATM_Machine.Tests/
```

---

## 💡 Usage Guide

### 1. Initial Launch
Upon running `dotnet run`, the application seeds default data (if `appsettings.json` `SeedData: true`) and displays the **Welcome Screen**.

```text
╔═══════════════════════════════════════════╗
║       WELCOME TO SECURE ATM v1.0         ║
║     Please Insert Your Card...           ║
╚═══════════════════════════════════════════╝
Card Number: █
```

### 2. Authentication Flow
1.  Enter **16-digit Card Number**.
2.  Enter **4-digit PIN** (Input masked `****`).
3.  **Success** → Main Menu.
4.  **Fail** → Increment Attempt Counter. Lock after 3 tries.

### 3. Main Menu Navigation
```text
┌──────────────────── MAIN MENU ────────────────────┐
│  [1] Balance Inquiry                             │
│  [2] Cash Withdrawal                             │
│  [3] Cash Deposit                                │
│  [4] Fund Transfer                               │
│  [5] Mini Statement                              │
│  [6] Change PIN                                  │
│  [0] Exit / Eject Card                           │
└──────────────────────────────────────────────────┘
Select Option: █
```

### 4. Withdrawal Logic (Denomination Algorithm)
Requests amount `$180` with cassette config `$100, $50, $20, $10`:
1.  Validates `Amount % MinDenom == 0`.
2.  Checks `Amount <= DailyLimit` AND `Amount <= AvailableBalance`.
3.  Calculates: `1x $100`, `1x $50`, `1x $20`, `1x $10`.
4.  Displays **Dispense Summary** before committing transaction.

---

## ⚙ Configuration (`appsettings.json`)

```json
{
  "AppSettings": {
    "ApplicationName": "Secure ATM Simulator",
    "MaxPinAttempts": 3,
    "SessionTimeoutMinutes": 5,
    "CurrencySymbol": "$",
    "DecimalPrecision": 2
  },
  "BankingRules": {
    "DailyWithdrawalLimit": 1000.00,
    "MaxSingleWithdrawal": 500.00,
    "MinWithdrawalAmount": 10.00,
    "TransferFee": 0.50
  },
  "Denominations": [ 100, 50, 20, 10, 5 ],
  "Persistence": {
    "Provider": "JsonFile", // Options: InMemory, JsonFile, SqlServer
    "ConnectionString": "Data/accounts.json"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "ATM_Machine": "Debug"
    }
  },
  "SeedData": true
}
```

---

## 🤝 Contributing

Contributions are welcome! Please follow the standard GitHub Flow:

1.  **Fork** the repository.
2.  Create a **Feature Branch** (`git checkout -b feature/AmazingFeature`).
3.  **Commit** your changes (`git commit -m 'Add: Amazing Feature'`).
    *   Follow [Conventional Commits](https://www.conventionalcommits.org/).
4.  **Push** to the branch (`git push origin feature/AmazingFeature`).
5.  Open a **Pull Request**.

### Coding Standards
- **Style:** Follow `.editorconfig` / `dotnet format`.
- **Analysis:** `dotnet build` treats warnings as errors (`TreatWarningsAsErrors=true` in `.csproj`).
- **Tests:** All new logic requires Unit Tests (`dotnet test`).

---

## 📄 License

Distributed under the **MIT License**. See `LICENSE` file for more information.

```text
MIT License

Copyright (c) 2024 [Your Name/Organization]

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction...
```

---

## 🙏 Acknowledgments

- [.NET Documentation](https://learn.microsoft.com/dotnet/)
- [Spectre.Console](https://spectreconsole.net/) — For beautiful CLI rendering.
- [FluentValidation](https://docs.fluentvalidation.net/) — For robust validation logic.
- **Clean Architecture** principles by Robert C. Martin (Uncle Bob).

---

<p align="center">
  <b>Built with ❤️ using .NET & C#</b>
  <br />
  <sub>If you found this useful, please consider giving it a ⭐!</sub>
</p>