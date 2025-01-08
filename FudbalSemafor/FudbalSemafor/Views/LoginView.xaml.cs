using FudbalSemafor.Properties;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Globalization;
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
            if (Properties.Settings.Default.Lang == "rs" || Properties.Settings.Default.Lang == "en")
            {
                SetLang(Properties.Settings.Default.Lang);
            }
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

        private void SetLang(String lang)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(lang);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);

            var languageResourceEn = Application.Current.Resources.MergedDictionaries
                .FirstOrDefault(r => r.Source != null && r.Source.ToString().Contains("Dictionary-en.xaml"));

            var languageResourceRs = Application.Current.Resources.MergedDictionaries
                .FirstOrDefault(r => r.Source != null && r.Source.ToString().Contains("Dictionary-rs.xaml"));

            if (languageResourceEn != null)
            {
                Application.Current.Resources.MergedDictionaries.Remove(languageResourceEn);
            }

            if (languageResourceRs != null)
            {
                Application.Current.Resources.MergedDictionaries.Remove(languageResourceRs);
            }

            ResourceDictionary resdict = new ResourceDictionary()
            {
                Source = new Uri($"/Resources/Dictionary-{lang}.xaml", UriKind.Relative)
            };

            Application.Current.Resources.MergedDictionaries.Add(resdict);
            Properties.Settings.Default.Lang = lang;
            Properties.Settings.Default.Save();
        }
    }
}
