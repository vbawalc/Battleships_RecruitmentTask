using Battleships;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace BattleshipsUnitTests
{
    [TestClass]
    public class TestsDestroyer
    {
        Destroyer ship;
        Tile tile;

        [TestInitialize]
        public void TestInit()
        {
            ship = new Destroyer();
            tile = new Tile();
            ship.AddTile(tile);
        }
        [TestMethod]
        public void TestIsDestroyed_False()
        {
            Assert.IsFalse(ship.IsDestroyed());
        }
        [TestMethod]
        public void TestIsDestroyed_True()
        {
            tile.Attack();
            Assert.IsTrue(ship.IsDestroyed());
        }
        [TestMethod]
        public void TestIsDestroyed_NotAllTilesHit()
        {
            Tile notHitTile = new Tile();
            ship.AddTile(notHitTile);
            tile.Attack();
            Assert.IsFalse(ship.IsDestroyed());
        }
        [TestMethod]
        public void TestIsDestroyed_AllTilesHit()
        {
            Tile hitTile = new Tile();
            ship.AddTile(hitTile);
            tile.Attack();
            hitTile.Attack();
            Assert.IsTrue(ship.IsDestroyed());
        }
        [TestMethod]
        public void TestRotate_Width()
        {
            int heigth = ship.Height;
            ship.Rotate();
            Assert.AreEqual(heigth, ship.Width);
        }
        [TestMethod]
        public void TestRotate_Height()
        {
            int width = ship.Width;
            ship.Rotate();
            Assert.AreEqual(width, ship.Height);
        }
    }
}
