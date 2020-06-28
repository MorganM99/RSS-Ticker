//Data Routines Class
//Purpose-To handle the writing and reading of the
//        watchLater.csv and feeds.txt files
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using CsvHelper;
//Since this file has several CSV handling routines, the CsvHelper 
//library must be referenced

namespace RSS_Ticker_Release
{
    class DataRoutines
    {
        public static string databasePath = "watchLater.csv";
        public static string feedPath = "feeds.txt";
       //For this application, the file paths are statically defined and cannot change,
       //as validating new file locations can prove difficult


    
        //Name:readAll
        //Purpose: Reads all data from the CSV file so it can be altered in the program
        //before changes are comitted to the watchLater database
        //Requisite Inputs: None
        //Returned Data: ObservableCollection of newsItem objects
        public static ObservableCollection<newsItem> readAll()
        {
            if (!File.Exists(databasePath))
            {
                System.IO.FileStream f = System.IO.File.Create(databasePath);
                f.Close();
            }
            using (StreamReader sr = new StreamReader(databasePath))
            {
                    CsvReader cr = new CsvReader(sr);
                
                    cr.Configuration.HasHeaderRecord = false;
                    ObservableCollection<newsItem> storedItems = new ObservableCollection<newsItem>(cr.GetRecords<newsItem>());
                    return storedItems;
                
            }
        }
        //Firstly, the function will create the database file if it currently does not 
        //exist at the specified path. 
        //Since the StreamReader and CsvReader are disposable they are enclosed in using
        //statements. Then, we ensure that the csvReader is configured to not check
        //for any header records. Then all data is read in and converted into an Observable Collection of
        //newsItems. This list is then returned.

        //Name:addItem
        //Purpose: Adds a new news item to the watchLater database
        //Requisite Inputes: One TickerItemElement which is to be saved
        //Returned Data: None
        public static void addItem (TickerItemElement sender)
        {
            ObservableCollection<newsItem> currentData = readAll();
            List<newsItem> currentDataList = new List<newsItem>(currentData);
            //An ObservableCollection of newsItem objects is returned
            //from the readAll function, and then converted into a list
            //format to allow for sorting

            currentDataList.Add(sender.FeedItem);
            //The new item is added to the list

            currentDataList.Sort((x, y) => y.Rating.CompareTo(x.Rating));
            //The following statement sorts the list of items to be 
            //stored by their rating value. This is done using a
            //lambda expression, comparing the rating of two objects.
            //By comparing y to x instead of x to y, this allows for
            //a descending order.

            using (StreamWriter sw = new StreamWriter(databasePath))
            {
                    CsvWriter cw = new CsvWriter(sw);
                    cw.Configuration.HasHeaderRecord = false;
                    cw.WriteRecords(currentDataList);
                
            }
            //The sorted and updated set of entries is written to
            //the watchLater.csv file
        }

        //Name:saveDatabase
        //Purpose:To save all items to the database when exiting the
        //        watchLater window, if the user has chosen to save their
        //        changes
        //Requisite Inputs:An ObservableCollection containing the
        //                  set of items to be saved as newsItem objects
        //Returned Data:None
        public static void saveDatabase(ObservableCollection<newsItem> watchLaterData)
        {
            if (!File.Exists(databasePath))
            {
                System.IO.FileStream f = System.IO.File.Create(databasePath);
                f.Close();
            }
            List<newsItem> watchLaterList = new List<newsItem>(watchLaterData);
            watchLaterList.Sort((x, y) => y.Rating.CompareTo(x.Rating));
            using (StreamWriter sw = new StreamWriter(databasePath))
            {
                    CsvWriter cw = new CsvWriter(sw);
                    cw.Configuration.HasHeaderRecord = false;
                    cw.WriteRecords(watchLaterList);
                
            }
        }
        //saveDatabase will firstly create the database if for some reason the file
        //has been moved or deleted while the ticker application is running. Then,
        //the ObservableCollection passed in is converted to a List, so that a lambda
        //expression (The same one as in the addItem function) can be used to sort
        //them into descending rating order. Then, the List is written to the watch
        //later csv file


        //Name:sourceRead
        //Purpose:To read in the current set of RSS sources from the feeds.txt file
        //Requisite Inputs: None
        //Returned Data:An ObservableCollection of strings
        public static ObservableCollection<string> sourceRead()
        {
            if (!File.Exists(feedPath))
            {
                System.IO.FileStream f = System.IO.File.Create(feedPath);
                f.Close();
            }
            string[] sourceArray=File.ReadAllLines(feedPath);
            ObservableCollection<string> sourceList = new ObservableCollection<string>(sourceArray);
            return sourceList;
        }
        //If the feeds.txt file does not exist, it will first be created. After that, or if
        //the file already exists, all lines of the feeds.txt file are read to a string array
        //which is then used to create the necessary ObservableCollection of strings, and
        //this ObservableCollection is returned


        //Name:saveSources
        //Purpose:To save all RSS sources to the feeds.txt file when the user chooses
        //        to save any changes made in the Settings window
        //Requisite Inputs:An ObservableCollection of strings, the data to be saved
        //Returned Data:None
        public static void saveSources(ObservableCollection<string> sources)
        {
            if (!File.Exists(feedPath))
            {
                System.IO.FileStream f = System.IO.File.Create(feedPath);
                f.Close();
            }
            File.WriteAllLines(feedPath, sources);
        }
        //Like above, the feeds.txt file is re-created if it for some reason is not
        //found. Then, all of the sources to be saved are written to this file at once,
        //in a line by line fashion

    }
}
