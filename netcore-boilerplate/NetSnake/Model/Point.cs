namespace NetSnake.Model
{
    public class Point
    {
        public int X;

        public int Y;

        public override bool Equals(object other)
        {
            if (other == null || GetType() != other.GetType())
                return false;

            var otherPoint = (Point)other;
            return X == otherPoint.X && Y == otherPoint.Y;
        }

        public override int GetHashCode()
        {
            return X ^ Y;
        }
    }
}