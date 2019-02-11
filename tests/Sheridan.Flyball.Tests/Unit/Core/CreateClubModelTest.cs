using Sheridan.Flyball.Core.ViewModels.Create;
using Shouldly;
using Xunit;

namespace Sheridan.Flyball.Tests.Unit.Core
{
    public class CreateClubModelTest
    {
        [Fact]
        public void CreateClub_ValidMapping()
        {
            var newClub = new CreateClubModel() { Name = "T", NafaClubNumber = 1 };

            var club = CreateClubModel.ToClub(newClub);

            club.NafaClubNumber.ShouldBe(newClub.NafaClubNumber);
            club.Name.ShouldBe(newClub.Name);
        }
    }
}
