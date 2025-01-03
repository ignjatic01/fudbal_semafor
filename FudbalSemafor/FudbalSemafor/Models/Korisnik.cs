using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace FudbalSemafor.Models;

public partial class Korisnik : INotifyPropertyChanged
{
    private int _idKorisnik;
    public int IdKorisnik 
    {
        get => _idKorisnik; 
        set
        {
            if (_idKorisnik != value)
            {
                _idKorisnik = value;
                OnPropertyChanged(nameof(IdKorisnik));
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

    private string _korisnickoIme = null!;
    public string KorisnickoIme 
    {
        get => _korisnickoIme; 
        set
        {
            if ( _korisnickoIme != value)
            {
                _korisnickoIme = value;
                OnPropertyChanged(nameof(KorisnickoIme));
            }
        }
    }

    private string _lozinka = null!;
    public string Lozinka 
    {
        get => _lozinka; 
        set
        {
            if ( _lozinka != value)
            {
                _lozinka = value;
                OnPropertyChanged(nameof(Lozinka));
            }
        }
    }

    private int _role;
    public int Role 
    { 
        get => _role; 
        set
        {
            if (_role != value)
            {
                _role = value;
                OnPropertyChanged(nameof(Role));
            }
        }
    }

    private Role _roleNavigation = null!;
    public virtual Role RoleNavigation 
    {
        get => _roleNavigation;
        set
        {
            if (_roleNavigation != value)
            {
                _roleNavigation = value;    
                OnPropertyChanged(nameof(RoleNavigation));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
