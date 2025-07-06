using QuickLingo.Helpers;
using System.Windows;

namespace QuickLingo.Services
{
    public class HotkeyHandler
    {
        private readonly ClipboardHelper _clipboardHelper = new();

        public async Task HandleTranslateHotkeyAsync()
        {
            string selectedText = await _clipboardHelper.TryCopySelectedTextAsync();

            if (string.IsNullOrWhiteSpace(selectedText))
            {
                System.Windows.MessageBox.Show("Не вдалося отримати виділений текст. Скопіюйте його вручну або перевірте фокус вікна.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            TranslatorService translatorService = new();
            string translatedText = await translatorService.TranslateAsync(selectedText);

            System.Windows.MessageBox.Show($"Переклад вибраного тексту: {translatedText}");

            _clipboardHelper.RestorePreviousClipboard();
        }
    }
}
