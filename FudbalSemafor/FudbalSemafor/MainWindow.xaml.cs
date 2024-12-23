﻿using FudbalSemafor.ViewModels;
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
            //DataContext = new KlubViewModel();
            MainContent.Content = new SharedMenu();
        }

        private void ChangeThemeLight(object sender, RoutedEventArgs e)
        {
            SetPrimaryColor(Colors.Blue, BaseTheme.Light);
        }

        private void ChangeThemeDark(object sender, RoutedEventArgs e)
        {
            SetPrimaryColor(Color.FromRgb(139, 195, 74), BaseTheme.Dark);
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