using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace RoundTimer.TimerLib
{
    public class RoundTimer
    {
        private TimeSpan roundTime;
        private TimeSpan pauseTime;
        private int numberOfRounds;
        private string name;

        private TimeSpan timeLeft;
        private TimeSpan pauseLeft;

        private int roundsLeft;

        public int RoundsLeft
        {
            get { return roundsLeft; }
            set { roundsLeft = value; }
        }

        public TimeSpan TimeLeft
        {
            get
            {
                return timeLeft;
            }
            set
            {
                this.timeLeft = value;
            }
        }

        public TimeSpan PauseLeft
        {
            get { return pauseLeft; }
            set { pauseLeft = value; }
        }

        public TimeSpan RoundTime
        {
            get
            {
                return roundTime;
            }
        }

        public TimeSpan PauseTime
        {
            get
            {
                return pauseTime;
            }
        }

        public int NumberOfRounds
        {
            get
            {
                return numberOfRounds;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
        }

        public RoundTimer(TimeSpan roundTime, TimeSpan pauseTime, int numberOfRounds, string name)
        {
            this.roundTime = roundTime;
            this.pauseTime = pauseTime;
            this.numberOfRounds = numberOfRounds;
            this.name = name;
        }
    }
}
