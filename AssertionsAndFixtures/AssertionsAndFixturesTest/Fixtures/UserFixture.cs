using System;



using AssertionsAndFixtures.DTO;

namespace AssertionsAndFixturesTest.Fixtures
{
    public class UserFixture
    {
        public User CreateValidUser()
        {
            User aUser = new User();
            aUser.UserName = "DefaultUser";
            aUser.FirstName = "Default";
            aUser.LastName = "User";
            aUser.Addresses = new AddressFixture().CreateValidAddressList();
            aUser.Phones = new PhoneFixture().CreateValidPhoneList();
            aUser.Emails = new EmailFixture().CreateValidEmailList();
            return aUser;
        }

    }
}
