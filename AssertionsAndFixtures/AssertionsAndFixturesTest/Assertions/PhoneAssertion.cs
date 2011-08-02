using System;
using System.Text;


using AssertionsAndFixtures.DTO;
using NUnit.Framework;

namespace AssertionsAndFixturesTest.Assertions
{
    public class PhoneAssertion
    {
        public void AreEqual(Phone expected, Phone actual)
        {
            AreEqual(expected, actual, "");
        }

        public void AreEqual(Phone expected, Phone actual, String message)
        {
            Assert.AreEqual(expected.Number, actual.Number, new StringBuilder(message).Append("; Phone Numbers are not equal").ToString());
            Assert.AreEqual(expected.Extension, actual.Extension, new StringBuilder(message).Append("; Phone Extensions are not equal").ToString());
            Assert.AreEqual(expected.Type, actual.Type, new StringBuilder(message).Append("; Phone Types are not equal").ToString());
        }
    }
}
