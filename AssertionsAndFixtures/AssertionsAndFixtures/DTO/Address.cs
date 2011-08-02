using System;
using System.Collections.Generic;



namespace AssertionsAndFixtures.DTO
{
    public enum AddressType { Home, Work, Alt }

    public class Address
    {
        public string Street { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public AddressType Type { get; set; }
    }

    public class AddressComparer : IComparer<Address>
    {
        #region IComparer<Address> Members

        //Exercise 1: Identify the hole(s) in the test harness with respect to this method
        public int Compare(Address x, Address y)
        {
            int rval = 0;
            if ((x == null && y == null)||(x == y))
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
                if (0 == (rval = x.ZipCode.CompareTo(y.ZipCode)))
                {
                    if (0 == (rval = x.Street.CompareTo(y.Street)))
                    {
                        if (x.Street2 == null && y.Street2 != null)
                        {
                            rval = 1;
                        }
                        else if (x.Street2 != null && y.Street2 == null)
                        {
                            rval = -1;
                        }
                        else if ((x.Street2 == null && y.Street2 == null) || (0 == (rval = x.Street2.CompareTo(y.Street2))))
                        {
                            rval = x.Type.CompareTo(y.Type);
                        }
                    }
                }
            }
            return rval;
        }

        #endregion
    }
}
