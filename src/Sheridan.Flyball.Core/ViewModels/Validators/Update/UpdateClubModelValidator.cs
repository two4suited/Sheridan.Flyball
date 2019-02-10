using FluentValidation;
using Sheridan.Flyball.Core.ViewModels.Update;

namespace Sheridan.Flyball.Core.ViewModels.Validators.Update
{public class UpdateClubModelValidator : AbstractValidator<UpdateClubModel>
        {
            public UpdateClubModelValidator()
            {
                RuleFor(club => club.NafaClubNumber).GreaterThan(0);
                RuleFor(club => club.Name).NotNull().MaximumLength(50).NotEmpty();
            }
        }
}