using Challenge_3;
using Challenge_UtilityMethods;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Challenge_3_Tests
{
    class TestData
    {
        public string ExpectedOutcome { get; set; }
        public List<string> Commands { get; set; }
        public TestData()
        {
            Commands = new List<string>();
        }

    }
    [TestClass]
    public class MockConsoleTests
    {
        private static readonly List<string> _commandsSeeAllOutings = new List<string>() { "List of Outings", "1", "1", "5" };

        [DataTestMethod]
        [DataRow("List of Outings", "1", "1", "5")]
        public void MockConsole_ConsolePrintsAllOutings(string expected, string input1, string input2, string input3)
        {
            var commandList = new List<string>() { input1, input2, input3 };

            var mockConsole = new MockConsole(commandList);

            var program = new ProgramUI(mockConsole);
            program.Run();

            Assert.IsTrue(mockConsole.Output.Contains(expected));
        }
    }
}
