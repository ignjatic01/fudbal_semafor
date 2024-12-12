using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace FudbalSemafor.Models;

public partial class Igrac : INotifyPropertyChanged
{
    private int _idIgrac;
    public int IdIgrac 
    { 
        get => _idIgrac;
        set
        {
            if (_idIgrac != value)
            {
                _idIgrac = value;
                OnPropertyChanged(nameof(IdIgrac));
            }
        }
    }

    private string _ime = null!;
    public string Ime 
    {
        get => _ime;
        set
        {
            if (_ime != value)
            {
                _ime = value;
                OnPropertyChanged(nameof(Ime));
            }
        }
    }

    private string _prezime = null!;
    public string Prezime 
    {
        get => _prezime;
        set
        {
            if (_prezime != value)
            {
                _prezime = value;
                OnPropertyChanged(nameof(Prezime));
            }
        }
    }

    private int _brojDresa;
    public int BrojDresa 
    {
        get => _brojDresa;
        set
        {
            if (value != _brojDresa)
            {
                _brojDresa = value;
                OnPropertyChanged(nameof(BrojDresa));
            }
        }
    }

    private int _klub;
    public int Klub 
    { 
        get => _klub;
        set
        {
            if (_klub != value)
            {
                _klub = value;
                OnPropertyChanged(nameof(Klub));
            }
        }
    }

    private string _pozicija = null!;
    public string Pozicija 
    {
        get => _pozicija; 
        set
        {
            if (_pozicija != value)
            {
                _pozicija = value;
                OnPropertyChanged(nameof(Pozicija));
            }
        }
    }

    public virtual ICollection<Gol> Gols { get; set; } = new List<Gol>();

    public virtual ICollection<Izmjena> IzmjenaIgracIzlaziNavigations { get; set; } = new List<Izmjena>();

    public virtual ICollection<Izmjena> IzmjenaIgracUlaziNavigations { get; set; } = new List<Izmjena>();

    public virtual ICollection<Karton> Kartons { get; set; } = new List<Karton>();

    private Klub _klubNavigation = null!;
    public virtual Klub KlubNavigation 
    {
        get => _klubNavigation;
        set
        {
            if (_klubNavigation != value)
            {
                _klubNavigation = value;
                OnPropertyChanged(nameof(KlubNavigation));
            }
        }
    }

    private Pozicija _pozicijaNavigation = null!;
    public virtual Pozicija PozicijaNavigation 
    {
        get => _pozicijaNavigation; 
        set
        {
            if (_pozicijaNavigation != value)
            {
                _pozicijaNavigation = value;
                OnPropertyChanged(nameof(PozicijaNavigation));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
