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

        private int _id;
        public int Id
        {
            get => _id;
            set
            {
                if (_id != value)
                {
                    _id = value;
                    OnPropertyChanged(nameof(Id));
                }
            }
        }

        private int _minut;
        public int Minut
        {
            get => _minut;
            set
            {
                if (_minut != value)
                {
                    _minut = value;
                    OnPropertyChanged(nameof(Minut));
                }
            }
        }

        public HorizontalAlignment Alignment { get; set; }

        public Dogadjaj(string tekst, HorizontalAlignment alignment, int minut, int id)
        {
            Tekst = tekst;
            Alignment = alignment;
            Minut = minut;
            Id = id;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
