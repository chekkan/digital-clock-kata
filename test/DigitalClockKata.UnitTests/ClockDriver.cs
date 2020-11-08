using System;
using System.Collections;

namespace DigitalClockKata.UnitTests
{
    public interface Observer
    {
        void Update();
    }

    public abstract class Subject
    {
        private ArrayList itsObservers = new ArrayList();

        protected void NotifyObservers()
        {
            foreach (Observer observer in itsObservers)
                observer.Update();
        }

        public void RegisterObserver(Observer observer)
        {
            itsObservers.Add(observer);
        }
    }

    internal class MockTimeSink : Observer
    {
        private int itsHours;
        private int itsMinutes;
        private int itsSeconds;
        private TimeSource itsSource;

        public MockTimeSink(TimeSource source)
        {
            itsSource = source;
        }

        public void Update()
        {
            itsHours = itsSource.GetHours();
            itsMinutes = itsSource.GetMinutes();
            itsSeconds = itsSource.GetSeconds();
        }

        internal int GetHours() => itsHours;

        internal int GetMinutes() => itsMinutes;

        internal int GetSeconds() => itsSeconds;
    }

    internal class MockTimeSource : Subject, TimeSource
    {
        private int itsHours;
        private int itsMinutes;
        private int itsSeconds;
        internal void SetTime(int hours, int minutes, int seconds)
        {
            itsHours = hours;
            itsMinutes = minutes;
            itsSeconds = seconds;
            NotifyObservers();
        }
        public int GetHours() => itsHours;

        public int GetMinutes() => itsMinutes;

        public int GetSeconds() => itsSeconds;
    }

    public interface TimeSource
    {
        int GetHours();

        int GetMinutes();

        int GetSeconds();
    }
}