using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;


namespace CustomLogEndPointExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dictionary<string, string> properties;
        Guid sessionGuid = Guid.NewGuid();
        public MainWindow()
        {
            properties = new Dictionary<string, string>() { { sessionGuid.ToString(), "Session Start" }, { "TDEVERE", "KICKING IT" } };
            SendEvt(sessionGuid.ToString(), properties);
            InitializeComponent();
        }

        private void btnSendEvent_Click(object sender, RoutedEventArgs e)
        {
            SendEvt("btnSendEvent_Click");
        }

        private void SendEvt(string eventName, Dictionary<string,string> properties)
        {
            try
            {
                Analytics.TrackEvent(eventName, properties);
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
            }
        }

        private void SendEvt(string eventName)
        {
            try
            {
                properties = new Dictionary<string, string>() { { sessionGuid.ToString(), DateTime.Now.ToLongTimeString() } };
                Analytics.TrackEvent(eventName, properties);
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
            }
        }
    }
}
