using FudbalSemafor.Models;
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
    internal class PozicijaViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Pozicija> Pozicijas { get; set; }
        public Pozicija NewPozicija { get; set; }
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

        public ICommand AddPozicijaCommand { get; set; }
        public ICommand EditPozicijaCommand { get; set; }
        public ICommand DeletePozicijaCommand { get; set; }
        public SemaforDbContext context { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public PozicijaViewModel()
        {
            context = new SemaforDbContext();
            var pozicijas = context.Pozicijas.ToList();
            Pozicijas = new ObservableCollection<Pozicija>();
            foreach (var pozicija in pozicijas)
            {
                Pozicijas.Add(pozicija);
            }
            NewPozicija = new Pozicija();
            AddPozicijaCommand = new RelayCommand(AddPozicija);
            EditPozicijaCommand = new RelayCommand(EditPozicija);
            DeletePozicijaCommand = new RelayCommand(DeletePozicija);
        }

        public void AddPozicija()
        {
            if (!string.IsNullOrWhiteSpace(NewPozicija.OznakaPozicije) && !string.IsNullOrWhiteSpace(NewPozicija.NazivPozicije))
            {
                try
                {
                    context.Pozicijas.Add(NewPozicija);
                    context.SaveChanges();

                    Pozicijas.Add(NewPozicija);

                    NewPozicija = new Pozicija();
                    OnPropertyChanged(nameof(NewPozicija));
                }
                catch(Exception ex) 
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void EditPozicija()
        {
            if (!string.IsNullOrWhiteSpace(SelectedPozicija.NazivPozicije) && !string.IsNullOrWhiteSpace(SelectedPozicija.OznakaPozicije))
            {
                try
                {
                    var existingPozicija = context.Pozicijas.FirstOrDefault(p => p.OznakaPozicije == SelectedPozicija.OznakaPozicije);
                    if (existingPozicija != null)
                    {
                        existingPozicija.OznakaPozicije = SelectedPozicija.OznakaPozicije;
                        existingPozicija.NazivPozicije = SelectedPozicija.NazivPozicije;

                        context.SaveChanges();

                        var index = Pozicijas.IndexOf(SelectedPozicija);
                        if (index != -1)
                        {
                            Pozicijas[index] = existingPozicija;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Pozicija nije pronadjena.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void DeletePozicija()
        {
            if (SelectedPozicija != null)
            {
                try
                {
                    var existingPozicija = context.Pozicijas.FirstOrDefault(p => p.OznakaPozicije == SelectedPozicija.OznakaPozicije);
                    if (existingPozicija != null)
                    {
                        context.Pozicijas.Remove(existingPozicija);
                        context.SaveChanges();
                        Pozicijas.Remove(SelectedPozicija);
                        SelectedPozicija = null;
                    }
                    else
                    {
                        MessageBox.Show("Pozicija nije pronadjena.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
