using UnitsNet;
using DataBindLesson.Models;
using DataBindLesson.Data;
namespace DataBindLesson;

public partial class MainPage : ContentPage
{
	public DataClass database = new();
	public List<Conversion> DataList {  get; set; }
	//List, Collection, ObservableCollection

	private void OnSliderChange(object sender, EventArgs e)
		{
			double sliderValue = weigthSlider.Value;
			Mass pounds = new Mass(sliderValue,UnitsNet.Units.MassUnit.Pound);
			double kg = pounds.Kilograms;
			kilogramLabel.Text = kg.ToString("F1");
		}

	public MainPage()
	{
		InitializeComponent();
		//fill the list
		foreach (Conversion conversion in DataList)
		{
			DataList.Add(conversion);
		}
	}
}

