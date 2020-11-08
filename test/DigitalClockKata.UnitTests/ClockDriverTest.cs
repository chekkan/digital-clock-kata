using System;
using Xunit;

namespace DigitalClockKata.UnitTests
{
    public class ClockDriverTest
    {
        private MockTimeSource source;
        private MockTimeSink sink;

        public ClockDriverTest()
        {
            source = new MockTimeSource();
            sink = new MockTimeSink();
            source.RegisterObserver(sink);
        }

        private void AssertSinkEquals(MockTimeSink sink, int hours, int minutes, int seconds)
        {
            Assert.Equal(hours, sink.GetHours());
            Assert.Equal(minutes, sink.GetMinutes());
            Assert.Equal(seconds, sink.GetSeconds());
        }

        [Fact]
        public void TestTimeChange()
        {
            source.SetTime(3, 4, 5);
            AssertSinkEquals(sink, 3, 4, 5);

            source.SetTime(7, 8, 9);
            AssertSinkEquals(sink, 7, 8, 9);
        }

        [Fact]
        public void TestMultipleSinks()
        {
            MockTimeSink sink2 = new MockTimeSink();
            source.RegisterObserver(sink2);

            source.SetTime(12, 13, 14);
            AssertSinkEquals(sink, 12, 13, 14);
            AssertSinkEquals(sink2, 12, 13, 14);
        }
    }
}
