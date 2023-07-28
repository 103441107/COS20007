using NUnit.Framework;
using System;
using Swin_Adventure;

namespace Tests //nguyen gia huy
{
    [TestFixture()]
    public class IdentifiableObjectTest
    {
        [Test()]
        public void TestAreYou()
        {
            
            IdentifiableObject id = new IdentifiableObject(new string[] { "fred", "bob" });
            Assert.IsTrue(id.AreYou("fred"));
        }

        [Test()]
        public void TestNotAreYou()
        {
            
            IdentifiableObject id = new IdentifiableObject(new string[] { "fred", "bob" });
            Assert.IsFalse(id.AreYou("wilma"));
        }

        [Test()]
        public void TestAreYouCaseSentitive()
        {
            
            IdentifiableObject id = new IdentifiableObject(new string[] { "fred", "bob" });
            Assert.IsTrue(id.AreYou("fReD"));
        }

        [Test()]
        public void TestFirstID()
        {
           
            IdentifiableObject id = new IdentifiableObject(new string[] { "fred", "bob" });
            Assert.AreEqual(id.FirstId(), "fred");
        }

        [Test()]
        public void TestAddID()
        {
           
            IdentifiableObject id = new IdentifiableObject(new string[] { "fred", "bob" });
            id.AddIdentifier("wilma");
            Assert.IsTrue(id.AreYou("wilma"));
        }

    }
}
