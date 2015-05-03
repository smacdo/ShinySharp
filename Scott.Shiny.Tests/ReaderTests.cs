using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Scott.Shiny.Objects;
using Scott.Shiny.REPL;

namespace Scott.Shiny.Tests
{
    [TestClass]
    public class ReaderTests
    {
        private SessionContext mSessionContext;

        [TestInitialize]
        public void TestSetUp()
        {
            mSessionContext = new SessionContext();
        }

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

        [TestMethod]
        [TestCategory("Reader/Values")]
        public void ReadTrueAndFalse()
        {
            // Read true, make sure it is right type and equal to singleton.
            var result = Read("#t");
            Assert.IsInstanceOfType(result, typeof(TrueBoolObject));
            Assert.AreSame(mSessionContext.True, result);

            // Read true again, make sure it is still singleton.
            var secondTrue = Read("#T");
            Assert.AreSame(result, secondTrue);
            Assert.AreSame(mSessionContext.True, result);

            // Read false, make sure it is right type and equal to singleton.
            result = Read("#f");
            Assert.IsInstanceOfType(result, typeof(FalseBoolObject));
            Assert.AreSame(mSessionContext.False, result);

            // Read false again, make sure it is still singleton.
            var secondFalse = Read("#F");
            Assert.AreSame(result, secondFalse);
            Assert.AreSame(mSessionContext.False, result);
        }

        private SObject Read(string s)
        {
            var reader = new Reader(s, mSessionContext);
            return reader.Read();
        }
    }
}
