using ContactTracing.Models;
namespace ContactTracing;

public partial class MainPage : ContentPage
{
    public List<Information> encounters = new List<Information>();

    public MainPage()
	{
		InitializeComponent();
        LoadEncounters();
    }

    private void OnAddEncounterClicked(object sender, EventArgs e)
    {
        string name = NameEntry.Text;
        string date = DatePicker.Date.ToString("d");
        string location = LocationEntry.Text;
        Information encounter = new(name,date,location);

        encounters.Add(encounter);
        //EncounterList.Children.Add(new Label { Text = encounter });
        SaveEncounters();
    }

    private void LoadEncounters()
    {
        // Load encounters from storage (settings or local database)
        // Populate EncounterList.Children with labels for each encounter
    }

    private void SaveEncounters()
    {
        // Save encounters to storage (settings or local database)
    }
}

