namespace ToyRobotSimulator
{
    public class ToyRobot
    {
        private readonly int _maxX;
        private readonly int _maxY;

        public ToyRobot(int maxX = 5, int maxY = 5)
        {
            _maxX = maxX;
            _maxY = maxY;
        }

        public int? X { get; private set; }
        public int? Y { get; private set; }
        public string Facing { get; private set; }

        public virtual void Place(int x, int y, string direction)
        {
            if (IsValid(x, y, direction))
            {
                X = x;
                Y = y;
                Facing = direction;
            }
        }

        public virtual void Move()
        {
            if (Facing == Direction.North && IsValid(X, Y + 1, Facing)) Y += 1;
            if (Facing == Direction.East && IsValid(X + 1, Y, Facing)) X += 1;
            if (Facing == Direction.South && IsValid(X, Y - 1, Facing)) Y -= 1;
            if (Facing == Direction.West && IsValid(X - 1, Y, Facing)) X -= 1;
        }

        public virtual void Left()
            => Facing = Facing.IsValid() ? Facing.RotateLeft() : null;

        public virtual void Right()
            => Facing = Facing.IsValid() ? Facing.RotateRight() : null;

        public virtual string Report()
            => IsValid(X, Y, Facing) ? $"{X},{Y},{Facing}" : null;

        private bool IsValid(int? x, int? y, string direction)
        {
            var xIsValid = x >= 0 && x < _maxX;
            var yIsValid = y >= 0 && y < _maxY;
            return xIsValid && yIsValid && direction.IsValid();
        }
    }
}