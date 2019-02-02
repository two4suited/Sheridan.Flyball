using Sheridan.Flyball.Core.Enumerations;
using Shouldly;
using Xunit;

namespace Sheridan.Flyball.Core.Tests
{
    public class PositionTest
    {
        public PositionTest()
        {
            
        }

       [Fact]
        public void NextPosition_StartTimeAndOpen_ThenFirst()
        {
            var nextPosition = Position.Start.NextPosition(false,null);

            nextPosition.ShouldBe(Position.First);
        }
        [Fact]
        public void NextPosition_StartTimeAndRegularAndNoFault_ThenFirst()
        {
           
            var nextPosition = Position.Start.NextPosition(false, null);

            nextPosition.ShouldBe(Position.First);
        }

       [Fact]
        public void NextPosition_StartTimeAndRegularAndFault_ThenStartReRun()
        {
            var nextPosition = Position.Start.NextPosition(true, Fault.BadStart);

            nextPosition.ShouldBe(Position.StartReRun);
        }



        [Fact]
        public void NextPosition_First_ThenSecond()
        {
            var nextPosition = Position.First.NextPosition(false, null);

            nextPosition.ShouldBe(Position.Second);
        }
        [Fact]
        public void NextPosition_Second_ThenThird()
        {
            var nextPosition = Position.Second.NextPosition(false, null);

            nextPosition.ShouldBe(Position.Third);
        }
       [Fact]
        public void NextPosition_Third_ThenFourth()
        {
            var nextPosition = Position.Third.NextPosition(false, null);

            nextPosition.ShouldBe(Position.Fourth);
        }


    }
}