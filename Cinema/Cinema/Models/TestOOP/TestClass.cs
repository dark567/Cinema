using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cinema.Models.TestOOP
{
    public class TestClass:TestInterface
    {
        public int TestInt { get; set; }

        public string TestString { get; set; }

        public TestClass()
        {

        }
        public TestClass(int testInt)
        {
            this.TestInt = testInt;
        }
        public TestClass(string testString)
        {
            this.TestString = testString;
        }
        public TestClass(int testInt, string testString)
        {
            this.TestInt = testInt;
            this.TestString = testString;
        }

        public string TestInterfaceMethod()
        {
            return "Hello";
        }
    }
}