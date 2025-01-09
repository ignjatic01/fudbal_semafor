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
    internal class IgracViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Igrac> Igracs { get; set; }
        public ObservableCollection<Klub> Klubs { get; set; }
        public ObservableCollection<Pozicija> Pozicijas { get; set; }
        public Igrac NewIgrac { get; set; }
        private Igrac _selectedIgrac;
        public Igrac SelectedIgrac
        {
            get => _selectedIgrac;
            set
            {
                if (_selectedIgrac != value)
                {
                    _selectedIgrac = value;
                    OnPropertyChanged(nameof(SelectedIgrac));
                }
            }
        }

        private Klub _selectedKlub;
        public Klub SelectedKlub
        {
            get => _selectedKlub;
            set
            {
                if (value != _selectedKlub)
                {
                    _selectedKlub = value;
                    OnPropertyChanged(nameof(SelectedKlub));
                }
            }
        }

        private Pozicija _selectedPozicija;

        public Pozicija SelectedPozicija
        {
            get => _selectedPozicija;
            set
            {
                if (_selectedPozicija != value)
                {
                    _selectedPozicija = value;
                    OnPropertyChanged(nameof(SelectedPozicija));
                }
            }
        }

        private Klub _selectedKlubEdit;
        public Klub SelectedKlubEdit
        {
            get => _selectedKlubEdit;
            set
            {
                if (value != _selectedKlubEdit)
                {
                    _selectedKlubEdit = value;
                    OnPropertyChanged(nameof(SelectedKlubEdit));
                }
            }
        }

        private Pozicija _selectedPozicijaEdit;

        public Pozicija SelectedPozicijaEdit
        {
            get => _selectedPozicijaEdit;
            set
            {
                if (_selectedPozicijaEdit != value)
                {
                    _selectedPozicijaEdit = value;
                    OnPropertyChanged(nameof(SelectedPozicijaEdit));
                }
            }
        }

        public ICommand AddIgracCommand { get; set; }
        public ICommand EditIgracCommand { get; set; }
        public ICommand DeleteIgracCommand { get; set; }
        public SemaforDbContext context { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public IgracViewModel()
        {
            context = new SemaforDbContext();
            var igracs = context.Igracs.Include(i => i.PozicijaNavigation).Include(i => i.KlubNavigation).ToList();
            Igracs = new ObservableCollection<Igrac>();
            foreach (var igrac in igracs)
            {
                Igracs.Add(igrac);
            }
            var klubs = context.Klubs.ToList();
            Klubs = new ObservableCollection<Klub>(klubs);

            var pozicijas = context.Pozicijas.ToList();
            Pozicijas = new ObservableCollection<Pozicija>(pozicijas);

            NewIgrac = new Igrac();
            AddIgracCommand = new RelayCommand(AddIgrac);
            EditIgracCommand = new RelayCommand(EditIgrac);
            DeleteIgracCommand = new RelayCommand(DeleteIgrac);
        }

        public void AddIgrac()
        {
            if (!string.IsNullOrWhiteSpace(NewIgrac.Ime) && !string.IsNullOrWhiteSpace(NewIgrac.Prezime) && NewIgrac.BrojDresa > 0 && SelectedKlub != null && SelectedPozicija != null)
            {
                try
                {
                    NewIgrac.Klub = SelectedKlub.IdKlub;
                    NewIgrac.Pozicija = SelectedPozicija.OznakaPozicije;
                    NewIgrac.UIgri = false;
                    context.Igracs.Add(NewIgrac);
                    context.SaveChanges();

                    Igracs.Add(NewIgrac);

                    NewIgrac = new Igrac();
                    SelectedKlub = null;
                    SelectedPozicija = null;
                    OnPropertyChanged(nameof(NewIgrac));
                    OnPropertyChanged(nameof(SelectedKlub));
                    OnPropertyChanged(nameof(SelectedPozicija));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        public void EditIgrac()
        {
            if (!string.IsNullOrWhiteSpace(SelectedIgrac.Ime) && !string.IsNullOrWhiteSpace(SelectedIgrac.Prezime) && SelectedIgrac.BrojDresa > 0)
            {
                try
                {
                    var existingIgrac = context.Igracs.FirstOrDefault(i => i.IdIgrac == SelectedIgrac.IdIgrac);
                    if (existingIgrac != null)
                    {
                        existingIgrac.Ime = SelectedIgrac.Ime;
                        existingIgrac.Prezime = SelectedIgrac.Prezime;
                        existingIgrac.BrojDresa = SelectedIgrac.BrojDresa;
                        existingIgrac.Pozicija = SelectedIgrac.Pozicija;
                        existingIgrac.Klub = SelectedIgrac.Klub;

                        existingIgrac.PozicijaNavigation = context.Pozicijas.FirstOrDefault(p => p.OznakaPozicije == SelectedIgrac.Pozicija);
                        existingIgrac.KlubNavigation = context.Klubs.FirstOrDefault(k => k.IdKlub == SelectedIgrac.Klub);

                        Console.WriteLine(SelectedIgrac.Pozicija);
                        context.SaveChanges();

                        var index = Igracs.IndexOf(SelectedIgrac);
                        if(index >= 0)
                        {
                            Igracs[index] = existingIgrac;
                        }
                    }
                    else
                    {
                        
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void DeleteIgrac()
        {
            if(SelectedIgrac != null)
            {
                try
                {
                    var existingIgrac = context.Igracs.FirstOrDefault(i => i.IdIgrac == SelectedIgrac.IdIgrac);
                    if (existingIgrac != null)
                    {
                        context.Igracs.Remove(existingIgrac);
                        context.SaveChanges();
                        Igracs.Remove(SelectedIgrac);
                        SelectedIgrac = null;
                    }
                    else
                    {
                        
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
