﻿using System;
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
        public SharedMenu()
        {
            InitializeComponent();
        }

        private void OpenKlub(object sender, RoutedEventArgs e)
        {
            KlubView klubView = new KlubView();
            klubView.Show();
            this.CloseWindow();
        }

        private void OpenKartonTip(object sender, RoutedEventArgs e)
        {
            KartonTipView kl = new KartonTipView();
            kl.Show();
            this.CloseWindow();
        }

        private void OpenPozicija(object sender, RoutedEventArgs e)
        {
            PozicijaView p = new PozicijaView();
            p.Show();
            this.CloseWindow();
        }

        private void OpenIgrac(object sender, RoutedEventArgs e)
        {
            IgracView i = new IgracView();
            i.Show();
            this.CloseWindow();
        }

        private void OpenStadion(Object sender, RoutedEventArgs e)
        {
            StadionView s = new StadionView();
            s.Show();
            this.CloseWindow();
        }

        private void OpenUtakmica(Object sender, RoutedEventArgs e)
        {
            UtakmicaView u = new UtakmicaView();
            u.Show();
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
