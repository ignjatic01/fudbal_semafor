using FudbalSemafor.Models;
using LiveCharts;
using LiveCharts.Wpf;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace FudbalSemafor.ViewModels
{
    class StatisticViewModel : INotifyPropertyChanged
    {
        public string YellowCardWord = Properties.Settings.Default.YellowCard;
        public string RedCardWord = Properties.Settings.Default.RedCard;

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

        private ChartValues<double> _strijelci;
        public ChartValues<double> Strijelci
        {
            get => _strijelci;
            set
            {
                if (_strijelci != value)
                {
                    _strijelci = value;
                    OnPropertyChanged(nameof(Strijelci));
                }
            }
        }

        private ChartValues<double> _neStrijelci;
        public ChartValues<double> NeStrijelci
        {
            get => _neStrijelci;
            set
            {
                if (_neStrijelci != value)
                {
                    _neStrijelci = value;
                    OnPropertyChanged(nameof(NeStrijelci));
                }
            }
        }
        private ObservableCollection<Klub> Klubs { get; set; }
        private ObservableCollection<Karton> Kartons { get; set; }
        private ObservableCollection<Igrac> Igracs { get; set; }
        private ObservableCollection<Gol> Gols { get; set; }
        public ObservableCollection<IgracStatistika> IgracStatistikas { get; set; }
        public ObservableCollection<KlubStatistika> KlubStatistikas { get; set;}
        private int BrojZutih = 0;
        private int BrojCtvenih = 0;
        private int BrojStrijelaca = 0;
        public SemaforDbContext context { get; set; }

        public StatisticViewModel()
        {
            context = new SemaforDbContext();
            Kartons = new ObservableCollection<Karton>(context.Kartons.Include(k => k.KartonTipNavigation).ToList());
            Igracs = new ObservableCollection<Igrac>(context.Igracs.ToList());
            Gols = new ObservableCollection<Gol>(context.Gols.ToList());
            Klubs = new ObservableCollection<Klub>(context.Klubs.ToList());
            IgracStatistikas = new ObservableCollection<IgracStatistika>(GetIgracStatistika());
            KlubStatistikas = new ObservableCollection<KlubStatistika>(GetKlubStatistika());

            foreach (var karton in Kartons)
            {
                if(karton.KartonTipNavigation.Tip == RedCardWord)
                {
                    BrojCtvenih++;
                }
                else if (karton.KartonTipNavigation.Tip == YellowCardWord)
                {
                    BrojZutih++;
                }
            }
            foreach(var igrac in Igracs)
            {
                foreach(var gol in Gols)
                {
                    if (igrac.IdIgrac == gol.Igrac)
                    {
                        BrojStrijelaca++;
                        break;
                    }
                }
            }
          
            ZutiKartoni = new ChartValues<double> { BrojZutih };
            CrveniKartoni = new ChartValues<double> { BrojCtvenih };
            Strijelci = new ChartValues<double> { BrojStrijelaca };
            NeStrijelci = new ChartValues<double> { Igracs.Count - BrojStrijelaca };
        }

        public List<IgracStatistika> GetIgracStatistika()
        {
            var statistike = context.Igracs
                .Select(igrac => new IgracStatistika
                {
                    IgracId = igrac.IdIgrac,
                    Ime = igrac.Ime,
                    Prezime = igrac.Prezime,
                    Klub = igrac.KlubNavigation.NazivKluba,
                    BrojGolova = igrac.Gols.Count,
                    BrojZutihKartona = igrac.Kartons.Count(k => k.KartonTipNavigation.Tip == YellowCardWord), 
                    BrojCrvenihKartona = igrac.Kartons.Count(k => k.KartonTipNavigation.Tip == RedCardWord)
                })
                .ToList();

            return statistike;
        }

        public List<KlubStatistika> GetKlubStatistika()
        {
            var statistike = context.Klubs
                .Select(klub => new KlubStatistika
                {
                    IdKlub = klub.IdKlub,
                    Naziv = klub.NazivKluba,
                    Grad = klub.Grad,
                    BrojUtakmica = klub.UtakmicaDomaciNavigations.Count + klub.UtakmicaGostiNavigations.Count,
                    BrojNerijesenih = context.Utakmicas.Count(u =>
                        (u.Domaci == klub.IdKlub || u.Gosti == klub.IdKlub) &&
                        u.GoloviDomaci == u.GoloviGosti 
                    ),
                    BrojPobjeda = context.Utakmicas.Count(u =>
                        (u.Domaci == klub.IdKlub && u.GoloviDomaci > u.GoloviGosti) ||
                        (u.Gosti == klub.IdKlub && u.GoloviGosti > u.GoloviDomaci)
                    ),
                    BrojPoraza = context.Utakmicas.Count(u =>
                        (u.Domaci == klub.IdKlub && u.GoloviDomaci < u.GoloviGosti) ||
                        (u.Gosti == klub.IdKlub && u.GoloviGosti < u.GoloviDomaci)
                    )
                }).ToList();

            return statistike;
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
