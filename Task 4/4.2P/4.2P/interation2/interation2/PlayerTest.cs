using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Iteration2
{
    [TestFixture()]
    class NUnitPlayerTest
    {
        Player Player1;
        Inventory inv = new Inventory();
        Item Sword;
        Item Bow;
        Item PC;

        [SetUp]
        public void SetUp()
        {
            Player1 = new Player("Frodo", "Inventory");
            Sword = new Item(new string[] { "Sword", "Long-Sword" }, "Long-Sword", "A heavy Weapon used to seriously maim the guy who created oop");
            Bow = new Item(new string[] { "Bow", "Long-Bow" }, "A long Ornate Bow ", "a Ranged Weapon used to seriously maim the guy who created oop ");
            PC = new Item(new string[] { "pc", "Personal Computer" }, "Persoal Computing devices ", "A tool Used by OOP devs to torture UNI Students ");
        }
        [Test]
        public void PlayerIdentifiable()
        {
            Assert.That(Player1.AreYou("me"), Is.True);
        }
        [Test]
        public void LocateItems()
        {
            Player1.Inventory.Put(Sword);
            Assert.AreEqual(Sword, Player1.Locate("Sword"));
        }
        [Test]
        public void PlayerLocatesItself()
        {
            Assert.AreNotEqual(Sword, Player1.Locate("me"));
        }
        [Test]
        public void LocateNothing()
        {
            Assert.AreEqual(null, Player1.Locate("Sword"));
        }
        [Test]
        public void FullDescription()
        {
            Player1.Inventory.Put(Sword);
            Assert.AreEqual("Long-Sword A heavy Weapon used to seriously maim the guy who created oop\n", Player1.FullDescription);
        }
    }
}
