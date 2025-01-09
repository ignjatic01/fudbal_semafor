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
    class RegisterViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Korisnik> Korisniks { get; set; }
        public Korisnik NewKorisnik { get; set; }
        public ICommand RegisterCommand {  get; set; }
        public SemaforDbContext context { get; set; }

        public RegisterViewModel() 
        {
            context = new SemaforDbContext();
            var korisniks = context.Korisniks.Include(k => k.RoleNavigation).ToList();
            Korisniks = new ObservableCollection<Korisnik>(korisniks);

            NewKorisnik = new Korisnik();
            RegisterCommand = new RelayCommand(Register);
        }

        private void Register()
        {
            if (!string.IsNullOrWhiteSpace(NewKorisnik.KorisnickoIme) && !string.IsNullOrWhiteSpace(NewKorisnik.Lozinka))
            {
                bool isUsernameExsists = false;
                foreach (var korisnik in Korisniks)
                {
                    if(korisnik.KorisnickoIme == NewKorisnik.KorisnickoIme)
                    {
                        isUsernameExsists = true;
                    }
                }
                if (!isUsernameExsists)
                {
                    string hashedPass = HashPassword(NewKorisnik.Lozinka);
                    NewKorisnik.Lozinka = hashedPass;
                    NewKorisnik.Role = 2;
                    context.Korisniks.Add(NewKorisnik);
                    context.SaveChanges();

                    NewKorisnik = new Korisnik();
                    OnPropertyChanged(nameof(NewKorisnik));

                    string message = (string)Application.Current.Resources["SuccessfulRegistration"];
                    string title = (string)Application.Current.Resources["NotificationTitle"];
                    var result = MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Information);
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
