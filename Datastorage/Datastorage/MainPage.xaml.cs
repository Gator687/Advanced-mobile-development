﻿using Datastorage.Models;
using System.Text.Json;
using System.IO;

namespace Datastorage;

public partial class MainPage : ContentPage
{
	int count = 0;

	public HelloClicker hc = new();
	private String _filename = FileSystem.AppDataDirectory + "/ HelloClicker.txt";
	private async void WriteToFile()
	{
		var writeData = JsonSerializer.Serialize(hc);
		File.WriteAllText(this._filename, writeData);
	}

	private async void ReadFile()
	{
		HelloClicker readHC = new();
		if(File.Exists(this._filename) == false)
		{
			return;
			//stop function if the file does not exist
		}

		var rawData = File.ReadAllText(_filename);
		readHC = JsonSerializer.Deserialize<HelloClicker>(rawData);

		hc.Total = readHC.Total;
		hc.Last = readHC.Current; //Current is the data from the last run
		hc.Current = 0;

		CounterBtn.Text = $"Clicked {hc.Total} times";
		CurrentCLickLabel.Text = hc.Current.ToString();
		LastCLickLabel.Text = hc.Last.ToString();
	}

	public MainPage()
	{
		InitializeComponent();
		ReadFile();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		//count++;
		hc.Current++;
		hc.Total++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {hc.Total} time";
		else
			CounterBtn.Text = $"Clicked {hc.Total} times";

		CurrentCLickLabel.Text = hc.Current.ToString();

		SemanticScreenReader.Announce(CounterBtn.Text);
		WriteToFile();
	}
}

