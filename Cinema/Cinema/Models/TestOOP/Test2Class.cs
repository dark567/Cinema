using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cinema.Models.TestOOP
{
    public class Test2Class
    {
        public int TestInt { get; set; }

        public string TestString { get; set; }

        public Test2Class()
        {

        }
        public Test2Class(int testInt)
        {
            this.TestInt = testInt;
        }
        public Test2Class(string testString)
        {
            this.TestString = testString;
        }
        public Test2Class(int testInt, string testString)
        {
            this.TestInt = testInt;
            this.TestString = testString;
        }
    }
}