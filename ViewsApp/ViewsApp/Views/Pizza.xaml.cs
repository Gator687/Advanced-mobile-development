using Microsoft.Maui.Controls;
using System;
namespace ViewsApp.Views;

public partial class Pizza : ContentPage
{
	public Pizza()
	{
		InitializeComponent();
	}

    private void OnBuildPizzaClicked(object sender, EventArgs e)
    {
        double basePrice = 0;
        double toppingPricePerUnit = 0;

        // Calculate base price and topping price per unit based on pizza size
        switch (sizePicker.SelectedItem as string)
        {
            case "Small":
                basePrice = 8.99;
                toppingPricePerUnit = 0.5;
                break;
            case "Medium":
                basePrice = 10.99;
                toppingPricePerUnit = 0.75;
                break;
            case "Large":
                basePrice = 12.99;
                toppingPricePerUnit = 1.0;
                break;
        }

        // Calculate topping price
        double toppingPrice = 0;
        if (pepperoniCheckbox.IsChecked)
            toppingPrice += toppingPricePerUnit;
        if (mushroomsCheckbox.IsChecked)
            toppingPrice += toppingPricePerUnit;
        if (peppersCheckbox.IsChecked)
            toppingPrice += toppingPricePerUnit;
        if (baconCheckbox.IsChecked)
            toppingPrice += toppingPricePerUnit;
        if (sausageCheckbox.IsChecked)
            toppingPrice += toppingPricePerUnit;

        double totalPrice = basePrice + toppingPrice;

        resultLabel.Text = $"Your Pizza:\nSize: {sizePicker.SelectedItem}\nToppings: {GetSelectedToppings()}\nTotal Price: ${totalPrice:F2}";
    }


    private string GetSelectedToppings()
    {
        var toppings = new List<string>();
        if (pepperoniCheckbox.IsChecked)
            toppings.Add("Pepperoni");
        if (mushroomsCheckbox.IsChecked)
            toppings.Add("Mushrooms");
        if (peppersCheckbox.IsChecked)
            toppings.Add("Peppers");
        if (baconCheckbox.IsChecked)
            toppings.Add("Bacon");
        if (sausageCheckbox.IsChecked)
            toppings.Add("Sausage");

        return string.Join(", ", toppings);
    }
}