namespace Battleships
{
    internal class Coordinates
    {
        private int _x;
        private int _y;
        public int X => _x;
        public int Y => _y;
        public Coordinates(int x, int y)
        {
            _x = x;
            _y = y;
        }
        public static Coordinates operator +(Coordinates coordinates1, Coordinates coordinates2)
        {
            return new Coordinates(coordinates1.X + coordinates2.X, coordinates1.Y + coordinates2.Y);
        }
    }
}
