using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8._1P
{
    public class Book : AbstractLib
    {
        private string _bookauthor;
        private string _isbn;

        public Book(string name, string creator, string isbn) : base(name)
        {
            _bookauthor = creator;
            _isbn = isbn;
        }

        public override string Creator
        {
            get
            {
                return _bookauthor;
            }
        }

        public string ISBN
        {
            get
            {
                return _isbn;
            }
        }

    }
}
