using System;



using AssertionsAndFixtures.DTO;
using AssertionsAndFixturesTest.Builders;
using NUnit.Framework;

namespace AssertionsAndFixturesTest
{
    [TestFixture]
    public class UserComparerTests
    {
        UserComparer userComparer = new UserComparer();
        User user1, user2;

        [SetUp]
        public void Setup()
        {
            user1 = new UserBuilder().BuildWithDefaults();
            user2 = new UserBuilder().BuildWithDefaults();
        }

        [Test]
        public void TestUserComparerWithIdenticalUsers()
        {
            //setup/arrange
            int expected = 0;

            //execute/act
            int actual = userComparer.Compare(user1, user2);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestUserComparerWithSameReferenceUser()
        {
            //setup/arrange
            user2 = user1;
            int expected = 0;

            //execute/act
            int actual = userComparer.Compare(user1, user2);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestUserComparerWithNulls()
        {
            //setup/arrange
            user1 = user2 = null;
            int expected = 0;

            //execute/act
            int actual = userComparer.Compare(user1, user2);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestUserComparerWithFirstArgNulled()
        {
            //setup/arrange
            user1 = null;
            int expected = 1;

            //execute/act
            int actual = userComparer.Compare(user1, user2);

            //assert
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void TestUserComparerWithSecondArgNulled()
        {
            //setup/arrange
            user2 = null;
            int expected = -1;

            //execute/act
            int actual = userComparer.Compare(user1, user2);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestUserComparerWithFirstUserFirstByUserName()
        {
            //setup/arrange
            user1.UserName = "aaaa";
            int expected = -1;

            //execute/act
            int actual = userComparer.Compare(user1, user2);

            //assert
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void TestUserComparerWithFirstUserLastByUserName()
        {
            //setup/arrange
            user1.UserName = "zzzz";
            int expected = 1;

            //execute/act
            int actual = userComparer.Compare(user1, user2);

            //assert
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void TestUserComparerWithFirstUserFirstByLastName()
        {
            //setup/arrange
            user1.LastName = "aaa";
            int expected = -1;

            //execute/act
            int actual = userComparer.Compare(user1, user2);

            //assert
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void TestUserComparerWithFirstUserLastByLastName()
        {
            //setup/arrange
            user1.LastName = "zzzz";
            int expected = 1;

            //execute/act
            int actual = userComparer.Compare(user1, user2);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestUserComparerWithFirstUserFirstByFirstName()
        {
            //setup/arrange
            user1.FirstName = "aaaa";
            int expected = -1;

            //execute/act
            int actual = userComparer.Compare(user1, user2);

            //assert
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void TestUserComparerWithFirstUserLastByFirstName()
        {
            //setup/arrange
            user1.FirstName = "zzzz";
            int expected = 1;

            //execute/act
            int actual = userComparer.Compare(user1, user2);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestUserComparerWithFirstUserNoAddresses()
        {
            //setup/arrange
            user1.Addresses = null;
            int expected = 1;

            //execute/act
            int actual = userComparer.Compare(user1, user2);

            //assert
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void TestUserComparerWithSecondUserNoAddresses()
        {
            //setup/arrange
            user2.Addresses = null;
            int expected = -1;

            //execute/act
            int actual = userComparer.Compare(user1, user2);

            //assert
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void TestUserComparerWithFirstUserNoPhones()
        {
            //setup/arrange
            user1.Phones = null;
            int expected = 1;

            //execute/act
            int actual = userComparer.Compare(user1, user2);

            //assert
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void TestUserComparerWithSecondUserNoPhones()
        {
            //setup/arrange
            user2.Phones = null;
            int expected = -1;

            //execute/act
            int actual = userComparer.Compare(user1, user2);

            //assert
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void TestUserComparerWithFirstUserNoEmails()
        {
            //setup/arrange
            user1.Emails = null;
            int expected = 1;

            //execute/act
            int actual = userComparer.Compare(user1, user2);

            //assert
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void TestUserComparerWithSecondUserNoEmails()
        {
            //setup/arrange
            user2.Emails = null;
            int expected = -1;

            //execute/act
            int actual = userComparer.Compare(user1, user2);

            //assert
            Assert.AreEqual(expected, actual);

        }
    }
}
