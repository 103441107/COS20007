using NUnit.Framework;

namespace Clock
{
    [TestFixture]
    public class ClockCheck
    {
        private Counter myCount;
        private ClockCounter Clock;

        [SetUp]
        public void SetUp()
        {
            myCount = new Counter("Counter 1", 0);
            Clock = new ClockCounter();
        }
        [Test]
        public void TestIncrement()
        {

            myCount.CountIncrement();
            myCount.CountIncrement();
            myCount.CountIncrement();
            Assert.AreEqual(3, myCount.count, "Count increased to 3 should match");
        }

        [Test]
        public void TestReset()
        {
            myCount.CountReset();
            Assert.AreEqual(0, myCount.count, "Counter reset should be 0");
        }

        [Test]
        public void TestSeconds()
        {
            for (int i = 0; i < 55; i++)
            {
                Clock.Tick();
            }
            Assert.AreEqual(55, Clock.Second, "Checking if the tick works and goes to 55 seconds");
        }

        [Test]
        public void TestMin()
        {
            for (int i = 0; i < 60; i++)
            {
                Clock.Tick();
            }
            Assert.AreEqual(1, Clock.Min, "Checking if the tick works and goes to 1 Min");
        }
        [Test]
        public void TestHour()
        {

            for (int i = 0; i < 3600; i++)
            {
                Clock.Tick();
            }
            Assert.AreEqual(1, Clock.Hour, "Hour should be one");
        }

        [Test]
        public void TestClockReset()
        {
            for (int i = 0; i < 86400; i++)
            {
                Clock.Tick();
                if (Clock.Hour == 24)
                {
                    Clock.ClockReset();
                }
            }
            Assert.AreEqual(0, Clock.Second, "Hour should be one");
        }



    }
}