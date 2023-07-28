using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Iteration4
{
    public class Inventory
    {
        private List<Item> _items;

        public Inventory()
        {
            _items = new List<Item>();
        }

        public bool HasItem(string id)
        {
            return _items.Contains(Fetch(id));
        }

        public void Put(Item itm)
        {
            _items.Add(itm);
        }

        public Item Take(string id)
        {
            Item Result = null;
            foreach (Item I in _items)
            {
                if (I.AreYou(id))
                {
                    Result = I;
                }
            }
            _items.Remove(Result);
            return Result;
        }

        public Item Fetch(String id)
        {
            Item Result = null;
            foreach (Item I in _items)
            {
                if (I.AreYou(id))
                {
                    Result = I;
                }
            }
            return Result;
        }

        public string ItemList
        {
            get
            {
                string i = "";
                foreach (Item I in _items)
                {
                    i += I.ShortDescription + "\n";

                }
                return i;
            }

        }

        
    }

}
