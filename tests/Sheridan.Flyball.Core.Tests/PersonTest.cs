﻿using System.Linq;
using AutoFixture.Xunit2;
using Sheridan.Flyball.Core.Entities;
using Shouldly;
using Xunit;

namespace Sheridan.Flyball.Core.Tests
{
    public class PersonTest
    {
        [Theory]
        [InlineAutoData()]
        public void AddDog_WhenDogAdded_OnlyOneDogAdded(Dog dog)
        {
            var person = new Person();
            person.AddDog(dog);

            person.Dogs.Count().ShouldBe(1);
        }
    }
}
