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
    internal class KlubViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Klub> Klubs { get; set; }
        public Klub NewKlub { get; set; }
        private Klub _selectedKlub;
        public Klub SelectedKlub 
        {
            get => _selectedKlub;
            set
            {
                if(_selectedKlub != value)
                {
                    _selectedKlub = value;
                    OnPropertyChanged(nameof(SelectedKlub));
                }
            }
        }

        public ICommand AddKlubCommand { get; set; }
        public ICommand EditKlubCommand { get; set;}
        public ICommand DeleteKlubCommand { get; set; }
        public SemaforDbContext context { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public KlubViewModel() 
        {
            context = new SemaforDbContext();
            var klubs = context.Klubs.ToList();
            //var klubs = context.Klubs.Where(k => k.Grad == "Banja Luka").ToList();
            Klubs = new ObservableCollection<Klub>();
            foreach ( var klub in klubs )
            {
                Klubs.Add( klub );
            }
            NewKlub = new Klub();
            AddKlubCommand = new RelayCommand(AddKlub);
            EditKlubCommand = new RelayCommand(EditKlub);
            DeleteKlubCommand = new RelayCommand(DeleteKlub);
        }

        public void AddKlub()
        {
            if (!string.IsNullOrWhiteSpace(NewKlub.NazivKluba) && !string.IsNullOrWhiteSpace(NewKlub.Grad))
            {
                try
                {
                    context.Klubs.Add(NewKlub);
                    context.SaveChanges();

                    Klubs.Add(NewKlub);

                    NewKlub = new Klub();
                    OnPropertyChanged(nameof(NewKlub));
                }
                catch (Exception ex)
                {
                }
            }
        }

        public void EditKlub()
        {
            if (!string.IsNullOrWhiteSpace(SelectedKlub.NazivKluba) && !string.IsNullOrWhiteSpace(SelectedKlub.Grad))
            {
                try
                {
                    var existingKlub = context.Klubs.FirstOrDefault(k => k.IdKlub == SelectedKlub.IdKlub);
                    if (existingKlub != null)
                    {
                        existingKlub.NazivKluba = SelectedKlub.NazivKluba;
                        existingKlub.Grad = SelectedKlub.Grad;
                        existingKlub.Slika = SelectedKlub.Slika;

                        context.SaveChanges();

                        var index = Klubs.IndexOf(SelectedKlub);
                        if (index >= 0)
                        {
                            Klubs[index] = existingKlub;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Klub nije pronađen.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void DeleteKlub()
        {
            if (SelectedKlub != null)
            {
                try
                {
                    var existingKlub = context.Klubs.FirstOrDefault(k => k.IdKlub == SelectedKlub.IdKlub);
                    if (existingKlub != null)
                    {
                        context.Klubs.Remove(existingKlub);
                        context.SaveChanges();
                        Klubs.Remove(SelectedKlub);
                        SelectedKlub = null;
                    }
                    else
                    {
                        MessageBox.Show("Klub nije pronađen.");
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
