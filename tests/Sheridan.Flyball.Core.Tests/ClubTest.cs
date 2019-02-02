using System.Linq;
using AutoFixture.Xunit2;
using Sheridan.Flyball.Core.Entities;
using Shouldly;
using Xunit;

namespace Sheridan.Flyball.Core.Tests
{
    public class ClubTest
    {
        [Theory]
        [InlineAutoData()]
        public void AddPerson_WhenPersonAdded_OnlyOnePersonAdded(Person person)
        {
            var club = new Club();
            club.AddPerson(person);

            club.People.Count().ShouldBe(1);
        }

       


        //Add Tournament
    }
}
