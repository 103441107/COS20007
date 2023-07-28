using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Iteration4
{
    [TestFixture]
    class LookCommandUnitTests
    {

        Command l;
        Player p;
        Bag b;

        Item redPot = new Item(new string[] { "potion" }, "red", "A bitter-smelling red potion.");
        Item whitePot = new Item(new string[] { "potion" }, "white", "A viscous white fluid. Reminds you of PLA glue, smells like it too.");
        Item Gem = new Item(new string[] { "gem" }, "phosphophyllite", "An emerald-green gem of about three-and-a-half hardness. Pretty.");

        [Test]
        public void Test_LookAtMe()
        {
            p = new Player("MC", "The player");
            l = new LookCommand();

            string expected = "You are MC, a mere shadow in the literature club.";
            string actual = l.Execute(p, new string[] { "look", "at", "inventory" });

            Assert.AreEqual(expected, actual, "TestLookCommand can look for 'inventory' and returns player long description");

        }

        [Test]
        public void Test_LookAtGem()
        {
            p = new Player("MC", "The player");
            p.Inventory.Put(Gem);
            l = new LookCommand();

            string expected = "An emerald-green gem of about three-and-a-half hardness. Pretty.";
            string actual = l.Execute(p, new string[] { "look", "at", "gem" });

            Assert.AreEqual(expected, actual, "TestLookCommand for gem player inventory, should return long desc for gem.");
        }

        [Test]
        public void Test_LookAtUnk()
        {
            p = new Player("MC", "The player");
            l = new LookCommand();

            string expected = "Could not find gem.";
            string actual = l.Execute(p, new string[] { "look", "at", "gem" });

            Assert.AreEqual(expected, actual, "TestLookCommand for  non-existent gem player inventory, should return 'not found'.");
        }

        [Test]
        public void Test_LookAtGemInMe()
        {
            p = new Player("MC", "The player");
            p.Inventory.Put(Gem);
            l = new LookCommand();

            string expected = "An emerald-green gem of about three-and-a-half hardness. Pretty.";
            string actual = l.Execute(p, new string[] { "look", "at", "gem", "in", "inventory" });

            Assert.AreEqual(expected, actual, "TestLookCommand for gem player inventory 'look at gem in inventory', should return long desc for gem.");
        }

        [Test]
        public void Test_LookAtGemInBag()
        {
            p = new Player("MC", "The player");
            b = new Bag(new string[] { "small", "cloth", "bag" }, "bag", "A small cloth bag");
            b.Inventory.Put(Gem);
            p.Inventory.Put(b);

            l = new LookCommand();

            string expected = "An emerald-green gem of about three-and-a-half hardness. Pretty.";
            string actual = l.Execute(p, new string[] { "look", "at", "gem", "in", "bag" });

            Assert.AreEqual(expected, actual, "TestLookCommand for gem in bag 'look at gem in bag', should return long desc for gem.");
        }

        [Test]
        public void Test_LookAtGemInNoBag()
        {
            p = new Player("MC", "The player");
            p.Inventory.Put(Gem);

            l = new LookCommand();

            string expected = "Could not find bag.";
            string actual = l.Execute(p, new string[] { "look", "at", "gem", "in", "bag" });

            Assert.AreEqual(expected, actual, "TestLookCommand for gem in no bag 'look at gem in bag', should return 'could not find bag'");
        }


        [Test]
        public void Test_LookAtNoGemInBag()
        {
            p = new Player("MC", "The player");
            b = new Bag(new string[] { "small", "cloth", "bag" }, "bag", "A small cloth bag");
            p.Inventory.Put(b);

            l = new LookCommand();

            string expected = "Could not find gem.";
            string actual = l.Execute(p, new string[] { "look", "at", "gem", "in", "inventory" });

            Assert.AreEqual(expected, actual, "TestLookCommand for no gem in bag 'look at gem in inventory', should return 'could not find'");
        }

        [Test]
        public void Test_InvalidLook()
        {
            l = new LookCommand();

            string expected = "Error in look input.";
            string actual = l.Execute(p, new string[] { "stare", "at", "gem", "in", "inventory" });

            Assert.AreEqual(expected, actual, "TestLookCommand for invalid look command. Should return 'Error in look input'");

        }

    }
}
