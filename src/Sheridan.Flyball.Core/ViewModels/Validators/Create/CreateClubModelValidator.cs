using FluentValidation;
using Sheridan.Flyball.Core.ViewModels.Create;

namespace Sheridan.Flyball.Core.ViewModels.Validators.Create
{
    public class CreateClubModelValidator : AbstractValidator<CreateClubModel>
    {
        public CreateClubModelValidator()
        {
            RuleFor(club => club.NafaClubNumber).GreaterThan(0);
            RuleFor(club => club.Name).NotNull().MaximumLength(50).NotEmpty();
        }
    }
}
