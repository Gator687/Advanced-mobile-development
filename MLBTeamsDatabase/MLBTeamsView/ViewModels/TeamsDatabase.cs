using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using MLBTeamsView.Models;
using System.ComponentModel;

namespace MLBTeamsView.ViewModels
{
    class TeamsDatabase
    {
        private SQLiteConnection _connection;
        private string _dbPath;
        private void Init()
        {   //build the connection to the database
            if (_connection != null)
            {
                return;
            }
            _connection = new SQLiteConnection(_dbPath);
            _connection.CreateTable<BaseballTeam>();

        }

        public TeamsDatabase(string dbPath)
        {
            _dbPath = dbPath;//set database name
        }

        public async void InsertTeam(BaseballTeam newTeam)
        {
            int result = 0;
            try
            {
                Init();
                if (string.IsNullOrEmpty(newTeam.TeamName))
                {
                    //protect my data
                    throw new Exception("Name Required");
                }//end if
                //check everything that could be an issue
                result = _connection.Insert(newTeam);
            }//end try
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("DB Error", ex.ToString(), "OK");
            }
        }//end function

        public List<BaseballTeam> GetTeams()
        {
            try
            {
                Init();
                return _connection.Table<BaseballTeam>().OrderBy(p => p.TeamName).ToList();
            }
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Read error", ex.ToString(), "OK");
            }

            //will return blank if the database fails
            return new List<BaseballTeam>();
        }
    }
}
