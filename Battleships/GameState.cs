using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Battleships
{
    internal class GameState
    {
        private AIPlayer _aiplayer;
        public AIPlayer aiplayer => _aiplayer;
        const int gridSize = 10;
        public enum MoveResult { hit, miss, sink, gameover };

        public GameState()
        {
            _aiplayer = new AIPlayer(new Random(), new Board(gridSize), CreatePlacableShips());
        }
        public GameState(Random random) //Dependancy injection needed for tests
        {
            _aiplayer = new AIPlayer(random, new Board(gridSize), CreatePlacableShips());
        }
        private Stack<Ship> CreatePlacableShips()
        {
            Stack<Ship> ships = new Stack<Ship>();
            ships.Push(new Destroyer());
            ships.Push(new Destroyer());
            ships.Push(new Battleship());
            return ships;
        }
        public MoveResult HitOrSink(Coordinates coordinates)
        {
            if (_aiplayer.Playerboard.Tiles[coordinates.X, coordinates.Y].IsWater())
            {
                return MoveResult.miss;
            }

            Ship ship = _aiplayer.Playerboard.Tiles[coordinates.X, coordinates.Y].Ship;
            if (!ship.IsDestroyed())
            {
                return MoveResult.hit;
            }

            if (_aiplayer.IsGameOver())
            {
                return MoveResult.gameover;
            }
            else
            {
                return MoveResult.sink;
            }
        }
    }
}
