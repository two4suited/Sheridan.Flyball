using System.Linq;
using AutoFixture.Xunit2;
using Sheridan.Flyball.Core.Entities;
using Sheridan.Flyball.Core.Enumerations;
using Shouldly;
using Xunit;

namespace Sheridan.Flyball.Tests.Core
{
    public class HeatTest
    {

        //Division
        //Heat
        //Dog 1-4
        //Time
        //Fault 

        //If Lineup is null return exception
        //

        [Theory, InlineAutoData()]
        public void AddStartTime_WhenDivisionReRunStartAndFault_ThenReturnsSameDog(Division division,
            Heat heat, Dog dog1,Dog dog2,Dog dog3,Dog dog4, Fault fault, double time)
        {
            division.RacingClass = RacingClass.Regular;
            heat.AddDogToLineup(division,dog1, dog2, dog3, dog4);
            fault = Fault.BadStart;

            var vut = heat.AddStartTime(dog1, time, fault, division);

            vut.Dog.ShouldBe(dog1);
        }

        [Theory, InlineAutoData()]
        public void AddStartTime_WhenDivisionReRunStartAndFault_ThenReturnsStartRerunPosition(Division division,
            Heat heat, Dog dog1, Dog dog2, Dog dog3, Dog dog4, Fault fault, double time)
        {
            division.RacingClass = RacingClass.Regular;
            heat.AddDogToLineup(division,dog1, dog2, dog3, dog4);
            fault = Fault.BadStart;

            var vut = heat.AddStartTime(dog1, time, fault, division);

            vut.Position.ShouldBe(Position.StartReRun);
        }

        [Theory, InlineAutoData()]
        public void AddStartTime_WhenDivisionReRunStartAndClean_ThenReturnsSameDog(Division division,
            Heat heat, Dog dog1, Dog dog2, Dog dog3, Dog dog4, Fault fault, double time)
        {
            division.RacingClass = RacingClass.Regular;
            heat.AddDogToLineup(division,dog1, dog2, dog3, dog4);
            fault = null;

            var vut = heat.AddStartTime(dog1, time, fault, division);

            vut.Dog.ShouldBe(dog1);
        }

        [Theory, InlineAutoData()]
        public void AddStartTime_WhenDivisionReRunStartAndClean_ThenReturnsStartFirstPosition(Division division,
            Heat heat, Dog dog1, Dog dog2, Dog dog3, Dog dog4, Fault fault, double time)
        {
            division.RacingClass = RacingClass.Regular;
            heat.AddDogToLineup(division,dog1, dog2, dog3, dog4);
            fault = null;

            var vut = heat.AddStartTime(dog1, time, fault, division);

            vut.Position.ShouldBe(Position.First);
        }
        [Theory, InlineAutoData()]
        public void AddStartTime_WhenDivisionNotReRunStartAndFault_ThenReturnsSameDog(Division division,
            Heat heat, Dog dog1, Dog dog2, Dog dog3, Dog dog4, Fault fault, double time)
        {
            division.RacingClass = RacingClass.Regular;
            heat.AddDogToLineup(division,dog1, dog2, dog3, dog4);
            fault = Fault.BadStart;

            var vut = heat.AddStartTime(dog1, time, fault, division);

            vut.Dog.ShouldBe(dog1);
        }

        [Theory, InlineAutoData()]
        public void AddStartTime_WhenDivisionNotRerunStartAndFault_ThenReturnsFirstPosition(Division division,
            Heat heat, Dog dog1, Dog dog2, Dog dog3, Dog dog4, Fault fault, double time)
        {
            division.RacingClass = RacingClass.Regular;
            heat.AddDogToLineup(division,dog1, dog2, dog3, dog4);
            fault = Fault.BadStart;
            division.RacingClass=RacingClass.Open;

            var vut = heat.AddStartTime(dog1, time, fault, division);

            vut.Position.ShouldBe(Position.First);
        }
        [Theory, InlineAutoData()]
        public void AddStartTime_WhenDivisionNotReRunStartAndClean_ThenReturnsSameDog(Division division,
            Heat heat, Dog dog1, Dog dog2, Dog dog3, Dog dog4,  double time)
        {
            division.RacingClass = RacingClass.Regular;
            heat.AddDogToLineup(division,dog1, dog2, dog3, dog4);
            Fault fault = null;

            var vut = heat.AddStartTime(dog1, time, fault, division);

            vut.Dog.ShouldBe(dog1);
        }

