using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Scott.Shiny.Objects;

namespace Scott.Shiny.Tests
{
    [TestClass]
    public class BoolTests
    {
        [TestMethod]
        [TestCategory("Objects/Fixnum")]
        public void BoolTrueAndFalseEqualityChecks()
        {
            var t = new TrueBoolObject();
            var otherTrue = new TrueBoolObject();
            var f = new FalseBoolObject();
            var otherFalse = new FalseBoolObject();
            var v = new FixnumObject(42);

            // True check.
            Assert.IsTrue(t.Equals(t));
            Assert.IsTrue(t.Equals((object) t));

            Assert.IsFalse(t.Equals(otherTrue));
            Assert.IsFalse(t.Equals((object) otherTrue));

            Assert.IsFalse(t.Equals(f));
            Assert.IsFalse(t.Equals((object) f));

            Assert.IsFalse(t.Equals(v));

            // False check.
            Assert.IsTrue(f.Equals(f));
            Assert.IsTrue(f.Equals((object) f));

            Assert.IsFalse(f.Equals(otherFalse));
            Assert.IsFalse(f.Equals((object) otherFalse));

            Assert.IsFalse(f.Equals(t));
            Assert.IsFalse(f.Equals((object) t));

            Assert.IsFalse(t.Equals(v));
        }
    }
}
