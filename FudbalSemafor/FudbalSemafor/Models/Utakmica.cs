using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace FudbalSemafor.Models;

public partial class Utakmica : INotifyPropertyChanged
{
    private int _idUtakmica;
    public int IdUtakmica 
    {
        get => _idUtakmica; 
        set
        {
            if (value != _idUtakmica)
            {
                _idUtakmica = value;

            }
        }
    }

    private int _domaci;
    public int Domaci 
    { 
        get => _domaci; 
        set
        {
            if (value != _domaci)
            {
                _domaci = value;
                OnPropertyChanged(nameof(Domaci));
            }
        }
    }

    private int _gosti;
    public int Gosti 
    {
        get => _gosti; 
        set
        {
            if (_gosti != value)
            {
                _gosti = value;
                OnPropertyChanged(nameof(Gosti));
            }
        }
    }

    private int? _stadion;
    public int? Stadion 
    {
        get => _stadion; 
        set
        {
            if (_stadion != value)
            {
                _stadion = value;
                OnPropertyChanged(nameof(Stadion));
            }
        }
    }

    private int _goloviDomaci;
    public int GoloviDomaci 
    {
        get => _goloviDomaci;
        set
        {
            if (_goloviDomaci != value)
            {
                _goloviDomaci = value;
                OnPropertyChanged(nameof(GoloviDomaci));
            }
        }
    }

    private int _goloviGosti;
    public int GoloviGosti 
    {
        get => _goloviGosti;
        set
        {
            if (value != _goloviGosti)
            {
                _goloviGosti = value;
                OnPropertyChanged(nameof(GoloviGosti));
            }
        }
    }

    private Klub _domaciNavigation = null!;
    public virtual Klub DomaciNavigation 
    {
        get => _domaciNavigation;
        set
        {
            if (_domaciNavigation != value)
            {
                _domaciNavigation = value;
                OnPropertyChanged(nameof(DomaciNavigation));
            }
        }
    }

    public virtual ICollection<Gol> Gols { get; set; } = new List<Gol>();

    private Klub _gostiNavigation = null!;
    public virtual Klub GostiNavigation 
    {
        get => _gostiNavigation;
        set
        {
            if (value != _gostiNavigation)
            {
                _gostiNavigation = value;
                OnPropertyChanged(nameof(GostiNavigation));
            }
        }
    }

    public virtual ICollection<Izmjena> Izmjenas { get; set; } = new List<Izmjena>();

    public virtual ICollection<Karton> Kartons { get; set; } = new List<Karton>();

    private Stadion? _stadionNavigation;
    public virtual Stadion? StadionNavigation 
    {
        get => _stadionNavigation;
        set
        {
            if (_stadionNavigation != value)
            {
                _stadionNavigation = value;
                OnPropertyChanged(nameof(StadionNavigation));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
