using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace FudbalSemafor.Models;

public partial class Klub : INotifyPropertyChanged
{
    private int _idKlub;
    public int IdKlub
    {
        get => _idKlub;
        set
        {
            if (_idKlub != value)
            {
                _idKlub = value;
                OnPropertyChanged(nameof(IdKlub));
            }
        }
    }

    private string _nazivKluba = null!;
    public string NazivKluba
    {
        get => _nazivKluba;
        set
        {
            if (_nazivKluba != value)
            {
                _nazivKluba = value;
                OnPropertyChanged(nameof(NazivKluba));
            }

        }
    }

    private string _grad = null!;
    public string Grad 
    { 
        get => _grad;
        set
        {
            if (_grad != value)
            {
                _grad = value;
                OnPropertyChanged(nameof(Grad));
            }
        }
    }

    private string? _slika;
    public string? Slika
    {
        get => _slika;
        set
        {
            if (_slika != value)
            {
                _slika = value;
                OnPropertyChanged(nameof(Slika));
            }
        }
    }

    private int _boja;
    public int Boja
    {
        get => _boja;
        set
        {
            if (_boja != value)
            {
                _boja = value;
                OnPropertyChanged(nameof(Boja));
            }
        }
    }


    public virtual Boja BojaNavigation { get; set; } = null!;

    public virtual ICollection<Gol> Gols { get; set; } = new List<Gol>();

    public virtual ICollection<Igrac> Igracs { get; set; } = new List<Igrac>();

    public virtual ICollection<Utakmica> UtakmicaDomaciNavigations { get; set; } = new List<Utakmica>();

    public virtual ICollection<Utakmica> UtakmicaGostiNavigations { get; set; } = new List<Utakmica>();

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
