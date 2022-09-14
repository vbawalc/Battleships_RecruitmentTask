using Battleships;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BattleshipsUnitTests
{
   
    [TestClass]
    public class TestsBoard
    {
        Board board;
        Ship ship;

        [TestInitialize]
        public void TestInit()
        {
            board = new Board(10);
            ship = new Battleship();
        }
        [TestMethod]
        public void TestPlaceShip_CoordinatesNotOnBoard()
        {
            try
            {
                board.PlaceShip(new Coordinates(21, 37), ship);
                Assert.Fail();
            }
            catch(Exception)
            {
                //Pass
            }
        }
        [TestMethod]
        public void TestPlaceShip_CorrectPossition()
        {
            board.PlaceShip(new Coordinates(0, 0), ship);
            for (int i = 0; i < 5; i++)
            {
                if (board.Tiles[0, i].IsWater())
                {
                    Assert.Fail();
                }
            }
        }
        [TestMethod]
        public void TestPlaceShip_ShipPartiallyOutOfBoard()
        {
            try
            {
                board.PlaceShip(new Coordinates(7, 7), ship);
                Assert.Fail();
            }
            catch (Exception)
            {
                //Pass
            }
        }
        [TestMethod]
        public void TestPlaceShip_ShipAlreadyPlacedInThisLocation()
        {
            board.PlaceShip(new Coordinates(0, 0), ship);
            try
            {
                board.PlaceShip(new Coordinates(0, 0), ship);
                Assert.Fail();
            }
            catch (Exception)
            {
                //Pass
            }
        }
        [TestMethod]
        public void TestCanPlaceShip_True()
        {         
            Assert.IsTrue(board.CanPlaceShip(new Coordinates(0,0), ship));           
        }
        [TestMethod]
        public void TestCanPlaceShip_CoordinatesNotOnBoard()
        {
            Assert.IsFalse(board.CanPlaceShip(new Coordinates(420, 520), ship));
        }
        [TestMethod]
        public void TestCanPlaceShip_ShipPartiallyOutOfBoard()
        {
            Assert.IsFalse(board.CanPlaceShip(new Coordinates(9, 9), ship));
        }
    }
}
