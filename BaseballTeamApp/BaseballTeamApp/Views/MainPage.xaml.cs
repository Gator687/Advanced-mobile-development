using Microsoft.Maui.Controls;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BaseballTeamApp
{
    public partial class MainPage : ContentPage
    {
        private DatabaseContext dbContext;

        public MainPage()
        {
            InitializeComponent();
            dbContext = new DatabaseContext();
        }

        private void OnSaveClicked(object sender, EventArgs e)
        {
            var baseballTeam = new BaseballTeam
            {
                TeamName = teamNameEntry.Text,
                City = cityEntry.Text,
                League = leagueEntry.Text
            };

            dbContext.Connection.Insert(baseballTeam);

            teamNameEntry.Text = "";
            cityEntry.Text = "";
            leagueEntry.Text = "";

            DisplayAlert("Success", "Team information saved.", "OK");
        }

        private void OnClearClicked(object sender, EventArgs e)
        {
            teamNameEntry.Text = "";
            cityEntry.Text = "";
            leagueEntry.Text = "";
        }

        private async void OnViewDatabaseClicked(object sender, EventArgs e)
        {
            var baseballTeams = dbContext.Connection.Table<BaseballTeam>().ToList();
            await Navigation.PushAsync(new DatabasePage(baseballTeams));
        }
    }
}
