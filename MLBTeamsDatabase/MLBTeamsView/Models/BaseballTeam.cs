using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.ComponentModel;
using SQLite;

namespace MLBTeamsView.Models
{
    [Table("Teams")]
    public class BaseballTeam : INotifyPropertyChanged
    {
        [PrimaryKey, AutoIncrement]
        public string Team { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChangedEventArgs args = new PropertyChangedEventArgs(propertyName);

                PropertyChanged(this, args);
            }
        }

        private string _teamName;
        [MaxLength(100)]
        public string TeamName
        {
            get { return _teamName; }
            set
            {
                _teamName = value;
                OnPropertyChanged("City");
            }
        }

        private string _city;
        [MaxLength(100)]
        public string City
		{
			get { return _city; }
			set { _city = value;
                OnPropertyChanged("City");
            }
		}

        private string _league;
        [MaxLength(100)]
        public string League
        {
            get { return _league; }
            set
            {
                _league = value;
                OnPropertyChanged("League");
            }
        }

        public BaseballTeam(string teamName, string city, string league)
        {
            _teamName = teamName;
            _city = city;
            _league = league;
        }

        public BaseballTeam()
        {
            _teamName = "No team";
            _city = "";
            _league = "";
        }
    }
}
