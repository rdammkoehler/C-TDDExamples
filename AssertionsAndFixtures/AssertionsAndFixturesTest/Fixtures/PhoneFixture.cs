using System;
using System.Collections.Generic;


using AssertionsAndFixtures.DTO;

namespace AssertionsAndFixturesTest.Fixtures
{
    public class PhoneFixture
    {
        public List<Phone> CreateValidPhoneList()
        {
            List<Phone> phones = new List<Phone>();
            phones.Add(CreateValidHomePhone());
            phones.Add(CreateValidWorkPhone());
            phones.Add(CreateValidFaxPhone());
            phones.Add(CreateValidMobilePhone());
            return phones;
        }

        public Phone CreateValidHomePhone()
        {
            Phone phone = new Phone();
            phone.Number = "212-555-1212";
            phone.Type = PhoneType.Home;
            return phone;
        }

        public Phone CreateValidWorkPhone()
        {
            Phone phone = new Phone();
            phone.Number = "212-555-1000";
            phone.Extension = "121";
            phone.Type = PhoneType.Work;
            return phone;
        }

        public Phone CreateValidFaxPhone()
        {
            Phone phone = new Phone();
            phone.Number = "212-555-1214";
            phone.Type = PhoneType.Fax;
            return phone;
        }

        public Phone CreateValidMobilePhone()
        {
            Phone phone = new Phone();
            phone.Number = "212-555-1215";
            phone.Type = PhoneType.Mobile;
            return phone;
        }

    }
}
