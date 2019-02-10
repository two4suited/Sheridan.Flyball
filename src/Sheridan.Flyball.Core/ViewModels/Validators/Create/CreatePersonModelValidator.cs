using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Sheridan.Flyball.Core.ViewModels.Create;

namespace Sheridan.Flyball.Core.ViewModels.Validators
{
    public class CreatePersonModelValidator : AbstractValidator<CreatePersonModel>
    {
        public CreatePersonModelValidator()
        {
            RuleFor(person => person.ClubId).GreaterThan(0);
            RuleFor(person => person.FirstName).NotNull().NotEmpty().MaximumLength(20);
            RuleFor(person => person.LastName).NotNull().NotEmpty().MaximumLength(20);
        }
    }
}
