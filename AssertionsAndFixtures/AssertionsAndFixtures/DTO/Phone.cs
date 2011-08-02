using System;
using System.Collections.Generic;



namespace AssertionsAndFixtures.DTO
{
    public enum PhoneType { Home, Work, Fax, Mobile }

    public class Phone
    {
        public string Number { get; set; }
        public string Extension { get; set; }
        public PhoneType Type { get; set; }
    }

    public class PhoneComparer : IComparer<Phone>
    {
        #region IComparer<Phone> Members

        //Exercise 1: Identify the hole(s) in the test harness with respect to this method
        public int Compare(Phone x, Phone y)
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
                if (0 == (rval = x.Number.CompareTo(y.Number)))
                {
                    if (0 == (rval = x.Extension.CompareTo(y.Extension)))
                    {
                        rval = x.Type.CompareTo(y.Type);
                    }
                }
            }
            return rval;
        }

        #endregion
    }
}
