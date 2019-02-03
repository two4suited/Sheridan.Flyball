using AutoFixture.Xunit2;
using Sheridan.Flyball.Core.Entities;
using Sheridan.Flyball.Data.EFCore.Repositories;
using Shouldly;
using Xunit;

namespace Sheridan.Flyball.Tests.Integration.Data
{
    public class PersonTest
    {
        [Theory]
        [InlineAutoData()]
        public void AddOne_ThenOne(Person person)
        {
            TestHelper.AddOne_ThenOne(person, typeof(Person).Name);

        }

        [Theory]
        [InlineAutoData()]
        public void GetListOfDogs_ReturnCorrectNumber(Person person)
        {
            //Setup Repository
            var methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            var context = TestHelper.SetupContext(methodName);
            var personRepo = new PersonRepository(context);
            personRepo.AddAndSave(person);

            //Pull Data out of object
            var dogs = person.Dogs;

            //Compare Data
            dogs.Count.ShouldBe(personRepo.GetListOfDogs(person.Id).Count);

        }
    }
}