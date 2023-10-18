using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Warhammer40KDatasheet.Models
{
    public partial class DataSheet : ObservableObject
    {
        [ObservableProperty]
        string untiName;

        [ObservableProperty]
        string toughness;

        [ObservableProperty]
        string strength;

        [ObservableProperty]
        string movement;

        [RelayCommand]
        public void AddUnit()
        {

        }
    }
}
