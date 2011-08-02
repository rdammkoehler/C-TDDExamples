using System;


using NUnit.Framework;
using AssertionsAndFixtures.DTO;
using AssertionsAndFixturesTest.Builders;

namespace AssertionsAndFixturesTest
{
    [TestFixture]
    public class PhoneComparerTests
    {
        PhoneComparer phoneComparer = new PhoneComparer();
        Phone phone1, phone2;

        [SetUp]
        public void Setup()
        {
            phone1 = new PhoneBuilder().BuildWithDefaults();
            phone2 = new PhoneBuilder().BuildWithDefaults();
        }

        [Test]
        public void TestPhoneComparerEqualReturnsZero()
        {
            //setup/arrange
            int expected = 0;

            //execute/act
            int actual = phoneComparer.Compare(phone1, phone2);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestPhoneComparerNullInputsAreEqual()
        {
            //setup/arrange
            phone1 = phone2 = null;
            int expected = 0;

            //execute/act
            int actual = phoneComparer.Compare(phone1, phone2);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestPhoneComparerSameRefReturnsZero()
        {
            //setup/arrange
            phone1 = phone2;
            int expected = 0;

            //execute/act
            int actual = phoneComparer.Compare(phone1, phone2);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestPhoneComparerFirstArgNullReturnsOne()
        {
            //setup/arrange
            phone1 = null;
            int expected = 1;

            //execute/act
            int actual = phoneComparer.Compare(phone1, phone2);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestPhoneComparerSecondArgNullReturnsMinusOne()
        {
            //setup/arrange
            phone2 = null;
            int expected = -1;

            //execute/act
            int actual = phoneComparer.Compare(phone1, phone2);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestPhoneComparerFirstNumberFirstReturnsMinusOne()
        {
            //setup/arrange
            phone1.Number = "1111111111"; //it's an alpha compare
            int expected = -1;

            //execute/act
            int actual = phoneComparer.Compare(phone1, phone2);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestPhoneCompareFirstNumberLastReturnsOne()
        {
            //setup/arrange
            phone1.Number = "9999999999";
            int expected = 1;

            //execute/act
            int actual = phoneComparer.Compare(phone1, phone2);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestPhoneCompareFirstExtensionFirstReturnsMinusOne()
        {
            //setup/arrange
            phone1.Extension = "1111";
            int expected = -1;

            //execute/act
            int actual = phoneComparer.Compare(phone1, phone2);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestPhoneCompareFirstExtensionLastReturnsOne()
        {
            //setup/arrange
            phone1.Extension = "9999";
            int expected = 1;

            //execute/act
            int actual = phoneComparer.Compare(phone1, phone2);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestPhoneCompareFirstTypeFirstReturnsMinusOne()
        {
            //setup/arrange
            phone1.Type = PhoneType.Home;
            int expected = -1;

            //execute/act
            int actual = phoneComparer.Compare(phone1, phone2);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestPhoneCompareFirstTypeLastReturnsOne()
        {
            //setup/arrange
            phone1.Type = PhoneType.Mobile;
            int expected = 1;

            //execute/act
            int actual = phoneComparer.Compare(phone1, phone2);

            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}
