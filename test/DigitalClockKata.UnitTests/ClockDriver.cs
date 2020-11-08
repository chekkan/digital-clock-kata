using System;
using System.Collections;

namespace DigitalClockKata.UnitTests
{
    public interface ClockObserver
    {
        void Update(int hours, int minutes, int seconds);
    }

    public abstract class TimeSource
    {
        private ArrayList itsObservers = new ArrayList();

        protected void Notify(int hours, int mins, int secs)
        {
            foreach (ClockObserver observer in itsObservers)
                observer.Update(hours, mins, secs);
        }

        public void RegisterObserver(ClockObserver observer)
        {
            itsObservers.Add(observer);
        }
    }

    internal class MockTimeSink : ClockObserver
    {
        private int itsHours;
        private int itsMinutes;
        private int itsSeconds;

        public void Update(int hours, int minutes, int seconds)
        {
            itsHours = hours;
            itsMinutes = minutes;
            itsSeconds = seconds;
        }

        internal int GetHours() => itsHours;

        internal int GetMinutes() => itsMinutes;

        internal int GetSeconds() => itsSeconds;
    }

    internal class MockTimeSource : TimeSource
    {
        internal void SetTime(int hours, int minutes, int seconds)
        {
            Notify(hours, minutes, seconds);
        }
    }
}