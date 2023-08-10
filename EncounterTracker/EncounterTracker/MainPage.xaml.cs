using System;
using System.IO;
using System.Collections.Generic;
using Microsoft.Maui.Controls;

namespace EncounterTracker
{
    public partial class MainPage : ContentPage
    {
        private List<string> encounterData = new List<string>();
        private string dataFilePath;

        public MainPage()
        {
            InitializeComponent();

            dataFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "encounter_data.txt");
            LoadEncounterData();
        }

        private async void OnAddEncounterClicked(object sender, EventArgs e)
        {
            string name = NameEntry.Text;
            DateTime date = DatePicker.Date;
            string location = LocationEntry.Text;

            string encounter = $"{date:d}: {name} - {location}";
            encounterData.Add(encounter);

            EncounterList.Children.Add(new Label { Text = encounter });

            NameEntry.Text = "";
            LocationEntry.Text = "";

            await SaveEncounterData();
        }

        private async void LoadEncounterData()
        {
            if (File.Exists(dataFilePath))
            {
                encounterData = new List<string>(await File.ReadAllLinesAsync(dataFilePath));
                foreach (string encounter in encounterData)
                {
                    EncounterList.Children.Add(new Label { Text = encounter });
                }
            }
        }

        private async System.Threading.Tasks.Task SaveEncounterData()
        {
            await File.WriteAllLinesAsync(dataFilePath, encounterData);
        }
    }
}
