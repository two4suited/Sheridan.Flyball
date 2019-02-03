using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using Sheridan.Flyball.Core.Entities;
using Sheridan.Flyball.Core.Interfaces.Repository;
using Sheridan.Flyball.Core.ViewModels.Create;
using Sheridan.Flyball.Service;
using Shouldly;
using Xunit;

namespace Sheridan.Flyball.Tests.Core
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
