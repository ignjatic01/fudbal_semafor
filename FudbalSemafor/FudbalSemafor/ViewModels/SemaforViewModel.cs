using FudbalSemafor.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Timers;
using Microsoft.EntityFrameworkCore;

namespace FudbalSemafor.ViewModels
{
    internal class SemaforViewModel : INotifyPropertyChanged
    {
        private static string GoalMark = "G: ";
        private static string YellowCardMark = "YC: ";
        private static string RedCardMark = "RC: ";
        public string YellowCardWord = Properties.Settings.Default.YellowCard;
        public string RedCardWord = Properties.Settings.Default.RedCard;
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
        public ObservableCollection<Igrac> GostiStarters { get; set; }
        public ObservableCollection<Igrac> GostiSubs {  get; set; }
        public ObservableCollection<Igrac> Subs { get; set; }
        public ObservableCollection<Dogadjaj> Dogadjajs { get; set; }

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
                    OnPropertyChanged(nameof(IgracFullName));
                    if(_selectedIgrac != null)
                    {
                        if (_selectedIgrac.Klub == SelectedUtakmica.Domaci)
                        {
                            Subs = DomaciSubs;
                        }
                        else
                        {
                            Subs = GostiSubs;
                        }
                        OnPropertyChanged(nameof(Subs));
                    }
                }
            }
        }

        private Igrac _selectedSub;
        public Igrac SelectedSub
        {
            get => _selectedSub;
            set
            {
                if (value != _selectedSub)
                {
                    _selectedSub = value;
                    OnPropertyChanged(nameof(SelectedSub));
                }
            }
        }
        public string IgracFullName => $"{SelectedIgrac?.BrojDresa} {SelectedIgrac?.Prezime}";

        private Igrac _selectedDomaciStarter;
        public Igrac SelectedDomaciStarter
        {
            get => _selectedDomaciStarter;
            set
            {
                if (_selectedDomaciStarter != value)
                {
                    _selectedDomaciStarter = value;
                    SelectedIgrac = value;
                    OnPropertyChanged(nameof(SelectedDomaciStarter));
                    if (_selectedDomaciStarter != null)
                        SelectedGostiStarter = null;
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

        private Igrac _selectedGostiStarter;
        public Igrac SelectedGostiStarter
        {
            get => _selectedGostiStarter;
            set
            {
                if (_selectedGostiStarter != value)
                {
                    _selectedGostiStarter = value;
                    SelectedIgrac = value;
                    OnPropertyChanged(nameof(SelectedGostiStarter));
                    if (_selectedGostiStarter != null)
                        SelectedDomaciStarter = null;
                }
            }
        }

        private Igrac _selectedGostiSub;
        public Igrac SelectedGostiSub
        {
            get => _selectedGostiSub;
            set
            {
                if (_selectedGostiSub != value)
                {
                    _selectedGostiSub = value;
                    OnPropertyChanged(nameof(SelectedGostiSub));
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
                    OnPropertyChanged(nameof(IsNotGamePhase));
                }
            }
        }

        private bool _secondHalf;
        public bool SecondHalf
        {
            get => _secondHalf;
            set
            {
                if (_secondHalf != value)
                {
                    _secondHalf = value;
                    OnPropertyChanged(nameof(SecondHalf));
                }
            }
        }

        public bool IsNotGamePhase => !_gamePhase;

        private System.Timers.Timer _timer;
        private int _currentMinute;
        private int _targetMinute;
        public int CurrentMinute
        {
            get => _currentMinute;
            private set
            {
                if (_currentMinute != value)
                {
                    _currentMinute = value;
                    OnPropertyChanged(nameof(CurrentMinute));
                }
            }
        }

        private int _currentSecond;
        public int CurrentSecond
        {
            get => _currentSecond;
            private set
            {
                if (_currentSecond != value)
                {
                    _currentSecond = value;
                    OnPropertyChanged(nameof(CurrentSecond));
                }
            }
        }

        private bool _autogoal;
        public bool Autogoal
        {
            get => _autogoal;
            set
            {
                if (value != _autogoal)
                {
                    _autogoal = value;
                    OnPropertyChanged(nameof(Autogoal));
                }
            }
        }

        public ICommand UbaciDomaciCommand { get; set; }
        public ICommand IzbaciDomaciCommand { get; set; }
        public ICommand UbaciGostiCommand { get; set; }
        public ICommand IzbaciGostiCommand { get; set; }
        public ICommand StartCommand { get; set; }
        public ICommand GolCommand { get; set; }
        public ICommand IzmjenaCommand { get; set; }
        public ICommand YellowCardCommand { get; set; }
        public ICommand RedCardCommand { get; set; }
        public ICommand SndHalfCommand { get; set; }
        public SemaforDbContext context { get; set; }

        public SemaforViewModel(int idUtakmica)
        {
            SecondHalf = false;
            IdUtakmica = idUtakmica;
            context = new SemaforDbContext();
            SelectedUtakmica = context.Utakmicas.FirstOrDefault(u => u.IdUtakmica == IdUtakmica);
            if (SelectedUtakmica.Zapoceta)
            {
                GamePhase = false;
            }
            else
            {
                GamePhase = true;
            }
            Domaci = context.Klubs.FirstOrDefault(k => k.IdKlub == SelectedUtakmica.Domaci);
            Gosti = context.Klubs.FirstOrDefault(k => k.IdKlub == SelectedUtakmica.Gosti);

            DomaciStarters = new ObservableCollection<Igrac>((from igrac in context.Igracs
                                                              join inu in context.IgracNaUtakmicis on igrac.IdIgrac equals inu.IdIgrac
                                                              where inu.IdUtakmica == idUtakmica && igrac.Klub == SelectedUtakmica.Domaci
                                                              select igrac).ToList());
            DomaciSubs = new ObservableCollection<Igrac>(context.Igracs.Where(i => i.Klub == SelectedUtakmica.Domaci).ToList());
            foreach (var sub in DomaciSubs.ToList())
            {
                if (context.IgracNaUtakmicis.Any(inu => inu.IdIgrac == sub.IdIgrac && inu.IdUtakmica == IdUtakmica))
                {
                    DomaciSubs.Remove(sub);
                }
            }

            UbaciDomaciCommand = new RelayCommand(UbaciDomaci);
            IzbaciDomaciCommand = new RelayCommand(IzbaciDomaci);

            GostiStarters = new ObservableCollection<Igrac>((from igrac in context.Igracs
                                                              join inu in context.IgracNaUtakmicis on igrac.IdIgrac equals inu.IdIgrac
                                                              where inu.IdUtakmica == idUtakmica && igrac.Klub == SelectedUtakmica.Gosti
                                                              select igrac).ToList());
            GostiSubs = new ObservableCollection<Igrac>(context.Igracs.Where(i => i.Klub == SelectedUtakmica.Gosti).ToList());
            foreach (var sub in GostiSubs.ToList())
            {
                if (context.IgracNaUtakmicis.Any(inu => inu.IdIgrac == sub.IdIgrac && inu.IdUtakmica == IdUtakmica))
                {
                    GostiSubs.Remove(sub);
                }
            }

            Dogadjajs = new ObservableCollection<Dogadjaj>();
            ObservableCollection<Gol> gols = new ObservableCollection<Gol>(context.Gols.Where(g => g.Utakmica == IdUtakmica).ToList());
            ObservableCollection<Karton> kartons = new ObservableCollection<Karton>(context.Kartons.Include(k => k.KartonTipNavigation).Where(k => k.Utakmica == IdUtakmica).ToList());

            foreach (var gol in gols)
            {
                Igrac temp = context.Igracs.FirstOrDefault(i => i.IdIgrac == gol.Igrac);
                if (gol.Klub == SelectedUtakmica.Domaci)
                {
                    Dogadjajs.Add(new Dogadjaj(GoalMark + temp.Prezime + " " + gol.Minut + "'", HorizontalAlignment.Left, gol.Minut));
                }
                else if(gol.Klub == SelectedUtakmica.Gosti)
                {
                    Dogadjajs.Add(new Dogadjaj(GoalMark + temp.Prezime + " " + gol.Minut + "'", HorizontalAlignment.Right, gol.Minut));
                }
            }

            foreach (var karton in kartons)
            {
                Igrac temp = context.Igracs.FirstOrDefault(i => i.IdIgrac == karton.Igrac);
                if (karton.KartonTipNavigation.Tip == YellowCardWord)
                {
                    if (temp.Klub == SelectedUtakmica.Domaci)
                    {
                        Dogadjajs.Add(new Dogadjaj(YellowCardMark + temp.Prezime + " " + karton.Minut + "'", HorizontalAlignment.Left, karton.Minut));
                    }
                    else if (temp.Klub == SelectedUtakmica.Gosti)
                    {
                        Dogadjajs.Add(new Dogadjaj(YellowCardMark + temp.Prezime + " " + karton.Minut + "'", HorizontalAlignment.Right, karton.Minut));
                    }
                }
                else if (karton.KartonTipNavigation.Tip == RedCardWord)
                {
                    if (temp.Klub == SelectedUtakmica.Domaci)
                    {
                        Dogadjajs.Add(new Dogadjaj(RedCardMark + temp.Prezime + " " + karton.Minut + "'", HorizontalAlignment.Left, karton.Minut + 1));
                    }
                    else if (temp.Klub == SelectedUtakmica.Gosti)
                    {
                        Dogadjajs.Add(new Dogadjaj(RedCardMark + temp.Prezime + " " + karton.Minut + "'", HorizontalAlignment.Right, karton.Minut + 1));
                    }
                }
            }

            Dogadjajs = new ObservableCollection<Dogadjaj>(Dogadjajs.OrderBy(d => d.Minut).ToList());

            UbaciGostiCommand = new RelayCommand(UbaciGosti);
            IzbaciGostiCommand = new RelayCommand(IzbaciGosti);

            GolCommand = new RelayCommand(GolComm);
            IzmjenaCommand = new RelayCommand(IzmjenaComm);
            YellowCardCommand = new RelayCommand(YellowCardComm);
            RedCardCommand = new RelayCommand(RedCardComm);

            StartCommand = new RelayCommand(StartUtakmica);
            SndHalfCommand = new RelayCommand(SndHalf);

            _timer = new System.Timers.Timer(1000); // 1 second interval
            _timer.Elapsed += OnTimerElapsed;
        }

        private void UbaciDomaci(object parameter)
        {
            if (parameter is Igrac igrac && DomaciStarters.Count < 11)
            {
                IgracNaUtakmici inu = new IgracNaUtakmici();
                inu.IdIgrac = igrac.IdIgrac;
                inu.IdUtakmica = IdUtakmica;
                context.Add(inu);
                context.SaveChanges();
                DomaciStarters.Add(igrac);
                DomaciSubs.Remove(igrac);
                OnPropertyChanged(nameof(DomaciStarters));
                OnPropertyChanged(nameof(DomaciSubs));
                
            }
        }

        private void IzbaciDomaci(object parameter)
        {
            if (parameter is Igrac igrac)
            {
                IgracNaUtakmici existingInu = context.IgracNaUtakmicis.FirstOrDefault(inu => inu.IdIgrac == igrac.IdIgrac && inu.IdUtakmica == IdUtakmica);
                context.Remove(existingInu);
                context.SaveChanges();
                DomaciSubs.Add(igrac);
                DomaciStarters.Remove(igrac);
                OnPropertyChanged(nameof(DomaciStarters));
                OnPropertyChanged(nameof(DomaciSubs));   
            }
        }

        private void UbaciGosti(object parameter)
        {
            if (parameter is Igrac igrac && GostiStarters.Count < 11)
            {
                IgracNaUtakmici inu = new IgracNaUtakmici();
                inu.IdIgrac = igrac.IdIgrac;
                inu.IdUtakmica = IdUtakmica;
                context.Add(inu);
                context.SaveChanges();
                GostiStarters.Add(igrac);
                GostiSubs.Remove(igrac);
                OnPropertyChanged(nameof(GostiStarters));
                OnPropertyChanged(nameof(GostiSubs));
            }
        }

        private void IzbaciGosti(object parameter)
        {
            if (parameter is Igrac igrac)
            {
                IgracNaUtakmici existingInu = context.IgracNaUtakmicis.FirstOrDefault(inu => inu.IdIgrac == igrac.IdIgrac && inu.IdUtakmica == IdUtakmica);
                context.Remove(existingInu);
                context.SaveChanges();
                GostiSubs.Add(igrac);
                GostiStarters.Remove(igrac);
                OnPropertyChanged(nameof(GostiStarters));
                OnPropertyChanged(nameof(GostiSubs));
            }
        }

        private void StartUtakmica()
        {
            GamePhase = false;
            SelectedUtakmica.Zapoceta = true;
            var existingUtakmica = context.Utakmicas.FirstOrDefault(u => u.IdUtakmica == SelectedUtakmica.IdUtakmica);
            existingUtakmica.Zapoceta = true;
            context.SaveChanges();
            StartTimer(1, 45);
        }

        private void SndHalf()
        {
            SecondHalf = true;
            StartTimer(46, 90);
        }

        public void StartTimer(int startingMinute, int targetMinute)
        {
            if (startingMinute < 0 || targetMinute <= startingMinute)
                throw new ArgumentException("Invalid starting or target minute.");

            CurrentMinute = startingMinute;
            CurrentSecond = 0;
            _targetMinute = targetMinute;
            _timer.Start();
        }

        public void StopTimer()
        {
            _timer.Stop();
        }

        private void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            if (CurrentMinute >= _targetMinute)
            {
                _timer.Stop();
                SecondHalf = true;
                return;
            }

            if (CurrentSecond == 59)
            {
                CurrentSecond = 0;
                CurrentMinute++;
            }
            else
            {
                CurrentSecond++;
            }
        }

        private void IzmjenaComm()
        {
            if (SelectedSub != null)
            {
                Izmjena izmjena = new Izmjena();
                izmjena.IgracUlazi = SelectedSub.IdIgrac;
                izmjena.IgracIzlazi = SelectedIgrac.IdIgrac;
                izmjena.Minut = CurrentMinute;
                izmjena.Utakmica = IdUtakmica;
                context.Izmjenas.Add(izmjena);
                context.SaveChanges();
                if(SelectedSub.Klub == SelectedUtakmica.Domaci)
                {
                    DomaciStarters.Remove(SelectedIgrac);
                    DomaciStarters.Add(SelectedSub);
                    DomaciSubs.Remove(SelectedSub);
                }
                else
                {
                    GostiStarters.Remove(SelectedIgrac);
                    GostiStarters.Add(SelectedSub);
                    GostiSubs.Remove(SelectedSub);
                }
                SelectedSub = null;
            }
        }

        private void YellowCardComm()
        {
            if(SelectedIgrac != null)
            {
                Karton karton = GenerateKarton(YellowCardWord);

                context.Kartons.Add(karton);
                Igrac temp = context.Igracs.FirstOrDefault(i => i.IdIgrac == karton.Igrac);
                if (karton.KartonTipNavigation.Tip == YellowCardWord)
                {
                    if (temp.Klub == SelectedUtakmica.Domaci)
                    {
                        Dogadjajs.Add(new Dogadjaj(YellowCardMark + temp.Prezime + " " + karton.Minut + "'", HorizontalAlignment.Left, karton.Minut));
                    }
                    else if (temp.Klub == SelectedUtakmica.Gosti)
                    {
                        Dogadjajs.Add(new Dogadjaj(YellowCardMark + temp.Prezime + " " + karton.Minut + "'", HorizontalAlignment.Right, karton.Minut));
                    }
                }
                context.SaveChanges();

                int numOfYellowCards = context.Kartons.Where(k => k.Igrac == SelectedIgrac.IdIgrac && k.KartonTip == karton.KartonTip && k.Utakmica == IdUtakmica).Count();

                if (numOfYellowCards > 1)
                {
                    Karton redCard = GenerateKarton(RedCardWord);

                    context.Kartons.Add(redCard);

                        if (temp.Klub == SelectedUtakmica.Domaci)
                        {
                            Dogadjajs.Add(new Dogadjaj(RedCardMark + temp.Prezime + " " + karton.Minut + "'", HorizontalAlignment.Left, karton.Minut + 1));
                        }
                        else if (temp.Klub == SelectedUtakmica.Gosti)
                        {
                            Dogadjajs.Add(new Dogadjaj(RedCardMark + temp.Prezime + " " + karton.Minut + "'", HorizontalAlignment.Right, karton.Minut + 1));
                        }

                    context.SaveChanges();

                    if (SelectedIgrac.Klub == SelectedUtakmica.Domaci)
                    {
                        DomaciStarters.Remove(SelectedIgrac);
                    }
                    else if (SelectedIgrac.Klub == SelectedUtakmica.Gosti)
                    {
                        GostiStarters.Remove(SelectedIgrac);
                    }
                }
            }
        }

        private Karton GenerateKarton(String type)
        {
            Karton karton = new Karton();
            KartonTip kt = context.KartonTips.FirstOrDefault(kt => kt.Tip == type);
            if (kt == null)
            {
                kt = new KartonTip();
                kt.Tip = type;
                context.SaveChanges();
                kt = context.KartonTips.FirstOrDefault(kt => kt.Tip == type);
            }
            karton.KartonTip = kt.IdKartonTip;
            karton.Igrac = SelectedIgrac.IdIgrac;
            karton.Utakmica = IdUtakmica;
            karton.Minut = CurrentMinute;
            return karton;
        }

        private void RedCardComm()
        {
            if (SelectedIgrac != null)
            {
                Karton karton = GenerateKarton(RedCardWord);

                context.Kartons.Add(karton);
                Igrac temp = context.Igracs.FirstOrDefault(i => i.IdIgrac == karton.Igrac);
                if (karton.KartonTipNavigation.Tip == RedCardWord)
                {
                    if (temp.Klub == SelectedUtakmica.Domaci)
                    {
                        Dogadjajs.Add(new Dogadjaj(RedCardMark + temp.Prezime + " " + karton.Minut + "'", HorizontalAlignment.Left, karton.Minut));
                    }
                    else if (temp.Klub == SelectedUtakmica.Gosti)
                    {
                        Dogadjajs.Add(new Dogadjaj(RedCardMark + temp.Prezime + " " + karton.Minut + "'", HorizontalAlignment.Right, karton.Minut));
                    }
                }
                context.SaveChanges();

                if (SelectedIgrac.Klub == SelectedUtakmica.Domaci)
                {
                    DomaciStarters.Remove(SelectedIgrac);
                }
                else if (SelectedIgrac.Klub == SelectedUtakmica.Gosti)
                {
                    GostiStarters.Remove(SelectedIgrac);
                }
            }
        }

        private void GolComm()
        {
            if (SelectedIgrac != null)
            {
                Gol gol = new Gol();
                gol.Utakmica = IdUtakmica;
                gol.Igrac = SelectedIgrac.IdIgrac;
                gol.Minut = CurrentMinute;
                if (!Autogoal)
                {
                    gol.Klub = SelectedIgrac.Klub;
                }
                else
                {
                    if (SelectedIgrac.Klub == Domaci.IdKlub)
                    {
                        gol.Klub = Gosti.IdKlub;
                    }
                    else if (SelectedIgrac.Klub == Gosti.IdKlub)
                    {
                        gol.Klub = Domaci.IdKlub;
                    }
                }
                context.Gols.Add(gol);
                var existingUtakmica = context.Utakmicas.FirstOrDefault(u => u.IdUtakmica == SelectedUtakmica.IdUtakmica);
                Igrac temp = context.Igracs.FirstOrDefault(i => i.IdIgrac == gol.Igrac);
                if (gol.Klub == Domaci.IdKlub)
                {
                    existingUtakmica.GoloviDomaci += 1;
                    Dogadjajs.Add(new Dogadjaj(GoalMark + temp.Prezime + " " + gol.Minut + "'", HorizontalAlignment.Left, gol.Minut));
                }
                else if (gol.Klub == Gosti.IdKlub)
                {
                    existingUtakmica.GoloviGosti += 1;
                    Dogadjajs.Add(new Dogadjaj(GoalMark + temp.Prezime + " " + gol.Minut + "'", HorizontalAlignment.Right, gol.Minut));
                }
                context.SaveChanges();
            }
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
