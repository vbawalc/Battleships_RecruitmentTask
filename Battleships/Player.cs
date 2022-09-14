using System;
using System.Collections.Generic;
using System.Linq;

namespace Battleships
{
    internal class Player
    {
        protected List<Ship> _ships;
        protected Board _playerboard;
        protected Stack<Ship> _placeableShips;
        public Board Playerboard => _playerboard;

        public Player(Board board, Stack<Ship> placeableShips)
        {
            _ships = new List<Ship>();
            _playerboard = board;
            _placeableShips = placeableShips;
        }

        public void RotatePlaceableShip()
        {
            if (!_placeableShips.Any())
            {
                throw new Exception("There is no ship to rotate");
            }
            _placeableShips.Peek().Rotate();
        }

        public void PlaceShip(Coordinates coordinates)
        {
            if (!_placeableShips.Any())
            {
                throw new Exception("No ships to place");
            }
            Ship ship = _placeableShips.Peek();
            _playerboard.PlaceShip(coordinates, ship);
            _ships.Add(ship);
            _placeableShips.Pop();
        }

        public bool IsGameOver()
        {
            return !_ships.Exists(ship => !ship.IsDestroyed()); 
        }
    }
}
