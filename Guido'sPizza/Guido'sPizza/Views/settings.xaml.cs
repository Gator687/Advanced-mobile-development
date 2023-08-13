namespace Guido_sPizza.Views;

public partial class settings : ContentPage
{
    private ResourceDictionary ColorResource = Application.Current.Resources.MergedDictionaries.FirstOrDefault() as ResourceDictionary;

    public settings()
	{
		InitializeComponent();
	}

    public void OnCheckChange(object sender, System.EventArgs e)
    {
        if (sender.Equals(Back1Radio))
        {
            Application.Current.Resources["AppBack"] = ColorResource["Back1"];
        }
        else if (sender.Equals(Back2Radio))
        {
            Application.Current.Resources["AppBack"] = ColorResource["Back2"];
        }
        else if (sender.Equals(Back3Radio))
        {
            Application.Current.Resources["AppBack"] = ColorResource["Back3"];
        }

        else
        {
            Application.Current.Resources["AppBack"] = ColorResource["Back1"];
        }//end if
        //do this for each property
        Color appBack;
        appBack = (Color)Application.Current.Resources["AppBack"];
        Preferences.Default.Set("AppBack", appBack.ToHex().ToString());
    }//end function

    public void OnSizeChange(object sender, System.EventArgs e)
    {
        if (sender.Equals(FontSize1Radio))
        {
            
        }

        else if (sender.Equals(FontSize2Radio))
        {

        }

        else if (sender.Equals(FontSize3Radio))
        {

        }

        else
        {

        }
    }
}