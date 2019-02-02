using FluentValidation.Results;
using Sheridan.Flyball.Core.ViewModels.Create;
using Sheridan.Flyball.Core.ViewModels.Validators;
using Shouldly;
using Xunit;

namespace Sheridan.Flyball.Core.Tests.Validators
{
    public class CreateClubModelValidatorTest
    {

        public static ValidationResult Setup(string name, int clubNumber)
        {
            var club = new CreateClubModel()
            {
                Name = name,
                NafaClubNumber = clubNumber
            };
            var validator = new CreateClubModelValidator();

            return validator.Validate(club);

        }

        [Fact]
        public void CreateClub_IsValid()
        {
            var results = Setup("Test", 1);

            results.IsValid.ShouldBe(true);
        }

        [Fact]
        public void CreateClub_ClubNameIsBlank_IsInvalid()
        {
            var results = Setup("", 1);

            results.IsValid.ShouldBe(false);
        }
        [Fact]
        public void CreateClub_ClubIsNull_IsInvalid()
        {
            var results = Setup(null, 1);

            results.IsValid.ShouldBe(false);
        }
        [Fact]
        public void CreateClub_ClubIdEqual0_IsInvalid()
        {
            var results = Setup("Test", 0);

            results.IsValid.ShouldBe(false);
        }
    }
}
