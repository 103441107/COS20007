using System;
using System.Collections.Generic;
using System.Text;

namespace Iteration2
{
    public class Player : Game_Object
    {
        private Inventory _inventory;

        public Inventory Inventory
        {
            get
            {
                return _inventory;
            }
        }
        public Player(string name, string desc) : base(new string[] { "me", "inventory" }, name, desc)
        {
            _inventory = new Inventory();
        }

        public override string FullDescription
        {
            get
            {
                return _inventory.ItemList;
            }
        }
        public Game_Object Locate(string id)
        {
            if (AreYou(id))
            {
                return this;
            }
            else
            {
                return _inventory.Fetch(id);
            }

        }
    }
}
