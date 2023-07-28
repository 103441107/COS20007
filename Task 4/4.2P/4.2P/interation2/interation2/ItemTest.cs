using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Iteration2
{
    [TestFixture()]
    class NUnitItemTest
    {
        Item Sword = new Item(new string[] { "Sword", "Long-Sword" }, "Long-Sword", "A heavy Weapon used to seriously maim the guy who created oop");

        [Test()]
        public void Item_Identifiable()
        {
            Assert.That(Sword.AreYou("Sword"), Is.True);
        }

        [Test()]
        public void Short_Description()
        {
            
            Assert.AreEqual("Long-Sword A heavy Weapon used to seriously maim the guy who created oop", Sword.ShortDescription);
        }

        [Test()]
        public void Full_Description()
        {
            Assert.AreEqual("You are: Long-Sword\n you are carrying\nA heavy Weapon used to seriously maim the guy who created oop", Sword.FullDescription);
        }
    }
}
