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
using System.Windows.Threading;
using System.Diagnostics;
using Microsoft.Phone.Controls;
using System.IO.IsolatedStorage;

namespace RoundTimer
{
    public partial class TimerPage : PhoneApplicationPage
    {
        private TimerLib.RoundTimer roundTimer = null;
        private IsolatedStorageSettings userSettings = IsolatedStorageSettings.ApplicationSettings;
        private Stopwatch stopwatch = new Stopwatch();

        public TimerLib.RoundTimer RoundTimer
        {
            set
            {
                this.roundTimer = value;
            }
        }

        public TimerPage()
        {
            InitializeComponent();
        }


        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            string timerName = "";
            
            if (NavigationContext.QueryString.TryGetValue("Timer", out timerName))
            {
                // Load the timer
                PageTitle.Text = timerName;
                Dictionary<string, TimerLib.RoundTimer> timers = (Dictionary<string, TimerLib.RoundTimer>)userSettings["Timers"];
                roundTimer = timers[timerName];

                roundTimer.TimeLeft = roundTimer.RoundTime;
                roundTimer.PauseLeft = roundTimer.PauseTime;
                roundTimer.RoundsLeft = roundTimer.NumberOfRounds;

                timeLeft.Text = getTimeLeftString(roundTimer.TimeLeft);
            }
        }

        private void start_Click(object sender, RoutedEventArgs e)
        {
            // start a timer thread that does the countdown
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(20);
            timer.Tick += TimeElapsed;
            stopwatch.Start();
            timer.Start();
        }

        private void TimeElapsed(object source, EventArgs e)
        {
            roundTimer.TimeLeft = roundTimer.RoundTime - stopwatch.Elapsed;
            timeLeft.Text = getTimeLeftString(roundTimer.TimeLeft);
        }

        private string getTimeLeftString(TimeSpan span)
        {
            return span.Minutes + ":" + span.Seconds;
        }
    }
}