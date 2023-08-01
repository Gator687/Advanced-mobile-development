using Microsoft.Maui.Controls;

namespace TipCalculator
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCalculateTipClicked(object sender, EventArgs e)
        {
            double bill = 0, tip = 0, percentage = 0;
            try
            {
                bill = Convert.ToDouble(BillAmountEntry.Text);   
            }
            catch (Exception)
            {
                bill = 0;
                BillAmountEntry.Focus();
                return;
            }

            percentage = Convert.ToDouble(TipPercentagePicker.SelectedItem as string);

            tip = bill * (percentage / 100.0);
            TipAmountLabel.Text = tip.ToString("$0.##");
        }
    }
}
