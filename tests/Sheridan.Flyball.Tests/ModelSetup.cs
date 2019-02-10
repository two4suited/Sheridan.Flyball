using System;
using System.Collections.Generic;
using System.Text;
using Sheridan.Flyball.Core.Entities;

namespace Sheridan.Flyball.Tests
{
    public class ModelSetup
    {
        public static Club SetupClub()
        {
            return new Club()
            {
                Id = 100,
                NafaClubNumber = 20,
                Name = "Rip It Up",
            };
        }

        
    }
}
