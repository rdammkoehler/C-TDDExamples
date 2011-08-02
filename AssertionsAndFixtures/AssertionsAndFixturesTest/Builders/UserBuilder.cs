using System;
using System.Collections.Generic;


using AssertionsAndFixtures.DTO;

namespace AssertionsAndFixturesTest.Builders
{
    public class UserBuilder
    {
        private User user = new User();

        public UserBuilder()
        {
            user = BuildWithDefaults();
        }

        public UserBuilder WithUserName(string userName)
        {
            user.UserName = userName;
            return this;
        }

        public UserBuilder WithFirstName(string firstName)
        {
            user.FirstName = firstName;
            return this;
        }

        public UserBuilder WithLastName(string lastName) {
            user.LastName = lastName;
            return this;
        }

        public UserBuilder WithAddresses(List<Address> addresses)
        {
            user.Addresses = addresses;
            return this;
        }

        public UserBuilder WithPhones(List<Phone> phones)
        {
            user.Phones = phones;
            return this;
        }

        public UserBuilder WithEmails(List<Email> emails)
        {
            user.Emails = emails;
            return this;
        }

        public User Build()
        {
            return user;
        }

        public User BuildWithDefaults()
        {
            AddressBuilder addressBuilder = new AddressBuilder();
            List<Address> defaultAddresses = new List<Address>();
            defaultAddresses.Add(addressBuilder.BuildWithDefaults());
            PhoneBuilder phoneBuilder = new PhoneBuilder();
            List<Phone> defaultPhones = new List<Phone>();
            defaultPhones.Add(phoneBuilder.BuildWithDefaults());
            EmailBuilder emailBuilder = new EmailBuilder();
            List<Email> defaultEmails = new List<Email>();
            defaultEmails.Add(emailBuilder.BuildWithDefaults());
            return WithUserName("DefaultUser")
                .WithFirstName("Default")
                .WithLastName("User")
                .WithAddresses(defaultAddresses)
                .WithPhones(defaultPhones)
                .WithEmails(defaultEmails)
                .Build();
        }
    }
}
