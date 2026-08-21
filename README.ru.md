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
  Я разрабатываю FileSync Sentinel как компактный desktop-инструмент для контроля изменений между рабочей и эталонной папкой.
</p>

<p align="center">
  <strong>Язык:</strong>
  Русский (текущий) |
  <a href="./README.md">English</a>
</p>

---

## О проекте

**FileSync Sentinel** - это WinForms-приложение, которое я сделал для локального мониторинга файлов без внешнего репозитория и лишней инфраструктуры. Я использую его как быстрый способ видеть, какие файлы изменились в рабочей папке `Out`, сравнивать их с эталоном `In` и выборочно переносить нужные изменения.

Проект особенно полезен, когда нужно регулярно сверять большое количество конфигурационных файлов, например `*.ini`, и аккуратно переносить только подтвержденные изменения.

![FileSync Sentinel interface](docs/FileSyncSentinelInfo.gif)

## Возможности

- Отслеживаю изменения и новые файлы в папке `Out`, включая вложенные директории.
- Сравниваю файлы с эталонной папкой `In` по относительным путям.
- Показываю список измененных и новых файлов в интерфейсе.
- Для новых файлов вывожу действие **Добавить**, для измененных - **Применить**.
- Позволяю просматривать различия через визуальную панель сравнения.
- Копирую отдельный файл или применяю все найденные изменения сразу.
- Создаю недостающие подпапки в `In` при добавлении новых файлов.
- Веду журнал событий мониторинга и синхронизации.

> [!IMPORTANT]
> Я отслеживаю только файлы, подходящие под маску из конфигурации, например `*.ini` или `*.json`.

## Технологии

- **.NET 8.0 / Windows Desktop** - основа приложения.
- **WinForms** - простой и предсказуемый desktop-интерфейс.
- **MVC-подход** - разделение представления, презентера и сервисов.
- **DiffPlex** - построение текстовых различий.
- **Newtonsoft.Json** - чтение конфигурации.
- **FastColoredTextBoxNet8** - панель просмотра и подсветки различий.
- **Costura.Fody** - упаковка зависимостей.

## Установка и запуск

### Готовая версия

Актуальная сборка доступна в разделе **Releases** проекта.

### Системные требования

- Windows
- .NET 8.0 Desktop Runtime:
  - [x64 installer](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/runtime-desktop-8.0.18-windows-x64-installer)
  - [x86 installer](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/runtime-desktop-8.0.18-windows-x86-installer)

## Быстрый старт

1. Установите `.NET 8.0 Desktop Runtime`.
2. Скачайте последнюю версию из `Releases`.
3. Откройте файл конфигурации из меню приложения.
4. Укажите путь к эталонной папке `In`.
5. Укажите путь к рабочей папке `Out`.
6. Задайте маску файлов, например `*.ini`.
7. Запустите мониторинг или выполните ручное сканирование.

## Принцип работы

Я считаю относительный путь файла внутри `Out` главным идентификатором. Если такой же путь есть в `In`, приложение сравнивает содержимое и показывает изменение. Если файла в `In` еще нет, приложение помечает его как новый и предлагает добавить.

При применении изменений FileSync Sentinel копирует файл из `Out` в соответствующее место внутри `In`. Если нужной подпапки нет, она создается автоматически.

## История изменений

- [CHANGELOG.ru.md](./CHANGELOG.ru.md) - история изменений на русском языке.
- [CHANGELOG.md](./CHANGELOG.md) - changelog in English.

---

<p align="center"><em>Профессиональный локальный контроль изменений для рабочих файлов.</em></p>

<p align="center">Dvurechensky</p>
