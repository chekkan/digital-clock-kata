using System;

namespace DigitalClockKata.UnitTests
{
    internal class MockTimeSource : TimeSource
    {
        private ClockDriver itsDriver;

        public void SetDriver(ClockDriver driver)
        {
            itsDriver = driver;
        }

        internal void SetTime(int hours, int minutes, int seconds)
        {
            itsDriver.Update(hours, minutes, seconds);
        }
    }
}