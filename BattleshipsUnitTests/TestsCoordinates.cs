using Battleships;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BattleshipsUnitTests
{
    [TestClass]
    public class TestsCoordinates
    {
        Coordinates coordinates1;
        Coordinates coordinates2;

        [TestInitialize]
        public void TestInit()
        {
            coordinates1 = new Coordinates(1, 1);
            coordinates2 = new Coordinates(2, 2);
        }

        [TestMethod]
        public void TestAddCoordinates_x()
        {
            Assert.AreEqual(new Coordinates(3, 3).X, (coordinates1 + coordinates2).X);
        }
        [TestMethod]
        public void TestAddCoordinates_y()
        {
            Assert.AreEqual(new Coordinates(3, 3).Y, (coordinates1 + coordinates2).Y);
        }
    }
}
