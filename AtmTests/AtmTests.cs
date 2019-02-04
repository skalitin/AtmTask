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
            var load = new[]
            {
                 new Pack(1000, 3),
                 new Pack(500, 2)
            };
            var terminal = new Terminal(load);

            Assert.AreEqual("2x1000 1x500", terminal.Take(2500));
            Assert.AreEqual("1x1000", terminal.Take(1000));
            Assert.AreEqual("Error", terminal.Take(10000));
            Assert.AreEqual("Error", terminal.Take(1700));
        }

        [TestMethod]
        public void ComplexTest()
        {
            var load = new[]
            {
                 new Pack(4, 4),
                 new Pack(3, 4),
                 new Pack(5, 4)
            };
            var terminal = new Terminal(load);

            Assert.AreEqual("2x5 1x4", terminal.Take(14));

            Assert.AreEqual("1x3", terminal.Take(3));
            Assert.AreEqual("1x4", terminal.Take(4));
            Assert.AreEqual("1x5", terminal.Take(5));
            
            Assert.AreEqual("3x5", terminal.Take(15));
            Assert.AreEqual("1x5 2x4 1x3", terminal.Take(16));

            Assert.AreEqual("Error", terminal.Take(2));
        }
    }
}
