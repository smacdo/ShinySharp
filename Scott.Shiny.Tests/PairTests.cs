using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Scott.Shiny.Objects;

namespace Scott.Shiny.Tests
{
    /// <summary>
    /// Summary description for PairTests
    /// </summary>
    [TestClass]
    public class PairTests
    {
        [TestMethod]
        [TestCategory("Objects/Pair")]
        public void PairsValuesAreSet()
        {
            var first = new FixnumObject(42);
            var second = new FixnumObject(5);
            var pair = new PairObject(first, second);

            Assert.AreSame(first, pair.Car);
            Assert.AreSame(second, pair.Cdr);
        }

        [TestMethod]
        [TestCategory("Objects/Pair")]
        public void PairsAreEquatable()
        {
            var a = new PairObject(new FixnumObject(42), new FixnumObject(5));

            Assert.IsTrue(a.Equals(a));
            Assert.IsTrue(a.Equals((object) a));

            var b = new PairObject(new FixnumObject(42), new FixnumObject(5));

            Assert.IsTrue(a.Equals(b));
            Assert.IsTrue(a.Equals((object) b));

            var c = new PairObject(new FixnumObject(42), new FixnumObject(4));

            Assert.IsFalse(a.Equals(c));
            Assert.IsFalse(a.Equals((object) c));

            var d = new PairObject(new FixnumObject(-42), new FixnumObject(5));

            Assert.IsFalse(a.Equals(d));
            Assert.IsFalse(a.Equals((object) d));

            var e = new PairObject(new FixnumObject(0), new FixnumObject(0));

            Assert.IsFalse(a.Equals(e));
            Assert.IsFalse(a.Equals((object) e));
        }

        [TestMethod]
        [TestCategory("Objects/Pair")]
        public void PairsPrintAsExpected()
        {
            var a = new PairObject(new EmptyListObject(), new EmptyListObject());
            Assert.AreEqual("(())", a.ToString());

            a = new PairObject(new FixnumObject(42), new EmptyListObject());
            Assert.AreEqual("(42)", a.ToString());

            a = new PairObject(new FixnumObject(42), new FixnumObject(5));
            Assert.AreEqual("(42 . 5)", a.ToString());

            a = new PairObject(new EmptyListObject(), new FixnumObject(5));
            Assert.AreEqual("(() . 5)", a.ToString());
        }

        [TestMethod]
        [TestCategory("Objects/Pair")]
        public void CanChangeCarAndCdrToNonNullValues()
        {
            var a = new PairObject(new FixnumObject(42), new FixnumObject(5));
            a.Car = new CharacterObject('y');
            a.Cdr = new CharacterObject('x');

            Assert.AreEqual('y', ((CharacterObject) a.Car).Value);
            Assert.AreEqual('x', ((CharacterObject) a.Cdr).Value);
        }

        [TestMethod]
        [TestCategory("Objects/Pair")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CannotGivePairNullCarInConstructor()
        {
            new PairObject(null, new EmptyListObject());
        }

        [TestMethod]
        [TestCategory("Objects/Pair")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CannotGivePairNullCdrInConstructor()
        {
            new PairObject(new EmptyListObject(), null);
        }

        [TestMethod]
        [TestCategory("Objects/Pair")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CannotSetNullCar()
        {
            var a = new PairObject(new FixnumObject(42), new FixnumObject(5));
            a.Car = null;
        }

        [TestMethod]
        [TestCategory("Objects/Pair")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CannotSetNullCdr()
        {
            var a = new PairObject(new FixnumObject(42), new FixnumObject(5));
            a.Cdr = null;
        }
    }
}