        [Theory, InlineAutoData()]
        public void AddStartTime_WhenDivisionNotRerunStartAndClean_ThenReturnsFirstPosition(Division division,
            Heat heat, Dog dog1, Dog dog2, Dog dog3, Dog dog4, Fault fault, double time)
        {
            division.RacingClass = RacingClass.Regular;
            heat.AddDogToLineup(division,dog1, dog2, dog3, dog4);
            fault = null;

            var vut = heat.AddStartTime(dog1, time, fault, division);

            vut.Position.ShouldBe(Position.First);
        }
        [Theory, InlineAutoData()]
        public void AddStartTime_AddFirstDog_ThenReturnsNextDogInLineup(Division division,
            Heat heat, Dog dog1, Dog dog2, Dog dog3, Dog dog4, Fault fault, double time)
        {
            division.RacingClass = RacingClass.Regular;
            heat.AddDogToLineup(division,dog1, dog2, dog3, dog4);
            fault = null;

            var vut = heat.AddStartTime(dog1, time, fault, division);

            vut.Dog.ShouldBe(dog1);
        }

        [Theory, InlineAutoData()]
        public void AddTime_WhenFirstDog_ThenReturnsSecondPosition(Division division,
            Heat heat, Dog dog1, Dog dog2, Dog dog3, Dog dog4, Fault fault, double time)
        {
            division.RacingClass = RacingClass.Regular;
            heat.AddDogToLineup(division,dog1, dog2, dog3, dog4);
            fault = null;

            var vut = heat.AddTime(dog1,Position.First,  time, fault, division);

            vut.Position.ShouldBe(Position.Second);
        }
        [Theory, InlineAutoData()]
        public void AddTime_AddFirstDog_ThenReturnsSecondDogInLineup(Division division,
            Heat heat, Dog dog1, Dog dog2, Dog dog3, Dog dog4, Fault fault, double time)
        {
            division.RacingClass = RacingClass.Regular;
            heat.AddDogToLineup(division,dog1, dog2, dog3, dog4);
            fault = null;

            var vut = heat.AddTime(dog1,Position.First,  time, fault, division);

            vut.Dog.ShouldBe(dog2);
        }
        [Theory, InlineAutoData()]
        public void AddTime_WhenSecondDog_ThenReturnsSecondPosition(Division division,
            Heat heat, Dog dog1, Dog dog2, Dog dog3, Dog dog4, Fault fault, double time)
        {
            division.RacingClass = RacingClass.Regular;
            heat.AddDogToLineup(division,dog1, dog2, dog3, dog4);
            fault = null;

            var vut = heat.AddTime(dog2, Position.Second, time, fault, division);

            vut.Position.ShouldBe(Position.Third);
        }
        [Theory, InlineAutoData()]
        public void AddTime_AddSecondDog_ThenReturnsThirdDogInLineup(Division division,
            Heat heat, Dog dog1, Dog dog2, Dog dog3, Dog dog4, Fault fault, double time)
        {
            division.RacingClass = RacingClass.Regular;
            heat.AddDogToLineup(division,dog1, dog2, dog3, dog4);
            fault = null;

            var vut = heat.AddTime(dog2, Position.Second, time, fault, division);

            vut.Dog.ShouldBe(dog3);
        }
        [Theory, InlineAutoData()]
        public void AddTime_WhenThirdDog_ThenReturnsFourthPosition(Division division,
            Heat heat, Dog dog1, Dog dog2, Dog dog3, Dog dog4, Fault fault, double time)
        {
            division.RacingClass = RacingClass.Regular;
            heat.AddDogToLineup(division,dog1, dog2, dog3, dog4);
            fault = null;

            var vut = heat.AddTime(dog3, Position.Third, time, fault, division);

            vut.Position.ShouldBe(Position.Fourth);
        }
        [Theory, InlineAutoData()]
        public void AddTime_AddThirdDog_ThenReturnsFourthDogInLineup(Division division,
            Heat heat, Dog dog1, Dog dog2, Dog dog3, Dog dog4, Fault fault, double time)
        {
            division.RacingClass = RacingClass.Regular;
            heat.AddDogToLineup(division,dog1, dog2, dog3, dog4);
            fault = null;

            var vut = heat.AddTime(dog3, Position.Third, time, fault, division);

            vut.Dog.ShouldBe(dog4);
        }




