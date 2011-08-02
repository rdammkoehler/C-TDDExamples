using System;
using System.Text;


using AssertionsAndFixtures.DTO;
using NUnit.Framework;

namespace AssertionsAndFixturesTest.Assertions
{
    public class EmailAssertion
    {
        public void AreEqual(Email expected, Email actual)
        {
            AreEqual(expected, actual, "");
        }

        public void AreEqual(Email expected, Email actual, String message)
        {
            Assert.AreEqual(expected.Address, actual.Address, new StringBuilder(message).Append("; Email Addresses are not equal").ToString());
            Assert.AreEqual(expected.Type, actual.Type, new StringBuilder(message).Append("; Email Types are not equal").ToString());
        }
    }
}
