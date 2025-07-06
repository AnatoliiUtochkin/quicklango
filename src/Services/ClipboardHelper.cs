using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows;
using WindowsInput;
using WindowsInput.Native;

namespace QuickLingo.Helpers
{
    public class ClipboardHelper
    {
        private string? _previousClipboardText;

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        public async Task<string> TryCopySelectedTextAsync()
        {
            try
            {
                _previousClipboardText = System.Windows.Clipboard.GetText();

                IntPtr targetWindow = GetForegroundWindow();

                await Task.Delay(100);
                SetForegroundWindow(targetWindow);
                await Task.Delay(150);

                var sim = new InputSimulator();
                sim.Keyboard.ModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_C);

                await Task.Delay(300);

                string copied = System.Windows.Clipboard.GetText();

                if (!string.IsNullOrWhiteSpace(copied) && copied != _previousClipboardText)
                    return copied;

                return string.Empty;
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"Помилка копіювання: {ex.Message}");
                return string.Empty;
            }
        }

        public void RestorePreviousClipboard()
        {
            if (!string.IsNullOrEmpty(_previousClipboardText))
            {
                System.Windows.Clipboard.SetText(_previousClipboardText);
            }
        }
    }
}
