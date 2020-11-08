using System;

namespace DigitalClockKata.UnitTests
{
    public class ClockDriver
    {
        private TimeSink sink;

        public ClockDriver(TimeSource source, TimeSink sink)
        {
            source.SetDriver(this);
            this.sink = sink;
        }

        internal void Update(int hours, int minutes, int seconds)
        {
            sink.SetTime(hours, minutes, seconds);
        }
    }

    public interface TimeSink
    {
        void SetTime(int hours, int minutes, int seconds);
    }

    public interface TimeSource
    {
        void SetDriver(ClockDriver clockDriver);
    }
}