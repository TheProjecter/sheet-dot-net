using Sheet.Facade.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace Sheet.GUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static INoteService Bll
        {
            get { return App.Current.Resources["Bll"] as INoteService; }
        }
    }
}
