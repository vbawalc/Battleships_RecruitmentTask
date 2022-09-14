using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Battleships;
using Moq;
using System.Collections.Generic;

namespace BattleshipsUnitTests
{
    [TestClass]
    public class TestsAIPlayer
    {
        Stack<Ship> placableships;
        AIPlayer aiplayer;
        Mock<Random> mockRandom;
        Queue<int> randomCoordinates;
        Queue<int> randomRotation;
        [TestInitialize]
        public void TestInit()
        {
            placableships = new Stack<Ship>();
            placableships.Push(new Battleship());
            mockRandom = new Mock<Random>();
          
        }
        [TestMethod]
        public void TestSetupShips_ShipPartiallyOutOfBoard()
        {
            var mockRandom = new Mock<Random>();
            //Ship setup location will be [9,9] so it wont fit the board, next random location will be [0,0] and ship should be placed there
            randomCoordinates = new Queue<int>(new[] { 9, 9, 0, 0});
            randomRotation = new Queue<int>(new[] { 0, 0});
            mockRandom.Setup(Random => Random.Next(0, 10)).Returns(randomCoordinates.Dequeue);
            mockRandom.Setup(Random => Random.Next(0, 2)).Returns(randomRotation.Dequeue);

            aiplayer = new AIPlayer(mockRandom.Object, new Board(10), placableships);
            for (int i=0;i<5;i++)
            {
                if (aiplayer.Playerboard.Tiles[0,i].IsWater())
                {
                    Assert.Fail();
                }
            }
        }
        [TestMethod]
        public void TestSetupShips_TwoShipsInSameLocation()
        {
            randomCoordinates = new Queue<int>(new[] { 5, 5, 5, 5, 0, 0 });
            randomRotation = new Queue<int>(new[] { 0, 0, 0 });
            mockRandom.Setup(Random => Random.Next(0, 10)).Returns(randomCoordinates.Dequeue);
            mockRandom.Setup(Random => Random.Next(0, 2)).Returns(randomRotation.Dequeue);
            //Random tile is the same for first and second ship, aiplayer should skip second pair and place ship in third location
            placableships.Push(new Battleship());
            aiplayer = new AIPlayer(mockRandom.Object, new Board(10), placableships);
            //Check if there is ship in third location from (0,0) to (0,4) 
            for (int i = 0; i < 5; i++)
            {
                if (aiplayer.Playerboard.Tiles[0, i].IsWater())
                {
                    Assert.Fail();
                }
            }
        }
    }
}
