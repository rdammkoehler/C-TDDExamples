using System;
using System.Collections.Generic;



namespace AssertionsAndFixtures.DTO
{
    public class Policy
    {
        public User Holder { get; set; }
        public List<Coverage> Coverages { get; set; }

        public Policy()
        {
            Coverages = new List<Coverage>();
        }
    }
}
