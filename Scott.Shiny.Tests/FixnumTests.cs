using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Scott.Shiny.Objects;

namespace Scott.Shiny.Tests
{
    [TestClass]
    public class FixnumTests
    {
        [TestMethod]
        [TestCategory("Objects/Fixnum")]
        public void CanCreateFixnumValues()
        {
            var obj = new FixnumObject(42);
            Assert.AreEqual(42, obj.Value);

            obj = new FixnumObject(5);
            Assert.AreEqual(5, obj.Value);
        }

        [TestMethod]
        [TestCategory("Objects/Fixnum")]
        public void FixnumEquality()
        {
            var a = new FixnumObject(42);
            var b = new FixnumObject(42);
            var c = new FixnumObject(50);
            var d = "stupidstring";

            Assert.AreEqual(a, a);
            Assert.AreEqual(a, b);
            Assert.AreEqual(b, a);
            Assert.AreNotEqual(a, c);
            Assert.AreNotEqual(a, d);
            Assert.AreNotEqual(a, null);
        }

        [TestMethod]
        [TestCategory("Objects/Fixnum")]
        public void FixnumCompare()
        {
            var a = new FixnumObject(42);
            var equalTo = new FixnumObject(42);
            var greaterThan = new FixnumObject(50);
            var lessThan = new FixnumObject(40);

            Assert.AreEqual(0, a.CompareTo(a));
            Assert.AreEqual(0, a.CompareTo(equalTo));
            Assert.AreEqual(-1, a.CompareTo(greaterThan));
            Assert.AreEqual(1, a.CompareTo(lessThan));
        }

        [TestMethod]
        [TestCategory("Objects/Fixnum")]
        public void FixnumToString()
        {
            var o = new FixnumObject(42);
            Assert.AreEqual("42", o.ToString());

            o = new FixnumObject(-42);
            Assert.AreEqual("-42", o.ToString());

            o = new FixnumObject(0);
            Assert.AreEqual("0", o.ToString());
        }
    }
}
