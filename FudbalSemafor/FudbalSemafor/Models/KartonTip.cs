using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace FudbalSemafor.Models;

public partial class KartonTip : INotifyPropertyChanged
{
    private int _idKartonTip;
    public int IdKartonTip 
    {
        get => _idKartonTip;
        set
        {
            if (_idKartonTip != value)
            {
                _idKartonTip = value;
                OnPropertyChanged(nameof(IdKartonTip));
            }
        }
    }

    private string _tip = null!;

    public string Tip 
    {
        get => _tip;
        set
        {
            if (_tip != value)
            {
                _tip = value;
                OnPropertyChanged(nameof(Tip));
            }
        }
    }

    public virtual ICollection<Karton> Kartons { get; set; } = new List<Karton>();

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
