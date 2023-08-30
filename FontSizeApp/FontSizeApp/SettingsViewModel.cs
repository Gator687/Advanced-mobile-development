using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FontSizeApp
{
    public class SettingsViewModel : INotifyPropertyChanged
    {
        private double fontSize;

        public double FontSize
        {
            get => fontSize;
            set
            {
                if (fontSize != value)
                {
                    fontSize = value;
                    OnPropertyChanged();
                    ApplyFontSize();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void ApplyFontSize()
        {
            // Apply the new font size to your app's styles here
            Application.Current.Resources["FontSize"] = FontSize;
        }
    }
}
