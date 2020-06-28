//TaggedDoubleAnimation Class
//Purpose:To provide a way of being able to tag those UI elements acted on by 
//        DoubleAnimation objects so they can be managed and cleaned easily and
//        effectively when no longer needed
//Requisite Inputs: None, inherits from DoublAnimation object

using System.Windows;
using System.Windows.Media.Animation;
//The necessary libraries are imported into the class file. The System.Windows class
//contains the FrameWorkElement class, whilst the System.Windows.Media.Animation class
//contains the DoubleAnimation class.

namespace RSS_Ticker_Release
{
   
    public class TaggedDoubleAnimation: DoubleAnimation
    {
        public FrameworkElement TargetElement { get; set; }
        protected override Freezable CreateInstanceCore()
        {
            return new TaggedDoubleAnimation { TargetElement = TargetElement };
        }
        //This class contains one publicly accessible variable, which is TargetElement. This class
        //allows for a FrameWork element to be tagged to the DoubleAnimation being performed upon it,
        //so that when the animation is complete it can be removed from the main window within the
        //Ticker class. This is important since removing these elements when the animation is done 
        //should help keep memory costs low and prevent scrolling newsitems from piling up along the
        //main window. To allow for this I had to override the inherited method CreateInstanceCore,
        //which is freezable. This allows for an instance of a TaggedDoubleAnimation
        //to be created and returned with the Target Element property set accordingly.
    }
}
