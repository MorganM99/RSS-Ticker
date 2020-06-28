//watchLater UI Element
//Purpose: To display the contents of the watchLater
//         database and allow for these items to be deleted
//         by the user
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Navigation;
//The libraries/packages that are
//needed are defined here

namespace RSS_Ticker_Release
{
    /// <summary>
    /// Interaction logic for watchLater.xaml
    /// </summary>
    /// 
    public partial class watchLater : Window
    {
        public ObservableCollection<newsItem> readData;
        //The ObservableCollection is defined as public
        //so functions within this file can access and
        //alter it

        public watchLater()
        {
            InitializeComponent();
            watchLaterLoaded();
        }
        //When the constructor instantiates the window,
        //the component is initialised and the function
        //watchLaterLoaded is called

        private void watchLaterLoaded()
        {
            readData = DataRoutines.readAll();
            itemList.ItemsSource = readData;
            this.DataContext = readData;
        }
        //On the loading of the watchLater window, all data from the csv file is read in
        //and added to the items collection of the ListView element itemList

        public void Navigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.ToString()));
        }
        //When a hyperlink is clicked on, this function will start a process which then 
        //is targeted to the URL specified, opening a window in the users default browser,
        //using System.Windows.Navigation and System.Diagnostics

        private void deleteAllChecked(object sender, RoutedEventArgs e)
        {
            List<newsItem> selected = (itemList.SelectedItems).OfType<newsItem>().ToList();
            foreach (newsItem selectedItem in selected)
            {
                readData.Remove(selectedItem);
            }
        }
        //When the button to delete all checked items is pressed, Linq is used to get all
        //of the selected items, and then these are iteratively removed from the 
        //collection

        private void closeWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        //When the button to save and exit is pressed, the window's close function is
        //called, which then fires the event watchLater_Close

        public void watchLater_Close(object sender, CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(this, "Do you wish to save changes to the database" +
                " before closing?", "Close Window", MessageBoxButton.YesNoCancel);
            //When the closing event fires, the following messageBox shows to allow for confirmation,
            //cancellation, and to save or not save any changes to the database, namely the deletion
            //of any items

            switch(result)
            {
                case MessageBoxResult.Yes:
                    DataRoutines.saveDatabase(readData);
                    closeEvents();
                    break;

                case MessageBoxResult.No:
                    closeEvents();
                    break;

                case MessageBoxResult.Cancel:
                    e.Cancel = true;
                    break;
            }
            //The result from the messageBox is used in this switch-case statement to call the appropriate
            //functions. If the yes button is pressed the DataRoutines function saveDatabase is called.
            //closeEvents is called after this or when no is pressed to return to the main tickerWindow,
            //and cancelling sets the necssary event argument to commence cancellation

        }

        public void closeEvents()
        {
            TickerWindow mainWindow = new TickerWindow();
            mainWindow.Show();
        }
        //closeEvents returns to the main tickerWindow after this window has closed.


    }
}
