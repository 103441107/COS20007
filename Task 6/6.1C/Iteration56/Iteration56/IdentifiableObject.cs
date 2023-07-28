using System;
using System.Collections.Generic;

namespace Swin_Adventure //nguyen gia huy
{
    public class IdentifiableObject
    {
        private List<string> _identifiers = new List<string>();

        
        public IdentifiableObject(string[] idents)
        {
            foreach (string id in idents)
            {
                _identifiers.Add(id.ToLower());
            }
        }

        public bool AreYou(string id)
        {
            if (_identifiers.Contains(id.ToLower()))
            {
                return true;
            }
            return false;
        }

        
        public string FirstId()
        {
            return _identifiers[0];
        }

        
        public void AddIdentifier(string id)
        {
            _identifiers.Add(id.ToLower());
        }

    }

}
