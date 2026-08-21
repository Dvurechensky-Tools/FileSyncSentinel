<p align="center">Dvurechensky</p>

<h1 align="center">
  FileSync Sentinel
  <img alt="Static Badge" src="https://shields.dvurechensky.pro/badge/FileSync-Real%20Time%20Monitor-purple">
</h1>

<p align="center">
  <img src="https://shields.dvurechensky.pro/badge/WinForms-.NET%208.0-blue?logo=dotnet&logoColor=white">
  <img src="https://shields.dvurechensky.pro/badge/MVC-Architecture-blue?logo=windowsterminal&logoColor=white">
  <img src="https://shields.dvurechensky.pro/badge/DiffPlex-Comparison-green?logo=git&logoColor=white">
  <img src="https://shields.dvurechensky.pro/badge/FastColoredTextBox-Syntax%20Highlighting-orange?logo=visualstudiocode&logoColor=white">
  <img src="https://shields.dvurechensky.pro/badge/JSON-Configuration-lightgrey?logo=json&logoColor=white">
</p>

<p align="center">
  I build FileSync Sentinel as a compact desktop tool for controlling changes between a working folder and a reference folder.
</p>

<p align="center">
  <strong>Language:</strong>
  <a href="./README.ru.md">Русский</a> |
  English (current)
</p>

---

## About

**FileSync Sentinel** is a WinForms application I built for local file monitoring without an external repository or heavy infrastructure. I use it to see which files changed in a working `Out` directory, compare them with a reference `In` directory, and apply only the changes I choose.

The project is useful for workflows with many configuration files, such as `*.ini`, where changes need to be reviewed and transferred carefully.

![FileSync Sentinel interface](docs/FileSyncSentinelInfo.gif)

## Features

- I monitor changed and newly added files in the `Out` directory, including nested folders.
- I compare files against the `In` directory by relative path.
- I show changed and new files in the application grid.
- I label new-file actions as **Add** and existing-file actions as **Apply**.
- I provide a visual diff panel for inspecting content changes.
- I support applying one file or all detected changes at once.
- I create missing subdirectories in `In` when adding new files.
- I keep a log of monitoring and synchronization events.

> [!IMPORTANT]
> I track only files matching the configured mask, for example `*.ini` or `*.json`.

## Technology

- **.NET 8.0 / Windows Desktop** - application platform.
- **WinForms** - straightforward desktop interface.
- **MVC-style structure** - separation between view, presenter, and services.
- **DiffPlex** - text diff generation.
- **Newtonsoft.Json** - configuration loading.
- **FastColoredTextBoxNet8** - diff viewing and highlighting.
- **Costura.Fody** - dependency packaging.

## Installation

### Release Build

The current build is available in the project's **Releases** section.

### Requirements

- Windows
- .NET 8.0 Desktop Runtime:
  - [x64 installer](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/runtime-desktop-8.0.18-windows-x64-installer)
  - [x86 installer](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/runtime-desktop-8.0.18-windows-x86-installer)

## Quick Start

1. Install `.NET 8.0 Desktop Runtime`.
2. Download the latest release from `Releases`.
3. Open the configuration file from the application menu.
4. Set the reference `In` directory.
5. Set the working `Out` directory.
6. Set the file mask, for example `*.ini`.
7. Start monitoring or run a manual scan.

## How It Works

I treat the relative path inside `Out` as the file identity. If the same relative path exists in `In`, the application compares file contents and reports a change. If the file does not exist in `In`, the application marks it as new and offers to add it.

When changes are applied, FileSync Sentinel copies the file from `Out` to the matching location in `In`. Missing target subdirectories are created automatically.

## Changelog

- [CHANGELOG.md](./CHANGELOG.md) - changelog in English.
- [CHANGELOG.ru.md](./CHANGELOG.ru.md) - история изменений на русском языке.

---

<p align="center"><em>Professional local change control for working files.</em></p>

<p align="center">Dvurechensky</p>
