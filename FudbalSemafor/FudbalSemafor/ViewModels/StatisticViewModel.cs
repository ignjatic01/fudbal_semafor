using FudbalSemafor.Models;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FudbalSemafor.ViewModels
{
    class StatisticViewModel : INotifyPropertyChanged
    {
        private ChartValues<double> _zutiKartoni;
        public ChartValues<double> ZutiKartoni 
        {
            get => _zutiKartoni;
            set
            {
                if (_zutiKartoni != value)
                {
                    _zutiKartoni = value;
                    OnPropertyChanged(nameof(ZutiKartoni));
                }
            }
        }

        private ChartValues<double> _crveniKartoni;
        public ChartValues<double> CrveniKartoni
        { 
            get => _crveniKartoni;
            set
            {
                if (_crveniKartoni != value)
                {
                    _crveniKartoni = value;
                    OnPropertyChanged(nameof(CrveniKartoni));
                }
            }
        }
        private ObservableCollection<Karton> Kartons { get; set; }
        private int BrojZutih = 0;
        private int BrojCtvenih = 0;
        public SemaforDbContext context { get; set; }

        public StatisticViewModel()
        {
            context = new SemaforDbContext();
            Kartons = new ObservableCollection<Karton>(context.Kartons.ToList());
            foreach (var karton in Kartons)
            {
                if(karton.KartonTip == 4)
                {
                    BrojCtvenih++;
                }
                else if (karton.KartonTip == 5)
                {
                    BrojZutih++;
                }
            }
            ZutiKartoni = new ChartValues<double> { BrojZutih };
            CrveniKartoni = new ChartValues<double> { BrojCtvenih };
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
