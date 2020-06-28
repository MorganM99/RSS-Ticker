//MainWindow UI element
//Purpose: Will display the ticker and has
//         buttons to go to different menus and interaction logic
//         to add items to the CSV database

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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel.Composition;
using System.ComponentModel;
using WpfAppBar;
using RSS_Ticker_Release;

namespace RSS_Ticker_Release
{
    /// <summary>
    /// Interaction logic for TickerWindow.xaml
    /// </summary>
    public partial class TickerWindow : Window
    {
        public Ticker<TickerItemElement> ticker;
        //This stores the current ticker object

        public MessageBoxResult result;
        public bool toWatchLater;
        public bool toSettings;
        //These variables are used to determine the appropriate
        //closing behaviour of the window

        public TickerWindow()
        {
            InitializeComponent();
        }

        protected void window_onLoad(object sender, RoutedEventArgs e)
        {
            initTicker();
        }
        //The function initTicker is called when loading is complete,
        //to initialise the key aspects of the window

        public void initTicker()
        {
            List<string> sources = (DataRoutines.sourceRead()).ToList();
            //The list of input newsSources is read using 
            //DataRoutines.sourceRead

            List<newsItem> news = RSS_Scraper.RSS_Scrape(sources);
            //This list of input sources is then passed to 
            //RSS_Scraper.RSS_Scrape, which gathers
            //all news from those sources

            ticker = new Ticker<TickerItemElement>(canv, this);
            //A new ticker is instantiated, with a parent of the 
            //current tickerWindow instantiating it, and a
            //containing window of the canvas element canv

            foreach (newsItem item in news)
            {
                ticker.items.Add(new TickerItemElement(item));
            }
            //Subsequently, the list of items the ticker has to
            //scroll is added to with the gathered news, creating
            //tickerItemElements as the process occurs

            ticker.refreshInterval = Properties.Settings.Default.refreshTime;
            //The refresh interval of the ticker is set to the user set
            //property refreshTime

            string tickerSpeedStr = Properties.Settings.Default.tickerSpeed;
            int defaultSpeed = 60;
            //The default speed of the ticker corresponds to a 60 second
            //TimeSpan. The string tickerSpeedStr is linked to the tickerSpeed
            //user setting, and is used to determine the modifier to this
            //value

            switch (tickerSpeedStr)
            {
                //The following switch-case block will choose the 
                //appropriate modifier to the speed value

                case "50%":
                    defaultSpeed = 2 * (defaultSpeed);
                    ticker.animDuration = new TimeSpan(0, 0, defaultSpeed);
                    break;
                //The speed being set to 50% slower means that the TimeSpan must
                //be doubled

                case "75%":
                    defaultSpeed = Convert.ToInt32((1.5 * (Convert.ToDouble(defaultSpeed))));
                    ticker.animDuration = new TimeSpan(0, 0, defaultSpeed);
                    break;
                //For 75%, this is halfway between 1.0 and 2.0 times the default value. As
                //this is multiplying by a double, the program must convert to the integer
                //deafult value to a double and back to an integer for use in the TimeSpan

                case "100%":
                    ticker.animDuration = new TimeSpan(0, 0, defaultSpeed);
                    break;
                //This is the default value, so there are no changes made

                case "150%":
                    defaultSpeed = Convert.ToInt32((0.75 * (Convert.ToDouble(defaultSpeed))));
                    ticker.animDuration = new TimeSpan(0, 0, defaultSpeed);
                    break;
                //A 150% speed corresponds to a 0.75 times multiplier, making the TimeSpan
                //smaller

                case "200%":
                    defaultSpeed = Convert.ToInt32((0.5 * (Convert.ToDouble(defaultSpeed))));
                    ticker.animDuration = new TimeSpan(0, 0, defaultSpeed);
                    break;
                    //A 200% speed halves the TimeSpan to 30 seconds
            }


            ticker.Start();
            dock();
            //The ticker is started and the dock function called
        }


        public void dock()
        {
            string dockStr = Properties.Settings.Default.dockEdge;
            //dockStr is set to the value of the setting which
            //defines which screen edge to dock to

            if (dockStr == "Bottom")
            {
                AppBarFunctions.SetAppBar(this, ABEdge.Bottom);
            }

            else if (dockStr == "Top")
            {
                AppBarFunctions.SetAppBar(this, ABEdge.Top);
            }
            //Using the WpfAppBar package, the window is
            //made into an AppBar, at the top or bottom edge
            //according to dockStr
        }

