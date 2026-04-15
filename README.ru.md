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
  <h3 align="center"><span style="color:#F5F752;">Мощный</span> мониторинг изменений файлов в <span style="color:#377;">реальном времени</span> с <span style="color:#15F752;">интеллектуальным сравнением 🔍</span></h3>
</p>

<div align="center" style="margin: 20px 0; padding: 10px; background: #1c1917; border-radius: 10px;">
  <strong>🌐 Язык: </strong>
  
  <span style="color: #F5F752; margin: 0 10px;">
    ✅ 🇷🇺 Русский (текущий)
  </span>
  | 
  <a href="./README.md" style="color: #0891b2; margin: 0 10px;">
    🇺🇸 English
  </a>
</div>

---

- [🚀 О проекте](#-о-проекте)
  - [🎯 Основные задачи](#-основные-задачи)
- [🛠 Технологии](#-технологии)
- [🚀 Установка и запуск](#-установка-и-запуск)
  - [Актуальная версия](#актуальная-версия)
  - [Системные требования](#системные-требования)
- [⚡ Быстрый старт](#-быстрый-старт)

## 🚀 О проекте

**FileSync Sentinel** - это профессиональная система мониторинга, созданная для потоковой работы в реальном времени. Приложение обеспечивает точное отслеживание только `изменений` файлов конкретного расширения с возможностью интеллектуального сравнения и синхронизации.

_🛠 Что-то вроде портативного Github Desktop но без внешнего репозитория где-либо и с ограниченными возможностями 💖_

![alt text](docs/FileSyncSentinelInfo.gif)

### 🎯 Основные задачи

- **Наблюдение за папкой `Out`** (`LizeriumChangesGame`) - отслеживание `изменений` файлов в течение дня
- **Сравнение с папкой `In`** (`LizeriumINI`) - эталонная директория для сравнения
- **Гибкая настройка форматов** - точное указание отслеживаемых файлов (поддержка десятков тысяч `.ini` файлов)
- **Детальное логирование** - фиксация всех изменений в лог-файл
- **Визуальное сравнение** - просмотр точных изменений между файлами
- **Интеллектуальная синхронизация** - применение изменений к файлам или папкам одной кнопкой

> [!IMPORTANT]
> FileSync Sentinel 📁 смотрит только за `изменениями` уже `существующих` файлов в папке `Out`! Не за их созданием где либо, а строго за `изменениями`.

## 🛠 Технологии

- **WinForms** - современный desktop интерфейс
- **NET 8.0** - последняя версия фреймворка
- **MVC Pattern** - чистая архитектура приложения
- **NuGet пакеты:**
  - `DiffPlex` - интеллектуальное сравнение файлов
  - `Newtonsoft.Json` - работа с конфигурацией
- **Дополнительные компоненты:**
  - **FastColoredTextBoxNet8** - кастомная реализация для .NET 8.0 (форк библиотеки [Pavel Torgashov](https://github.com/PavelTorgashov/FastColoredTextBox))
  - **Подсветка различий** - как в `VSCode`, `WinMerge`, `Beyond Compare`

## 🚀 Установка и запуск

### Актуальная версия

Доступна в разделе **Release** проекта

### Системные требования

- **.NET 8.0 Desktop Runtime**
  - [x64 версия](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/runtime-desktop-8.0.18-windows-x64-installer)
  - [x86 версия](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/runtime-desktop-8.0.18-windows-x86-installer)

## ⚡ Быстрый старт

1. Скачайте и установите `.NET 8.0 Desktop Runtime`
2. Загрузите последнюю версию из раздела `Release`
3. Настройте `пути` к папкам `в конфигурации`
4. Укажите отслеживаемый `формат` файлов
5. Запустите мониторинг!

> [!IMPORTANT]
> FileSync Sentinel 📁 смотрит только за одним конкретным `расширением` файлов в папке `Out`, например только за `*.ini` если укажете или за `*.json`!

---

<p align="center"><em>✨ Профессиональный контроль изменений для ваших проектов ✨</em></p>

<p align="center">✨Dvurechensky✨</p>
