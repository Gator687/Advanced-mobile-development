using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;

namespace BaseballTeamApp
{
    public partial class DatabasePage : ContentPage
    {
        public DatabasePage(List<BaseballTeam> baseballTeams)
        {
            InitializeComponent();
            teamListView.ItemsSource = baseballTeams;
        }
    }
}
