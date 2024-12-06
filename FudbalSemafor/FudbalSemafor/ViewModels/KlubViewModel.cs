using FudbalSemafor.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FudbalSemafor.ViewModels
{
    internal class KlubViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Klub> Klubs { get; set; }
        public Klub NewKlub { get; set; }

        public ICommand AddKlubCommand { get; set; }
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
        }

        public void AddKlub()
        {
            if (!string.IsNullOrWhiteSpace(NewKlub.NazivKluba))
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

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
