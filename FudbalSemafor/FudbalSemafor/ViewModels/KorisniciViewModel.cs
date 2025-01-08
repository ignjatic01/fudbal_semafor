using FudbalSemafor.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FudbalSemafor.ViewModels
{
    internal class KorisniciViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Korisnik> Korisniks { get; set; }
        public ObservableCollection<Role> Roles { get; set; }
        private Korisnik _selectedKorisnik;
        public Korisnik SelectedKorisnik
        {
            get => _selectedKorisnik;
            set
            {
                if (_selectedKorisnik != value)
                {
                    _selectedKorisnik = value;
                    OnPropertyChanged(nameof(SelectedKorisnik));
                }
            }
        }

        public ICommand EditKorisnikCommand { get; set; }
        public ICommand DeleteKorisnikCommand { get; set; }
        public SemaforDbContext context { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
        
        public KorisniciViewModel()
        {
            context = new SemaforDbContext();
            Korisniks = new ObservableCollection<Korisnik>(context.Korisniks.Include(k => k.RoleNavigation).ToList());
            Roles = new ObservableCollection<Role>(context.Roles.ToList());

            EditKorisnikCommand = new RelayCommand(EditKorisnik);
            DeleteKorisnikCommand = new RelayCommand(DeleteKorisnik);
        }

        private void EditKorisnik()
        {
            if(SelectedKorisnik.Role != null)
            {
                try
                {
                    var existingKorisnik = context.Korisniks.FirstOrDefault(k => k.IdKorisnik == SelectedKorisnik.IdKorisnik);
                    if (existingKorisnik != null)
                    {
                        existingKorisnik.Role = SelectedKorisnik.Role;
                        existingKorisnik.RoleNavigation = context.Roles.FirstOrDefault(r => r.IdRole == SelectedKorisnik.Role);

                        context.SaveChanges();

                        var index = Korisniks.IndexOf(SelectedKorisnik);
                        if(index != -1)
                        {
                            Korisniks[index] = existingKorisnik;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Igrac nije pronađen.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void DeleteKorisnik()
        {
            if(SelectedKorisnik != null)
            {
                try
                {
                    var existingKorisnik = context.Korisniks.FirstOrDefault(k => k.IdKorisnik == SelectedKorisnik.IdKorisnik);
                    if (existingKorisnik != null)
                    {
                        context.Korisniks.Remove(existingKorisnik);
                        context.SaveChanges();
                        Korisniks.Remove(SelectedKorisnik);
                        SelectedKorisnik = null;
                    }
                    else
                    {
                        MessageBox.Show("Igrac nije pronađen.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
            }
        }
        
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
