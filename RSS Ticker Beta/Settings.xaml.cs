//Settings UI Element
//Purpose: Displays settings the user can alter, and allows
//         for the addition and deletion of new news sources

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Windows.Media;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Navigation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
//All useful libraries/packages are
//defined here

namespace RSS_Ticker_Release
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        public string newSource;
        public string sourceInpText = "Input new news sources here";
        public ObservableCollection<string> sources;
        //These declarations are for important variables which must be 
        //passed between functions in this module

        public Settings()
        {
            sources = DataRoutines.sourceRead();
            InitializeComponent();
            feedList.ItemsSource = sources;
            this.DataContext = sources;
        }
        //Upon construction, the sourceRead function is called, which 
        //reads from a text file containing all news sources input

        private void addFeed(object sender, RoutedEventArgs e)
        {
            newSource = this.sourceInp.Text;
            bool valid=RSS_Scraper.validateSource(newSource);
            if(valid==true)
            {
                sources.Add(newSource);
                sourceInp.Text = sourceInpText;
                sourceInp.Foreground = Brushes.Gray;
            }
            else if(valid==false)
            {
                MessageBox.Show(this,"The data you entered is not a valid RSS source, please try again.",
                    "Invalid Input", MessageBoxButton.OK);
                sourceInp.Text = sourceInpText;
                sourceInp.Foreground = Brushes.Gray;
            }
        }
        //When the appropriate button is pressed, the text from the source input textbox is
        //stored and the validateSource function from the RSS_Scraper module called, which
        //returns a bool based on whether the input text is valid or invalid. If valid,
        //the Observable Collection of news source strings is added to. Otherwise, a 
        //messageBox is shown which informs the user of their invalid input. In both cases
        //after these events occur, the source input textbox is reset to default.

        private void closeSettings(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        //The button which says to save and exit the Settings window will start
        //closure of the window, triggering the event handler for the Closing
        //event

        public void Settings_Closing(object sender, CancelEventArgs e)
        {
            MessageBoxResult result=MessageBox.Show(this, "Do you wish to save changes to settings before closing?",
                "Save changes?", MessageBoxButton.YesNoCancel);

            switch(result)
            {
                case MessageBoxResult.Yes:
                    saveSettings();
                    closeEvent();
                    break;

                case MessageBoxResult.No:
                    closeEvent();
                    break;

                case MessageBoxResult.Cancel:
                    e.Cancel = true;
                    break;
            }
        }
        //When the Settings window has began to close, a MessageBox is shown which asks for
        //user confirmation, via buttons to save the changes to settings, not save them, or
        //cancel it. A switch-case statement is performed against the result of the messageBox,
        //calling the appropriate events or triggering cancellation as necessary

        public void closeEvent()
        {
            TickerWindow mainWindow = new TickerWindow();
            mainWindow.Show();
        }
        //When the Settings window has closed, a new instance of the 
        //main tickerWindow is called and shown, returning the program
        //to scrolling news on the screen

        public void saveSettings()
        {
            DataRoutines.saveSources(sources);
            Properties.Settings.Default.Save();
        }
        //If settings are chosen to be saved, the text file of news sources
        //is saved via the saveSources function in DataRoutines.

        private void deleteAllChecked(object sender, RoutedEventArgs e)
        {
            List<string> selected = (feedList.SelectedItems).OfType<string>().ToList();
            foreach(string selectedItem in selected)
            {
                sources.Remove(selectedItem);
            }
        }
        //When the button to delete all checked feeds is clicked, a List of all
        //selected items is cast using the SelectedItems property of my 
        //news source ListView feedList. Then, these selected items are
        //removed from the sources ObservableCollection iteratively. The ToList
        //casting function is called from the Linq library

        private void sourceInp_MouseEnter(object sender, MouseEventArgs e)
        {
            if (sourceInp.Text == "" || sourceInp.Text == sourceInpText)
            {
                sourceInp.Text = "";
                sourceInp.Foreground = Brushes.Black;
            }
        }
        //When the mouse enters the source input text box, checks are
        //done to ensure that the user has not already started inputting a feed,
        //by checking if the textBox is blank or if it contains the original
        //prompting text.
        //If they havent, the textbox is cleared and the text set to a black colour.

        private void sourceInp_MouseLeave(object sender, MouseEventArgs e)
        {
            if(sourceInp.Text=="")
            {
                sourceInp.Text = sourceInpText;
                sourceInp.Foreground = Brushes.Gray;
            }
        }
        //When the mouse leaves the source input text box, a check is done to ensure
        //that a news source has not been partially input by the user already, by seeing
        //if this textBox has no text in it. If this is true, the textbox is reset to
        //displaying the prompting text, greyed out.

        public void Navigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.ToString()));
        }
        //When a hyperlink is clicked on, using the System.Windows.Navigation and
        //System.Diagnostics packages a process is started which will open
        //the hyperlink in the default web browser of the users computer
    }
}
