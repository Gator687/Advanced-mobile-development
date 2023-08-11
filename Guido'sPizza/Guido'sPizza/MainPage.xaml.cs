using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;

namespace Guido_sPizza
{
    public partial class MainPage : ContentPage
    {
        private Dictionary<string, double> toppingPrices = new Dictionary<string, double>
        {
            { "Pepperoni", 1.5 },
            { "Mushrooms", 1.0 },
            { "Onions", 1.0 },
            { "Green Peppers", 1.0 },
            { "Olives", 1.5 }
            // Add more toppings and prices as needed
        };

        public MainPage()
        {
            InitializeComponent();
        }

        private void BuildPizza_Clicked(object sender, EventArgs e)
        {
            double basePrice = 0;
            double toppingPrice = 0;

            // Calculate base price based on pizza size
            switch (SizePicker.SelectedItem.ToString())
            {
                case "Small":
                    basePrice = 5.99;
                    break;
                case "Medium":
                    basePrice = 8.99;
                    break;
                case "Large":
                    basePrice = 11.99;
                    break;
            }

            // Calculate topping price based on selected toppings
            foreach (var toppingCheckbox in ToppingCheckBoxes)
            {
                if (toppingCheckbox.IsChecked)
                {
                    string toppingName = toppingCheckbox.Text;
                    toppingPrice += toppingPrices[toppingName];
                }
            }

            double totalPrice = basePrice + toppingPrice;

            // Display the result
            ResultLabel.Text = $"Your {SizePicker.SelectedItem} pizza with selected toppings costs: ${totalPrice:F2}";
        }
    }
}
