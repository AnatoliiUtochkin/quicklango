using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace QuickLingo.Views.Popups
{
    /// <summary>
    /// Interaction logic for TranslationPopup.xaml
    /// </summary>
    public partial class TranslationPopup : Window
    {
        public TranslationPopup(string translationResult)
        {
            InitializeComponent();
            ResultTextBox.Text = translationResult;

            var shadow = new DropShadowEffect
            {
                Color = Colors.Black,
                BlurRadius = 20,
                ShadowDepth = 0,
                Opacity = 0.6
            };
            this.Resources["DropShadowEffect"] = shadow;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TitleBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
        }
    }
}
