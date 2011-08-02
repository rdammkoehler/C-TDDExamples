using System;



using AssertionsAndFixtures.DTO;

namespace AssertionsAndFixturesTest.Builders
{
    public class PhoneBuilder
    {
        private Phone phone = new Phone();

        public PhoneBuilder()
        {
            phone = BuildWithDefaults();
        }

        public PhoneBuilder WithNumber(string number) {
            phone.Number = number;
            return this;
        }

        public PhoneBuilder WithExtension(string ext) {
            phone.Extension = ext;
            return this;
        }

        public PhoneBuilder WithType(PhoneType type) {
            phone.Type = type;
            return this;
        }

        public Phone Build()
        {
            return phone;
        }

        public Phone BuildWithDefaults()
        {
            return WithNumber("212-555-1212")
                .WithExtension("123")
                .WithType(PhoneType.Work)
                .Build();
        }
    }
}
