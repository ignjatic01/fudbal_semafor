using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace FudbalSemafor.Models;

public partial class Pozicija : INotifyPropertyChanged
{
    private string _oznakaPozicije = null!;
    public string OznakaPozicije 
    {
        get => _oznakaPozicije; 
        set
        {
            if (_oznakaPozicije != value)
            {
                _oznakaPozicije = value;
                OnPropertyChanged(nameof(OznakaPozicije));
            }
        }
    }

    private string _nazivPozicije = null!;
    public string NazivPozicije 
    {
        get => _nazivPozicije; 
        set
        {
            if (_nazivPozicije != value)
            {
                _nazivPozicije= value;
                OnPropertyChanged(nameof(NazivPozicije));
            }
        }
    }

    public virtual ICollection<Igrac> Igracs { get; set; } = new List<Igrac>();

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
