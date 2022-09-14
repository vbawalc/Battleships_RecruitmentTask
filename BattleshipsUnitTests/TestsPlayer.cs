using Microsoft.VisualStudio.TestTools.UnitTesting;
using Battleships;
using System.Collections.Generic;
using System;
using System.Globalization;
using System.Linq;

namespace BattleshipsUnitTests
{
    [TestClass]
    public class TestsPlayer
    {
        Stack<Ship> placableShips;
        Player player;

        [TestInitialize]
        public void TestInit()
        {
            placableShips = new Stack<Ship>();
            placableShips.Push(new Battleship());
            player = new Player(new Board(10), placableShips);
        }
        [TestMethod]
        public void TestRotateShip_Width()
        {
            int height =placableShips.First().Height;
            player.RotatePlaceableShip();
            
            Assert.AreEqual(height,placableShips.Pop().Width);
        }
        [TestMethod]
        public void TestRotateShip_Height()
        {
            int width = placableShips.First().Width;
            player.RotatePlaceableShip();

            Assert.AreEqual(width, placableShips.Pop().Height);
        }
        [TestMethod]
        public void TestRotateShip_NoShip()
        {
            placableShips = null;
            try
            {
                player.RotatePlaceableShip();
                Assert.Fail(); //Fail if code is done - exception should be thrown
            }
            catch (Exception)
            {
                //Catches the assertion exception, and the test passes
            }
        }
        [TestMethod]
        public void TestPlaceShip_CorrectPlacement()
        {
            player.PlaceShip(new Coordinates(0, 0));

            for(int i=0;i<5;i++)
            {
                if (player.Playerboard.Tiles[0,i].IsWater())
                {
                    Assert.Fail();
                }
            }
        }
        [TestMethod]
        public void TestPlaceShip_NoShip()
        {
            placableShips = null;
            try
            {
                player.PlaceShip(new Coordinates(0, 0));
                Assert.Fail(); //Fail if code is done - exception should be thrown
            }
            catch (Exception)
            {
                //Catches the assertion exception, and the test passes
            }
        }
        [TestMethod]
        public void TestGameOver_AllShipsDestroyed()
        {
            player.PlaceShip(new Coordinates(0, 0));
            //Mark all tiles as Hit
            for(int i=0;i<5;i++)
            {
                player.Playerboard.Tiles[0, i].Attack();
            }
            Assert.IsTrue(player.IsGameOver());
        }
        [TestMethod]
        public void TestGameOver_NotAllShipsDestroyed()
        {
            player.PlaceShip(new Coordinates(0, 0));
            //Mark all tiles as Hit
            for (int i = 0; i < 4; i++)
            {
                player.Playerboard.Tiles[0, i].Attack();
            }
            Assert.IsFalse(player.IsGameOver());
        }
    }
}
