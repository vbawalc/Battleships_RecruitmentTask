using Battleships;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace BattleshipsUnitTests
{
    [TestClass]
    public class TestsGameState
    {
        GameState gameState;
        Mock<Random> mockRandom;
        Queue<int> randomCoordinates;
        Queue<int> randomRotation;

        [TestInitialize]
        public void TestInit()
        {
            mockRandom = new Mock<Random>();
            randomCoordinates = new Queue<int>(new[] { 0, 0, 5, 0, 5, 5 });
            randomRotation = new Queue<int>(new[] { 1, 1, 1 });
            mockRandom.Setup(Random => Random.Next(0, 10)).Returns(randomCoordinates.Dequeue);
            mockRandom.Setup(Random => Random.Next(0, 2)).Returns(randomRotation.Dequeue);
        }
        [TestMethod]
        public void TestCreatePlacableShips()
        {
            gameState = new GameState();
            int shiptiles = new int();
            foreach (Tile tile in gameState.aiplayer.Playerboard.Tiles)
            {
                if (!tile.IsWater())
                {
                    shiptiles++;
                }
            }
            //2 Destroyers  1 Battleship = 8 tiles + 5 tiles = 13 tiles 
            Assert.AreEqual(13, shiptiles);
        }
        [TestMethod]
        public void TestHitOrSink_Miss()
        {
            gameState = new GameState();
            gameState.aiplayer.Playerboard.Tiles[0, 0].Attack();

            Assert.AreEqual(GameState.MoveResult.miss,gameState.HitOrSink(new Coordinates(0, 0)));
        }
        [TestMethod]
        public void TestHitOrSink_Hit()
        {
            gameState = new GameState(mockRandom.Object);
            gameState.aiplayer.Playerboard.Tiles[0, 0].Attack();

            Assert.AreEqual(GameState.MoveResult.hit, gameState.HitOrSink(new Coordinates(0, 0)));
        }
        [TestMethod]
        public void TestHitOrSink_Sink()
        {
            GameState gameState = new GameState(mockRandom.Object);
            for (int i = 0; i < 5; i++)
            {
                gameState.aiplayer.Playerboard.Tiles[0, i].Attack();
            }

            Assert.AreEqual(GameState.MoveResult.sink, gameState.HitOrSink(new Coordinates(0, 4)));
        }
        [TestMethod]
        public void TestHitOrSink_GameOver()
        {
            gameState = new GameState(mockRandom.Object);
            foreach(Tile tile in gameState.aiplayer.Playerboard.Tiles)
            {
                tile.Attack();
            }

            Assert.AreEqual(GameState.MoveResult.gameover, gameState.HitOrSink(new Coordinates(0, 0)));
        }
    }
}
