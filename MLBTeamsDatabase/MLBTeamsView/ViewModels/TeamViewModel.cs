using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MLBTeamsView.Models;
using System.ComponentModel;
using MLBTeamsView.ViewModels;

namespace MLBTeamsView.ViewModels
{
    class TeamViewModel :INotifyPropertyChanged
    {
        public Command NewTeamCommand { get; set; }
        public async void NewTeam()
        {
            bool saveIt = await App.Current.MainPage.DisplayAlert("New Team?",
                    "Save and clear Team?", "Yes", "No");
            if (saveIt)
            {
                //will write to database here
                App.TeamDBase.InsertTeam(_theTeam);
                _theTeam.TeamName = null;
                _theTeam.City = null;
                _theTeam.League = null;
            }
        }

        public TeamViewModel()
        {
            NewTeamCommand = new Command(NewTeam);
            _theTeam = new BaseballTeam();
        }

        private BaseballTeam _theTeam;

        public BaseballTeam TheTeam
        {
            get { return _theTeam; }
            set { _theTeam = value; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                // PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

                PropertyChangedEventArgs args = new PropertyChangedEventArgs(propertyName);

                PropertyChanged(this, args);
            }
        }
    }
}
