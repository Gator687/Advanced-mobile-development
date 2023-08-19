using MLBTeamsView.Models;
namespace MLBTeamsView;

public partial class MainPage : ContentPage
{
    public BaseballTeam[] TeamsArray = new BaseballTeam[4];
    public MainPage()
	{
		InitializeComponent();
        TeamsArray[0] = new BaseballTeam("Yankees", "New York", "American League");
        TeamsArray[1] = new BaseballTeam("Dodgers", "Los Angeles", "National League");
        TeamsArray[2] = new BaseballTeam("Nationals", "Washington", "National League");
        TeamsArray[3] = new BaseballTeam("Mariners", "Seattle", "American League");

        TeamsListView.ItemsSource = TeamsArray;
    }

}

