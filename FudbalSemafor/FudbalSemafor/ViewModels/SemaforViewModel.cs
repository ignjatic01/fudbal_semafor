using FudbalSemafor.Models;
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
    internal class SemaforViewModel : INotifyPropertyChanged
    {
        public int IdUtakmica {  get; set; }
        private Utakmica _selectedUtakmica;
        public Utakmica SelectedUtakmica 
        {
            get => _selectedUtakmica; 
            set
            {
                if (value != _selectedUtakmica)
                {
                    _selectedUtakmica = value;
                    OnPropertyChanged(nameof(SelectedUtakmica));
                }
            }
        }

        public Klub Domaci { get; set; }
        public Klub Gosti { get; set; }

        public ObservableCollection<Igrac> DomaciStarters { get; set; }
        public ObservableCollection<Igrac> DomaciSubs { get; set; }

        private Igrac _selectedDomaciStarter;
        public Igrac SelectedDomaciStarter
        {
            get => _selectedDomaciStarter;
            set
            {
                if (_selectedDomaciStarter != value)
                {
                    _selectedDomaciStarter = value;
                    OnPropertyChanged(nameof(SelectedDomaciStarter));
                }
            }
        }

        private Igrac _selectedDomaciSub;
        public Igrac SelectedDomaciSub
        {
            get => _selectedDomaciSub;
            set
            {
                if (_selectedDomaciSub != value)
                {
                    _selectedDomaciSub = value;
                    OnPropertyChanged(nameof(SelectedDomaciSub));
                }
            }
        }

        private bool _gamePhase;
        public bool GamePhase 
        { 
            get => _gamePhase;
            set
            {
                if (_gamePhase != value)
                {
                    _gamePhase = value;
                    OnPropertyChanged(nameof(GamePhase));
                }
            }
        }

        public ICommand UbaciDomaciCommand { get; set; }
        public SemaforDbContext context { get; set; }

        public SemaforViewModel(int idUtakmica)
        {
            GamePhase = true;
            IdUtakmica = idUtakmica;
            context = new SemaforDbContext();
            SelectedUtakmica = context.Utakmicas.FirstOrDefault(u => u.IdUtakmica == IdUtakmica);
            Domaci = context.Klubs.FirstOrDefault(k => k.IdKlub == SelectedUtakmica.Domaci);
            Gosti = context.Klubs.FirstOrDefault(k => k.IdKlub == SelectedUtakmica.Gosti);
            DomaciStarters = new ObservableCollection<Igrac>(context.Igracs.Where(i => i.UIgri && i.Klub == SelectedUtakmica.Domaci).ToList());
            DomaciSubs = new ObservableCollection<Igrac>(context.Igracs.Where(i => !i.UIgri && i.Klub == SelectedUtakmica.Domaci).ToList());
            UbaciDomaciCommand = new RelayCommand(UbaciDomaci);          
        }

        private void UbaciDomaci(object parameter)
        {
            if (parameter is Igrac igrac)
            {
                igrac.UIgri = true;
                context.Igracs.Update(igrac);
                context.SaveChanges();
                DomaciStarters.Add(igrac);
                DomaciSubs.Remove(igrac);
                SelectedDomaciSub = null;
                OnPropertyChanged(nameof(DomaciStarters));
                OnPropertyChanged(nameof(DomaciSubs));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
