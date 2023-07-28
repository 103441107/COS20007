using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8._1P
{
    public abstract class AbstractLib
    {
        private string _name;
        private bool _onloan;

        public AbstractLib(string name)
        {
            _name = name;
            _onloan = false;
        }

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public abstract string Creator
        {
            get;
        }
        public bool OnLoan
        {
            get
            {
                return _onloan;
            }

            set
            {
                _onloan = value;
            }
        }


    }
}
