using System;



using AssertionsAndFixtures.DAO;
using AssertionsAndFixtures.DTO;

namespace AssertionsAndFixtures.BO
{
    public class PolicyManagerImpl : PolicyManager
    {
        public PolicyDAO PolicyDAO { get; set; }

        public PolicyManagerImpl(PolicyDAO policyDao)
        {
            PolicyDAO = policyDao;
        }

        #region PolicyManager Members

        public Policy CreateEmptyPolicy(User user)
        {
            Policy policy = new Policy();
            policy.Holder = user;
            // other initialization code would go here
            PolicyDAO.Save(policy);
            return policy;
        }

        #endregion
    }
}
