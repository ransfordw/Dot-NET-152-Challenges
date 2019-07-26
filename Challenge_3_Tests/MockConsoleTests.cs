using System;
using System.Collections.Generic;
using Challenge_3;
using Challenge_UtilityMethods;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Challenge_3_Tests
{
    [TestClass]
    public class MockConsoleTests
    {
        [DataTestMethod]
        [DataRow("true","1", "1", "5")]
        public void TestMethod1(string expected, string[] args )
        {
            var commandList = new List<string>();
            foreach(var arg in args)
            {
                commandList.Add(arg);
            }
            var mockConsole = new MockConsole(commandList);

            var program = new ProgramUI(mockConsole);
            program.Run();

            Assert.IsTrue(mockConsole.Output.Contains(expected));
        }
    }
}
