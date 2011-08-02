using System;
using System.Text;

using System.Collections.Generic;
using AssertionsAndFixtures.DTO;
using NUnit.Framework;

namespace AssertionsAndFixturesTest.Assertions
{
    public class UserAssertion
    {
        public void AreEqual(User expected, User actual)
        {
            AreEqual(expected, actual, "");
        }

        public void AreEqual(User expected, User actual, string message)
        {
            Assert.AreEqual(expected.UserName, actual.UserName, new StringBuilder(message).Append("; UserNames are not equal").ToString());
            Assert.AreEqual(expected.FirstName, actual.FirstName, new StringBuilder(message).Append("; FirstNames are not equal").ToString());
            Assert.AreEqual(expected.LastName, actual.LastName, new StringBuilder(message).Append("; LastNames are not equal").ToString());

            AddressAssertion addressAssertion = new AddressAssertion();
            List<Address> expectedAddresses = expected.Addresses;
            List<Address> actualAddresses = actual.Addresses;
            AddressComparer addressComparer = new AddressComparer();
            expectedAddresses.Sort(addressComparer);
            actualAddresses.Sort(addressComparer);
            for (int i = 0; i < expectedAddresses.Count; i++)
            {
                addressAssertion.AreEqual(expectedAddresses[i], actualAddresses[i], message);
            }

            PhoneAssertion phoneAssertion = new PhoneAssertion();
            List<Phone> expectedPhones = expected.Phones;
            List<Phone> actualPhones = actual.Phones;
            PhoneComparer phoneComparer = new PhoneComparer();
            expectedPhones.Sort(phoneComparer);
            actualPhones.Sort(phoneComparer);
            for (int i = 0; i < expectedPhones.Count; i++)
            {
                phoneAssertion.AreEqual(expectedPhones[i], actualPhones[i], message);
            }

            EmailAssertion emailAssertion = new EmailAssertion();
            List<Email> expectedEmails = expected.Emails;
            List<Email> actualEmails = actual.Emails;
            EmailComparer emailComparer = new EmailComparer();
            expectedEmails.Sort(emailComparer);
            actualEmails.Sort(emailComparer);
            for (int i = 0; i < expectedEmails.Count; i++)
            {
                emailAssertion.AreEqual(expectedEmails[i], actualEmails[i], message);
            }
        }

    }
}
