using System;
using System.Collections.Generic;
using System.Text;

namespace Iteration2
{
    public abstract class Game_Object : Indentifiable
    {
        private string _description;
        private string _name;

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public string ShortDescription
        {
            get
            {
                return _name + " " + _description;
            }
        }

        public virtual string FullDescription
        {
            get
            {
                return "You are: "+_name+ "\n you are carrying\n" + _description;
            }
        }

        public Game_Object(string[] ids, string name, string desc) : base(ids)
        {
            _name = name;
            _description = desc;
        }
    }
}
