using System;
using NUnit.Framework;
using AssertionsAndFixtures.DTO;
using AssertionsAndFixturesTest.Builders;

namespace AssertionsAndFixturesTest
{
    [TestFixture]
    public class EmailComparerTests
    {
        EmailComparer emailComparer = new EmailComparer();
        Email email1, email2;

        [SetUp]
        public void Setup()
        {
            email1 = new EmailBuilder().BuildWithDefaults();
            email2 = new EmailBuilder().BuildWithDefaults();
        }

        [Test]
        public void TestEmailComparerEqualReturnsZero()
        {
            //setup/arrange
            int expected = 0;

            //execute/act
            int actual = emailComparer.Compare(email1, email2);

            //assert
            Assert.AreEqual(expected,actual);
        }

        [Test]
        public void TestEmailComparerNullArgumentsReturnsZero()
        {
            //setup/arrange
            email1 = email2 = null;
            int expected = 0;

            //execute/act
            int actual = emailComparer.Compare(email1, email2);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestEmailComparerFirstArgNullReturnsOne()
        {
            //setup/arrange
            email1 = null;
            int expected = 1;

            //execute/act
            int actual = emailComparer.Compare(email1, email2);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestEmailComparerSecondArgNullReturnsMinusOne()
        {
            //setup/arrange
            email2 = null;
            int expected = -1;

            //execute/act
            int actual = emailComparer.Compare(email1, email2);

            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}
