using Battleships;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BattleshipsUnitTests
{
    [TestClass]
    public class TestsTile
    {
        Tile tile;

        [TestInitialize]
        public void TestInit()
        {
            tile = new Tile();
        }

        [TestMethod]
        public void TestAttack()
        {
            tile.Attack();
            Assert.IsTrue (tile.IsHit);
        }
        [TestMethod]
        public void TestAddShip()
        {
            tile.AddShip(new Battleship());
            Assert.IsFalse(tile.IsWater());
        }
        [TestMethod]
        public void TestIsWater_True()
        {
            //newly created tiles should be water until ship is added to them - IsWater should return True
            Assert.IsTrue(tile.IsWater());
        }
        public void TestIsWater_False()
        {
            tile.AddShip(new Battleship());
            //IsWater should return false when ship is placed on the tile
            Assert.IsFalse(tile.IsWater());
        }
    }
}
