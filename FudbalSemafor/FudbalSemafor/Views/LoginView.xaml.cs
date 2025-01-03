using FudbalSemafor.Properties;
using MaterialDesignThemes.Wpf;
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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FudbalSemafor.Views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
            LoadSavedTheme();
        }

        private void OpenRegister(Object sender, RoutedEventArgs e)
        {
            RegisterView r = new RegisterView();
            r.Show();
            this.CloseWindow();
        }

        private void CloseWindow()
        {
            Window currentWindow = Window.GetWindow(this);
            if (currentWindow != null)
            {
                currentWindow.Close();
            }
        }

        private void LoadSavedTheme()
        {
            var baseTheme = Settings.Default.SelectedBaseTheme;
            var primaryColorString = Settings.Default.SelectedPrimaryColor;

            if (!string.IsNullOrWhiteSpace(baseTheme) && !string.IsNullOrWhiteSpace(primaryColorString))
            {
                var primaryColor = (Color)ColorConverter.ConvertFromString(primaryColorString);
                var bt = baseTheme == "Dark" ? BaseTheme.Dark : BaseTheme.Light;

                SetPrimaryColor(primaryColor, bt);
            }
        }

        private static void SetPrimaryColor(Color color, BaseTheme bt)
        {
            PaletteHelper paletteHelper = new PaletteHelper();
            var theme = paletteHelper.GetTheme();

            theme.SetBaseTheme(bt);
            theme.SetPrimaryColor(color);

            paletteHelper.SetTheme(theme);
        }
    }
}
