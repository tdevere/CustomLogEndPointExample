using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

namespace CustomLogEndPointExample
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            AppCenter.LogLevel = LogLevel.Verbose;
            AppCenter.SetLogUrl("https://azurefunctionproxyforappcenter.azurewebsites.net");
            AppCenter.Start("e68d0c3c-489c-4a9f-b366-c026d78ed851",
                   typeof(Analytics), typeof(Crashes));

            base.OnStartup(e);
        }
    }
}
