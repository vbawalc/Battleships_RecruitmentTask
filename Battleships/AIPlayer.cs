using System;
using System.Collections.Generic;
using System.Linq;

namespace Battleships
{
    internal class AIPlayer : Player
    {
        private Random _random;

        public AIPlayer(Random random, Board board, Stack<Ship> placeableShips) : base(board, placeableShips)
        {
            _random = random;
            SetupShips();
        }

        public void SetupShips()
        {
            while (_placeableShips.Any())
            {
                int x = _random.Next(0, _playerboard.Size);
                int y = _random.Next(0, _playerboard.Size);

                bool rotate = _random.Next(0, 2) == 0;
                if (rotate)
                {
                    RotatePlaceableShip();
                }

                if (_playerboard.CanPlaceShip(new Coordinates(x, y), _placeableShips.Peek()))
                {
                    PlaceShip(new Coordinates(x, y));
                }
            }
        }
    }
}
 