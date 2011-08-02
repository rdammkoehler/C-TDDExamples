using System;
using System.Collections.Generic;


using AssertionsAndFixtures.DTO;

namespace AssertionsAndFixturesTest.Fixtures
{
    public class AddressFixture
    {
        public List<Address> CreateValidAddressList()
        {
            List<Address> addresses = new List<Address>();
            addresses.Add(CreateValidHomeAddress());
            addresses.Add(CreateValidWorkAddress());
            addresses.Add(CreateValidAltAddress());
            return addresses;
        }

        public Address CreateValidHomeAddress()
        {
            Address homeAddress = new Address();
            homeAddress.Street = "123 Main St.";
            homeAddress.City = "Anytown";
            homeAddress.State = "NY";
            homeAddress.ZipCode = "10101";
            homeAddress.Type = AddressType.Home;
            return homeAddress;
        }

        public Address CreateValidWorkAddress()
        {
            Address workAddress = new Address();
            workAddress.Street = "787 1st St.";
            workAddress.Street2 = "13th Floor";
            workAddress.City = "Cincinnati";
            workAddress.State = "OH";
            workAddress.ZipCode = "54043";
            workAddress.Type = AddressType.Work;
            return workAddress;
        }

        public Address CreateValidAltAddress()
        {
            Address altAddress = new Address();
            altAddress.Street = "1 Vacation Pl.";
            altAddress.City = "FarAway";
            altAddress.State = "CA";
            altAddress.ZipCode = "90210";
            altAddress.Type = AddressType.Alt;
            return altAddress;
        }
    }
}
