using System;
using Xunit;

namespace DigitalClockKata.UnitTests
{
    public class ClockDriverTest
    {
        [Fact]
        public void TestTimeChange()
        {
            MockTimeSource source = new MockTimeSource();
            MockTimeSink sink = new MockTimeSink();
            ClockDriver driver = new ClockDriver(source, sink);
            source.SetTime(3, 4, 5);
            Assert.Equal(3, sink.GetHours());
            Assert.Equal(4, sink.GetMinutes());
            Assert.Equal(5, sink.GetSeconds());

            source.SetTime(7, 8, 9);
            Assert.Equal(7, sink.GetHours());
            Assert.Equal(8, sink.GetMinutes());
            Assert.Equal(9, sink.GetSeconds());
        }
    }
}
