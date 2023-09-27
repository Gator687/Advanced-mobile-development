using Microsoft.Maui.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.Maui.Controls.Compatibility;

namespace WordleSuggestions
{
    public partial class MainPage : ContentPage
    {

        //create a list of each word from file to store
        public static List<string> allWords = ReadTextFileLines("5letterwords.txt");

        //create a temporary generationList of words. The user will use this list until they reset the words, to allow multiple requests.
        public static List<string> generationList = new List<string>(allWords);

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        //read all words from file
        private static List<String> ReadTextFileLines(string fileName)
        {
            //create output list and build filepath using filename
            List<String> output = new List<String>();
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);

            //try to read file
            try
            {
                //build array to hold all lines of file
                string[] lines = File.ReadAllLines(filePath);

                //for each line in file, trim it and add to output
                foreach (string line in lines)
                {
                    string word = line.Trim();
                    output.Add(word);
                }
            }
            catch (Exception ex)
            {
                //if no file or error, output
                Debug.WriteLine("Error: " + ex.ToString());
            }

            return output;
        }

        //On resetButtonClick:
        //clear out all button inputs
        //clear out the generationList (generationList = allWords)

        public void OnResetButtonClicked(object sender, EventArgs e)
        {
            //Debug.WriteLine("Clicked");

            //clear out all button inputs
            Letter1.Text = null;
            Letter1Color.SelectedItem = null;
            Letter2.Text = null;
            Letter2Color.SelectedItem = null;
            Letter3.Text = null;
            Letter3Color.SelectedItem = null;
            Letter4.Text = null;
            Letter4Color.SelectedItem = null;
            Letter5.Text = null;
            Letter5Color.SelectedItem = null;

            //clear out the generationList (generationList = allWords)
            generationList = new List<string>(allWords);

            //update the list to be empty
            ReturnedOutput.ItemsSource = "";
        }

        //On buttonClick:
        //check if all data is input:
        //  if not, then message user
        //  if so, then generate object with each character
        //call return list

        public async void OnGenerateClicked(object sender, EventArgs e)
        {
            //Debug.WriteLine("Clicked");

            //check if any data is missing
            if(Letter1.Text == null || Letter1Color.SelectedItem == null || Letter1.Text == "")
            {
                await DisplayAlert("Error in Generating list", "Letter 1 has either No Character or No Selected Color", "OK");
            }

            else if (Letter2.Text == null || Letter2Color.SelectedItem == null || Letter2.Text == "")
            {
                await DisplayAlert("Error in Generating list", "Letter 2 has either No Character or No Selected Color", "OK");
            }

            else if (Letter3.Text == null || Letter3Color.SelectedItem == null || Letter3.Text == "")
            {
                await DisplayAlert("Error in Generating list", "Letter 3 has either No Character or No Selected Color", "OK");
            }

            else if (Letter4.Text == null || Letter4Color.SelectedItem == null || Letter4.Text == "")
            {
                await DisplayAlert("Error in Generating list", "Letter 4 has either No Character or No Selected Color", "OK");
            }

            else if (Letter5.Text == null || Letter5Color.SelectedItem == null || Letter5.Text == "")
            {
                await DisplayAlert("Error in Generating list", "Letter 5 has either No Character or No Selected Color", "OK");
            }

            //if it all works, then we do calculations
            else
            {
                string[] letters = { Letter1.Text.ToLower(), Letter2.Text.ToLower(), Letter3.Text.ToLower(), Letter4.Text.ToLower(), Letter5.Text.ToLower() };
                string[] colors = { Letter1Color.SelectedItem.ToString(), Letter2Color.SelectedItem.ToString(), Letter3Color.SelectedItem.ToString(), Letter4Color.SelectedItem.ToString(), Letter5Color.SelectedItem.ToString() };
                generationList = DoAllLogic(letters, colors);
                //DisplayData(generationList);
                ReturnedOutput.ItemsSource = generationList;
            }
        }

        public static List<string> DoAllLogic(string[] letters, string[] colors)
        {
            List<string> output = new List<string>();

            //generate a list for each type of data (green, yellow, gray)
            //the green characters is not needed here
            List<string> grayCharacters = new List<string>();
            List<string> yellowCharacters = new List<string>();

            //we use a dictionary to hold the green characters since index is important!
            Dictionary<int, string> greenCharacters = new Dictionary<int, string>();

            for (int i = 0; i < colors.Length; i++) //do for all 5 colors
            {
                if (colors[i] == "Gray")
                {
                    grayCharacters.Add(letters[i]);
                } else if (colors[i] == "Yellow")
                {
                    yellowCharacters.Add(letters[i]);
                } else if (colors[i] == "Green")
                {
                    greenCharacters.Add(i, letters[i]);
                }
                else
                {
                    Debug.WriteLine("Error in defining all colors!");
                }
            }

            //for each word in the generationList
            foreach (string word in generationList) {
                bool hasGray = false;
                Dictionary<int, string> greenRequirements = new Dictionary<int, string>(greenCharacters);
                List<string> yellowRequirements = new List<string>(yellowCharacters);

                //get the array of characters of the word
                char[] wordCharacters = word.ToCharArray();

                //for every letter inside of the input word
                for (int i = 0; i < wordCharacters.Length; i++)
                {
                    //if the word has ANY grey character, we dont want it in the list. break to delete faster.
                    if (grayCharacters.Contains(wordCharacters[i].ToString()))
                    {
                        hasGray = true;
                        break;
                    }

                    //if we notice a yellow, remove it from the yellow list. If at the end of the checks yellow list is empty, then we can keep the word
                    else if (yellowRequirements.Contains(wordCharacters[i].ToString()))
                    {
                        yellowRequirements.Remove(wordCharacters[i].ToString());
                    }

                    //if we notice a green, remove it from the green list. If at the end of the checks green list is empty, then we can keep the word
                    else if (greenRequirements.ContainsValue(wordCharacters[i].ToString()))
                    {
                        greenRequirements.Remove(i);
                    }
                }

                //If yellow list is NOT empty, we don't have a grey character, and all green characters are in the right spots
                if (yellowRequirements.Count == 0 && hasGray == false && greenRequirements.Count == 0)
                {
                    //we can add the word to a new temp list
                    output.Add(word);
                }
            }

            //return this updated list to the user (display it)
            Debug.WriteLine("~~~~~~~~~~~~~~~~");
            foreach (string word in output)
            {
                Debug.WriteLine($"{word}");
            }

            //return the list of the words
            return output;
        }
    }
}