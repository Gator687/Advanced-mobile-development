using System.Globalization;
using System;
using System.Resources;

namespace ViewsApp;

[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class MainPage : ContentPage
{
    private ResourceManager _resourceManager = new ResourceManager(typeof(ViewsApp.Resources.Strings));

    public MainPage()
	{
		InitializeComponent();
	}

    private void ChangeLanguageButton_Clicked(object sender, EventArgs e)
    {
        // Toggle between English and Spanish
        string newCulture = CultureInfo.CurrentCulture.Name.StartsWith("en") ? "es" : "en";
        CultureInfo.CurrentCulture = new CultureInfo(newCulture);
        UpdateUI();
    }

    private void UpdateUI()
    {
        // Refresh UI elements with new language resources
        TitleLabel.Text = _resourceManager.GetString("Title");
    }
}

