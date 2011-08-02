using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace DALImplementationTestingDemo.Source
{
    public class MockDBCommandFactory : DBCommandFactory 
    {
        IList<Expectation> expectations = new List<Expectation>();

        public Expectation RespondTo(string request)
        {
            Expectation expectation = new Expectation(new Invocation(request));
            expectations.Add(expectation);
            return expectation;
        }

        public void VerifyExpectations()
        {
            foreach (Expectation expectation in expectations)
            {
                expectation.AssertSatisfied();
            }
        }

        /** DBCommandFactory Impl **/
        public DbCommand GetStoredProcCommand(string commandName)
        {
            DbCommand command = null;
            Expectation theExpectation = null;
            foreach (Expectation expectation in expectations)
            {
                if (commandName.Equals(expectation.Invocation.Name))
                {
                    theExpectation = expectation;
                    break;
                }
            }
            if (theExpectation != null)
            {
                theExpectation.Satisfied = true;
                command = (DbCommand)theExpectation.RVal;
            }
            return command;
        }
    }

    public class Expectation
    {

        public bool Satisfied { get; set; }
        public object RVal { get; set; }
        public Invocation Invocation { get; set; }

        public Expectation(Invocation inv) {
            Invocation = inv;
        }

        public void With(object obj)
        {
            RVal = obj;
        }

        public void AssertSatisfied()
        {
            Assert.IsTrue(Satisfied,CreateMessage());
        }

        private string CreateMessage()
        {
            return new StringBuilder("Expected ").Append(Invocation).ToString();
        }
    }

    public class Invocation
    {
        public string Name { get; set; }
        public Invocation(string nm)
        {
            Name = nm;
        }

        override public string ToString()
        {
            return new StringBuilder("invocation of GetStoredProcCommand with the argument '").Append(Name).Append("'").ToString();
        }
    }


}
