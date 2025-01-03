using FudbalSemafor.Models;
using FudbalSemafor.Properties;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FudbalSemafor.Views.Shared
{
    /// <summary>
    /// Interaction logic for SharedMenu.xaml
    /// </summary>
    public partial class SharedMenu : UserControl
    {

        public static bool IsIgraciActive { get; set; }
        public static bool IsKluboviActive { get; set; }
        public static bool IsUtakmiceActive { get; set; }
        public static bool IsStadioniActive { get; set; }
        public static bool IsSifarniciActive { get; set; }
        public static bool IsOpcijeActive { get; set; }

        private void SetAllNull()
        {
            IgraciMenuItem.Background = null;
            KluboviMenuItem.Background = null;
            StadioniMenuItem.Background = null;
            UtakmicaMenuItem.Background = null;
            SifarniciMenuItem.Background = null;
            OpcijeMenuItem.Background = null;
        }

        private void SetAllFalse()
        {
            IsIgraciActive = false;
            IsKluboviActive = false;
            IsStadioniActive = false;
            IsSifarniciActive = false;
            IsUtakmiceActive = false;
            IsOpcijeActive = false;
        }
        public SharedMenu()
        {
            InitializeComponent();
            PrilagodiMeni();
            SetAllNull();
            var primaryColorString = Settings.Default.SelectedPrimaryColor;
            if (IsIgraciActive)
                IgraciMenuItem.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(primaryColorString));
            else if (IsKluboviActive)
                KluboviMenuItem.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(primaryColorString));
            else if (IsStadioniActive)
                StadioniMenuItem.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(primaryColorString));
            else if (IsUtakmiceActive)
                UtakmicaMenuItem.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(primaryColorString));
            else if (IsOpcijeActive)
                OpcijeMenuItem.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(primaryColorString));
            else if (IsSifarniciActive)
                SifarniciMenuItem.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(primaryColorString));
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

        private void OpenKlub(object sender, RoutedEventArgs e)
        {
            SetAllFalse();
            IsKluboviActive = true;
            KlubView klubView = new KlubView();
            klubView.Show();
            this.CloseWindow();
        }

        private void OpenKartonTip(object sender, RoutedEventArgs e)
        {
            SetAllFalse();
            IsSifarniciActive = true;
            KartonTipView kl = new KartonTipView();
            kl.Show();
            this.CloseWindow();
        }

        private void OpenPozicija(object sender, RoutedEventArgs e)
        {
            SetAllFalse();
            IsSifarniciActive = true;
            PozicijaView p = new PozicijaView();
            p.Show();
            this.CloseWindow();
        }

        private void OpenIgrac(object sender, RoutedEventArgs e)
        {
            SetAllFalse();
            IsIgraciActive = true;
            IgracView i = new IgracView();
            i.Show();
            this.CloseWindow();
        }

        private void OpenStadion(Object sender, RoutedEventArgs e)
        {
            SetAllFalse();
            IsStadioniActive = true;
            StadionView s = new StadionView();
            s.Show();
            this.CloseWindow();
        }

        private void OpenUtakmica(Object sender, RoutedEventArgs e)
        {
            SetAllFalse();
            IsUtakmiceActive = true;
            UtakmicaView u = new UtakmicaView();
            u.Show();
            this.CloseWindow();
        }

        private void OpenOpcije(Object sender, RoutedEventArgs e)
        {
            SetAllFalse();
            IsOpcijeActive = true;
            MainWindow mw = new MainWindow();
            mw.Show();
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
    }
}
