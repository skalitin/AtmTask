using Microsoft.VisualStudio.TestTools.UnitTesting;
using Atm;

namespace AtmTests
{
    [TestClass]
    public class TerminalTests
    {
        [TestMethod]
        public void SimpleTest()
        {
            var load = new[] { new Pack(1000, 3)};
            var terminal = new Terminal(load);
            Assert.AreEqual("", terminal.Take(1000));
        }
    }
}
