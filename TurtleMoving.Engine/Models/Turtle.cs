using TurtleMoving.Engine.Commands;

namespace TurtleMoving.Engine.Models
{
    public class Turtle
    {
        private int positionX;
        public int PositionX
        {
            get { return positionX; }
            set 
            {
                positionX = ArrangeValueWithDimension(value, Table.Instance.DimensionX);
            }
        }

        private int positionY;
        public int PositionY
        {
            get { return positionY; }
            set
            {
                positionY = ArrangeValueWithDimension(value, Table.Instance.DimensionY);
            }
        }

        public bool IsInitialized { get; private set; }

        public void Initialize(int positionX, int positionY, Facing facing)
        {
            PositionX = positionX;
            PositionY = positionY;
            Facing = facing;
            IsInitialized = true;
        }

        public Facing Facing { get; set; }

        public override string ToString()
        {
            return string.Join(",", PositionX, PositionY, Facing.ToString().ToUpper());
        }

        private int ArrangeValueWithDimension(int value, int dimension)
        {
            int position;
            if (value < 0)
            {
                position = 0;
            }
            else if (value >= dimension)
            {
                position = dimension - 1;
            }
            else
            {
                position = value;
            }

            return position;
        }
    }
}
