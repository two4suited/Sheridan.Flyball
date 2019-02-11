using System;
using AutoFixture.Xunit2;
using Sheridan.Flyball.Core.Entities;
using Shouldly;
using Xunit;

namespace Sheridan.Flyball.Tests.Unit.Core
{
    public class RaceYearTest
    {
        [Theory]
        [InlineAutoData("11/1/2016","10/31/2017","2016-2017")]
        public void GetYear_GiveTwoDate_ValidFormat(string startTimeString, string endTimeString,string expectedValue)
        {
            var startTime = Convert.ToDateTime(startTimeString);
            var endTime = Convert.ToDateTime(endTimeString);

            var raceYear = new RaceYear(startTime, endTime);

            raceYear.GetYears().ShouldBe(expectedValue);
        }
        [Theory]
        [InlineAutoData("2016-2017", "11/1/2016")]
        public void GetStartDate_GivenYears_ValidStartDate(string yearspan, string expectedValueString)
        {
            var expectedValue = Convert.ToDateTime(expectedValueString);
           
            var raceYear = new RaceYear();

            raceYear.GetStartDate(yearspan).ShouldBe(expectedValue);
        }
        [Theory]
        [InlineAutoData("2016-2017", "10/31/2017")]
        public void GetStartDate_GivenYears_ValidEndDate(string yearspan, string expectedValueString)
        {
            var expectedValue = Convert.ToDateTime(expectedValueString);
            var raceYear = new RaceYear();

            raceYear.GetEndDate(yearspan).ShouldBe(expectedValue);
        }
    }
}
