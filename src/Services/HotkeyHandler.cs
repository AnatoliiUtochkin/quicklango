using QuickLingo.Helpers;
using QuickLingo.Views.Popups;
using System.Windows;

namespace QuickLingo.Services
{
    public class HotkeyHandler
    {
        private readonly ClipboardHelper _clipboardHelper = new();

        public async Task HandleTranslateHotkeyAsync()
        {
            string selectedText = await _clipboardHelper.TryCopySelectedTextAsync();

            TranslatorService translatorService = new();
            string translatedText = await translatorService.TranslateAsync(selectedText);

            var translationWindow = new TranslationPopup(translatedText);

            var mousePosition = Control.MousePosition;

            var screen = Screen.FromPoint(mousePosition);

            double left = mousePosition.X + 15;
            double top = mousePosition.Y + 15;

            if (left + translationWindow.Width > screen.WorkingArea.Right)
            {
                left = screen.WorkingArea.Right - translationWindow.Width;
            }

            if (top + translationWindow.Height > screen.WorkingArea.Bottom)
            {
                top = screen.WorkingArea.Bottom - translationWindow.Height;
            }

            translationWindow.Left = left;
            translationWindow.Top = top;

            translationWindow.Show();
            translationWindow.Activate();

            _clipboardHelper.RestorePreviousClipboard();
        }
    }
}
