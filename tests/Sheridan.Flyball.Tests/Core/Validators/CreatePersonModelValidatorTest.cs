using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoFixture.Xunit2;
using FluentValidation.Results;
using Sheridan.Flyball.Core.ViewModels.Create;
using Sheridan.Flyball.Core.ViewModels.Validators;
using Shouldly;
using Xunit;

namespace Sheridan.Flyball.Tests.Core.Validators
{
    public class CreatePersonModelValidatorTest
    {
        public static ValidationResult Setup(CreatePersonModel person)
        {
            var validator = new CreatePersonModelValidator();
            return validator.Validate(person);

        }

        [Fact]
        public void CreatePerson_IsValid()
        {
            var person = new CreatePersonModel() {ClubId = 1, FirstName = "1", LastName = "2"};

            var results = Setup(person);

            results.IsValid.ShouldBe(true);
        }

        [Fact]
        public void CreatePerson_PersonClubIdLessThan1_IsInvalid()
        {
            var person = new CreatePersonModel() { ClubId = 0, FirstName = "1", LastName = "2" };

            var results = Setup(person);

            results.IsValid.ShouldBe(false);
        }
        [Fact]
        public void CreatePerson_FirstNameIsNull_IsInvalid()
        {
            var person = new CreatePersonModel() { ClubId = 1, FirstName = null, LastName = "2" };

            var results = Setup(person);

            results.IsValid.ShouldBe(false);
        }

        [Fact]
        public void CreatePerson_FirstNameIsBlank_IsInvalid()
        {
            var person = new CreatePersonModel() { ClubId = 1, FirstName = "", LastName = "2" };

            var results = Setup(person);

            results.IsValid.ShouldBe(false);
        }
        [Fact]
        public void CreatePerson_FirstNameIsGreaterThan20_IsInvalid()
        {
            var person = new CreatePersonModel() { ClubId = 1, FirstName = "012345678901234567890", LastName = "2" };

            var results = Setup(person);

            results.IsValid.ShouldBe(false);
        }

        [Fact]
        public void CreatePerson_LastNameIsNull_IsInvalid()
        {
            var person = new CreatePersonModel() { ClubId = 1, FirstName = "1", LastName = null };

            var results = Setup(person);

            results.IsValid.ShouldBe(false);
        }

        [Fact]
        public void CreatePerson_LastNameIsBlank_IsInvalid()
        {
            var person = new CreatePersonModel() { ClubId = 1, FirstName = "1", LastName = "" };

            var results = Setup(person);

            results.IsValid.ShouldBe(false);
        }
        [Fact]
        public void CreatePerson_LastNameIsGreaterThan20_IsInvalid()
        {
            var person = new CreatePersonModel() { ClubId = 1, FirstName = "1", LastName = "123456789012345678901" };
     
            var results = Setup(person);

            results.IsValid.ShouldBe(false);
        }
    }
}
