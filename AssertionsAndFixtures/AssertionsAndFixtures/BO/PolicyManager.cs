using System;



using AssertionsAndFixtures.DTO;

namespace AssertionsAndFixtures.BO
{
    public interface PolicyManager
    {
        Policy CreateEmptyPolicy(User user);
    }
}
