using System;
using System.Text;


using AssertionsAndFixtures.DTO;
using NUnit.Framework;

namespace AssertionsAndFixturesTest.Assertions
{
    public class AddressAssertion
    {
        public void AreEqual(Address expected, Address actual)
        {
            AreEqual(expected, actual, "");
        }

        public void AreEqual(Address expected, Address actual, String message)
        {
            Assert.AreEqual(expected.Street, actual.Street, new StringBuilder(message).Append("; Streets are not equal").ToString());
            Assert.AreEqual(expected.Street2, actual.Street2, new StringBuilder(message).Append("; Street2s are not equal").ToString());
            Assert.AreEqual(expected.City, actual.City, new StringBuilder(message).Append("; Cities are not equal").ToString());
            Assert.AreEqual(expected.State, actual.State, new StringBuilder(message).Append("; States are not equal").ToString());
            Assert.AreEqual(expected.ZipCode, actual.ZipCode, new StringBuilder(message).Append("; ZipCodes are not equal").ToString());
            Assert.AreEqual(expected.Type, actual.Type, new StringBuilder(message).Append("; Address Types are not equal").ToString());
        }

    }
}
