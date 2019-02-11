using Sheridan.Flyball.Core.ViewModels.Create;
using Shouldly;
using Xunit;

namespace Sheridan.Flyball.Tests.Unit.Core
{
    public class CreatePersonModelTest
    {
        [Fact]
        public void CreateClub_ValidMapping()
        {
            var newPerson = new CreatePersonModel() { ClubId = 1,LastName = "T",FirstName = "T"};

            var person = CreatePersonModel.ToPerson(newPerson);

            person.ClubId.ShouldBe(newPerson.ClubId);
            person.FirstName.ShouldBe(newPerson.FirstName);
            person.LastName.ShouldBe(newPerson.LastName);
        }
    }
}
