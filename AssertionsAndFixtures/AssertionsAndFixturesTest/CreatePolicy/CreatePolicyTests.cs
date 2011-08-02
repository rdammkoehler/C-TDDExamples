using System;



using NUnit.Framework;
using AssertionsAndFixtures.BO;
using AssertionsAndFixtures.DAO;
using AssertionsAndFixtures.DTO;
using AssertionsAndFixturesTest.Assertions;
using AssertionsAndFixturesTest.Builders;
using AssertionsAndFixturesTest.Fixtures;
using NMock2;

namespace AssertionsAndFixturesTest.CreatePolicy
{
    [TestFixture]
    public class CreatePolicyTests
    {
        [Test]
        public void Test_CreateEmptyPolicyWithDefaultUserSucceeds_WithBuilder()
        {
            //setup/arrange
            Mockery mockery = new Mockery();
            User user = new UserBuilder().BuildWithDefaults();
            PolicyDAO policyDAO = mockery.NewMock<PolicyDAO>();
            Expect.Once.On(policyDAO).Method("Save").WithAnyArguments();
            PolicyManager manager = new PolicyManagerImpl(policyDAO);

            //execute/act
            Policy policy = manager.CreateEmptyPolicy(user);

            //assert
            mockery.VerifyAllExpectationsHaveBeenMet();
            Assert.AreSame(user, policy.Holder, "holder should be user we created for");
            Assert.AreEqual(0, policy.Coverages.Count, "coverages should be zero");

        }

        [Test]
        public void Test_CreateEmptyPolicyWithDefaultUserSucceeds_WithFixture()
        {
            //setup/arrange
            Mockery mockery = new Mockery();
            User user = new UserFixture().CreateValidUser();
            PolicyDAO policyDAO = mockery.NewMock<PolicyDAO>();
            Expect.Once.On(policyDAO).Method("Save").WithAnyArguments();
            PolicyManager manager = new PolicyManagerImpl(policyDAO);

            //execute/act
            Policy policy = manager.CreateEmptyPolicy(user);

            //assert
            mockery.VerifyAllExpectationsHaveBeenMet();
            Assert.AreSame(user, policy.Holder, "holder should be user we created for");
            Assert.AreEqual(0, policy.Coverages.Count, "coverages should be zero");

        }

        // With the proceeding two tests, fixture v. builder mox-nix, but...
        [Test]
        public void Test_CreateEmptyPolicyWithCustomUserSucceeds_WithBuilder()
        {
            //setup/arrange
            Mockery mockery = new Mockery();
            User user = new UserBuilder().WithUserName("customuser").Build();                   //this would require something special in the fixture, or more code here
            PolicyDAO policyDAO = mockery.NewMock<PolicyDAO>();
            Expect.Once.On(policyDAO).Method("Save").WithAnyArguments();
            PolicyManager manager = new PolicyManagerImpl(policyDAO);

            //execute/act
            Policy policy = manager.CreateEmptyPolicy(user);

            //assert
            mockery.VerifyAllExpectationsHaveBeenMet();
            Assert.AreSame(user, policy.Holder, "holder should be user we created for");
            Assert.AreEqual(user.UserName, policy.Holder.UserName, "usernames should be equal"); 
            Assert.AreEqual(0, policy.Coverages.Count, "coverages should be zero");

        }

        // Let's say you want to verify the equality of two users that are different objects
        [Test]
        public void Test_UserFixtureCreateValidUserIsConsistent()
        {
            //setup/arrange
            User user1 = new UserFixture().CreateValidUser();
            User user2 = new UserFixture().CreateValidUser();

            //execute/act
            // no operation for this example

            //assert
            new UserAssertion().AreEqual(user1, user2, "Example Assertions");

        }
        
        [Test]
        public void Test_UserBuilderBuildWithDefaultsIsConsistent()
        {
            //setup/arrange
            User user1 = new UserBuilder().BuildWithDefaults();
            User user2 = new UserBuilder().BuildWithDefaults();

            //execute/act
            // no operation for this example

            //assert
            new UserAssertion().AreEqual(user1, user2, "Example Assertions");

        }
    }
}
