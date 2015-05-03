using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Scott.Shiny.Objects;

namespace Scott.Shiny.Tests
{
    [TestClass]
    public class CharacterTests
    {
        [TestMethod]
        [TestCategory("Objects/Character")]
        public void CharacterValuesAreSet()
        {
            var a = new CharacterObject('a');
            var x = new CharacterObject('x');
            var y = new CharacterObject('y');

            Assert.AreEqual('a', a.Value);
            Assert.AreEqual('x', x.Value);
            Assert.AreEqual('y', y.Value);
        }

        [TestMethod]
        [TestCategory("Objects/Character")]
        public void CharacterValuesAreEquatable()
        {
            var a = new CharacterObject('a');
            var secondA = new CharacterObject('a');
            var x = new CharacterObject('x');
            var secondX = new CharacterObject('x');

            Assert.IsTrue(a.Equals(a));
            Assert.IsTrue(a.Equals((object) a));

            Assert.IsTrue(a.Equals(secondA));
            Assert.IsTrue(a.Equals((object) secondA));

            Assert.IsFalse(a.Equals(x));
            Assert.IsFalse(a.Equals((object) x));

            Assert.IsTrue(x.Equals(x));
            Assert.IsTrue(x.Equals((object) x));

            Assert.IsTrue(x.Equals(secondX));
            Assert.IsTrue(x.Equals((object) secondX));

            Assert.IsFalse(x.Equals(a));
            Assert.IsFalse(x.Equals((object) a));
        }

        [TestMethod]
        [TestCategory("Objects/Character")]
        public void CharacterValuesAreComparable()
        {
            var e = new CharacterObject('e');
            var secondE = new CharacterObject('e');
            var x = new CharacterObject('x');
            var a = new CharacterObject('a');

            Assert.AreEqual(0, e.CompareTo(e));
            Assert.AreEqual(0, e.CompareTo((object) e));

            Assert.AreEqual(0, e.CompareTo(secondE));
            Assert.AreEqual(0, e.CompareTo((object) secondE));

            Assert.IsTrue(e.CompareTo(a) > 0);
            Assert.IsTrue(e.CompareTo((object) a) > 0);

            Assert.IsTrue(e.CompareTo(x) < 0);
            Assert.IsTrue(e.CompareTo((object) x) < 0);
        }

        [TestMethod]
        [TestCategory("Objects/Character")]
        public void CharactersPrintAsExpected()
        {
            var x = new CharacterObject('x');
            var y = new CharacterObject('y');
            var newline = new CharacterObject('\n');
            var tab = new CharacterObject('\t');
            var space = new CharacterObject(' ');

            Assert.AreEqual("#\\x", x.ToString());
            Assert.AreEqual("#\\y", y.ToString());
            Assert.AreEqual("#\\newline", newline.ToString());
            Assert.AreEqual("#\\tab", tab.ToString());
            Assert.AreEqual("#\\space", space.ToString());
        }
    }
}
