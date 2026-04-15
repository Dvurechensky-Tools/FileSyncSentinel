<p align="center">✨Dvurechensky✨</p>

<p align="center"> 
  <p align="center"> 
    <h1 align="center">FileSync Sentinel 📁✨  <img alt="Static Badge" src="https://shields.dvurechensky.pro/badge/FileSync-Real%20Time%20Monitor-purple"></h1>
  </p> 
  <p align="center"> 
    <img src="https://shields.dvurechensky.pro/badge/WinForms-.NET%208.0-blue?logo=dotnet&logoColor=white"> 
    <img src="https://shields.dvurechensky.pro/badge/MVC-Architecture-blue?logo=windowsterminal&logoColor=white"> 
    <img src="https://shields.dvurechensky.pro/badge/DiffPlex-Comparison-green?logo=git&logoColor=white"> 
    <img src="https://shields.dvurechensky.pro/badge/FastColoredTextBox-Syntax%20Highlighting-orange?logo=visualstudiocode&logoColor=white"> 
    <img src="https://shields.dvurechensky.pro/badge/JSON-Configuration-lightgrey?logo=json&logoColor=white"> 
    <img src="https://shields.dvurechensky.pro/badge/Costura-Fody%20Packager-lightgrey?logo=packagist&logoColor=white"> 
  </p> 
  <h3 align="center">
    <span style="color:#F5F752;">Powerful</span> real-time file monitoring with 
    <span style="color:#15F752;">intelligent comparison 🔍</span>
  </h3>
</p>

<div align="center" style="margin: 20px 0; padding: 10px; background: #1c1917; border-radius: 10px;">
  <strong>🌐 Language: </strong>
  
  <a href="./README.ru.md" style="color: #F5F752; margin: 0 10px;">
    🇷🇺 Russian
  </a>
  | 
  <span style="color: #0891b2; margin: 0 10px;">
    ✅ 🇺🇸 English (current)
  </span>
</div>

---

- [🚀 About the Project](#-about-the-project)
  - [🎯 Core Objectives](#-core-objectives)
- [🛠 Technologies](#-technologies)
  - [NuGet Packages:](#nuget-packages)
  - [Additional Components:](#additional-components)
- [🚀 Installation \& Launch](#-installation--launch)
  - [Latest Version](#latest-version)
  - [System Requirements](#system-requirements)
- [⚡ Quick Start](#-quick-start)

## 🚀 About the Project

**FileSync Sentinel** is a professional real-time monitoring system designed for continuous file tracking workflows.  
The application focuses on detecting **changes** in files of a specific extension, with support for intelligent comparison and synchronization.

_🛠 Think of it as a lightweight, portable GitHub Desktop — but without any external repository, focused purely on local workflows 💖_

![alt text](docs/FileSyncSentinelInfo.gif)

### 🎯 Core Objectives

- **Monitor `Out` directory** (`LizeriumChangesGame`) — track file **changes** throughout the day
- **Compare with `In` directory** (`LizeriumINI`) — reference baseline directory
- **Flexible format configuration** — precise control over tracked file types (supports tens of thousands of `.ini` files)
- **Detailed logging** — record all detected changes into log files
- **Visual diff viewer** — inspect exact differences between files
- **Intelligent synchronization** — apply changes to files or entire directories with a single click

> [!IMPORTANT]  
> FileSync Sentinel 📁 monitors only **changes of existing files** in the `Out` directory —  
> it does **not** track file creation elsewhere.

## 🛠 Technologies

- **WinForms** — modern desktop UI
- **.NET 8.0** — latest framework version
- **MVC Pattern** — clean application architecture

### NuGet Packages:

- `DiffPlex` — intelligent file comparison
- `Newtonsoft.Json` — configuration handling

### Additional Components:

- **FastColoredTextBoxNet8** — custom .NET 8.0 implementation (fork of [Pavel Torgashov](https://github.com/PavelTorgashov/FastColoredTextBox))
- **Diff highlighting** — similar to `VSCode`, `WinMerge`, `Beyond Compare`

## 🚀 Installation & Launch

### Latest Version

Available in the **Releases** section of the project

### System Requirements

- **.NET 8.0 Desktop Runtime**
  - [x64 version](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/runtime-desktop-8.0.18-windows-x64-installer)
  - [x86 version](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/runtime-desktop-8.0.18-windows-x86-installer)

## ⚡ Quick Start

1. Install `.NET 8.0 Desktop Runtime`
2. Download the latest release from the `Releases` section
3. Configure paths to your directories in the configuration file
4. Specify the file format to monitor
5. Start monitoring!

> [!IMPORTANT]  
> FileSync Sentinel 📁 monitors only **one specific file extension** in the `Out` directory  
> (e.g. `*.ini`, `*.json`, etc.)

---

<p align="center"><em>✨ Professional change tracking for your projects ✨</em></p>

<p align="center">✨Dvurechensky✨</p>