        public void undock()
        {
            AppBarFunctions.SetAppBar(this, ABEdge.None);
        }
        //When focus moves away from the ticker window or it 
        //closes, it must first be undocked so that reserved screen space
        //is freed for use by other programs


        public void Refresh()
        //This function calls when the ticker needs to be refreshed
        {
            canv.Children.Clear();
            //The canvas is cleared of any TickerItemElements

            List<string> sources = (DataRoutines.sourceRead()).ToList();
            List<newsItem> news = RSS_Scraper.RSS_Scrape(sources);
            ticker.items.Clear();
            foreach (newsItem item in news)
            {
                ticker.items.Add(new TickerItemElement(item));
            }
            //The tickers list of items is cleared, and then filled
            //with a new set of news

            ticker.refreshInterval = Properties.Settings.Default.refreshTime;
            ticker.animTimer.Interval = new TimeSpan(0, 0, 1);

            string tickerSpeedStr = Properties.Settings.Default.tickerSpeed;
            int defaultSpeed = 60;

            switch (tickerSpeedStr)
            {


                case "50%":
                    defaultSpeed = 2 * (defaultSpeed);
                    ticker.animDuration = new TimeSpan(0, 0, defaultSpeed);
                    break;


                case "75%":
                    defaultSpeed = Convert.ToInt32((1.5 * (Convert.ToDouble(defaultSpeed))));
                    ticker.animDuration = new TimeSpan(0, 0, defaultSpeed);
                    break;


                case "100%":
                    ticker.animDuration = new TimeSpan(0, 0, defaultSpeed);
                    break;


                case "150%":
                    defaultSpeed = Convert.ToInt32((0.75 * (Convert.ToDouble(defaultSpeed))));
                    ticker.animDuration = new TimeSpan(0, 0, defaultSpeed);
                    break;


                case "200%":
                    defaultSpeed = Convert.ToInt32((0.5 * (Convert.ToDouble(defaultSpeed))));
                    ticker.animDuration = new TimeSpan(0, 0, defaultSpeed);
                    break;

            }
            ticker.Start();
            //The ticker is then reset and started. WHile inefficient, this does function
            //as intended
        }

        private void goToWatchLater(object sender, RoutedEventArgs e)
        {
            this.Hide();
            undock();
            toWatchLater = true;
            this.Close();
        }
        //The watchLater window is created and shown when the watchLater button is pressed via this event
        //This also closes the tickerWindow by hiding, undocking, and closing the window.
        //toWatchLater is also set to true

        private void goToSettings(object sender, RoutedEventArgs e)
        {
            this.Hide();
            undock();
            toSettings = true;
            this.Close();
        }
        //The Settings window is created and shown when the settings button is pressed via this event,
        //which closes the tickerWindow and sets toSettings to true

        public void TickerWidnow_Closing(object sender, CancelEventArgs e)
        {
            result = MessageBox.Show(this, "Are you sure you want to close the ticker? \n (If seeing this when" +
                " attempting to enter watchLater or settings, the application will not be closed, but entering no will" +
                " reopen the main ticker)", "Exiting Ticker Application", MessageBoxButton.YesNo);
            //When the tickerWindow closing event fires, a dialog box is shown which alerts the user. This fires
            //regardless of if the window is closed by closing the application or navigating to the settings
            //or watchLater window, so this is also explained to the user

            switch (result)
            {
                case MessageBoxResult.Yes:
                    undock();
                    if (toWatchLater == true)
                    {
                        watchLater watchLater = new watchLater();
                        watchLater.Show();
                        toWatchLater = false;
                    }
                    //When the tickerWindow is closed, toWatchLater is checked
                    //to see if the user had pressed the button to navigate to it,
                    //then this window is created or the user is returned to a new main
                    //tickerWindow depending upon the result

                    else if (toSettings == true)
                    {
                        Settings settings = new Settings();
                        settings.Show();
                        toSettings = false;
                    }
                    //The same is true for the Settings window using toSettings instead

                    else if((toSettings!=true)&&(toWatchLater!=true))
                    {
                    }

                    break;
                case MessageBoxResult.No:
                    DoNotClose();
                    break;
            }
        }
        //Finally, if the buttons were not pressed and the user has said No,
        //then this is cancelled

        public void DoNotClose()
        {
            this.Hide();
            undock();
            TickerWindow mainWindow = new TickerWindow();
            mainWindow.Show();
        }

    }
}

