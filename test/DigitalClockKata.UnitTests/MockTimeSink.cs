using System;
using System.Collections.Generic;

namespace DigitalClockKata.UnitTests
{
    internal class MockTimeSink : TimeSink
    {
        private int itsHours;
        private int itsMinutes;
        private int itsSeconds;

        public void SetTime(int hours, int minutes, int seconds)
        {
            itsHours = hours;
            itsMinutes = minutes;
            itsSeconds = seconds;
        }

        internal int GetHours() => itsHours;

        internal int GetMinutes() => itsMinutes;

        internal int GetSeconds() => itsSeconds;
    }
}