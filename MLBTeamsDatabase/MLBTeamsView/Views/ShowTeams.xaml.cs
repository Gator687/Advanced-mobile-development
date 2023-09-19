using MLBTeamsView.Models;

namespace MLBTeamsView.Views;

public partial class ShowTeams : ContentPage
{
	public ShowTeams()
	{
		InitializeComponent();
	}

    public void FillTheList(object sender, EventArgs e)
    {
        List<BaseballTeam> Teams = App.pitchDBase.GetTeams();
        pitcherList.ItemsSource = Teams;
    }
}