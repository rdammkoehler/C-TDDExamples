using System;
using System.Collections.Generic;



namespace AssertionsAndFixtures.DTO
{
    public enum EmailType { Home, Work, Alt }

    public class Email
    {
        public string Address { get; set; }
        public EmailType Type { get; set; }
    }

    public class EmailComparer : IComparer<Email>
    {
        #region IComparer<Email> Members

        //Exercise 1: Identify the hole(s) in the test harness with respect to this method
        public int Compare(Email x, Email y)
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
                if (0 == (rval = x.Address.CompareTo(y.Address)))
                {
                    rval = x.Type.CompareTo(y.Type);
                }
            }
            return rval;
        }

        #endregion
    }
}
