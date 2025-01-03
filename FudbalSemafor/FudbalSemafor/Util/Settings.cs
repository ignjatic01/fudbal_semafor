using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FudbalSemafor.Util
{
    public sealed partial class Settings : ApplicationSettingsBase, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        [UserScopedSetting]
        [DefaultSettingValue("12")]
        public int FontSize
        {
            get => (int)this["FontSize"];
            set
            {
                this["FontSize"] = value;
                OnPropertyChanged(nameof(FontSize));
            }
        }
    }

}
