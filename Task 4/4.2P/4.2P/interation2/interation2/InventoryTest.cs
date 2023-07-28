using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Iteration2
{
    [TestFixture()]
    class NUnitInventoryTest
    {
        Inventory inv = new Inventory();
        Item Sword;
        Item Bow;
        Item PC;

        [SetUp]
        public void SetUp()
        {
            Sword = new Item(new string[] { "Sword", "Long-Sword" }, "Long-Sword", "A heavy Weapon used to seriously maim the guy who created oop");
            Bow = new Item(new string[] { "Bow", "Long-Bow" }, "long Ornate Bow ", "a Ranged Weapon used to seriously maim the guy who created oop ");
            PC = new Item(new string[] { "pc", "Personal Computer" }, "Persoal Computing devices ", "A tool Used by OOP devs to torture UNI Students ");
        }

        [Test]
        public void TakeItem()
        {
            inv.Take("Sword");
            Assert.AreNotEqual(true, inv.HasItem("Sword"));
        }

        [Test]
        public void FindItem()
        {
            inv.Put(Sword);
            Assert.AreEqual(true, inv.HasItem("Sword"));
        }

        [Test]
        public void FetchItem()
        {
            
            inv.Fetch("Sword");
            Assert.AreNotEqual(true, inv.Fetch("Sword"));
        }

        [Test]
        public void ItemList()
        {
            Assert.AreEqual("Long-Sword A heavy Weapon used to seriously maim the guy who created oop\n", inv.ItemList);
        }

        [Test]
        public void NoItem()
        {
            inv.Fetch("Sword");
            inv.Take("Sword");
            Assert.That(inv.HasItem("Sword"), Is.False);
        }
    }
}
