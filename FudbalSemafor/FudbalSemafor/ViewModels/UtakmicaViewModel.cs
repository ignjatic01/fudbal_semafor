using FudbalSemafor.Models;
using FudbalSemafor.Views;
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
    class UtakmicaViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Utakmica> Utakmicas { get; set; }
        public ObservableCollection<Klub> Klubs { get; set; }
        public ObservableCollection<Stadion> Stadions { get; set; }
        public Utakmica NewUtakmica { get; set; }
        private Utakmica _selectedUtakmica;
        public Utakmica SelectedUtakmica
        {
            get => _selectedUtakmica;
            set
            {
                if (_selectedUtakmica != value)
                {
                    _selectedUtakmica = value;
                    OnPropertyChanged(nameof(SelectedUtakmica));
                }
            }
        }

        private Klub _selectedDomaci;
        public Klub SelectedDomaci
        {
            get => _selectedDomaci;
            set
            {
                if (_selectedDomaci != value)
                {
                    _selectedDomaci = value;
                    OnPropertyChanged(nameof(SelectedDomaci));
                }
            }
        }

        private Klub _selectedGosti;
        public Klub SelectedGosti
        {
            get => _selectedGosti;
            set
            {
                if (_selectedGosti != value)
                {
                    _selectedGosti = value;
                    OnPropertyChanged(nameof(SelectedGosti));
                }
            }
        }

        private Stadion _selectedStadion;
        public Stadion SelectedStadion
        {
            get => _selectedStadion;
            set
            {
                if (value != _selectedStadion)
                {
                    _selectedStadion = value;
                    OnPropertyChanged(nameof(SelectedStadion));
                }
            }
        }

        private Klub _selectedDomaciEdit;
        public Klub SelectedDomaciEdit
        {
            get => _selectedDomaciEdit;
            set
            {
                if (_selectedDomaciEdit != value)
                {
                    _selectedDomaciEdit = value;
                    OnPropertyChanged(nameof(SelectedDomaciEdit));
                }
            }
        }

        private Klub _selectedGostiEdit;
        public Klub SelectedGostiEdit
        {
            get => _selectedGostiEdit;
            set
            {
                if (_selectedGostiEdit != value)
                {
                    _selectedGostiEdit = value;
                    OnPropertyChanged(nameof(SelectedGostiEdit));
                }
            }
        }

        private Stadion _selectedStadionEdit;
        public Stadion SelectedStadionEdit
        {
            get => _selectedStadionEdit;
            set
            {
                if( value != _selectedStadionEdit )
                {
                    _selectedStadionEdit = value;
                    OnPropertyChanged(nameof(SelectedStadionEdit));
                }
            }
        }

        public ICommand AddUtakmicaCommand { get; set; }
        public ICommand EditUtakmicaCommand { get; set; }
        public ICommand DeleteUtakmicaCommand { get; set; }
        public ICommand OpenUtakmicaCommand { get; set; }
        public SemaforDbContext context { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public UtakmicaViewModel()
        {
            context = new SemaforDbContext();
            var utakmicas = context.Utakmicas.Include(u => u.DomaciNavigation).Include(u => u.GostiNavigation).Include(u => u.StadionNavigation).ToList();
            Utakmicas = new ObservableCollection<Utakmica>();
            foreach(var utakmica in utakmicas)
            {
                Utakmicas.Add(utakmica);
            }
            var klubs = context.Klubs.ToList();
            Klubs = new ObservableCollection<Klub>(klubs);

            var stadions = context.Stadions.ToList();
            Stadions = new ObservableCollection<Stadion>(stadions);

            NewUtakmica = new Utakmica();
            AddUtakmicaCommand = new RelayCommand(AddUtakmica);
            EditUtakmicaCommand = new RelayCommand(EditUtakmica);
            DeleteUtakmicaCommand = new RelayCommand(DeleteUtakmica);
            OpenUtakmicaCommand = new RelayCommand(OpenUtakmica);
        }

        public void AddUtakmica()
        {
            if (SelectedDomaci.IdKlub != 0 && SelectedGosti.IdKlub != 0)
            {
                try
                {
                    NewUtakmica.Domaci = SelectedDomaci.IdKlub;
                    NewUtakmica.Gosti = SelectedGosti.IdKlub;
                    NewUtakmica.Stadion = SelectedStadion.IdStadion;
                    NewUtakmica.GoloviDomaci = 0;
                    NewUtakmica.GoloviGosti = 0;

                    context.Add(NewUtakmica);
                    context.SaveChanges();

                    Utakmicas.Add(NewUtakmica);

                    NewUtakmica = new Utakmica();
                    SelectedDomaci = null;
                    SelectedGosti = null;
                    SelectedStadion = null;
                    OnPropertyChanged(nameof(NewUtakmica));
                    OnPropertyChanged(nameof(SelectedGosti));
                    OnPropertyChanged(nameof(SelectedStadion));
                    OnPropertyChanged(nameof(SelectedDomaci));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        public void EditUtakmica() 
        {
            if (SelectedUtakmica.Domaci != 0 && SelectedUtakmica.Gosti != 0)
            {
                try
                {
                    var existingUtakmica = context.Utakmicas.FirstOrDefault(u => u.IdUtakmica == SelectedUtakmica.IdUtakmica);
                    if (existingUtakmica != null)
                    {
                        existingUtakmica.Domaci = SelectedUtakmica.Domaci;
                        existingUtakmica.Gosti = SelectedUtakmica.Gosti;
                        existingUtakmica.Stadion = SelectedUtakmica.Stadion;

                        existingUtakmica.DomaciNavigation = context.Klubs.FirstOrDefault(d => d.IdKlub == SelectedUtakmica.Domaci);
                        existingUtakmica.GostiNavigation = context.Klubs.FirstOrDefault(g => g.IdKlub == SelectedUtakmica.Gosti);
                        existingUtakmica.StadionNavigation = context.Stadions.FirstOrDefault(s => s.IdStadion == SelectedUtakmica.Stadion);

                        context.SaveChanges();

                        var index = Utakmicas.IndexOf(SelectedUtakmica);
                        if(index >= 0)
                        {
                            Utakmicas[index] = existingUtakmica;
                        }
                    }
                    else
                    {
                        //MessageBox.Show("Utakmica nije pronađena.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public void DeleteUtakmica()
        {
            if (SelectedUtakmica != null)
            {
                try
                {
                    var existingUtakmica = context.Utakmicas.FirstOrDefault(u => u.IdUtakmica == SelectedUtakmica.IdUtakmica);
                    if (existingUtakmica != null)
                    {
                        context.Utakmicas.Remove(existingUtakmica);
                        context.SaveChanges();
                        Utakmicas.Remove(SelectedUtakmica);
                        SelectedUtakmica = null;
                    }
                    else
                    {
                        //MessageBox.Show("Utakmica nije pronađena.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
            }
        }

        public void OpenUtakmica()
        {
            if (SelectedUtakmica != null)
            {
                int idUtakmica = SelectedUtakmica.IdUtakmica;

                SemaforView sw = new SemaforView(idUtakmica);
                sw.Show();
            }
        }
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
