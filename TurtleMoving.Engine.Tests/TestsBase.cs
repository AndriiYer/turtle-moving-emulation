namespace TurtleMoving.Engine.Tests
{
    public class TestsBase
    {
        protected TurtleMovingProcessor GetProcessor() =>
            new TurtleMovingProcessor(5, 5);
    }
}
