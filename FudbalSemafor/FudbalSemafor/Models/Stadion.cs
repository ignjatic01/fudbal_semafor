using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace FudbalSemafor.Models;

public partial class Stadion : INotifyPropertyChanged
{
    private int _idStadion;
    public int IdStadion 
    { 
        get => _idStadion;
        set
        {
            if (_idStadion != value)
            {
                _idStadion = value;
                OnPropertyChanged(nameof(IdStadion));
            }
        }
    }

    private string _naziv = null!;
    public string Naziv 
    { 
        get => _naziv;
        set
        {
            if (_naziv != value)
            {
                _naziv = value;
                OnPropertyChanged(nameof(Naziv));
            }
        }
    }

    private string? _grad;
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

    private int _kapacitet;
    public int Kapacitet 
    {
        get => _kapacitet; 
        set
        {
            if (value != _kapacitet)
            {
                _kapacitet = value;
                OnPropertyChanged(nameof(Kapacitet));
            }
        }
    }

    private string? _podloga;
    public string Podloga 
    {
        get => _podloga;
        set
        {
            if (_podloga != value)
            {
                _podloga = value;
                OnPropertyChanged(nameof(Podloga));
            }
        }
    }

    public virtual ICollection<Utakmica> Utakmicas { get; set; } = new List<Utakmica>();

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
