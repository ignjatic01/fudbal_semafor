using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FudbalSemafor.Models
{
    public class Dogadjaj : INotifyPropertyChanged
    {
        private string _tekst;
        public string Tekst
        {
            get => _tekst;
            set
            {
                if (_tekst != value)
                {
                    _tekst = value;
                    OnPropertyChanged(nameof(Tekst));
                }
            }
        }

        public HorizontalAlignment Alignment { get; set; }

        public Dogadjaj(string tekst, HorizontalAlignment alignment)
        {
            Tekst = tekst;
            Alignment = alignment;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
