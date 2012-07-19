using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using RoundTimer.TimerLib;
using System.IO.IsolatedStorage;

namespace RoundTimer
{
    public partial class MainPage : PhoneApplicationPage
    {
        private Dictionary<string, TimerLib.RoundTimer> timers = null;
        private IsolatedStorageSettings userSettings = IsolatedStorageSettings.ApplicationSettings;

        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            // initialize with when first time use

            if (userSettings.Contains("Timers")){
                timers = (Dictionary<string, TimerLib.RoundTimer>)userSettings["Timers"];
            }
            else
            {
                timers = new Dictionary<string, TimerLib.RoundTimer>();
                timers.Add("Demo Timer", new TimerLib.RoundTimer(new TimeSpan(0, 0, 30), new TimeSpan(0, 0, 30), 3, "Demo Timer"));
            }

            foreach (TimerLib.RoundTimer timer in timers.Values)
            {
                Button timerButton = new Button();
                timerButton.Name = timer.Name;
                timerButton.Content = timer.Name + " >>";
                timerButton.Margin = new Thickness(5);
                timerButton.Height = 70;
                timerButton.Click += timerButton_Click;
                timerStack.Children.Add(timerButton);
            }

            userSettings.Add("Timers", timers);
        }

        private void timerButton_Click(object sender, RoutedEventArgs e)
        {
            Button s = (Button)sender;
            NavigationService.Navigate(new Uri("/TimerPage.xaml?Timer=" + s.Name, UriKind.Relative));
        }
    }
}