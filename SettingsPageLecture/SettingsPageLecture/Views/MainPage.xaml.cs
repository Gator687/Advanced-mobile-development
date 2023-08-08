namespace SettingsPageLecture;

public partial class MainPage : ContentPage
{
	int count = 0;

	private void ReadSettings()
	{
		Color appBack;
		if (Preferences.Default.ContainsKey("AppBack"))
		{
			appBack = Color.FromHex(Preferences.Default.Get("AppBack", "#ffffff"));
		}
		else
		{
			appBack = Color.FromHex("#ffffff");
		}
		Application.Current.Resources["AppBack"] = appBack;
	}
	public MainPage()
	{
		InitializeComponent();
		//read back in
		ReadSettings();
	}

	/*private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}*/
}

