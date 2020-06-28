//RSS Ticker-RSS_Scraper
//Purpose: To scrape data from the Internet into a list of newsItem objects
//         and validate new news feeds when input

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml;
using System.ServiceModel.Syndication;

//The necessary using directives are specified at the top of the program as is conventional
//In this block are the XML, Generic and ServiceModel.Syndication Namespaces which allow for the
//reading of RSS feeds and use of Generic classes like Lists. In addition, the Globalization class
//is implemented for formatting dateTime values in an appropriate manner. 

namespace RSS_Ticker_Release
{
    class RSS_Scraper
    {
        //Function Name: RSS_Scrape
        //Purpose: To read RSS data from a list of sources
        //Requisite Inputs: A list of RSS sources, saved as string variables
        //Returned items: A list of newsItem objects

        
        public static List<newsItem> RSS_Scrape(List<string> sources)
        {
            XmlReaderSettings settings = new XmlReaderSettings() { IgnoreComments = true, DtdProcessing = DtdProcessing.Parse };
            List<SyndicationItem> unformattedItems = new List<SyndicationItem>();
            List<newsItem> formattedItems = new List<newsItem>();
            //For the purposes of formatting SyndicationItems to newsItems, these
            //two lists are defined, with the appropriate type assignment

            foreach (string source in sources)
            {
                using (XmlReader reader = XmlReader.Create(source,settings))
                {
                    SyndicationFeed feed = SyndicationFeed.Load(reader);
                    foreach (SyndicationItem item in feed.Items)
                    {
                        unformattedItems.Add(item);
                    }
                }
            }
            //For each source in the input list of strings, an XML Reader is instantiated 
            //and targeted to that link (Encased in a using directive so it is disposed of
            //after use), which is then passed to a new SyndicationFeed. A further foreach loop
            //then iterates through every SyndicationItem in the list and adds it to the list
            //of unformatted items.

            foreach (SyndicationItem item in unformattedItems)
            //Following on from obtaning the news items, this next foreach loop then formats
            //each SyndicationItem into a newsItem object
            {
                string linkString = "";
                foreach (SyndicationLink link in item.Links)
                {
                    linkString = link.Uri.AbsoluteUri;
                }
                //As the URL is stored in a collection called SyndicationLink, the full
                //URL in string form must be obtained using a for each loop. It is then stored
                //in the variable linkString

                string dateString = "";
                if (item.PublishDate.DateTime == DateTime.MinValue)
                {
                    dateString = "No Date Available";
                }
                else
                {
                    dateString = item.PublishDate.DateTime.ToString("ddd dd/MM/yyyy HH:mm:ss",
                    CultureInfo.InvariantCulture);
                }
                //Since some RSS providers may post news items with an undefined dateTime
                //value(Which then is automatically interpreted as the default in C#:
                //00:00:00.0000000 UTC, January 1, 0001), this must be checked for
                //using an if-else block. A placeholder is assigned if the dateTime value 
                //is at its default value. If a value has been assigned, this is parsed to 
                //a string, and formatted as "Abbreviated Day Day Number/Month Number/4 digit Year
                //Hours:Minutes:Seconds" using the defined special characters. 
                //The InvariantCulture provider is then used to make this culturally insensitive to
                //ensure appropriate formatting.

                string titleText = "";
                TextSyndicationContent headline = item.Title;
                if (headline != null)
                {
                    titleText = item.Title.Text;
                }
                else
                {
                    titleText = "No Title Available";
                }

                string descText = "";
                TextSyndicationContent summary = item.Summary;
                if (summary != null)
                {
                    descText = item.Summary.Text;
                }
                else
                {
                    descText = "No Summary Available";
                }
                //In some instances the title or summary of an item of news may be defined as null,
                //and using an if statment to access this property directly caused errors in the program during
                //tests. As such, these attributes are retrieved separately and then checked. If a value is
                //assigned, the attribute is assigned to the appropriate string by accessing the text of it.
                //If the text is not defined, a placeholder message is assigned instead

                formattedItems.Add(new newsItem(titleText, descText, dateString, linkString, 0.0));
                //Then, a new newsItem is created using the generated strings, and added into the list of
                //formatted items
            }
            return formattedItems;
            //The list of formatted items is then returned to the main program namespace
        }

        public static bool validateSource(string source)
        {
            try
            {
                XmlReaderSettings settings = new XmlReaderSettings() { IgnoreComments = true, DtdProcessing = DtdProcessing.Parse };
                XmlReader reader = XmlReader.Create(source,settings);
                SyndicationFeed feed = SyndicationFeed.Load(reader);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        //The function validateSource checks any input news source by trying to create an
        //XML reader from that string, returning true if it works and false if any exceptions
        //are thrown and caught in the try-catch block. If a regular website is entered, the 
        //XML reader will be created, so the subsequent creation of a SyndicationFeed from
        //the XML reader ensures that this case also will return an invalid result.
    }
}
