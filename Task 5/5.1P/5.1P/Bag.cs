using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Iteration4
{
    class Bag : Item, IHaveInventory
    {
        Inventory _inventory;

        public Bag(string[] ids, string name, string desc) :
            base(ids, name, desc)
        {
            _inventory = new Inventory();
        }

        public GameObject Locate(string id)
        {
            if (this.AreYou(id))
                return this;

            return _inventory.Fetch(id);
        }

        
        
        public string FullDescription
        {
            get => "A bag endorned with a six-sided star inside a circle";
        }

        public Inventory Inventory
        {
            get => _inventory;
        }

    }
}
