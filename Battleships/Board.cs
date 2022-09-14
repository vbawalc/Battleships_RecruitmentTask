using System;
using System.Drawing;

namespace Battleships
{
    internal class Board
    {
        private Tile[,] _tiles;
        public Tile[,] Tiles => _tiles;
        int _size;
        public int Size => _size;
     
        public Board(int size)
        {
            _size = size;          
            _initialiseTiles(size);
        }

        private void _initialiseTiles(int size)
        {
            _tiles = new Tile[size, size];

            for (int row = 0; row < _size; row++)
            {
                for (int column = 0; column < _size; column++)
                {
                    _tiles[row, column] = new Tile();
                }
            }
        }

        public void PlaceShip(Coordinates coordinates, Ship ship)
        {
            if (!CanPlaceShip(coordinates, ship))
            {
                throw new Exception("Invalid ship position");
            }
            for (int x = coordinates.X; x < coordinates.X + ship.Width; x++)
            {
                for (int y = coordinates.Y; y < coordinates.Y + ship.Height; y++)
                {
                        _tiles[y, x].AddShip(ship);
                        ship.AddTile(_tiles[y, x]);
                }
            }
        }

        public bool CanPlaceShip(Coordinates coordinates, Ship ship)
        {
            Coordinates shipLastTile = (coordinates+new Coordinates(ship.Width - 1, ship.Height - 1));
            //ship starts at coordinates location and ends in shipLastTile location, only need to check those to see if ship is not outside of board
            if (!_isOnBoard(coordinates) || !_isOnBoard((shipLastTile)))
            {
                return false;
            }
            //check if any tile does not have ship already
            for (int x = coordinates.X; x < coordinates.X + ship.Width; x++)
            {
                for (int y = coordinates.Y; y < coordinates.Y + ship.Height; y++)
                {
                    if (!_tiles[y, x].IsWater())
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private bool _isOnBoard(Coordinates coordinates)
        {
            return coordinates.X >= 0 && coordinates.X < _size && coordinates.Y >= 0 && coordinates.Y < _size;
        }

    }
}
