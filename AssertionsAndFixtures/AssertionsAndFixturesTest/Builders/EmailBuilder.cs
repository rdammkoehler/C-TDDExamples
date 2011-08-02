using System;



using AssertionsAndFixtures.DTO;

namespace AssertionsAndFixturesTest.Builders
{
    public class EmailBuilder
    {
        private Email email = new Email();

        public EmailBuilder()
        {
            email = BuildWithDefaults();
        }

        public EmailBuilder WithAddress(string address)
        {
            email.Address = address;
            return this;
        }

        public EmailBuilder WithType(EmailType type) {
            email.Type = type;
            return this;
        }

        public Email Build()
        {
            return email;
        }

        public Email BuildWithDefaults()
        {
            return WithAddress("default.user@work.com")
                .WithType(EmailType.Work)
                .Build();
        }
    }
}
