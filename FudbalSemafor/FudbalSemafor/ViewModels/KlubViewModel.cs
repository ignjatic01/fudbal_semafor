using FudbalSemafor.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

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

        private string _nazivSlike;
        public string NazivSlike
        {
            get => _nazivSlike;
            set
            {
                _nazivSlike = value;
                OnPropertyChanged(nameof(NazivSlike));
            }
        }

        private BitmapImage _prikazSlike;

        private string _trenutnaPutanjaSlike;

        public BitmapImage PrikazSlike
        {
            get => _prikazSlike;
            set
            {
                _prikazSlike = value;
                OnPropertyChanged(nameof(PrikazSlike));
            }
        }

        public ICommand DodajSlikuCommand { get; set; }

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
            DodajSlikuCommand = new RelayCommand(DodajSliku);
        }

        public void AddKlub()
        {
            if (!string.IsNullOrWhiteSpace(NewKlub.NazivKluba) && !string.IsNullOrWhiteSpace(NewKlub.Grad))
            {
                try
                {
                    if(!string.IsNullOrEmpty(_trenutnaPutanjaSlike))
                    {
                        NewKlub.Slika = _trenutnaPutanjaSlike;
                    }

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

        public void DodajSliku()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image files (*.jpg, *.jpeg, *.png, *.bmp)|*.jpg;*.jpeg;*.png;*.bmp",
                Title = "Izaberite sliku"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                string originalPath = openFileDialog.FileName;
                string fileName = System.IO.Path.GetFileName(originalPath);

                // Dobijanje putanje projekta (2 nivoa iznad bin foldera)
                string projectDirectory = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\");
                string imagesDirectory = System.IO.Path.Combine(projectDirectory, "Images");

                // Kreirajte folder ako ne postoji
                if (!Directory.Exists(imagesDirectory))
                {
                    Directory.CreateDirectory(imagesDirectory);
                }

                // Nova putanja za sliku
                string newImagePath = System.IO.Path.Combine(imagesDirectory, fileName);

                // Kopirajte sliku u projektni folder
                File.Copy(originalPath, newImagePath, overwrite: true);

                // Postavite novu putanju u ViewModel
                _trenutnaPutanjaSlike = System.IO.Path.Combine("Images", fileName); // Relativna putanja
                NazivSlike = fileName;

                // Prikaz slike
                BitmapImage bitmap = new BitmapImage(new Uri(newImagePath, UriKind.Absolute));
                PrikazSlike = bitmap;
            }
            else
            {
                MessageBox.Show("Niste izabrali sliku.", "Obaveštenje", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }



        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
