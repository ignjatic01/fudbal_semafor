using FudbalSemafor.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FudbalSemafor.ViewModels
{
    class LoginViewModel : INotifyPropertyChanged
    {
        public  ObservableCollection<Korisnik> Korisniks { get; set; }
        public Korisnik SelectedKorisnik { get; set; }
        public ICommand LoginCommand { get; set; }
        public SemaforDbContext context { get; set; }
        public LoginViewModel()
        {
            context = new SemaforDbContext();
            var korisniks = context.Korisniks.Include(k => k.RoleNavigation).ToList();
            Korisniks = new ObservableCollection<Korisnik>(korisniks);

            SelectedKorisnik = new Korisnik();
            LoginCommand = new RelayCommand(Login);
        }

        private void Login(object parameter)
        {
            if (!string.IsNullOrWhiteSpace(SelectedKorisnik.KorisnickoIme) && !string.IsNullOrWhiteSpace(SelectedKorisnik.Lozinka))
            {
                bool isUsernameExsists = false;
                Korisnik dbKorisnik = new Korisnik();
                foreach (var korisnik in Korisniks)
                {
                    if (korisnik.KorisnickoIme == SelectedKorisnik.KorisnickoIme)
                    {
                        isUsernameExsists = true;
                        dbKorisnik = korisnik;
                        break;
                    }
                }
                if (isUsernameExsists && dbKorisnik != null)
                {
                    string hashedPass = HashPassword(SelectedKorisnik.Lozinka);
                    if (hashedPass == dbKorisnik.Lozinka)
                    {
                        CurrentUser.Role = dbKorisnik.RoleNavigation.NazivRole;

                        MainWindow mainWindow = new MainWindow();
                        mainWindow.Show();

                        if ( parameter is Window window)
                        {
                            window.Close();
                        }
                    }
                    else 
                    {
                        var result = MessageBox.Show("Lozinka nije ispravna!", "Obaveštenje", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                if (!isUsernameExsists)
                {
                    var result = MessageBox.Show("Korisnicko ime nije ispravno!", "Obaveštenje", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha256.ComputeHash(passwordBytes);
                return Convert.ToBase64String(hashBytes);
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
