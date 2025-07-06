using NHotkey;
using NHotkey.Wpf;
using QuickLingo.Services;
using System.Windows;
using System.Windows.Input;
using static System.Net.Mime.MediaTypeNames;
using Application = System.Windows.Application;

namespace QuickLingo
{
    public partial class App : Application
    {
        private NotifyIcon _notifyIcon;
        private static Mutex? _mutex;

        private HotkeyHandler _hotkeyHandler;

        protected override void OnStartup(StartupEventArgs e)
        {
            const string mutexName = "QuickLingo_Mutex";
            _mutex = new Mutex(true, mutexName, out bool isNewInstance);

            if (!isNewInstance)
            {
                System.Windows.MessageBox.Show("Програму вже запущено.", "Увага", MessageBoxButton.OK, MessageBoxImage.Information);
                Shutdown();
                return;
            }

            base.OnStartup(e);
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            _notifyIcon = new NotifyIcon
            {
                Icon = new System.Drawing.Icon("icon.ico"),
                Visible = true,
                Text = "QuickLingo"
            };

            var contextMenu = new ContextMenuStrip();
            contextMenu.Items.Add("Налаштування", null, Settings_Click);
            contextMenu.Items.Add("Вийти", null, Exit_Click);

            _notifyIcon.ContextMenuStrip = contextMenu;

            _hotkeyHandler = new();
            HotkeyManager.Current.AddOrReplace("TranslateHotkey", Key.A, ModifierKeys.Alt | ModifierKeys.Shift, OnHotkey);
        }

        private void Settings_Click(object sender, EventArgs e)
        {
            System.Windows.MessageBox.Show(
                $"Скоро...", "Інформація",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            _notifyIcon?.Dispose();
            Shutdown();
        }

        private async void OnHotkey(object sender, HotkeyEventArgs e)
        {
            await _hotkeyHandler.HandleTranslateHotkeyAsync();
            e.Handled = true;
        }
    }
}
