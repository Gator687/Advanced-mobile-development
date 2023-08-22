﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PitchCounter.Models;
using System.ComponentModel;

namespace PitchCounter.ViewModels
{
    public class PlayerViewModel : INotifyPropertyChanged
    {
        public Command AddBallCommand { get; set; }
        public Command AddStrikeCommand { get; set; }
        public Command ResetCommand { get; set; }

        public void Reset()
        {
            _thePitcher.Balls = 0;
            _thePitcher.Strikes = 0;
            _thePitcher.Total = 0;
        }

        public void AddBall()
        {
            _thePitcher.Balls++;
        }

        public void AddStrike() 
        {
            _thePitcher.Strikes++;
        }
        private PlayerClass _thePitcher;

        public PlayerClass ThePitcher
        {
            get { return _thePitcher; }
            set { _thePitcher = value; }
        }

        //default Constructor
        public PlayerViewModel()
        {
            //link the public Command to the logic function
            AddBallCommand = new Command(AddBall);
            AddStrikeCommand = new Command(AddStrike);
            ResetCommand = new Command(Reset);
            _thePitcher = new PlayerClass();
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

                //PropertyChangedEventArgs args = new PropertyChangedEventArgs(propertyName);

                //PropertyChanged(this, args);
            }
        }
    }
}
