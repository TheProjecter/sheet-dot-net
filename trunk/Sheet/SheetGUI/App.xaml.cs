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
        public static BusinessLogicDispatcher Bll
        {
            get { return App.Current.Resources["Bll"] as BusinessLogicDispatcher; }
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
#if !DEBUG
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
#endif
        }

        void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            MessageBox.Show("We are sorry to admit that you have found a bug. We most probaby already know about it, but hey, time is money.", "Sheet happens.", MessageBoxButton.OK, MessageBoxImage.Error);
            this.Shutdown();
        }
    }
}
