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
    class StadionViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Stadion> Stadions { get; set; }
        public Stadion NewStadion { get; set; }
        private Stadion _selectedStadion;
        public Stadion SelectedStadion
        {
            get => _selectedStadion;
            set
            {
                if (_selectedStadion != value)
                {
                    _selectedStadion = value;
                    OnPropertyChanged(nameof(SelectedStadion));
                }
            }
        }

        public ICommand AddStadionCommand { get; set; }
        public ICommand EditStadionCommand { get; set; }
        public ICommand DeleteStadionCommand { get; set; }
        public SemaforDbContext context { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public StadionViewModel()
        {
            context = new SemaforDbContext();
            var stadions = context.Stadions.ToList();
            Stadions = new ObservableCollection<Stadion>();
            foreach ( var stadion in stadions )
            {
                Stadions.Add( stadion );
            }
            NewStadion = new Stadion();
            AddStadionCommand = new RelayCommand(AddStadion);
            EditStadionCommand = new RelayCommand(EditStadion);
            DeleteStadionCommand = new RelayCommand(DeleteStadion);
        }

        public void AddStadion()
        {
            if (!string.IsNullOrWhiteSpace(NewStadion.Naziv) && !string.IsNullOrWhiteSpace(NewStadion.Grad) && NewStadion.Kapacitet >= 0 && !string.IsNullOrWhiteSpace(NewStadion.Podloga))
            {
                try
                {
                    context.Stadions.Add(NewStadion);
                    context.SaveChanges();

                    Stadions.Add(NewStadion);

                    NewStadion = new Stadion();
                    OnPropertyChanged(nameof(NewStadion));
                }
                catch( Exception ex) 
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        
        public void EditStadion()
        {
            if (!string.IsNullOrWhiteSpace(SelectedStadion.Naziv) && !string.IsNullOrWhiteSpace(SelectedStadion.Grad) && SelectedStadion.Kapacitet >= 0 && !string.IsNullOrWhiteSpace(SelectedStadion.Podloga))
            {
                try
                {
                    var existingStadion = context.Stadions.FirstOrDefault(s => s.IdStadion == SelectedStadion.IdStadion);
                    if (existingStadion != null)
                    {
                        existingStadion.Naziv = SelectedStadion.Naziv;
                        existingStadion.Grad = SelectedStadion.Grad;
                        existingStadion.Podloga = SelectedStadion.Podloga;
                        existingStadion.Kapacitet = SelectedStadion.Kapacitet;
                        
                        context.SaveChanges();

                        var index = Stadions.IndexOf(SelectedStadion);
                        if(index >= 0)
                        {
                            Stadions[index] = existingStadion;
                        }
                    }
                    else
                    {
                        //MessageBox.Show("Stadion nije pronađen.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }

        public void DeleteStadion()
        {
            if (SelectedStadion != null)
            {
                try
                {
                    var existingStadion = context.Stadions.FirstOrDefault(s => s.IdStadion == SelectedStadion.IdStadion);
                    if (existingStadion != null)
                    {
                        context.Stadions.Remove(existingStadion);
                        context.SaveChanges();
                        Stadions.Remove(SelectedStadion);
                        SelectedStadion = null;
                    }
                    else
                    {
                        //MessageBox.Show("Stadion nije pronađen.");
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
