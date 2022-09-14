namespace Battleships
{
    internal class Tile
    {
        private bool _isHit;
        private Ship _ship;
        public bool IsHit => _isHit;
        public Ship Ship => _ship;
        public Tile()
        {
            _isHit = false;
        }

        public bool IsWater()
        {
            return _ship is null;
        }

        public void Attack()
        {
            _isHit = true;
        }
        public void AddShip(Ship ship)
        {
            _ship = ship;
        }
    }
}
