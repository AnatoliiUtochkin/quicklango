# QuickLingo

## Overview
QuickLingo is a lightweight background application for Windows, designed to instantly translate any selected text using a configurable hotkey.
It runs silently in the system tray, providing fast and convenient translations without interrupting your workflow.

## Features
- Runs in the background with a system tray icon  
- Translate selected text from any language with autodetection
- Configurable hotkey activation  
- Uses Microsoft Azure Translator API for reliable translations  
- Built with .NET 8 and WPF

## Installation
1. Clone the repository:  
   ```git clone https://github.com/AnatoliiUtochkin/quicklango.git```
2. Open the solution in Visual Studio or your preferred IDE.
3. Create appsettings.json in the project root by copying appsettings.example.json
4. Build and run the application.

## Usage
- Select any text in any application.
- Press the configured hotkey.
- The translation will appear in a popup or notification near the tray icon.

## Technologies
- C# (.NET 8)
- WPF
- Newtonsoft.Json for JSON processing
- NHotkey.WPF for global hotkey handling
- InputSimulator for simulating user input
- Microsoft Azure Translator API for translations
- Microsoft.Extensions.Configuration for configuration

## License
This project is licensed under the [MIT License](LICENSE).
