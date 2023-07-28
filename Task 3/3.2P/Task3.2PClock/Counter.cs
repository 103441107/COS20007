using System;
using System.Collections.Generic;
using System.Text;

namespace Clock
{
    public class Counter
    {
        private int _count;
        private string _name;

        public string name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public int count
        {
            get
            {
                return _count;
            }
            set
            {
                _count = value;
            }
        }
        public Counter(string name, int count)
        {
            _name = name;
            _count = count;
        }

        public int CountIncrement()
        {

            return _count += 1;

        }

        public int CountReset()
        {
            return _count = 0;
        }
    }
}

