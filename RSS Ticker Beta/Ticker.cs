//Ticker Class
//Purpose: To manage the animation of TickerItemElement objects
//Requisite Inputs: A panel object representing the container all
//                  TickerItemElement objects will be collected in,
//                  as well as the parent TickerWindow object

using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Threading;
//There are a variety of libraries imported for use in this code
//which allow for the use of TimeSpans, DispatcherTimers, and 
//DoubleAnimations

namespace RSS_Ticker_Release
{
    public class Ticker<T> where T:FrameworkElement
        //Ticker is defined as a generic class which will be
        //keyed to operate on any FrameWorkElement type object
        //T
    {
        public List<T> items { get; private set; }
        private int listPoint = 0;
        public int animSpeed { get; private set; }
        public int refreshInterval { get; set; }
        public TimeSpan animDuration { get; set; }
        public TimeSpan refreshSpan { get; private set; }
        public Panel tickerContainer { get; private set; }
        public DispatcherTimer RefreshTimer { get; private set; }
        public DispatcherTimer animTimer { get; private set; }
        public TickerWindow displayWindow { get; private set; }
        public TaggedDoubleAnimation animScroll { get; private set; }
        public double seperatorSize { get; private set; }
        public TranslateTransform translate;
        private int unitsPerSec;
        private int nextFire;
        private double startPos;
        private double endPos;

        //These are the key variables used in the Ticker class. 
        //Many are accessed via the TickerWindow.cs file, hence why they
        //employ the use of public getters and private setters. Others are only
        //used inside the ticker class, so are declared as solely private

        public Ticker(Panel container, TickerWindow parent)
        {
            seperatorSize = 60;
            tickerContainer = container;
            displayWindow = parent;
            tickerContainer.Measure(new Size(Double.PositiveInfinity,
                Double.PositiveInfinity));
            tickerContainer.Arrange(new Rect(tickerContainer.DesiredSize));
            items = new List<T>();
            animTimer = new DispatcherTimer();
            animTimer.Tick += animTimer_Tick;

        }
        //When supplied with the container the scrolling news is to be
        //embedded in, the constructor will have the container arrange to fill
        //as much space as possible. animTimer is instantiated,
        //with an on tick behaviour specified as animTimer_Tick

        public void Start()
        {
            refreshSpan = new TimeSpan(0, refreshInterval, 0);
            RefreshTimer = new DispatcherTimer();
            RefreshTimer.Interval = refreshSpan;
            RefreshTimer.Start();
            RefreshTimer.Tick += Refresh;
            animTimer.Start();
            animTimer.Interval = new TimeSpan(0, 0, 0, 1);

        }
        //When the ticker class is started, animTimer is began
        //with an interval of 1 second so that the on tick behaviour
        //activates quickly. The refresh timer RefreshTimer is also
        //instantiated and started, with the user set refresh value
        //which has been stored in the variable refreshInterval in
        //the TickerWindow.cs file. Its on tick behaviour is linked
        //to an appropriately named function called Refresh.

        public void Refresh(object sender, EventArgs e)
        {
            items.Clear();
            animTimer.Stop();
            listPoint = 0;
            displayWindow.Refresh();
        }
        //When the refresh timer has elapsed and it ticks, the
        //animTimer is stopped, and the pointer to the next piece
        //of news to scroll is reset to 0. Then, the parent TickerWindow's
        //own Refresh function is called.

        private void animTimer_Tick(object sender, EventArgs e)
        {
            displayNext();
        }
        //On every tick, a new item of news will be displayed by calling
        //displayNext

        private void displayNext()
        {
            if (listPoint > ((items.Count)-1))
            {
                animTimer.Stop();
                listPoint = 0;
                displayWindow.Refresh();
            }
            else
            {
                T item = items[listPoint];
                tickerContainer.Children.Add(item);
                listPoint += 1;
                animItem(item);
            }
        }
        //displayNext will first retrieve the next TickerItemElement
        //to be displayed, and then move the listPointer listPoint up by
        //1. Then the function animItem is called on the retrieved element
        //The retrieved item is added as a child of the tickers 
        //container.

        //However, if the pointer variable listPoint exceeds the length
        //of the list of items, it will then execute the same actions as
        //in the Refresh function. The Refresh function itself cannot be 
        //called as the if statement will not pass the required parameters.

        private void animItem(FrameworkElement e)
        {
            //animItem acts on a FrameWorkElement e

            e.Measure(new Size(Double.PositiveInfinity, 
                Double.PositiveInfinity));
            e.Arrange(new Rect(e.DesiredSize));
            //The element is scaled and arranged in the standard method, into
            //a rectangle of suitable size

            startPos = tickerContainer.ActualWidth;
            endPos = -1000;
            //The start position is the far right of the ticker, and the end position is
            //1000 pixels off of the far left of the ticker, so that items can be removed
            //invisibly. This value is large since items with long descriptions, particularly
            //at larger font sizes, may still have the description showing when they are
            //removed otherwise

            unitsPerSec = Convert.ToInt32((Math.Abs(startPos-endPos))
                /(animDuration.TotalSeconds));
            nextFire = Convert.ToInt32((e.ActualWidth + 
                seperatorSize) / unitsPerSec);
            //To calculate the appropriate time interval between a new item being 
            //scrolled along the screen, the amount of units per second is first
            //defined as the full animation width, over the specified duration
            //value in seconds. Then, using the width of the TickerItemElement
            //and a seperator to prevent overlap, we calculate nextFire as this
            //width plus the seperator size, divided by the units per second value
            //This thusly defines the appropriate interval, which is recalculated
            //each time to ensure that animation continues as expected. This 
            //nextFire variable specifies when the next item of news is to be scrolled
            //along the screen, providing separation between newsitems so there is
            //no overlap.

            animTimer.Stop();
            animTimer.Interval = new TimeSpan(0, 0, nextFire);
            animTimer.Start();
            //animTimer is stopped and restarted, with the new interval
            //nextFire. As nextFire is calculated as a seconds value,
            //this is placed in the seconds part of the new TimeSpan object.
            

            animScroll = new TaggedDoubleAnimation();
            animScroll.From = startPos;
            animScroll.To = endPos;
            animScroll.TargetElement = e;
            animScroll.Duration = new Duration(animDuration);
            animScroll.Completed += animScroll_Completed;
            //animScroll is defined as a newTaggedDoubleAnimation, which animates from startPos
            //to endPos, targeted on the TickerItemElement e. Its duration is formulated from
            //the animDuration value, which is affected by the user set percentage modifier 
            //of the original speed value.

            translate = new TranslateTransform();
            e.RenderTransform = translate;
            //A new TranslateTransform object is created, and this object is associated with the
            //RenderTransform dependency property of the news item to be scrolled

            translate.BeginAnimation(TranslateTransform.XProperty, animScroll, HandoffBehavior.Compose);
            //Then, the animation is began, translating the X property of the TickerItemElement, the 
            //animScroll animation used to animate this property, and the handoff behavior is set to
            //compose

        }

        private void animScroll_Completed(object sender, EventArgs e)
        {

            Clock clock = (Clock)sender;
            TaggedDoubleAnimation ani = (TaggedDoubleAnimation)clock.Timeline;

            FrameworkElement element = ani.TargetElement;
            tickerContainer.Children.Remove(element);
        }
        //When the animation is complete, the target element of the animation sending the 
        //completed event is retrieved via retrieving the clock of the animation which
        //sent the completed message, then getting the actual animation associated with
        //this clock from the timeline from which the clock was created. Then, this element
        //is removed from the container, so that memory is managed effectively.

    }
}
