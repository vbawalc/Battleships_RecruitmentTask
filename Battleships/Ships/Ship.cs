using System.Collections.Generic;

namespace Battleships
{
    internal abstract class Ship
    {
        protected List<Tile> _tiles;
        protected int _width;
        protected int _height;
        public int Width => _width;
        public int Height => _height;

        public bool IsDestroyed()
        {
            return !_tiles.Exists(Tile => !Tile.IsHit);
        }

        public Ship(int width, int height)
        {
            _width = width;
            _height = height;
            _tiles = new List<Tile>();
        }

        public void Rotate()
        {
            int width = _width;
            _width = _height;
            _height = width;
        }

        public void AddTile(Tile tile)
        {
            _tiles.Add(tile);
        }
    }
}
