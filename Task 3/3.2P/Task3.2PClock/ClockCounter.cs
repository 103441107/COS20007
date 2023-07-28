using System;
using System.Collections.Generic;
using System.Text;

namespace Clock
{
    public class ClockCounter
    {
        private Counter _hour = new Counter("Hour", 0);
        private Counter _min = new Counter("Min", 0);
        private Counter _Second = new Counter("Second", 0);
        public int Hour
        {
            get
            {
                return _hour.count;
            }
        }

        public int Min
        {
            get
            {
                return _min.count;
            }
        }

        public int Second
        {
            get
            {
                return _Second.count;
            }
        }

        public string Formatted_string()
        {
            return string.Format("{0:00}:{1:00}:{2:00}", Hour, Min, Second);

        }

        public void Tick()
        {
            _Second.CountIncrement();
            if (Second >= 60)
            {
                _Second.CountReset();
                _min.CountIncrement();
                if (Min >= 60)
                {
                    _min.CountReset();
                    _hour.CountIncrement();
                    if (Hour >= 24)
                    {
                        ClockReset();
                    }
                }
            }
        }

        public void ClockReset()
        {
            _hour.CountReset();
            _min.CountReset();
            _Second.CountReset();

        }
    }
}
