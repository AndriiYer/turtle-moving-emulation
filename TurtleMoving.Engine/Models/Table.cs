namespace TurtleMoving.Engine.Models
{
    internal class Table
    {
        private static Table instance;

        public static Table Instance { get => instance; }

        public static void Instantiate(int dimensionX, int dimensionY)
        {
            instance = new Table(dimensionX, dimensionY);
        }

        public int DimensionX { get; private set; }

        public int DimensionY { get; private set; }

        private Table(int dimensionX, int dimensionY)
        {
            DimensionX = dimensionX;
            DimensionY = dimensionY;
        }
    }
}
