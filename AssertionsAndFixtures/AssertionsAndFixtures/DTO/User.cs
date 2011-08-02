using System;
using System.Collections.Generic;



namespace AssertionsAndFixtures.DTO
{
    public class User
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Address> Addresses { get; set; }
        public List<Phone> Phones { get; set; }
        public List<Email> Emails { get; set; }
    }

    public class UserComparer : IComparer<User>
    {
        #region IComparer<User> Members

        public int Compare(User x, User y)
        {
            int rval = 0;
            if ((x == null && y == null) || (x == y))
            {
                rval = 0;
            }
            else if (x == null)
            {
                rval = 1;
            }
            else if (y == null)
            {
                rval = -1;
            }
            else
            {
                rval = DeepCompare(x, y);
            }
            return rval;
        }
        private int DeepCompare(User x, User y)
        {
            int rval = 0;

            if (0 == (rval = x.UserName.CompareTo(y.UserName)))
            {
                if (0 == (rval = x.LastName.CompareTo(y.LastName)))
                {
                    if (0 == (rval = x.FirstName.CompareTo(y.FirstName)))
                    {
                        if (0 == (rval = CompareAddressLists(x, y)))
                        {
                            if (0 == (rval = ComparePhoneLists(x, y)))
                            {
                                rval = CompareEmailLists(x, y);
                            }
                        }
                    }
                }
            }

            return rval;
        }
        private int CompareAddressLists(User x, User y)
        {
            int rval = 0;
            if ((x.Addresses == null && y.Addresses == null) || (x.Addresses == y.Addresses))
            {
                rval = 0;
            }
            else if (x.Addresses == null)
            {
                rval = 1;
            }
            else if (y.Addresses == null)
            {
                rval = -1;
            }
            else if (0 == (rval = x.Addresses.Count - y.Addresses.Count))
            {
                AddressComparer addressComparer = new AddressComparer();
                for (int idx = 0; rval == 0 && idx < x.Addresses.Count; idx++)
                {
                    rval = addressComparer.Compare(x.Addresses[idx], y.Addresses[idx]);
                }
            }
            return rval;
        }
        private int ComparePhoneLists(User x, User y)
        {
            int rval = 0;
            if ((x.Phones == null && y.Phones == null) || (x.Phones == y.Phones))
            {
                rval = 0;
            }
            else if (x.Phones == null)
            {
                rval = 1;
            }
            else if (y.Phones == null)
            {
                rval = -1;
            }
            else if (0 == (rval = x.Phones.Count - y.Phones.Count))
            {
                PhoneComparer phoneComparer = new PhoneComparer();
                for (int idx = 0; rval == 0 && idx < x.Phones.Count; idx++)
                {
                    rval = phoneComparer.Compare(x.Phones[idx], y.Phones[idx]);
                }
            }
            return rval;
        }
        private int CompareEmailLists(User x, User y)
        {
            int rval = 0;
            if ((x.Emails == null && y.Emails == null) || (x.Emails == y.Emails))
            {
                rval = 0;
            }
            else if (x.Emails == null)
            {
                rval = 1;
            }
            else if (y.Emails == null)
            {
                rval = -1;
            }
            else if (0 == (rval = x.Emails.Count - y.Emails.Count))
            {
                EmailComparer emailComparer = new EmailComparer();
                for (int idx = 0; rval == 0 && idx < x.Emails.Count; idx++)
                {
                    rval = emailComparer.Compare(x.Emails[idx], y.Emails[idx]);
                }
            }
            return rval;
        }

        #endregion
    }
}
