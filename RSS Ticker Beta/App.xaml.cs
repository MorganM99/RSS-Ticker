﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace RSS_Ticker_Release
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public void Ticker_Startup(object sender, StartupEventArgs e)
        {
            TickerWindow main = new TickerWindow();
            main.Show();
        }
    }
}
