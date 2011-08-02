using System;



using AssertionsAndFixtures.DTO;

namespace AssertionsAndFixturesTest.Builders
{
    public class AddressBuilder
    {
        private Address address = new Address();

        public AddressBuilder()
        {
            address = BuildWithDefaults();
        }

        public AddressBuilder WithStreet(string street) {
            address.Street = street;
            return this;
        }

        public AddressBuilder WithStreet2(string street) {
            address.Street2 = street;
            return this;
        }

        public AddressBuilder WithCity(string city) {
            address.City = city;
            return this;
        }

        public AddressBuilder WithState(string state) {
            address.State = state;
            return this;
        }

        public AddressBuilder WithZipCode(string zipcode) {
            address.ZipCode = zipcode;
            return this;
        }

        public AddressBuilder WithType(AddressType type) {
            address.Type = type;
            return this;
        }

        public Address Build()
        {
            return address;
        }

        public Address BuildWithDefaults()
        {
            return WithStreet("123 Main St.")
                .WithStreet2(null)
                .WithCity("Anytown")
                .WithState("NY")
                .WithZipCode("10101")
                .WithType(AddressType.Home)
                .Build();
        }
    }
}
