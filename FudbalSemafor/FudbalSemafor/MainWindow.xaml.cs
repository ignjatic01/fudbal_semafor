using FudbalSemafor.Models;
using FudbalSemafor.Properties;
using FudbalSemafor.ViewModels;
using FudbalSemafor.Views;
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
            PrilagodiMeni();
            SetAllNull();
            MainContent.Content = new OpcijeView();
        }

        private void OpenUtakmica(object sender, RoutedEventArgs e)
        {
            SetAllNull();
            UtakmicaMenuItem.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(Settings.Default.SelectedPrimaryColor));
            MainContent.Content = new UtakmicaView();
        }


        private void OpenOpcije(object sender, RoutedEventArgs e)
        {
            SetAllNull();
            OpcijeMenuItem.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(Settings.Default.SelectedPrimaryColor));
            MainContent.Content = new OpcijeView();
        }

        private void OpenIgrac(object sender, RoutedEventArgs e)
        {
            SetAllNull();
            IgraciMenuItem.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(Settings.Default.SelectedPrimaryColor));
            MainContent.Content = new IgracView();
        }

        private void OpenKartonTip(object sender, RoutedEventArgs e)
        {
            SetAllNull();
            SifarniciMenuItem.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(Settings.Default.SelectedPrimaryColor));
            MainContent.Content = new KartonTipView();
        }

        private void OpenKlub(object sender, RoutedEventArgs e)
        {
            SetAllNull();
            KluboviMenuItem.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(Settings.Default.SelectedPrimaryColor));
            MainContent.Content = new KlubView();
        }

        private void OpenPozicija(object sender, RoutedEventArgs e)
        {
            SetAllNull();
            SifarniciMenuItem.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(Settings.Default.SelectedPrimaryColor));
            MainContent.Content = new PozicijaView();
        }

        private void OpenStadion(object sender, RoutedEventArgs e)
        {
            SetAllNull();
            StadioniMenuItem.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(Settings.Default.SelectedPrimaryColor));
            MainContent.Content = new StadionView();
        }

        private void OpenStatistic(Object sender, RoutedEventArgs e)
        {
            SetAllNull();
            StatisticMenuItem.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(Settings.Default.SelectedPrimaryColor));
            MainContent.Content = new StatisticView();
        }

        private void SetAllNull()
        {
            IgraciMenuItem.Background = null;
            KluboviMenuItem.Background = null;
            StadioniMenuItem.Background = null;
            UtakmicaMenuItem.Background = null;
            SifarniciMenuItem.Background = null;
            OpcijeMenuItem.Background = null;
            StatisticMenuItem.Background = null;
        }

        private void PrilagodiMeni()
        {
            switch (CurrentUser.Role)
            {
                case "ADMIN":
                    break;

                case "OPERATER":
                    KluboviMenuItem.Visibility = Visibility.Collapsed;
                    IgraciMenuItem.Visibility = Visibility.Collapsed;
                    StadioniMenuItem.Visibility = Visibility.Collapsed;
                    SifarniciMenuItem.Visibility = Visibility.Collapsed;
                    break;

                default:
                    KluboviMenuItem.Visibility = Visibility.Collapsed;
                    IgraciMenuItem.Visibility = Visibility.Collapsed;
                    StadioniMenuItem.Visibility = Visibility.Collapsed;
                    SifarniciMenuItem.Visibility = Visibility.Collapsed;
                    UtakmicaMenuItem.Visibility = Visibility.Collapsed;
                    break;
            }
        }
    }
}