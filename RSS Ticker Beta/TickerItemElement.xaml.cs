//TickerItemElement userControl
//Purpose: To provide a simple UI element which can
//         embed and scroll news along the screen

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Microsoft.VisualBasic;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Diagnostics;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RSS_Ticker_Release
{
    /// <summary>
    /// Interaction logic for TickerItemElement.xaml
    /// </summary>
    public partial class TickerItemElement : UserControl
    {
        public Double ratingDbl;
        public string ratingStr;
        private newsItem feedItem;
        //The feedItem variable will store the passed in
        //newsItem, whereas ratingDbl and ratingStr are
        //used when getting and validating the watchLater
        //rating

        public newsItem FeedItem
        {
            get { return feedItem; }
            set { feedItem=value; }
        }
        //The FeedItem property stores a newsItem which can
        //be set and retrieved

        public TickerItemElement(newsItem itemIn)
        {
            InitializeComponent();
            DataContext = this;
            FeedItem = itemIn;
        }
        //The constructor initialises the component, then
        //sets the data context to itself and sets the FeedItem
        //property accordingly.

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            bool ratingValid = false;
            //This variable sets up a loop in order to allow
            //for a while loop to be used

            while(ratingValid==false)
            {
            //The while loop allows for the rating input to be retried
            //by the user, or cancelled if they change their mind

                ratingStr = Interaction.InputBox("Please enter an importance rating from 0.0 to 10.0 to 1 decimal place" +
                    " (Entering nothing will cancel this operation, as will pressing the cancel button) ", "Assign rating", "");
                //A VisualBasic InputBox is created and displays the following message, with a suitable title and blank 
                //default response. The input response is stored in a suitable variable, ratingStr, defined at the start of 
                //the code for this object.

                if(ratingStr=="")
                {
                    break;
                }
                //Pressing the cancel button on the InputBox will always return an empty string, so this if statement
                //is used to detect the cancellation event and break the while loop

                try
                {
                    ratingDbl = Double.Parse(ratingStr);
                }
                //A try-catch block is used, and an attempt is made to parse the input string to a Double

                catch(Exception)
                {
                    MessageBox.Show("Entered rating is not a valid number, please try again or cancel", "Invalid Format", MessageBoxButton.OK);
                    continue;
                }
                //Any exception is caught here. This would be from an invalid parse, due to input of non-numeric characters.
                //As such, the following dialog box alerts the user of this, and continues the while loop to allow for
                //input to be retried.

                ratingDbl=Math.Round(ratingDbl, 1);
                //If the parsing is a success, the Double value is rounded to one decimal place

                if(ratingDbl>= 0.0 && ratingDbl<=10.0)
                {
                    newsItem currentItem = FeedItem;
                    currentItem.Rating = ratingDbl;
                    FeedItem = currentItem;
                    ratingValid = true;
                }
                //If the rating input is between the boundaries of 0 and 10 inclusive, then the rating of the 
                //newsItem object contained in the TickerItemEelement object is set to this input rating value
                //by first retrieving the stored newsItem, setting the rating value, and then storing the altered
                //newsItem
                //ratingValid is thereafter set to true, breaking the while loop.

                else
                {
                    MessageBox.Show("Entered rating is not between 0.0 and 10.0, please try again", "Invalid Range", MessageBoxButton.OK);
                    continue;
                }
                //If the rating value is outside of these boundaries, the following is displayed, and the
                //while loop continues to allow the user to retry inputting the rating

            }

            if (ratingStr == "")
            {

            }
            //If the input was cancelled then the while loop breaks, and so to stop
            //the addition of an unwanted item to the watchLater database, this if statement
            //detects that eventuality and ensures that no action is taken

            else
            {
                DataRoutines.addItem(this);
            }
            //If the if statement above is not triggered, then the TickerItemElement object
            //is added to the database using the DataRoutines function addItem.
        }

        public void Navigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.ToString()));
        }
        //When a hyperlink is clicked, this code will start a process
        //which opens a window in the users default web browser

    }
}
