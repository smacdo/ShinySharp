using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Scott.Shiny.Objects;
using Scott.Shiny.REPL;

namespace Scott.Shiny.Tests
{
    [TestClass]
    public class ReaderTests
    {
        [TestMethod]
        [TestCategory("Reader/Values")]
        public void ReadValidFixnums()
        {
            // Simple zero.
            var result = Read("0");
            Assert.IsInstanceOfType(result, typeof(FixnumObject));
            Assert.AreEqual(0, ((FixnumObject) result).Value);

            // One digit fixnum.
            result = Read("2");
            Assert.IsInstanceOfType(result, typeof(FixnumObject));
            Assert.AreEqual(2, ((FixnumObject) result).Value);

            // Two digit fixnum.
            result = Read("42");
            Assert.IsInstanceOfType(result, typeof(FixnumObject));
            Assert.AreEqual(42, ((FixnumObject) result).Value);

            // Multi digit fixnum.
            result = Read("12378");
            Assert.IsInstanceOfType(result, typeof(FixnumObject));
            Assert.AreEqual(12378, ((FixnumObject) result).Value);

            // Negative value.
            result = Read("-42");
            Assert.IsInstanceOfType(result, typeof(FixnumObject));
            Assert.AreEqual(-42, ((FixnumObject) result).Value);

            // Positive value.
            result = Read("+42");
            Assert.IsInstanceOfType(result, typeof(FixnumObject));
            Assert.AreEqual(42, ((FixnumObject) result).Value);
        }

        [TestMethod]
        [TestCategory("Reader/Values")]
        [ExpectedException(typeof(ReaderFloatNotSupportedException))]
        public void FloatingPointValueNotSupport()
        {
            var result = Read("42.0");
        }

        [TestMethod]
        [TestCategory("Reader/Values")]
        [ExpectedException(typeof(ReaderInvalidFixnumTokenException))]
        public void NumberEndingWithCharacterIsInvalid()
        {
            var result = Read("42x");
        }

        private SObject Read(string s)
        {
            var reader = new Reader(s);
            return reader.Read();
        }
    }
}
