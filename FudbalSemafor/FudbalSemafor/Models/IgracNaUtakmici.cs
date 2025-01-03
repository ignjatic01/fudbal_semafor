using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FudbalSemafor.Models
{
    public partial class IgracNaUtakmici : INotifyPropertyChanged
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



        private int _idUtakmica;
        public int IdUtakmica
        {
            get => _idUtakmica;
            set
            {
                if (value != _idUtakmica)
                {
                    _idUtakmica = value;
                    OnPropertyChanged(nameof(IdUtakmica));
                }
            }
        }

        /*
        private Igrac _igracNavigation = null!;
        public virtual Igrac IgracNavigation
        {
            get => _igracNavigation;
            set
            {
                if (_igracNavigation != value)
                {
                    _igracNavigation = value;
                    OnPropertyChanged(nameof(IgracNavigation));
                }
            }
        }

        private Utakmica _utakmicaNavigation = null!;
        public virtual Utakmica UtakmicaNavigation
        {
            get => _utakmicaNavigation;
            set
            {
                if (_utakmicaNavigation != value)
                {
                    _utakmicaNavigation = value;
                    OnPropertyChanged(nameof(UtakmicaNavigation));
                }
            }
        }
        */

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
