using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8._1P
{
    public class Game : AbstractLib
    {
        private string _developer;
        private string _rating;

        public Game(string name, string creator, string rating) : base(name)
        {
            _developer = creator;
            _rating = rating;
        }

        public override string Creator
        {
            get
            {
                return _developer;
            }
        }

        public string Rating
        {
            get
            {
                return _rating;
            }
        }
    }
}
