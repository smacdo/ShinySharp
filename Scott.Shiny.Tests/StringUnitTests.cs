using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Scott.Shiny.Objects;

namespace Scott.Shiny.Tests
{
    [TestClass]
    public class StringUnitTests
    {
        [TestMethod]
        [TestCategory("Objects/String")]
        public void StringValuesAreSet()
        {
            var a = new StringObject("Hello world");
            var b = new StringObject("Scott");
            var c = new StringObject("You get a cookie if you read this");

            Assert.AreEqual("Hello world", a.Value);
            Assert.AreEqual("Scott", b.Value);
            Assert.AreEqual("You get a cookie if you read this", c.Value);
        }

        [TestMethod]
        [TestCategory("Objects/String")]
        public void StringValuesAreEquatable()
        {
            var a = new StringObject("moooooooo imma cow");
            var secondA = new StringObject("moooooooo imma cow");
            var b = new StringObject("moooooooo imma cat");
            var secondB = new StringObject("moooooooo imma cat");

            Assert.IsTrue(a.Equals(a));
            Assert.IsTrue(a.Equals((object) a));

            Assert.IsTrue(a.Equals(secondA));
            Assert.IsTrue(a.Equals((object) secondA));

            Assert.IsFalse(a.Equals(b));
            Assert.IsFalse(a.Equals((object) b));

            Assert.IsTrue(b.Equals(b));
            Assert.IsTrue(b.Equals((object) b));

            Assert.IsTrue(b.Equals(secondB));
            Assert.IsTrue(b.Equals((object) secondB));

            Assert.IsFalse(b.Equals(a));
            Assert.IsFalse(b.Equals((object) a));
        }

        [TestMethod]
        [TestCategory("Objects/String")]
        public void StringValuesAreComparable()
        {
            var a = new StringObject("caroline");
            var secondA = new StringObject("caroline");
            var b = new StringObject("betsy");
            var c = new StringObject("daisy");

            Assert.AreEqual(0, a.CompareTo(a));
            Assert.AreEqual(0, a.CompareTo((object) a));

            Assert.AreEqual(0, a.CompareTo(secondA));
            Assert.AreEqual(0, a.CompareTo((object) secondA));

            Assert.IsTrue(a.CompareTo(b) > 0);
            Assert.IsTrue(a.CompareTo((object) b) > 0);

            Assert.IsTrue(a.CompareTo(c) < 0);
            Assert.IsTrue(a.CompareTo((object) c) < 0);
        }

        [TestMethod]
        [TestCategory("Objects/String")]
        public void StringPrintAsExpected()
        {
            var a = new StringObject("meow");
            Assert.AreEqual("\"meow\"", a.ToString());

            a = new StringObject("meow imma kitty");
            Assert.AreEqual("\"meow imma kitty\"", a.ToString());

            a = new StringObject("chargin\"lazar");
            Assert.AreEqual("\"chargin\\\"lazar\"", a.ToString());

            a = new StringObject("123\n!");
            Assert.AreEqual("\"123\\n!\"", a.ToString());
        }
    }
}
