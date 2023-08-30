using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Guido_sPizza.Models
{
    public class SettingsViewModel : INotifyPropertyChanged
    {
        private double _globalFontSize = 14; // Default font size

        public double GlobalFontSize
        {
            get => _globalFontSize;
            set
            {
                if (_globalFontSize != value)
                {
                    _globalFontSize = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
