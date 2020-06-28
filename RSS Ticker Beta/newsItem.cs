//newsItem Class
//Purpose: To encapsulate the necessary data which is to be scrolled on the user's screen, and used in the watch later list
//Requisite inputs: 4 string variables and one double variable; title, desc, date, URL, Rating
public class newsItem
{
    public string Title { get; private set; }
    public string Description { get; private set; }
    public string PubDate { get; private set; }
    public string Link { get; private set;}
    public double Rating { get; set; } 
    //These fields define the information the newsItem class is composed of. These are implemented with
    //auto properties. All information can only be set privately except for the rating, which would need to be
    //set when adding a newsItem into the watch later database. This means that rating must be alterable publicly
    //or else this field could not be set at the time it is added to the watch later database.

    public newsItem(string title, string desc, string date, string URL, double rating)
	{
        Title = title;
        Description = desc;
        PubDate = date;
        Link = URL;
        Rating = rating;
	}
    //The constructor for this class takes in the 4 requisite string variables and assigns them to the necessary fields.
    //The Rating value upon instantiation will be 0.0 by default and remain as such until a user set
    //rating is assigned to it.
}
