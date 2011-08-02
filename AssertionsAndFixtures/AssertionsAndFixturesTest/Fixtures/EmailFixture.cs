using System;
using System.Collections.Generic;


using AssertionsAndFixtures.DTO;

namespace AssertionsAndFixturesTest.Fixtures
{
    public class EmailFixture
    {
        public List<Email> CreateValidEmailList()
        {
            List<Email> emails = new List<Email>();
            emails.Add(CreateValidHomeEmail());
            emails.Add(CreateValidWorkEmail());
            emails.Add(CreateValidAltEmail());
            return emails;
        }

        public Email CreateValidHomeEmail()
        {
            Email email = new Email();
            email.Address = "valid.user@home.org";
            email.Type = EmailType.Home;
            return email;
        }

        public Email CreateValidWorkEmail()
        {
            Email email = new Email();
            email.Address = "valid.user@office.com";
            email.Type = EmailType.Work;
            return email;
        }

        public Email CreateValidAltEmail()
        {
            Email email = new Email();
            email.Address = "valid.user@alt.net";
            email.Type = EmailType.Alt;
            return email;
        }
    }
}
