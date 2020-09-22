using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cinema.Models.TestOOP
{
    public class Parent : TestClass, TestInterface
    {
        public Parent()
        {
        }

        public Parent(int testInt) : base(testInt)
        {
        }

        public Parent(string testString) : base(testString)
        {
        }

        public Parent(int testInt, string testString) : base(testInt, testString)
        {
        }

        public string TestInterfaceMethod()
        {
            throw new NotImplementedException();
        }
    }
}