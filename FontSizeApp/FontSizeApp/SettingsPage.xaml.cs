//using FontSizeApp.Models;
namespace FontSizeApp;

public partial class SettingsPage : ContentPage
{
    public SettingsPage()
    {
        InitializeComponent();
        BindingContext = new MainViewModel();
    }

    private void OnSliderChange(object sender, EventArgs e)
    {
        double sliderValue = FontSizeSlider.Value;

    }
}