        [Theory, InlineAutoData()]
        public void SetLineup_AddFourDogs_ThenDogsInRightOrder(Dog dog1, Dog dog2, Dog dog3, Dog dog4,Division division)
        {
            var heat = new Heat();
            division.RacingClass = RacingClass.Open;
            
            heat.AddDogToLineup(division,dog1,dog2,dog3,dog4);

            var firstDog = heat.Lineup.First(x => x.Position == Position.First).Dog;
            var secondDog = heat.Lineup.First(x => x.Position == Position.Second).Dog;
            var thirdDog = heat.Lineup.First(x => x.Position == Position.Third).Dog;
            var fourthDog = heat.Lineup.First(x => x.Position == Position.Fourth).Dog;


            firstDog.ShouldBe(dog1);
            secondDog.ShouldBe(dog2);
            thirdDog.ShouldBe(dog3);
            fourthDog.ShouldBe(dog4);
        }

        [Theory, InlineAutoData()]
        public void SetLineup_AddFourDogsAndOpen_ThenFiveSpots(Dog dog1, Dog dog2, Dog dog3, Dog dog4,Division division)
        {
            var heat = new Heat();
            division.RacingClass = RacingClass.Open;

            heat.AddDogToLineup(division,dog1, dog2, dog3, dog4);

            heat.Lineup.Count.ShouldBe(5);
        }
        [Theory, InlineAutoData()]
        public void SetLineup_AddFourDogsAndRegular_ThenSixSpots(Dog dog1, Dog dog2, Dog dog3, Dog dog4, Division division)
        {
            var heat = new Heat();
            division.RacingClass = RacingClass.Regular;

            heat.AddDogToLineup(division, dog1, dog2, dog3, dog4);

            heat.Lineup.Count.ShouldBe(6);
        }

        [Theory, InlineAutoData()]
        public void SetLineup_AddOneDogs_ThenDogInFirstPosition(Dog dog1,Division division)
        {
            var heat = new Heat();
            division.RacingClass=RacingClass.Open;

            heat.AddDogToLineup(division,dog1);

            var firstDog = heat.Lineup.First(x => x.Position == Position.First).Dog;
           
            firstDog.ShouldBe(dog1);
        }
        [Theory, InlineAutoData()]
        public void SetLineup_AddOneDogsAndOpen_ThenTwoSpots(Dog dog1,Division division)
        {
            var heat = new Heat();
            division.RacingClass = RacingClass.Open;

            heat.AddDogToLineup(division,dog1);

            heat.Lineup.Count.ShouldBe(2);
        }
        [Theory, InlineAutoData()]
        public void SetLineup_AddOneDogsAndRegular_ThenThreeSpots(Dog dog1, Division division)
        {
            var heat = new Heat();
            division.RacingClass = RacingClass.Regular;

            heat.AddDogToLineup(division,dog1);

            heat.Lineup.Count.ShouldBe(3);
        }

        [Theory, InlineAutoData()]
        public void SetLineup_AddTwoDogs_ThenDogsInRightOrder(Dog dog1, Dog dog2, Dog dog3, Dog dog4,Division division)
        {
            var heat = new Heat();

            heat.AddDogToLineup(division,dog1, dog2, dog3, dog4);

            var firstDog = heat.Lineup.First(x => Equals(x.Position, Position.First)).Dog;
            var secondDog = heat.Lineup.First(x => Equals(x.Position, Position.Second)).Dog;
          
            firstDog.ShouldBe(dog1);
            secondDog.ShouldBe(dog2);
            
        }

        [Theory, InlineAutoData()]
        public void SetLineup_AddTwoDogsAndOpen_ThenThreeSpots(Dog dog1, Dog dog2,Division division)
        {
            var heat = new Heat();
            division.RacingClass = RacingClass.Open;

            heat.AddDogToLineup(division,dog1, dog2);

            heat.Lineup.Count.ShouldBe(3);

        }
        [Theory, InlineAutoData()]
        public void SetLineup_AddTwoDogsAndRegular_ThenFourSpots(Dog dog1, Dog dog2,Division division)
        {
            var heat = new Heat();
            division.RacingClass = RacingClass.Regular;

            heat.AddDogToLineup(division,dog1, dog2);

            heat.Lineup.Count.ShouldBe(4);

        }

        [Theory]
        [InlineAutoData(20.00,25)]
        [InlineAutoData(25.00, 5)]
        [InlineAutoData(29.00, 1)]
        [InlineAutoData(45.00, 0)]
        public void Points_WhenUnder24Seconds_Then25Points(double timeInSeconds,int shouldBePoints, Heat heat)
        {
            heat.HeatTime = timeInSeconds;

            var points = heat.Points();

            points.ShouldBe(shouldBePoints);
        }
    }
}
