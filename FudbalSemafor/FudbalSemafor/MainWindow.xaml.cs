using FudbalSemafor.Properties;
using FudbalSemafor.ViewModels;
using FudbalSemafor.Views.Shared;
using MaterialDesignThemes.Wpf;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static MaterialDesignThemes.Wpf.Theme;

namespace FudbalSemafor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainContent.Content = new SharedMenu();
        }

        private void ChangeThemeLight(object sender, RoutedEventArgs e)
        {
            SetPrimaryColor((Color)ColorConverter.ConvertFromString("#2196F3"), BaseTheme.Light);
            SaveTheme("Light", (Color)ColorConverter.ConvertFromString("#2196F3"));
        }

        private void ChangeThemeDark(object sender, RoutedEventArgs e)
        {
            SetPrimaryColor(Color.FromRgb(139, 195, 74), BaseTheme.Dark);

            SaveTheme("Dark", Color.FromRgb(139, 195, 74));
        }

        private void ChangeThemeMid(object sender, RoutedEventArgs e)
        {
            SetPrimaryColor((Color)ColorConverter.ConvertFromString("#FF5722"), BaseTheme.Inherit);
            SaveTheme("Inherit", (Color)ColorConverter.ConvertFromString("#FF5722"));
        }

        private void ChangeFontSmall(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.FontSize = 13;
            Properties.Settings.Default.Save();
        }

        private void ChangeFontMid(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.FontSize = 16;
            Properties.Settings.Default.Save();
        }

        private void ChangeFontBig(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.FontSize = 18;
            Properties.Settings.Default.Save();
        }

        private void ChangeFontDefault(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.FontFamilyName = "Segoe UI";
            Properties.Settings.Default.Save();
        }

        private void ChangeFontConsolas(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.FontFamilyName = "Consolas";
            Properties.Settings.Default.Save();
        }

        private static void SetPrimaryColor(Color color, BaseTheme bt)
        {
            PaletteHelper paletteHelper = new PaletteHelper();

            var theme = paletteHelper.GetTheme();

            theme.SetBaseTheme(bt);
            theme.SetPrimaryColor(color);

            paletteHelper.SetTheme(theme);
        }

        private void SaveTheme(string baseTheme, Color primaryColor)
        {
            Settings.Default.SelectedBaseTheme = baseTheme;
            Settings.Default.SelectedPrimaryColor = primaryColor.ToString();
            Settings.Default.Save();
        }
    }
}