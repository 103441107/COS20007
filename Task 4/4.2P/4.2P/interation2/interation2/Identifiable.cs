using System;
using System.Collections.Generic;
using System.Text;

namespace Iteration2
{
    public class Indentifiable
    {
        private List<string> _identifiers;
        public List<string> Identifiers
        {
            get
            {
                return _identifiers;
            }
            set
            {
                _identifiers = value;
            }
        }

        public Indentifiable(string[] indents)
        {
            Identifiers = new List<string>(indents);
        }

        public bool AreYou(string id)
        {
            foreach (string i in Identifiers)
            {
                if (id.ToLower() == i.ToLower())
                {
                    return true;
                }
            }
            return false;
        }

        public string FirstId()
        {
            if (Identifiers.Count == 0)
            {
                return "";
            }
            return Identifiers[0].ToLower();
        }

        public void AddIdentifier(string id)
        {
            Identifiers.Add(id.ToLower());
        }

    }
}
